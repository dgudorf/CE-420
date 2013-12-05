//#include <WProgram.h>
#include <RoverDrive.h>

/* constants */
const uint8_t STOP_POWER = 0x00;

RoverDrive::RoverDrive
	()
{
	// determine if debug mode is enabled
	if (ENABLE_ROVER_DEBUG) { Serial.println("RoverDrive  >> RoverDrive"); }
	// set the pin mode of the drive pins
	pinMode(DRIVE_LEFT_PWM_PIN, OUTPUT);
	pinMode(DRIVE_LEFT_DIRECTION_PIN, OUTPUT);
	pinMode(DRIVE_LEFT_RELAY_PIN, OUTPUT);
	pinMode(DRIVE_RIGHT_PWM_PIN, OUTPUT);
	pinMode(DRIVE_RIGHT_DIRECTION_PIN, OUTPUT);
	pinMode(DRIVE_RIGHT_RELAY_PIN, OUTPUT);
}

void RoverDrive::setLeft(uint8_t new_power, bool new_direction)
{
	// determine if debug mode is enabled
	if (ENABLE_ROVER_DEBUG) { Serial.println("RoverDrive  >> setLeft"); }
	// determine if the new power is zero
	if (new_power == STOP_POWER)
	{
		// it is
		// disable the left drive relay
		digitalWrite(DRIVE_LEFT_RELAY_PIN, false);
	}
	else
	{
		// it is not
		// enable the left drive relay
		digitalWrite(DRIVE_LEFT_RELAY_PIN, true);
	}
	// determine if the power has changed
	if (new_power != LeftPwm)
	{
		// write the new power value
		analogWrite(DRIVE_LEFT_PWM_PIN, LeftPwm = new_power);
	}
	// determine if the direction has changed
	if (new_direction != LeftDirection)
	{
		// write the new direction value
		digitalWrite(DRIVE_LEFT_DIRECTION_PIN, LeftDirection = new_direction);
	}
}

void RoverDrive::setRight(uint8_t new_power, bool new_direction)
{
	// determine if debug mode is enabled
	if (ENABLE_ROVER_DEBUG) { Serial.println("RoverDrive  >> setRight"); }
	// determine if the new power is zero
	if (new_power == STOP_POWER)
	{
		// it is
		// disable the right drive relay
		digitalWrite(DRIVE_RIGHT_RELAY_PIN, false);
	}
	else
	{
		// it is not
		// enable the right drive relay
		digitalWrite(DRIVE_RIGHT_RELAY_PIN, true);
	}
	// determine if the power has changed
	if (new_power != RightPwm)
	{
		// write the new power value
		analogWrite(DRIVE_RIGHT_PWM_PIN, RightPwm = new_power);
	}
	// determine if the direction has changed
	if (new_direction != RightDirection)
	{
		// write the new direction value
		digitalWrite(DRIVE_RIGHT_DIRECTION_PIN, RightDirection = new_direction);
	}
}

void RoverDrive::fullStop()
{
	// determine if debug mode is enabled
	if (ENABLE_ROVER_DEBUG) { Serial.println("RoverDrive  >> fullStop"); }
	// disable the left drive relay
	digitalWrite(DRIVE_LEFT_RELAY_PIN, false);
	// disable the right drive relay
	digitalWrite(DRIVE_RIGHT_RELAY_PIN, false);
	// stop the left motor
	analogWrite(DRIVE_LEFT_PWM_PIN, LeftPwm = STOP_POWER);
	// stop the right motor
	analogWrite(DRIVE_RIGHT_PWM_PIN, RightPwm = STOP_POWER);
}