//#include <WProgram.h>
#include <RoverServo.h>
#include <SoftPWMServo.h>
typedef struct {
	int16_t minimum;
	int16_t maximum;
} Range;

// the ranges
Range 			input_range;
Range 			output_range;

uint8_t 		servo_pin 				= 0x00;

RoverServo::RoverServo(uint8_t pin)
{
	// determine if debug mode is enabled
	if (ENABLE_ROVER_DEBUG) { Serial.println("RoverServo  >> RoverServo"); }
	// save the pin
	servo_pin = pin;
	// set the pin mode
	pinMode(pin, OUTPUT);
	// create the default input range
	input_range.minimum 	= INT8_MINIMUM;
	input_range.maximum 	= INT8_MAXIMUM;
	// create the default output range
	output_range.minimum	= SERVO_OUTPUT_MINIMUM;
	output_range.maximum	= SERVO_OUTPUT_MAXIMUM;
}

void RoverServo::setRange
	(int8_t input_min, int8_t input_max, 
	 uint16_t output_min, uint16_t output_max)
{
	// determine if debug mode is enabled
	if (ENABLE_ROVER_DEBUG) { Serial.println("RoverGps    >> setRange"); }
	// save the input range
	input_range.minimum 	= input_min;
	input_range.maximum 	= input_max;
	// save the output range
	output_range.minimum	= output_min;
	output_range.maximum	= output_max;
}

void RoverServo::setPosition(int8_t input)
{
	// the target position
	int16_t position 	= 0;
	// determine if debug mode is enabled
	if (ENABLE_ROVER_DEBUG) { Serial.println("RoverGps    >> setPosition"); }
	// map the input to the output range
	ScaledPosition		= mapPosition(input, &Position);
	// set the servo position
	SoftPWMServoServoWrite(servo_pin, Position);
}

uint16_t RoverServo::mapPosition(int8_t input, int16_t * position)
{
	// the processed input
	int16_t new_input 	= 0;
	// the result
	uint16_t result		= 0;
	// determine if debug mode is enabled
	if (ENABLE_ROVER_DEBUG) { Serial.println("RoverGps    >> mapPosition"); }
	// determine if the range is valid
	if (input < input_range.minimum)
	{
		// the input is below the minimum input value
		// set the input to minimum
		new_input		= input_range.minimum;
	}
	else
	if (input > input_range.maximum)
	{
		// the input is above the maximum input value
		// set the input to maximum
		new_input		= input_range.maximum;
	}
	else
	{
		// the input is valid
		// save the input
		new_input		= input;
	}
	// map the input to the output range
	result		= map(new_input, 
					  input_range.minimum, input_range.maximum, 
				      output_range.minimum, output_range.maximum);	
	// save the processed input
	*position	= new_input;
	// return the result
	return result;
}