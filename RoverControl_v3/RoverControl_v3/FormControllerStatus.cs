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
    public partial class FormControllerStatus : Form
    {
        public FormControllerStatus()
        {
            InitializeComponent();
        }

        private void FormControllerStatus_Load(object sender, EventArgs e)
        {
            // initialize the controller
            ControllerMonitor.Initialize();
            // enable controller polling
            ControllerMonitor.EnablePolling(25);
            // attach the controller state changed event handler
            ControllerMonitor.ControllerStateChanged += ControllerMonitor_ControllerStateChanged;
        }

        private void ControllerMonitor_ControllerStateChanged(object sender, ControllerStateChangedEventArgs e)
        {
            // determine if there is an active controller with valid data
            if (ControllerMonitor.IsConnected   == true && 
                ControllerMonitor.CanRead       == true)
            {
                // there is
                // update the state of the button controls
                labelButtonA.Text               = (ControllerMonitor.CurrentState.A) ? "HI" : "LO";
                labelButtonB.Text               = (ControllerMonitor.CurrentState.B) ? "HI" : "LO";
                labelButtonX.Text               = (ControllerMonitor.CurrentState.X) ? "HI" : "LO";
                labelButtonY.Text               = (ControllerMonitor.CurrentState.Y) ? "HI" : "LO";
                labelButtonStart.Text           = (ControllerMonitor.CurrentState.Start) ? "HI" : "LO";
                labelButtonBack.Text            = (ControllerMonitor.CurrentState.Back) ? "HI" : "LO";
                labelButtonLeftJoystick.Text    = (ControllerMonitor.CurrentState.LeftJoystick) ? "HI" : "LO";
                labelButtonRightJoystick.Text   = (ControllerMonitor.CurrentState.RightJoystick) ? "HI" : "LO";
                labelButtonLeftShoulder.Text    = (ControllerMonitor.CurrentState.LeftShoulder) ? "HI" : "LO";
                labelButtonRightShoulder.Text   = (ControllerMonitor.CurrentState.RightShoulder) ? "HI" : "LO";
                labelPovUp.Text                 = (ControllerMonitor.CurrentState.Up) ? "HI" : "LO";
                labelPovDown.Text               = (ControllerMonitor.CurrentState.Down) ? "HI" : "LO";
                labelPovLeft.Text               = (ControllerMonitor.CurrentState.Left) ? "HI" : "LO";
                labelPovRight.Text              = (ControllerMonitor.CurrentState.Right) ? "HI" : "LO";
                // update the state of the axis controls
                labelLeftJoystickX.Text         = (ControllerMonitor.CurrentState.LeftJoystickX_F.ToString("F2"));
                labelLeftJoystickXRaw.Text      = (ControllerMonitor.CurrentState.LeftJoystickX.ToString());
                labelLeftJoystickY.Text         = (ControllerMonitor.CurrentState.LeftJoystickY_F.ToString("F2"));
                labelLeftJoystickYRaw.Text      = (ControllerMonitor.CurrentState.LeftJoystickY.ToString());
                labelRightJoystickX.Text        = (ControllerMonitor.CurrentState.RightJoystickX_F.ToString("F2"));
                labelRightJoystickXRaw.Text     = (ControllerMonitor.CurrentState.RightJoystickX.ToString());
                labelRightJoystickY.Text        = (ControllerMonitor.CurrentState.RightJoystickY_F.ToString("F2"));
                labelRightJoystickYRaw.Text     = (ControllerMonitor.CurrentState.RightJoystickY.ToString());
                labelLeftTrigger.Text           = (ControllerMonitor.CurrentState.LeftTrigger_F.ToString("F2"));
                labelLeftTriggerRaw.Text        = (ControllerMonitor.CurrentState.LeftTrigger.ToString());
                labelRightTrigger.Text          = (ControllerMonitor.CurrentState.RightTrigger_F.ToString("F2"));
                labelRightTriggerRaw.Text       = (ControllerMonitor.CurrentState.RightTrigger.ToString());
            }
        }

        private void ButtonValue_TextChanged(object sender, EventArgs e)
        {
            // the label responsible for raising this event
            Label label = sender as Label;
            // determine if there is a value in the label
            if (String.IsNullOrWhiteSpace(label.Text) || label.Text == "NaN")
            {
                // there is no value in the label
                // set the colors of the label
                label.BackColor = SystemColors.Control;
                label.ForeColor = Color.Black;
                // clear the time
                label.Tag       = null;
            }
            else
            {
                // there is a value in the label
                // determine the value
                if (label.Text == "HI")
                {
                    // set the colors of the label
                    label.BackColor = Color.FromArgb(0, 200, 0);
                    label.ForeColor = Color.White;
                    // record the time
                    label.Tag       = DateTime.Now.ToBinary();
                }
                else
                {
                    // set the colors of the label
                    label.BackColor = Color.FromArgb(200, 0, 0);
                    label.ForeColor = Color.White;
                    // clear the time
                    label.Tag       = null;
                }
            }
        }

        private void AxisValue_TextChanged(object sender, EventArgs e)
        {
            // the label responsible for raising this event
            Label   label           = sender as Label;
            // the input value
            Double  value           = 0;
            // the scaled value
            Int32   scaled_value    = 0;
            // determine if there is a value in the label
            if (String.IsNullOrWhiteSpace(label.Text) || label.Text == "NaN")
            {
                // there is no value in the label
                // set the colors of the label
                label.BackColor = SystemColors.Control;
                label.ForeColor = Color.Black;
            }
            else
            { 
                // there is a value in the label
                // determine if this is a valid double value
                switch (Double.TryParse(label.Text, out value))
                {
                    case true:
                        // it is
                        // calculate the scaled value
                        scaled_value        = Convert.ToInt32(Math.Abs((value / 100.00) * 200.00));
                        // determine the sign of the value
                        if (value > 0)
                        {
                            // the value is positive
                            // set the colors of the label
                            label.BackColor = Color.FromArgb(0, scaled_value, 0);
                            label.ForeColor = Color.White;
                        }
                        else
                        if (value < 0)
                        {
                            // the value is negative
                            // set the colors of the label
                            label.BackColor = Color.FromArgb(scaled_value, 0, 0);
                            label.ForeColor = Color.White;
                        }
                        else
                        {
                            // the value is zero
                            // set the colors of the label
                            label.BackColor = SystemColors.Control;
                            label.ForeColor = Color.Black;
                        }
                        // break out
                        break;
                }
            }
        }

        private void timerUpdateTimeHeld_Tick(object sender, EventArgs e)
        {
            // update the time held values for the buttons
            labelButtonATimeHeld.Text               = CalculateTimeHeld((Int64?)(labelButtonA.Tag));
            labelButtonBTimeHeld.Text               = CalculateTimeHeld((Int64?)(labelButtonB.Tag));
            labelButtonXTimeHeld.Text               = CalculateTimeHeld((Int64?)(labelButtonX.Tag));
            labelButtonYTimeHeld.Text               = CalculateTimeHeld((Int64?)(labelButtonY.Tag));
            labelButtonStartTimeHeld.Text           = CalculateTimeHeld((Int64?)(labelButtonStart.Tag));
            labelButtonBackTimeHeld.Text            = CalculateTimeHeld((Int64?)(labelButtonBack.Tag));
            labelButtonLeftJoystickTimeHeld.Text    = CalculateTimeHeld((Int64?)(labelButtonLeftJoystick.Tag));
            labelButtonRightJoystickTimeHeld.Text   = CalculateTimeHeld((Int64?)(labelButtonRightJoystick.Tag));
            labelButtonLeftShoulderTimeHeld.Text    = CalculateTimeHeld((Int64?)(labelButtonLeftShoulder.Tag));
            labelButtonRightShoulderTimeHeld.Text   = CalculateTimeHeld((Int64?)(labelButtonRightShoulder.Tag));
            labelPovUpTimeHeld.Text                 = CalculateTimeHeld((Int64?)(labelPovUp.Tag));
            labelPovDownTimeHeld.Text               = CalculateTimeHeld((Int64?)(labelPovDown.Tag));
            labelPovLeftTimeHeld.Text               = CalculateTimeHeld((Int64?)(labelPovLeft.Tag));
            labelPovRightTimeHeld.Text              = CalculateTimeHeld((Int64?)(labelPovRight.Tag));
        }

        private String CalculateTimeHeld(Int64? value)
        {
            // the result
            String      result      = "NaN";
            // the start time
            DateTime    start_time  = DateTime.MinValue;
            // the timespan
            TimeSpan    time_held   = TimeSpan.Zero;
            // the number of seconds
            Double      seconds     = 0.00;
            // determine if there is a value
            if (value != null)
            {
                // there is
                // get the value
                start_time          = DateTime.FromBinary((Int64)(value));
                // calculate the timespan
                time_held           = DateTime.Now.Subtract(start_time);
                // save the number of seconds
                seconds             = time_held.TotalSeconds;
                // format the result
                result              = String.Format("{0:F3}", seconds);
            }
            // return the result
            return result;
        }
    }
}
