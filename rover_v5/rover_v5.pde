//#include <HardwareSerial.h>
#include <SoftPWMServo.h>
#include <RoverDefs.h>
#include <RoverCamera.h>
#include <RoverGps.h>
#include <RoverServo.h>
#include <RoverDrive.h>
#include <RoverIR.h>
#include <WiFiShieldOrPmodWiFi_G.h>
#include <DNETcK.h>
#include <DWIFIcK.h>

/* rover component declarations 	*/
RoverCamera   	camera;
RoverDrive    	drive;
RoverServo	  	pan(CAMERA_PAN_SERVO_PIN);
RoverServo		tilt(CAMERA_TILT_SERVO_PIN);
RoverGps		gps;
RoverIR			ir;

/* camera value declarations 		*/
uint32_t		image_size 		= 0;
uint32_t		block_count 	= 0;
uint32_t		data_address	= 0;
bool			image_eof_flag	= false;
uint8_t  		camera_response[32];

/* update declarations				*/
uint32_t		last_update		= millis();
uint16_t		ir_distance		= 0;
int16_t			gps_latitude	= 0;
int16_t			gps_longitude	= 0;
		
/* rover networking declarations	*/
// the wi-fi connect macro
#define	WiFiConnect() DWIFIcK::connect(network_ssid, passphrase, &status)
// the connection id
uint32_t		connection_id	= DWIFIcK::INVALID_CONNECTION_ID;
// the target ip address
char * 			server_ip_addr 	= "192.168.1.200";
// the wi-fi ssid
const char * 	network_ssid	= "TheAegeanSea";
// the wi-fi passphrase
const char *	passphrase		= "dicknancydanmatt";
// the read buffer
uint8_t			read_buffer[SET_PACKET_SIZE];
// the status buffer
uint8_t			status_buffer[STATUS_PACKET_SIZE];
// the camera status buffer
uint8_t			camera_status_buffer[CAMERA_STATUS_PACKET_SIZE];
// the camera buffer
uint8_t			camera_buffer[CAMERA_BLOCK_PACKET_SIZE];
// the datagram cache
uint8_t			datagram_cache[MAX_PACKET_SIZE];
// the udp client
UdpClient		client(datagram_cache, sizeof(datagram_cache));

