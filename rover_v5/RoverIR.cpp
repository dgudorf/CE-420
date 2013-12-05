//#include <WProgram.h>
#include <RoverIR.h>

// the ir pin
uint8_t 	ir_pin 				= 0x00;


RoverIR::RoverIR
	()
{
	// determine if debug mode is enabled
	if (ENABLE_ROVER_DEBUG) { Serial.println("RoverIR     >> RoverIR"); }
	// set the pin mode of the ir pin
	pinMode(IR_INPUT_PIN, INPUT);
}

void RoverIR::getVoltage
	(float * voltage)
{
	// determine if debug mode is enabled
	if (ENABLE_ROVER_DEBUG) { Serial.println("RoverIR     >> getVoltage"); }
	// get the voltage
	*voltage 	= analogRead(IR_INPUT_PIN);
}
void RoverIR::getScaledVoltage
	(uint16_t * voltage)
{
	// the raw voltage
	float 		raw_voltage 	= 0.00;
	// determine if debug mode is enabled
	if (ENABLE_ROVER_DEBUG) { Serial.println("RoverIR     >> getScaledVoltage"); }
	// get the raw voltage
	getVoltage(&raw_voltage);
	// scale the voltage
	*voltage		= map(raw_voltage, 
						  IR_VOLTAGE_MINIMUM, IR_VOLTAGE_MAXIMUM, 
						  UINT16_MINIMUM, UINT16_MAXIMUM);
}

void RoverIR::getDistance
	(float * distance)
{
	// the raw voltage
	float		raw_voltage		= 0.00;
	// determine if debug mode is enabled
	if (ENABLE_ROVER_DEBUG) { Serial.println("RoverIR     >> getDistance"); }
	// get the raw voltage
	getVoltage(&raw_voltage);
	// calculate the distance
	*distance		= IR_CALIBRATION_COEFFICIENT * pow(raw_voltage, IR_CALIBRATION_EXPONENT);
}

void RoverIR::getScaledDistance
	(uint16_t * distance)
{
	// the raw voltage
	float		raw_voltage		= 0.00;
	// the raw distance
	float		raw_distance	= 0.00;
	// determine if debug mode is enabled
	if (ENABLE_ROVER_DEBUG) { Serial.println("RoverIR     >> getScaledDistance"); }
	// get the raw voltage
	getVoltage(&raw_voltage);
	// calculate the raw distance
	raw_distance	= IR_CALIBRATION_COEFFICIENT * pow(raw_voltage, IR_CALIBRATION_EXPONENT);
	// scale the distance
	*distance		= map(raw_distance, 
						  IR_DISTANCE_MINIMUM, IR_DISTANCE_MAXIMUM, 
						  UINT16_MINIMUM, UINT16_MAXIMUM);
}
