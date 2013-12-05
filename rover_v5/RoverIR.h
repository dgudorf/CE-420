#ifndef RoverIR_h
	#define RoverIR_h
	#include <WProgram.h>
	#include <RoverDefs.h>

	class RoverIR
	{
		public:
			RoverIR
				();
			
			void getVoltage
				(float * voltage);
			
			void getScaledVoltage
				(uint16_t * voltage);
			
			void getDistance
				(float * distance);
				
			void getScaledDistance
				(uint16_t * distance);
	};
	
#endif