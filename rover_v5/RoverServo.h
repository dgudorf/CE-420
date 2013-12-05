#ifndef RoverServo_h
	#define RoverServo_h
	#include <SoftPWMServo.h>
	#include <WProgram.h>
	#include <RoverDefs.h>

	class RoverServo
	{
		public:
			RoverServo(uint8_t pin);
			void setRange(int8_t input_min, int8_t input_max, uint16_t output_min, uint16_t output_max);
			void setPosition(int8_t input);
			
			uint16_t ScaledPosition;
			int16_t  Position;
				
		private:
			uint16_t mapPosition(int8_t input, int16_t * position);
	};
	
#endif