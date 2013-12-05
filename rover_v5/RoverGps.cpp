//#include <WProgram.h>
#include <RoverGps.h>

RoverGps::RoverGps
	()
{
	// set the pin mode of the nav lock pin
	pinMode(GPS_NAV_LOCK_PIN, INPUT);
	// initialize the serial port
	Serial2.begin(9600);
}

bool RoverGps::getCoordinates
	(float * latitude, float * longitude, uint32_t timeout)
{
	// a serial message
	char 		message[GPS_MESSAGE_SIZE];
	// a single character
	char		value				= 0x00;
	// the start time
	uint32_t 	start_time 			= millis();
	// a direction field
	char *		direction_field;
	// a coordinate field
	char * 		coordinate_field;
	// a coordinate value
	float		coordinate_value	= 0.000;	
	// the timed out flag
	bool		timed_out			= false;
	// the latitude direction
	bool		latitude_north		= false;
	// the longitude direction
	bool		longitude_east		= false;
	// the result
	bool		result				= false;
	// determine if debug mode is enabled
	if (ENABLE_ROVER_DEBUG) { Serial.println("RoverGps    >> getCoordinates"); }
	// wait until there is data or until an error has occurred
	while ((!Serial2.available()) && 
		   (!timed_out) &&
		   (digitalRead(GPS_NAV_LOCK_PIN)))
   {
		// determine if the gps has timed out
		timed_out = ((millis() - start_time) < timeout);
   }
	// determine if there was an error
	if ((millis() - start_time > timeout) || !Serial2.available() || !digitalRead(GPS_NAV_LOCK_PIN))
	{
		// there was
		// save the result
		result = false;		
	}
	else
	if (!timed_out && Serial2.available() && digitalRead(GPS_NAV_LOCK_PIN))
	{
		// there was not
		// loop through the available data
		for (uint32_t index = 0; index < GPS_MESSAGE_SIZE; index++)
		{
			// get this character
			value	= Serial2.read();
			// determine if this value is a newline character
			if (value  != '\n')
			{
				// it is not
				// save this value
				message[index] = value;
			}
			else
			{
				// it is
				// save the null terminator
				message[index] = '\x00';
			}
		}
		// get the latitude field
		coordinate_field	= getField(message, GPS_LATITUDE_VALUE_FIELD_INDEX);		
		// get the latitude direction field
		direction_field 	= getField(message, GPS_LATITUDE_DIRECTION_FIELD_INDEX);
		// convert the coordinate string to a float
		coordinate_value 	= strtof(coordinate_field, NULL);
		// determine the latitude direction
		if (strcmp(direction_field, "N") == 0)
		{
			// the latitude is to the north
			// save the latitude
			*latitude 	= coordinate_value;
		}
		else
		if (strcmp(direction_field, "S") == 0)
		{
			// the latitude is to the south
			// save the latitude
			*latitude 	= -coordinate_value;
		}
		// get the coordinate field
		coordinate_field	= getField(message, GPS_LONGITUDE_VALUE_FIELD_INDEX);
		// get the longitude direction field
		direction_field 	= getField(message, GPS_LONGITUDE_DIRECTION_FIELD_INDEX);
		// convert the coordinate string to a float
		coordinate_value	= strtof(coordinate_field, NULL);
		// determine the longitude direction
		if (strcmp(direction_field, "E") == 0)
		{
			// the longitude is to the east
			// save the longitude
			*longitude	= coordinate_value;
		}
		else
		if (strcmp(direction_field, "W") == 0)
		{
			// the longitude is to the west
			// save the longitude
			*longitude	= -coordinate_value;
		}
		// save the results
		Latitude	= *latitude;
		Longitude	= *longitude;
	}	
	// return the result
	return result;
}

bool RoverGps::getScaledCoordinates
	(int16_t * latitude, int16_t * longitude, uint32_t timeout)
{
	// the latitude
	float 	raw_latitude 	= 0.00;
	// the longitude
	float 	raw_longitude	= 0.00;
	// the result
	bool	result 			= getCoordinates(&raw_latitude, &raw_longitude, timeout);
	// determine if debug mode is enabled
	if (ENABLE_ROVER_DEBUG) { Serial.println("RoverGps    >> getScaledCoordinates"); }
	// determine if the result is true
	if (result)
	{
		// it is
		// map the latitude to the output range
		*latitude		= map(raw_latitude, 
							  GPS_COORDINATE_VALUE_MINIMUM, GPS_COORDINATE_VALUE_MAXIMUM, 
							  INT16_MINIMUM, INT16_MAXIMUM);
		// map the longitude to the output range
		*longitude		= map(raw_longitude, 
							  GPS_COORDINATE_VALUE_MINIMUM, GPS_COORDINATE_VALUE_MAXIMUM, 
							  INT16_MINIMUM, INT16_MAXIMUM);
		// save the results
		ScaledLatitude	= *latitude;
		ScaledLongitude	= *longitude;
	}
	else
	{
		// it is not
		// do nothing
	}
	// return the result
	return result;
}

char * RoverGps::getField
	(char * message, uint32_t target)
{
	// a position within a sentence
	uint32_t	sentence_position 	= 0;
	// a position within a field
	uint32_t 	field_position		= 0;
	// the number of commas
	uint32_t	comma_count			= 0;
	// the result
	char   		result[GPS_FIELD_SIZE];
	// determine if debug mode is enabled
	if (ENABLE_ROVER_DEBUG) { Serial.println("RoverGps    >> getField"); }
	// loop through the message
	for (uint32_t index = 0; index < GPS_MESSAGE_SIZE; index++)
	{
		// determine if this character is a comma
		if (message[index] == ',')
		{
			// it is
			// increment the comma count
			comma_count++;
		}
		// determine if the field has been found
		if (comma_count == target)
		{
			// it has
			// save this character
			result[field_position++] = message[sentence_position];
		}
	}
	// add the null terminator
	message[field_position] = '\0';
	// return the result
	return result;
}

