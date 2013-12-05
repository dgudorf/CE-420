using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RoverControl_v3
{
    public partial class FormAnnunciatorPanel : Form
    {
        // the highest priority level among the active alarms
        PriorityLevel       HighestPriority = PriorityLevel.None;
        // the alarm controls
        List<AlarmButton>   AlarmControls   = new List<AlarmButton>();
        // the icons
        List<Icon>          PriorityIcons   = new List<Icon>();

        public FormAnnunciatorPanel()
        {
            // required for designer support
            InitializeComponent();
        }

        private void FormAnnunciatorPanel_Load(object sender, EventArgs e)
        {
            // convert the icons
            PriorityIcons.Add(new Icon("low-priority.ico"));
            PriorityIcons.Add(new Icon("medium-priority.ico"));
            PriorityIcons.Add(new Icon("high-priority.ico"));
            PriorityIcons.Add(new Icon("severe-priority.ico"));
            PriorityIcons.Add(new Icon("extreme-priority.ico"));
            // save the alarms
            AlarmControls.Add(alarmCommunicationFailure);
            AlarmControls.Add(alarmBatteryFailure);
            AlarmControls.Add(alarmLeftMotorOvercurrent);
            AlarmControls.Add(alarmRightMotorOvercurrent);
            AlarmControls.Add(alarmLowVoltageBusUndervolt);
            AlarmControls.Add(alarmHighVoltageBusUndervolt);
            AlarmControls.Add(alarmOvercurrentWarningLeft);
            AlarmControls.Add(alarmOvercurrentImminentLeft);
            AlarmControls.Add(alarmOvercurrentImminentRight);
            AlarmControls.Add(alarmOvercurrentWarningRight);
            AlarmControls.Add(alarmStallLeft);
            AlarmControls.Add(alarmCollisionImminentFront);
            AlarmControls.Add(alarmStallRight);
            AlarmControls.Add(alarmFrontLeftPowerCutoff);
            AlarmControls.Add(alarmCollisionWarningFront);
            AlarmControls.Add(alarmFrontRightPowerCutoff);
            AlarmControls.Add(alarmRearLeftPowerCutoff);
            AlarmControls.Add(alarmCollisionAvoidanceActive);
            AlarmControls.Add(alarmRearRightPowerCutoff);
            AlarmControls.Add(alarmRoverOff);
            AlarmControls.Add(alarmRoverIdle);
            AlarmControls.Add(alarmRoverError);
            AlarmControls.Add(alarmRoverRun);
        }

        private void Alarm_AlarmEnabledChanged(object sender, EventArgs e)
        {
            // get the sender
            AlarmButton     alarm   = sender as AlarmButton;
            // iterate through the alarms
            foreach (AlarmButton control in AlarmControls)
            {
                // determine if this alarm's priority is higher than the current
                if (control.AlarmEnabled && control.AlarmPriority > HighestPriority)
                {
                    // it is
                    // save the priority level
                    HighestPriority = control.AlarmPriority;
                }
            }
            // determine the active priority
            switch (HighestPriority)
            {
                case PriorityLevel.None:
                default:
                    // there is no priority level
                    // set the properties of the notify icon
                    notifyIcon.Visible      = false;
                    // break out
                    break;
                case PriorityLevel.Low:
                    // this is the low priority state
                    // set the properties of the notify icon
                    notifyIcon.Visible      = true;
                    notifyIcon.Icon         = PriorityIcons[0];
                    // break out
                    break;
                case PriorityLevel.Medium:
                    // this is the medium priority state
                    // set the properties of the notify icon
                    notifyIcon.Visible      = true;
                    notifyIcon.Icon         = PriorityIcons[1];
                    // break out
                    break;
                case PriorityLevel.High:
                    // this is the high priority state
                    // set the properties of the notify icon
                    notifyIcon.Visible      = true;
                    notifyIcon.Icon         = PriorityIcons[2];
                    // break out
                    break;
                case PriorityLevel.Severe:
                    // this is the severe priority state
                    // set the properties of the notify icon
                    notifyIcon.Visible      = true;
                    notifyIcon.Icon         = PriorityIcons[3];
                    // break out
                    break;
                case PriorityLevel.Extreme:
                    // this is the extreme priority state
                    // set the properties of the notify icon
                    notifyIcon.Visible      = true;
                    notifyIcon.Icon         = PriorityIcons[4];
                    // break out
                    break;
            }
            // determine if this is a newly enabled alarm
            if (alarm.AlarmEnabled == true)
            {
                // it is
                // set the notifyicon's balloon properties
                notifyIcon.BalloonTipIcon   = ToolTipIcon.Warning;
                notifyIcon.BalloonTipTitle  = "Rover Control Interface";
                notifyIcon.BalloonTipText   = String.Format("An alarm of type {0} and priority {1} occurred at {2}",
                                                            alarm.AlarmCode.ToString(),
                                                            alarm.AlarmPriority.ToString(),
                                                            alarm.AlarmEnabledTime.HasValue 
                                                                ? alarm.AlarmEnabledTime.Value 
                                                                : DateTime.Now);
                // show the balloon
                notifyIcon.ShowBalloonTip(5000);
            }
        }

        private void timerUpdate_Tick(object sender, EventArgs e)
        {
            /* update the alarm states */
            alarmBatteryFailure.AlarmEnabled                = RoverController.AlarmFlags.HasFlag(AlarmCode.BatteryFailure);
            alarmCollisionAvoidanceActive.AlarmEnabled      = RoverController.AlarmFlags.HasFlag(AlarmCode.CollisionAvoidanceActive);
            alarmCollisionImminentFront.AlarmEnabled        = RoverController.AlarmFlags.HasFlag(AlarmCode.CollisionImminentFront);
            alarmCollisionWarningFront.AlarmEnabled         = RoverController.AlarmFlags.HasFlag(AlarmCode.CollisionWarningFront);
            alarmCommunicationFailure.AlarmEnabled          = RoverController.AlarmFlags.HasFlag(AlarmCode.CommunicationFailure);
            alarmFrontLeftPowerCutoff.AlarmEnabled          = RoverController.AlarmFlags.HasFlag(AlarmCode.FrontLeftPowerCutoff);
            alarmFrontRightPowerCutoff.AlarmEnabled         = RoverController.AlarmFlags.HasFlag(AlarmCode.FrontRightPowerCutoff);
            alarmHighVoltageBusUndervolt.AlarmEnabled       = RoverController.AlarmFlags.HasFlag(AlarmCode.HighVoltageBusUndervolt);
            alarmLeftMotorOvercurrent.AlarmEnabled          = RoverController.AlarmFlags.HasFlag(AlarmCode.OvercurrentLeft);
            alarmLowVoltageBusUndervolt.AlarmEnabled        = RoverController.AlarmFlags.HasFlag(AlarmCode.LowVoltageBusUndervolt);
            alarmOvercurrentImminentLeft.AlarmEnabled       = RoverController.AlarmFlags.HasFlag(AlarmCode.OvercurrentImminentLeft);
            alarmOvercurrentImminentRight.AlarmEnabled      = RoverController.AlarmFlags.HasFlag(AlarmCode.OvercurrentImminentRight);
            alarmOvercurrentWarningLeft.AlarmEnabled        = RoverController.AlarmFlags.HasFlag(AlarmCode.OvercurrentWarningLeft);
            alarmOvercurrentWarningRight.AlarmEnabled       = RoverController.AlarmFlags.HasFlag(AlarmCode.OvercurrentWarningRight);
            alarmRearLeftPowerCutoff.AlarmEnabled           = RoverController.AlarmFlags.HasFlag(AlarmCode.RearLeftPowerCutoff);
            alarmRearRightPowerCutoff.AlarmEnabled          = RoverController.AlarmFlags.HasFlag(AlarmCode.RearRightPowerCutoff);
            alarmRightMotorOvercurrent.AlarmEnabled         = RoverController.AlarmFlags.HasFlag(AlarmCode.OvercurrentRight);
            alarmRoverError.AlarmEnabled                    = RoverController.AlarmFlags.HasFlag(AlarmCode.RoverError);
            alarmRoverIdle.AlarmEnabled                     = RoverController.AlarmFlags.HasFlag(AlarmCode.RoverIdle);
            alarmRoverOff.AlarmEnabled                      = RoverController.AlarmFlags.HasFlag(AlarmCode.RoverOff);
            alarmRoverRun.AlarmEnabled                      = RoverController.AlarmFlags.HasFlag(AlarmCode.RoverRun);
            alarmStallLeft.AlarmEnabled                     = RoverController.AlarmFlags.HasFlag(AlarmCode.StallLeft);
            alarmStallRight.AlarmEnabled                    = RoverController.AlarmFlags.HasFlag(AlarmCode.StallRight);
        }
    }
}
