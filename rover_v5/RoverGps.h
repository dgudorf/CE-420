#ifndef RoverGps_h
	#define RoverGps_h
	#include <WProgram.h>
	#include <RoverDefs.h>

	class RoverGps
	{
		public:
			RoverGps			
				();
				 
			bool getCoordinates	
				(float * latitude, 
				 float * longitude,
				 uint32_t timeout);
			
			bool getScaledCoordinates
				(int16_t * latitude, 
				 int16_t * longitude,
				 uint32_t timeout);
			
			float 	Latitude;
			float 	Longitude;
			int16_t ScaledLatitude;
			int16_t ScaledLongitude;
			
		private:
			char * getField		
				(char * message, 
				 uint32_t target);
	};
	
#endif