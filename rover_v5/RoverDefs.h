#ifndef RoverDefs_h
	#define RoverDefs_h
	
	#define ENABLE_ROVER_DEBUG						true
	
	#define DRIVE_LEFT_PWM_PIN						0
	#define DRIVE_LEFT_DIRECTION_PIN				0
	#define DRIVE_LEFT_RELAY_PIN 					0
				
	#define DRIVE_RIGHT_PWM_PIN						0
	#define DRIVE_RIGHT_DIRECTION_PIN				0
	#define DRIVE_RIGHT_RELAY_PIN					0
			
	#define GPS_NAV_LOCK_PIN						0
			
	#define CAMERA_PAN_SERVO_PIN					0
	#define CAMERA_TILT_SERVO_PIN					0
	#define CAMERA_BLOCK_SIZE						32
	#define CAMERA_EOF_LOW_BYTE						0xFF
	#define CAMERA_EOF_HIGH_BYTE					0xD9
			
	#define IR_INPUT_PIN							0
	#define STATUS_UPDATE_TIMEOUT					5000
	
	#define LEFT_MOTOR_CHANGE_BIT_MASK				0x08
	#define RIGHT_MOTOR_CHANGE_BIT_MASK				0x04
	#define PAN_SERVO_CHANGE_BIT_MASK				0x02
	#define TILT_SERVO_CHANGE_BIT_MASK				0x01
	
	#define PACKET_CODE_INDEX						0
	#define CHANGE_FLAGS_INDEX						1
	#define LEFT_PWM_INDEX							2
	#define LEFT_DIRECTION_INDEX					3
	#define RIGHT_PWM_INDEX							4
	#define RIGHT_DIRECTION_INDEX					5
	#define	PAN_ANGLE_INDEX							6
	#define TILT_ANGLE_INDEX						7
	#define IMAGE_SIZE_INDEX						1
	#define DATA_ADDRESS_INDEX						1
	#define END_OF_IMAGE_INDEX						5
	#define CAMERA_RESPONSE_INDEX					6
	#define IR_DISTANCE_INDEX						1
	#define GPS_LATITUDE_INDEX						3
	#define GPS_LONGITUDE_INDEX						5
	
	#define SET_PACKET_SIZE							8
	#define STATUS_PACKET_SIZE						7
	#define CAMERA_STATUS_PACKET_SIZE				9
	#define CAMERA_BLOCK_PACKET_SIZE				38
	#define MAX_PACKET_SIZE							64
	#define	DATAGRAM_CACHE_SIZE						64
			
	#define DEBUG_BAUD_RATE							9600
	
	#define SET_PACKET_CODE							0x10
	#define TAKE_PICTURE_PACKET_CODE				0x20
	#define STATUS_PACKET_CODE						0x30
	#define CAMERA_STATUS_PACKET_CODE				0x40
	#define CAMERA_BLOCK_PACKET_CODE				0x50
	
	#define GPS_BAUD_RATE							9600
	#define GPS_TIMEOUT								5000
	#define GPS_MESSAGE_SIZE						80
	#define GPS_FIELD_SIZE							20
	#define GPS_LATITUDE_VALUE_FIELD_INDEX			3
	#define GPS_LATITUDE_DIRECTION_FIELD_INDEX		4
	#define GPS_LONGITUDE_VALUE_FIELD_INDEX			5
	#define GPS_LONGITUDE_DIRECTION_FIELD_INDEX		6
	#define GPS_COORDINATE_VALUE_MINIMUM			-90.00			// degrees
	#define GPS_COORDINATE_VALUE_MAXIMUM			90.00			// degrees
			
	#define SERVO_OUTPUT_MINIMUM					1000
	#define SERVO_OUTPUT_MAXIMUM					2000
			
	#define IR_CALIBRATION_COEFFICIENT				26.804798
	#define IR_CALIBRATION_EXPONENT					-1.119432
			
	#define	IR_VOLTAGE_MINIMUM						0.00			// volts
	#define IR_VOLTAGE_MAXIMUM						3.30			// volts
			
	#define IR_DISTANCE_MINIMUM						10				// centimeters
	#define IR_DISTANCE_MAXIMUM 					80				// centimeters
			
	#define UINT8_MINIMUM							0x00			// +0
	#define UINT8_MAXIMUM							0xFF			// +255
			
	#define INT8_MINIMUM							0x80			// -128
	#define INT8_MAXIMUM							0x7F			// +127
			
	#define UINT16_MINIMUM							0x0000			// +0
	#define UINT16_MAXIMUM							0xFFFF			// +65535
			
	#define INT16_MINIMUM							0x8000			// -32768
	#define INT16_MAXIMUM							0x7FFF			// +32767
			
	#define UINT32_MINIMUM							0x00000000		// +0
	#define UINT32_MAXIMUM							0xFFFFFFFF		// +4294967296
			
	#define INT32_MINIMUM							0x80000000		// -2147483648
	#define INT32_MAXIMUM							0x7FFFFFFF		// +2147483647
	
#endif