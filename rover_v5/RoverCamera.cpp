//#include <WProgram.h>
#include <RoverCamera.h>
// the chunk size
const uint8_t	read_size = 32;

RoverCamera::RoverCamera()
{
	// open the serial port
	Serial1.begin(38400);
}

uint32_t RoverCamera::resetCamera
	(uint8_t * response)
{
	// the "reset camera' command
	const uint8_t 	RESET_CAMERA[4] 	= { 0x56, 0x00, 0x26, 0x00 };
	// determine if debug mode is enabled
	if (ENABLE_ROVER_DEBUG) { Serial.println("RoverCamera >> resetCamera"); }
	// send the command
	return sendCommand(RESET_CAMERA, response, 4);
}

uint32_t RoverCamera::getImageSize
	(uint8_t * response, uint32_t * size)
{
	// the "get image size" command
	const uint8_t 	GET_IMAGE_SIZE[5] 	= { 0x56, 0x00, 0x34, 0x01, 0x00 };
	// send the command
	uint32_t	result	= sendCommand(GET_IMAGE_SIZE, response, 5);
	// determine if debug mode is enabled
	if (ENABLE_ROVER_DEBUG) { Serial.println("RoverCamera >> getImageSize"); }
	// read four characters
	for (uint32_t index = 0; index < 4; index++)
	{
		// loop until there is data
		while (!Serial1.available());
		// save this value
		response[result + index] = Serial1.read();
	}
	// increment the result by four
	result += 4;
	// calculate and save the size
	*size	= (uint32_t)(response[result - 2] & 0x00FF) << 8;
	*size  += (uint32_t)(response[result - 1] & 0x00FF);
	// return the result
	return result;
}

uint32_t RoverCamera::takePicture
	(uint8_t * response)
{
	// the "take picture" command
	const uint8_t 	TAKE_PICTURE[5] 	= { 0x56, 0x00, 0x36, 0x01, 0x00 };
	// determine if debug mode is enabled
	if (ENABLE_ROVER_DEBUG) { Serial.println("RoverCamera >> takePicture"); }
	// send the command
	return sendCommand(TAKE_PICTURE, response, 5);

}

uint32_t RoverCamera::stopCapture
	(uint8_t * response)
{
	// the "stop capture" command"
	const uint8_t 	STOP_CAPTURE[5] 	= { 0x56, 0x00, 0x36, 0x01, 0x03 };
	// determine if debug mode is enabled
	if (ENABLE_ROVER_DEBUG) { Serial.println("RoverCamera >> stopCapture"); }
	// send the command
	return sendCommand(STOP_CAPTURE, response, 5);
}

uint32_t RoverCamera::getBlockCount
	(uint8_t * response, uint32_t * count)
{
	// the "get image size" command
	const uint8_t 	GET_IMAGE_SIZE[5] 	= { 0x56, 0x00, 0x34, 0x01, 0x00 };
	// the size of the image
	uint32_t image_size = 0;
	// the result
	uint32_t result		= 0;
	// determine if debug mode is enabled
	if (ENABLE_ROVER_DEBUG) { Serial.println("RoverCamera >> getBlockCount"); }
	// get the image size
	result = getImageSize(response, &image_size);
	// calculate the number of blocks
	*count =  image_size / read_size;
	// return the result
	return result;
	
}

uint32_t RoverCamera::readBlock
	(uint8_t * response, uint32_t data_address)
{
	// the read data command
	const uint8_t READ_DATA[8]		= { 0x56, 0x00, 0x32, 0x0C, 0x00, 0x0A, 0x00, 0x00 };
	// the result
	uint32_t result = 0;
	// determine if debug mode is enabled
	if (ENABLE_ROVER_DEBUG) { Serial.println("RoverCamera >> readBlock"); }
	// flush the serial port buffer
	Serial1.flush();
	// send the base of the read data command
	for (uint32_t index = 0; index < 8; index++)
	{
		// write this byte
		Serial1.write((uint32_t)(READ_DATA[index]));
	}
	// finish the read data command
	Serial1.write(data_address >> 8);
	Serial1.write(data_address);
	Serial1.write((uint8_t)(0x00));
	Serial1.write((uint8_t)(0x00));
	Serial1.write((uint8_t)(read_size >> 8));
	Serial1.write(read_size);
	Serial1.write((uint8_t)(0x00));
	Serial1.write((uint8_t)(0x0A));
	// read the returned data
	for (uint32_t index = 0; index < 5; index++)
	{
		// loop until there is data
		while (!Serial1.available());
		// read a byte
		Serial1.read();
	}
	// loop until there is data
	while (result < read_size)
	{
		// loop until there is data
		while (!Serial1.available());
		// read a byte
		*response++ = Serial1.read();
		// increment the result
		result++;
	}
	// return the result
	return result;
}

uint32_t RoverCamera::sendCommand
	(const uint8_t * command, uint8_t * response, uint32_t length)
{
	// the read data command
	const uint8_t READ_DATA[8]		= { 0x56, 0x00, 0x32, 0x0C, 0x00, 0x0A, 0x00, 0x00 };
	// the result
	uint32_t result = 0;
	// determine if debug mode is enabled
	if (ENABLE_ROVER_DEBUG) { Serial.println("RoverCamera >> sendCommand"); }
	// flush the serial buffer
	Serial1.flush();
	// send the command
	for (uint32_t index = 0; index < length; index++)
	{
		// send this byte
		Serial1.write(*command++);
	}
	// read the camera's response
	for (uint32_t index = 0; index < length; index++)
	{
		// loop until there is data
		while (!Serial1.available());
		// save this byte
		*response++ = Serial1.read();
		// increment the result
		result++;
	}
	// return the result
	return result;
}