void setup()
{
   // the connection status
	DNETcK::STATUS status;
	// initialize the debug serial port
	Serial.begin(DEBUG_BAUD_RATE);
	// reset the camera
	camera.resetCamera(camera_response);
	// set the range of the servos
	pan.setRange(0, 255, 1000, 2000);
	tilt.setRange(0, 255, 1000, 2000);
	// determine if the connection is successful
	connection_id = WiFiConnect();	
} 
boolean hasFlag(uint32_t value, uint32_t bit_mask)
{
	// the result
	boolean result = false;
	// calculate the result
	result = (value & bit_mask == bit_mask);
	// return the result
	return result;
}
void loop()
{
	// the number of bytes to read
	uint32_t 	read_count 	= client.available();
	// determine if there is anything to read
	if (read_count > 0 && connection_id != DWIFIcK::INVALID_CONNECTION_ID)
	{
		// there is
		// recalculate the number of bytes
		read_count = (read_count < MAX_PACKET_SIZE) ? read_count : MAX_PACKET_SIZE;
		// get the datagram
		read_count = client.readDatagram(read_buffer, read_count);
		// determine the type of message
		switch (read_buffer[PACKET_CODE_INDEX])
		{
			case SET_PACKET_CODE:
				// this is a set packet
				// determine if the left motor value has changed
				if (hasFlag(read_buffer[CHANGE_FLAGS_INDEX], 
							LEFT_MOTOR_CHANGE_BIT_MASK))
				{
					// set the left motor's power and direction
					drive.setLeft(read_buffer[LEFT_PWM_INDEX], 
								  read_buffer[LEFT_DIRECTION_INDEX] == 0xFF);
				}
				// determine if the right motor value has changed
				if (hasFlag(read_buffer[CHANGE_FLAGS_INDEX],
							RIGHT_MOTOR_CHANGE_BIT_MASK))
				{
					// set the right motor's power and direction
					drive.setRight(read_buffer[RIGHT_PWM_INDEX],
								   read_buffer[RIGHT_DIRECTION_INDEX] == 0xFF);
				}
				// determine if the pan servo angle has changed
				if (hasFlag(read_buffer[CHANGE_FLAGS_INDEX],
							PAN_SERVO_CHANGE_BIT_MASK))
				{
					// set the pan servo angle
					pan.setPosition(read_buffer[PAN_ANGLE_INDEX]);
				}
				// determine if the tilt servo angle has changed
				if (hasFlag(read_buffer[CHANGE_FLAGS_INDEX],
							TILT_SERVO_CHANGE_BIT_MASK))
				{
					// set the tilt servo angle
					tilt.setPosition(read_buffer[TILT_ANGLE_INDEX]);
				}
				// break out
				break;
			case TAKE_PICTURE_PACKET_CODE:
				// this is a take picture packet
				// take a picture
				camera.takePicture(camera_response);
				// get the image size
				camera.getImageSize(camera_response, &image_size);
				// get the block count
				camera.getBlockCount(camera_response, &block_count);
				// create the camera status buffer
				camera_status_buffer[PACKET_CODE_INDEX] = CAMERA_STATUS_PACKET_CODE;
				// save the image size
				camera_status_buffer[IMAGE_SIZE_INDEX + 0] = (uint8_t)((image_size >> 24) & 0xFF);
				camera_status_buffer[IMAGE_SIZE_INDEX + 1] = (uint8_t)((image_size >> 16) & 0xFF);
				camera_status_buffer[IMAGE_SIZE_INDEX + 2] = (uint8_t)((image_size >>  8) & 0xFF);
				camera_status_buffer[IMAGE_SIZE_INDEX + 3] = (uint8_t)((image_size >>  0) & 0xFF);
				// send the camera status buffer
				client.writeDatagram(camera_status_buffer, CAMERA_STATUS_PACKET_SIZE);
				// reset the data address
				data_address = 0;
				// loop through the image data
				while (data_address < image_size)
				{
					// read the data from the camera
					camera.readBlock(camera_response, data_address);
					// set the code byte
					camera_buffer[PACKET_CODE_INDEX] = CAMERA_BLOCK_PACKET_CODE;
					// set the address bytes
					camera_buffer[DATA_ADDRESS_INDEX + 0] = (uint8_t)((data_address >> 24) & 0xFF);
					camera_buffer[DATA_ADDRESS_INDEX + 1] = (uint8_t)((data_address >> 16) & 0xFF);
					camera_buffer[DATA_ADDRESS_INDEX + 2] = (uint8_t)((data_address >>  8) & 0xFF);
					camera_buffer[DATA_ADDRESS_INDEX + 3] = (uint8_t)((data_address >>  0) & 0xFF);
					// iterate through the data in this block
					for (int byte_index = 0; byte_index < CAMERA_BLOCK_SIZE; byte_index++)
					{
						// determine if the end-of-file flag should be set
						if ((camera_response[byte_index] 	 	== (char)(CAMERA_EOF_HIGH_BYTE)) &&
							(camera_response[byte_index - 1] 	== (char)(CAMERA_EOF_LOW_BYTE)))
						{
							// it should
							// set the end-of-file flag
							image_eof_flag = true;
							// save the end-of-image flag
							camera_buffer[END_OF_IMAGE_INDEX] = (uint8_t)((image_eof_flag == true) ? 0xFF : 0x00);
						}
						// save this byte
						camera_buffer[CAMERA_RESPONSE_INDEX + byte_index] = camera_response[byte_index];
						// determine if the end-of-file flag is set
						if (image_eof_flag == true)
						{
							// it is
							// break out
							break;
						}
					}
					// increase the data address
					data_address += CAMERA_BLOCK_SIZE;
					// send the buffer
					client.writeDatagram(camera_buffer, CAMERA_BLOCK_PACKET_SIZE);
					// sleep
					delay(5);
				}
				// break out
				break;
		}
	}
	// determine if the status needs to be updated and sent
	if ((millis() - last_update) > STATUS_UPDATE_TIMEOUT)
	{
		// get the ir distance
		ir.getScaledDistance(&ir_distance);
		// get the gps coordinates
		gps.getScaledCoordinates(&gps_latitude, &gps_longitude, GPS_TIMEOUT);
		// create the status buffer
		status_buffer[PACKET_CODE_INDEX] 		= CAMERA_BLOCK_PACKET_CODE;
		status_buffer[IR_DISTANCE_INDEX] 		= (uint8_t)(ir_distance & 0x00FF);
		status_buffer[IR_DISTANCE_INDEX + 1] 	= (uint8_t)((ir_distance >> 8) & 0x00FF);
		status_buffer[GPS_LATITUDE_INDEX] 		= (uint8_t)(gps_latitude & 0x00FF);
		status_buffer[GPS_LATITUDE_INDEX + 1] 	= (uint8_t)((gps_latitude >> 8) & 0x00FF);
		status_buffer[GPS_LONGITUDE_INDEX] 		= (uint8_t)(gps_longitude & 0x00FF);
		status_buffer[GPS_LONGITUDE_INDEX + 1]	= (uint8_t)((gps_longitude >> 8) & 0x00FF);
	}
}
