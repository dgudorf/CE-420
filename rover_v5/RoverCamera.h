#ifndef RoverCamera_h
	#define RoverCamera_h
	#include <WProgram.h>
	#include <RoverDefs.h>
	class RoverCamera
	{
		public:
			RoverCamera();
			uint32_t getBlockCount(uint8_t * response, uint32_t * count);
			uint32_t getImageSize(uint8_t * response, uint32_t * size);
			uint32_t resetCamera(uint8_t * response);
			uint32_t takePicture(uint8_t * response);
			uint32_t stopCapture(uint8_t * response);
			uint32_t readBlock(uint8_t * response, uint32_t data_address);
				
		private:
			uint32_t sendCommand(const uint8_t * command, uint8_t * response, uint32_t length);
	};
#endif