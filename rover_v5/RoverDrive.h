#ifndef RoverDrive_h
	#define RoverDrive_h
	#include <WProgram.h>
	#include <RoverDefs.h>

	class RoverDrive
	{
		public:
			RoverDrive
				();
			
			void setLeft
				(uint8_t new_power,
				 bool new_direction);
			
			void setRight
				(uint8_t new_power,
				 bool new_direction);
			
			void fullStop
				();
				
			uint8_t LeftPwm;
			uint8_t RightPwm;
			bool LeftDirection;
			bool RightDirection;
			
	};
	
#endif