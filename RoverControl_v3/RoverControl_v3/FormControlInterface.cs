using SlimDX.XInput;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RoverControl_v3
{
    public partial class FormControlInterface : Form
    {
        public FormControlInterface()
        {
            // required for designer support
            InitializeComponent();
        }

        private void FormControlInterface_Load(object sender, EventArgs e)
        {
            // attach the controller state changed event
            ControllerMonitor.ControllerStateChanged   += ControllerMonitor_ControllerStateChanged;
            // attach the network controller's packet received event
            NetworkController.PacketReceived           += NetworkController_PacketReceived;
            // attach the network controller's packet transmitted event
            NetworkController.PacketTransmitted        += NetworkController_PacketTransmitted;
            // clear the vibration
            ControllerMonitor.SetVibration(left_speed: 0, right_speed: 0);
        }
        private void NetworkController_PacketTransmitted(object sender, EventArgs e)
        {
            // a packet was transmitted
            // update the control state
            UpdateControlState();
            // save the log state
            LogController.RecordState(event_type: LogEvents.Transmit);
        }
        private void NetworkController_PacketReceived(object sender, EventArgs e)
        { 
            // a packet was received
            // update the control state
            UpdateControlState();
            // save the log state
            LogController.RecordState(event_type: LogEvents.Receive);
        }
        private void ControllerMonitor_ControllerStateChanged(object sender, ControllerStateChangedEventArgs e)
        {
            // update the rover state
            UpdateRoverState(e);
            // update the control state
            UpdateControlState();
        }
        private void UpdateRoverState(ControllerStateChangedEventArgs e)
        {
            /* determine if the controller state values have changed */
            if (e.Flags.HasFlag(ControllerChangeFlags.A))
            {
                // the a button value has changed
                // save the value
                RoverController.LeftMotorDirection  = !(e.State.A);
            }
            if (e.Flags.HasFlag(ControllerChangeFlags.B))
            {
                // the b button value has changed
                // save the value
                RoverController.RightMotorDirection = !(e.State.B);
            }
            if (e.Flags.HasFlag(ControllerChangeFlags.X))
            {
                // the x button value has changed
                // save the value
                RoverController.ImageRequested      = (e.State.X) ? true : RoverController.ImageRequested;
            }
            if (e.Flags.HasFlag(ControllerChangeFlags.Y))
            {
                // the y button value has changed
            }
            if (e.Flags.HasFlag(ControllerChangeFlags.Start))
            {
                // the start button value has changed
            }
            if (e.Flags.HasFlag(ControllerChangeFlags.Back))
            {
                // the back button value has changed
            }
            if (e.Flags.HasFlag(ControllerChangeFlags.LeftJoystick))
            {
                // the left joystick button value has changed
                // determine if the joystick has been pressed or released
                if (e.State.LeftJoystick == true)
                {
                    // it has been pressed
                    // determine the servo hold state
                    switch (RoverController.ServoHoldEnabled)
                    {
                        case true:
                            // the hold is currently enabled
                            // disable the hold
                            RoverController.ServoHoldEnabled    = false;
                            // clear the servo hold angles
                            RoverController.PanServoHoldAngle   = 128;
                            RoverController.TiltServoHoldAngle  = 128;
                            // break out
                            break;
                        case false:
                            // the hold is currently disabled
                            // enable the hold
                            RoverController.ServoHoldEnabled    = true;
                            // save the current angles
                            RoverController.PanServoHoldAngle   = RoverController.PanServoAngle;
                            RoverController.TiltServoHoldAngle  = RoverController.TiltServoAngle;
                            // break out
                            break;
                    }
                }
                else
                {
                    // it has been released
                    // unlock the hold position
                }
            }
            if (e.Flags.HasFlag(ControllerChangeFlags.RightJoystick))
            {
                // the right joystick button value has changed
            }
            if (e.Flags.HasFlag(ControllerChangeFlags.LeftShoulder))
            {
                // the left shoulder button value has changed
                if (e.State.Down == true)
                {
                    // full stop is enabled
                    // save the value
                    RoverController.LeftMotorPower          = 0;
                }
                else
                if (e.State.LeftShoulder == true)
                {
                    // full ahead left is enabled
                    // save the value
                    RoverController.LeftMotorPower          = 255;
                }
                else
                {
                    // it is not
                    // save the value
                    RoverController.LeftMotorPower          = e.State.LeftTrigger;
                }
            }
            if (e.Flags.HasFlag(ControllerChangeFlags.RightShoulder))
            {
                // the right shoulder button value has changed
                // determine which input mode is enabled
                if (e.State.Down == true)
                {
                    // full stop is enabled
                    // save the value
                    RoverController.RightMotorPower         = 0;
                }
                else
                if (e.State.RightShoulder == true)
                {
                    // full ahead right is enabled
                    // save the value
                    RoverController.RightMotorPower         = 255;
                }
                else
                {
                    // it is not
                    // save the value
                    RoverController.RightMotorPower         = e.State.RightTrigger;
                }
            }
            if (e.Flags.HasFlag(ControllerChangeFlags.Up))
            {
                // the pov up button value has changed
                // save the value
                RoverController.CaptureMode                 = CaptureMode.TimedCapture;
            }
            if (e.Flags.HasFlag(ControllerChangeFlags.Down))
            {
                // the pov down button value has changed
                // determine if the button is pressed
                switch (e.State.Down)
                {
                    case true:
                        // the button is pressed
                        // initiate full stop
                        RoverController.LeftMotorPower      = 0;
                        RoverController.RightMotorPower     = 0;
                        // break out
                        break;
                    case false:
                        // the button has been released
                        // restore the original state
                        RoverController.LeftMotorPower      = e.State.LeftTrigger;
                        RoverController.RightMotorPower     = e.State.RightTrigger;
                        // break out
                        break;
                }
            }
            if (e.Flags.HasFlag(ControllerChangeFlags.Left))
            {
                // the pov left button value has changed
                // save the value
                RoverController.CaptureMode                 = CaptureMode.OnDemandCapture;
            }
            if (e.Flags.HasFlag(ControllerChangeFlags.Right))
            {
                // the pov right button value has changed
                // save the value
                RoverController.CaptureMode                 = CaptureMode.VideoCapture;
            }
            if (e.Flags.HasFlag(ControllerChangeFlags.LeftTrigger))
            {
                // the left trigger axis value has changed
                if (e.State.Down == true)
                {
                    // full stop is enabled
                    // save the value
                    RoverController.LeftMotorPower          = 0;
                }
                else
                if (e.State.LeftShoulder == true)
                {
                    // full ahead left is enabled
                    // save the value
                    RoverController.LeftMotorPower          = 255;
                }
                else
                {
                    // it is not
                    // save the value
                    RoverController.LeftMotorPower          = e.State.LeftTrigger;
                }
            }
            if (e.Flags.HasFlag(ControllerChangeFlags.LeftJoystickX))
            {
                // the left joystick x-axis value has changed
                // determine if the servo is in hold mode
                if (RoverController.ServoHoldEnabled)
                {
                    // it is
                    // save the values
                    RoverController.PanServoAngle           = RoverController.PanServoHoldAngle;
                    RoverController.TiltServoAngle          = RoverController.TiltServoHoldAngle;
                }
                else
                {
                    // it is
                    // save the value
                    RoverController.PanServoAngle           = Tools.MapIntToByte(e.State.LeftJoystickX, 
                                                                                 Int16.MinValue, Int16.MaxValue,
                                                                                 Byte.MinValue, Byte.MaxValue,
                                                                                 0.00);
                }
            }
            if (e.Flags.HasFlag(ControllerChangeFlags.LeftJoystickY))
            {
                // the left joystick y-axis value has changed
                // determine if the servo is in hold mode
                if (RoverController.ServoHoldEnabled)
                {
                    // it is
                    // save the values
                    RoverController.PanServoAngle           = RoverController.PanServoHoldAngle;
                    RoverController.TiltServoAngle          = RoverController.TiltServoHoldAngle;
                }
                else
                {
                    // it is
                    // save the value
                    RoverController.TiltServoAngle          = Tools.MapIntToByte(e.State.LeftJoystickY, 
                                                                                 Int16.MinValue, Int16.MaxValue,
                                                                                 Byte.MinValue, Byte.MaxValue,
                                                                                 0.00);
                }
            }
            if (e.Flags.HasFlag(ControllerChangeFlags.RightTrigger))
            {
                // the right trigger axis value has changed
                if (e.State.Down == true)
                {
                    // full stop is enabled
                    // save the value
                    RoverController.RightMotorPower         = 0;
                }
                else
                if (e.State.RightShoulder == true)
                {
                    // full ahead left is enabled
                    // save the value
                    RoverController.RightMotorPower         = 255;
                }
                else
                {
                    // it is not
                    // save the value
                    RoverController.RightMotorPower         = e.State.RightTrigger;
                }
            }
            if (e.Flags.HasFlag(ControllerChangeFlags.RightJoystickX))
            {
                // the right joystick x-axis value has changed
            }
            if (e.Flags.HasFlag(ControllerChangeFlags.RightJoystickY))
            {
                // the right joystick y-axis value has changed
            }
        }
        private void UpdateControlState()
        {
            // update the left motor input trackbar
            trackLeftMotorInput.Value           = (RoverController.LeftMotorDirection) ? RoverController.LeftMotorPower : -RoverController.LeftMotorPower;
            // update the left motor current trackbar
            trackLeftMotorCurrent.Value         = Tools.MapUIntToUInt16(RoverController.LeftMotorCurrent, UInt16.MinValue, UInt16.MaxValue, 0, 5000, 0.00);
            // update the left motor setpoint trackbar
            trackLeftMotorSetpoint.Value        = (RoverController.LeftMotorDirectionSetpoint) ? RoverController.LeftMotorPowerSetpoint : -RoverController.LeftMotorPowerSetpoint;
            // update the right motor input trackbar
            trackRightMotorInput.Value          = (RoverController.RightMotorDirection) ? RoverController.RightMotorPower : -RoverController.RightMotorPower;
            // update the right motor current trackbar
            trackRightMotorCurrent.Value        = Tools.MapUIntToUInt16(RoverController.RightMotorCurrent, UInt16.MinValue, UInt16.MaxValue, 0, 5000, 0.00);
            // update the right motor setpoint trackbar
            trackRightMotorSetpoint.Value       = (RoverController.RightMotorDirectionSetpoint) ? RoverController.RightMotorPowerSetpoint : -RoverController.RightMotorPowerSetpoint;
            // update the pan servo input trackbar
            trackPanServoInput.Value            = Tools.MapUIntToInt16(RoverController.PanServoAngle, Byte.MinValue, Byte.MaxValue, -9000, 9000, 0.00);
            // update the pan servo setpoint trackbar
            trackPanServoSetpoint.Value         = Tools.MapUIntToInt16(RoverController.PanServoAngleSetpoint, Byte.MinValue, Byte.MaxValue, -9000, 9000, 0.00);
            // update the tilt servo input trackbar
            trackTiltServoInput.Value           = Tools.MapUIntToInt16(RoverController.TiltServoAngle, Byte.MinValue, Byte.MaxValue, -9000, 9000, 0.00);
            // update the pan servo setpoint trackbar
            trackTiltServoSetpoint.Value        = Tools.MapUIntToInt16(RoverController.TiltServoAngleSetpoint, Byte.MinValue, Byte.MaxValue, -9000, 9000, 0.00);
            // update the left motor input label
            labelLeftMotorInput.Text            = String.Format("{0:F0}%", (RoverController.LeftMotorDirection)
                                                                            ? Tools.MapIntToDouble(RoverController.LeftMotorPower, -255, 255, -100.00, 100.00, 0.00)
                                                                            : Tools.MapIntToDouble(-RoverController.LeftMotorPower, -255, 255, -100.00, 100.00, 0.00));
            // update the left motor current label
            labelLeftMotorCurrent.Text          = String.Format("{0:F2}A", Tools.MapUIntToDouble(RoverController.LeftMotorCurrent, UInt16.MinValue, UInt16.MaxValue, 0.000, 5.00, 0.00));
            // update the left motor setpoint label
            labelLeftMotorSetpoint.Text         = String.Format("{0:F0}%", (RoverController.LeftMotorDirectionSetpoint)
                                                                            ? Tools.MapIntToDouble(RoverController.LeftMotorPowerSetpoint, -255, 255, -100.00, 100.00, 0.00)
                                                                            : Tools.MapIntToDouble(-RoverController.LeftMotorPowerSetpoint, -255, 255, -100.00, 100.00, 0.00));
            // update the right motor input label
            labelRightMotorInput.Text           = String.Format("{0:F0}%", (RoverController.RightMotorDirection) 
                                                                            ? Tools.MapIntToDouble(RoverController.RightMotorPower, -255, 255, -100.00, 100.00, 0.00)
                                                                            : Tools.MapIntToDouble(-RoverController.RightMotorPower, -255, 255, -100.00, 100.00, 0.00));
            // update the right motor current label
            labelRightMotorCurrent.Text         = String.Format("{0:F2}A", Tools.MapUIntToDouble(RoverController.RightMotorCurrent, UInt16.MinValue, UInt16.MaxValue, 0.000, 5.000, 0.00));
            // update the right motor setpoint label
            labelRightMotorSetpoint.Text        = String.Format("{0:F0}%", (RoverController.RightMotorDirectionSetpoint)
                                                                            ? Tools.MapIntToDouble(RoverController.RightMotorPowerSetpoint, -255, 255, -100.00, 100.00, 0.00)
                                                                            : Tools.MapIntToDouble(-RoverController.RightMotorPowerSetpoint, -255, 255, -100.00, 100.00, 0.00));
            // update the pan servo angle label
            labelPanServoInput.Text             = String.Format("{0:F0}°", Tools.MapUIntToDouble(RoverController.PanServoAngle, Byte.MinValue, Byte.MaxValue, -90.00, 90.00, 0.00));
            // update the pan servo angle setpoint label
            labelPanServoSetpoint.Text          = String.Format("{0:F0}°", Tools.MapUIntToDouble(RoverController.PanServoAngleSetpoint, Byte.MinValue, Byte.MaxValue, -90.00, 90.00, 0.00));
            // update the tilt servo angle label
            labelTiltServoInput.Text            = String.Format("{0:F0}°", Tools.MapUIntToDouble(RoverController.TiltServoAngle, Byte.MinValue, Byte.MaxValue, -90.00, 90.00, 0.00));
            // update the pan servo angle setpoint label
            labelTiltServoSetpoint.Text         = String.Format("{0:F0}°", Tools.MapUIntToDouble(RoverController.TiltServoAngleSetpoint, Byte.MinValue, Byte.MaxValue, -90.00, 90.00, 0.00));
            // update the servo hold indicator
            checkServoPositionLocked.Checked    = RoverController.ServoHoldEnabled;
            // update the ir distance trackbar
            trackDistance.Value                 = Tools.MapUIntToUInt16(RoverController.Distance, 
                                                                        UInt16.MinValue, UInt16.MaxValue,
                                                                        1000, 8000, 0.00);
            // update the pan servo angle label
            labelDistance.Text                  = String.Format("{0:F2} cm", Tools.MapUIntToDouble(RoverController.Distance, UInt16.MinValue, UInt16.MaxValue, 10.00, 80.00, 0.00));
            // update the left distance label
            labelLeftMotorDistance.Text         = String.Format("{0:F2} cm", RoverController.LeftMotorDistance);
            // update the left displacement label
            labelLeftMotorDisplacement.Text     = String.Format("{0:F2} cm", RoverController.LeftMotorDisplacement);
            // update the right distance label
            labelRightMotorDistance.Text        = String.Format("{0:F2} cm", RoverController.RightMotorDistance);
            // update the right displacement label
            labelRightMotorDisplacement.Text    = String.Format("{0:F2} cm", RoverController.RightMotorDisplacement);
            // update the current latitude label
            labelCurrentLatitude.Text           = String.Format("{0:F6}°", RoverController.Locations.CurrentLatitude);
            // update the current longitude label
            labelCurrentLongitude.Text          = String.Format("{0:F6}°", RoverController.Locations.CurrentLongitude);
            // update the previous latitude label
            labelPreviousLatitude.Text          = String.Format("{0:F6}°", RoverController.Locations.PreviousLatitude);
            // update the previous longitude label
            labelPreviousLongitude.Text         = String.Format("{0:F6}°", RoverController.Locations.PreviousLongitude);
            // update the latitude change label
            labelLatitudeChange.Text            = String.Format("{0:F6}°", RoverController.Locations.LatitudeChange);
            // update the latitude change label
            labelLongitudeChange.Text           = String.Format("{0:F6}°", RoverController.Locations.LongitudeChange);
            // update the capture mode
            radioOnDemandCapture.Checked        = RoverController.CaptureMode.HasFlag(CaptureMode.OnDemandCapture);
            radioTimedCapture.Checked           = RoverController.CaptureMode.HasFlag(CaptureMode.TimedCapture);
            radioVideoCapture.Checked           = RoverController.CaptureMode.HasFlag(CaptureMode.VideoCapture);
            // update the vibration
            ControllerMonitor.SetVibration((UInt16)(UInt16.MaxValue - RoverController.Distance), 0);
        }

        private void linkClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void FormControlInterface_FormClosing(object sender, FormClosingEventArgs e)
        {
            // clear the vibration speed
            ControllerMonitor.SetVibration(left_speed: 0, right_speed: 0);
        }

        private void labelLongitudeChange_Click(object sender, EventArgs e)
        {

        }

        private void linkEnableDataCollection_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // enable the log
            LogController.EnableLog(save_existing: false);
        }
    }
}
