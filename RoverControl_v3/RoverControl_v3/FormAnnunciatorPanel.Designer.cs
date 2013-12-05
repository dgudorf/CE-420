namespace RoverControl_v3
{
    partial class FormAnnunciatorPanel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.rectangleShape1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.alarmCommunicationFailure = new RoverControl_v3.AlarmButton();
            this.alarmBatteryFailure = new RoverControl_v3.AlarmButton();
            this.alarmRoverOff = new RoverControl_v3.AlarmButton();
            this.alarmRoverIdle = new RoverControl_v3.AlarmButton();
            this.alarmRoverRun = new RoverControl_v3.AlarmButton();
            this.alarmRoverError = new RoverControl_v3.AlarmButton();
            this.alarmRearRightPowerCutoff = new RoverControl_v3.AlarmButton();
            this.alarmCollisionAvoidanceActive = new RoverControl_v3.AlarmButton();
            this.alarmRearLeftPowerCutoff = new RoverControl_v3.AlarmButton();
            this.alarmFrontRightPowerCutoff = new RoverControl_v3.AlarmButton();
            this.alarmFrontLeftPowerCutoff = new RoverControl_v3.AlarmButton();
            this.alarmHighVoltageBusUndervolt = new RoverControl_v3.AlarmButton();
            this.alarmLowVoltageBusUndervolt = new RoverControl_v3.AlarmButton();
            this.alarmStallRight = new RoverControl_v3.AlarmButton();
            this.alarmOvercurrentWarningRight = new RoverControl_v3.AlarmButton();
            this.alarmOvercurrentImminentRight = new RoverControl_v3.AlarmButton();
            this.alarmOvercurrentImminentLeft = new RoverControl_v3.AlarmButton();
            this.alarmCollisionWarningFront = new RoverControl_v3.AlarmButton();
            this.alarmCollisionImminentFront = new RoverControl_v3.AlarmButton();
            this.alarmStallLeft = new RoverControl_v3.AlarmButton();
            this.alarmOvercurrentWarningLeft = new RoverControl_v3.AlarmButton();
            this.alarmRightMotorOvercurrent = new RoverControl_v3.AlarmButton();
            this.alarmLeftMotorOvercurrent = new RoverControl_v3.AlarmButton();
            this.timerUpdate = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.Visible = true;
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.rectangleShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(496, 446);
            this.shapeContainer1.TabIndex = 8;
            this.shapeContainer1.TabStop = false;
            // 
            // rectangleShape1
            // 
            this.rectangleShape1.BackColor = System.Drawing.Color.Black;
            this.rectangleShape1.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
            this.rectangleShape1.Location = new System.Drawing.Point(16, 14);
            this.rectangleShape1.Name = "rectangleShape1";
            this.rectangleShape1.Size = new System.Drawing.Size(465, 417);
            // 
            // alarmCommunicationFailure
            // 
            this.alarmCommunicationFailure.AlarmCode = RoverControl_v3.AlarmCode.CommunicationFailure;
            this.alarmCommunicationFailure.AlarmEnabled = false;
            this.alarmCommunicationFailure.AlarmPriority = RoverControl_v3.PriorityLevel.Extreme;
            this.alarmCommunicationFailure.AlarmSilenced = false;
            this.alarmCommunicationFailure.AlarmText = "COMMUNICATION\r\nFAILURE";
            this.alarmCommunicationFailure.Font = new System.Drawing.Font("04b_03b", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alarmCommunicationFailure.Location = new System.Drawing.Point(20, 18);
            this.alarmCommunicationFailure.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.alarmCommunicationFailure.Name = "alarmCommunicationFailure";
            this.alarmCommunicationFailure.Size = new System.Drawing.Size(226, 46);
            this.alarmCommunicationFailure.TabIndex = 7;
            this.alarmCommunicationFailure.AlarmEnabledChanged += new System.EventHandler(this.Alarm_AlarmEnabledChanged);
            // 
            // alarmBatteryFailure
            // 
            this.alarmBatteryFailure.AlarmCode = RoverControl_v3.AlarmCode.BatteryFailure;
            this.alarmBatteryFailure.AlarmEnabled = false;
            this.alarmBatteryFailure.AlarmPriority = RoverControl_v3.PriorityLevel.Extreme;
            this.alarmBatteryFailure.AlarmSilenced = false;
            this.alarmBatteryFailure.AlarmText = "BATTERY\r\nFAILURE";
            this.alarmBatteryFailure.Font = new System.Drawing.Font("04b_03b", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alarmBatteryFailure.Location = new System.Drawing.Point(252, 18);
            this.alarmBatteryFailure.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.alarmBatteryFailure.Name = "alarmBatteryFailure";
            this.alarmBatteryFailure.Size = new System.Drawing.Size(226, 46);
            this.alarmBatteryFailure.TabIndex = 6;
            this.alarmBatteryFailure.AlarmEnabledChanged += new System.EventHandler(this.Alarm_AlarmEnabledChanged);
            // 
            // alarmRoverOff
            // 
            this.alarmRoverOff.AlarmCode = RoverControl_v3.AlarmCode.RoverOff;
            this.alarmRoverOff.AlarmEnabled = false;
            this.alarmRoverOff.AlarmPriority = RoverControl_v3.PriorityLevel.Low;
            this.alarmRoverOff.AlarmSilenced = false;
            this.alarmRoverOff.AlarmText = "OFF";
            this.alarmRoverOff.Font = new System.Drawing.Font("04b_03b", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alarmRoverOff.Location = new System.Drawing.Point(20, 382);
            this.alarmRoverOff.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.alarmRoverOff.Name = "alarmRoverOff";
            this.alarmRoverOff.Size = new System.Drawing.Size(110, 46);
            this.alarmRoverOff.TabIndex = 2;
            this.alarmRoverOff.AlarmEnabledChanged += new System.EventHandler(this.Alarm_AlarmEnabledChanged);
            // 
            // alarmRoverIdle
            // 
            this.alarmRoverIdle.AlarmCode = RoverControl_v3.AlarmCode.RoverIdle;
            this.alarmRoverIdle.AlarmEnabled = false;
            this.alarmRoverIdle.AlarmPriority = RoverControl_v3.PriorityLevel.Low;
            this.alarmRoverIdle.AlarmSilenced = false;
            this.alarmRoverIdle.AlarmText = "IDLE";
            this.alarmRoverIdle.Font = new System.Drawing.Font("04b_03b", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alarmRoverIdle.Location = new System.Drawing.Point(136, 382);
            this.alarmRoverIdle.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.alarmRoverIdle.Name = "alarmRoverIdle";
            this.alarmRoverIdle.Size = new System.Drawing.Size(110, 46);
            this.alarmRoverIdle.TabIndex = 3;
            this.alarmRoverIdle.AlarmEnabledChanged += new System.EventHandler(this.Alarm_AlarmEnabledChanged);
            // 
            // alarmRoverRun
            // 
            this.alarmRoverRun.AlarmCode = RoverControl_v3.AlarmCode.RoverRun;
            this.alarmRoverRun.AlarmEnabled = false;
            this.alarmRoverRun.AlarmPriority = RoverControl_v3.PriorityLevel.Low;
            this.alarmRoverRun.AlarmSilenced = false;
            this.alarmRoverRun.AlarmText = "RUN";
            this.alarmRoverRun.Font = new System.Drawing.Font("04b_03b", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alarmRoverRun.Location = new System.Drawing.Point(368, 382);
            this.alarmRoverRun.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.alarmRoverRun.Name = "alarmRoverRun";
            this.alarmRoverRun.Size = new System.Drawing.Size(110, 46);
            this.alarmRoverRun.TabIndex = 4;
            this.alarmRoverRun.AlarmEnabledChanged += new System.EventHandler(this.Alarm_AlarmEnabledChanged);
            // 
            // alarmRoverError
            // 
            this.alarmRoverError.AlarmCode = RoverControl_v3.AlarmCode.RoverError;
            this.alarmRoverError.AlarmEnabled = false;
            this.alarmRoverError.AlarmPriority = RoverControl_v3.PriorityLevel.Low;
            this.alarmRoverError.AlarmSilenced = false;
            this.alarmRoverError.AlarmText = "ERROR";
            this.alarmRoverError.Font = new System.Drawing.Font("04b_03b", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alarmRoverError.Location = new System.Drawing.Point(252, 382);
            this.alarmRoverError.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.alarmRoverError.Name = "alarmRoverError";
            this.alarmRoverError.Size = new System.Drawing.Size(110, 46);
            this.alarmRoverError.TabIndex = 5;
            this.alarmRoverError.AlarmEnabledChanged += new System.EventHandler(this.Alarm_AlarmEnabledChanged);
            // 
            // alarmRearRightPowerCutoff
            // 
            this.alarmRearRightPowerCutoff.AlarmCode = RoverControl_v3.AlarmCode.RearRightPowerCutoff;
            this.alarmRearRightPowerCutoff.AlarmEnabled = false;
            this.alarmRearRightPowerCutoff.AlarmPriority = RoverControl_v3.PriorityLevel.Medium;
            this.alarmRearRightPowerCutoff.AlarmSilenced = false;
            this.alarmRearRightPowerCutoff.AlarmText = "RR PWR CUTOFF";
            this.alarmRearRightPowerCutoff.Font = new System.Drawing.Font("04b_03b", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alarmRearRightPowerCutoff.Location = new System.Drawing.Point(368, 330);
            this.alarmRearRightPowerCutoff.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.alarmRearRightPowerCutoff.Name = "alarmRearRightPowerCutoff";
            this.alarmRearRightPowerCutoff.Size = new System.Drawing.Size(110, 46);
            this.alarmRearRightPowerCutoff.TabIndex = 0;
            this.alarmRearRightPowerCutoff.AlarmEnabledChanged += new System.EventHandler(this.Alarm_AlarmEnabledChanged);
            // 
            // alarmCollisionAvoidanceActive
            // 
            this.alarmCollisionAvoidanceActive.AlarmCode = RoverControl_v3.AlarmCode.CollisionAvoidanceActive;
            this.alarmCollisionAvoidanceActive.AlarmEnabled = false;
            this.alarmCollisionAvoidanceActive.AlarmPriority = RoverControl_v3.PriorityLevel.Medium;
            this.alarmCollisionAvoidanceActive.AlarmSilenced = false;
            this.alarmCollisionAvoidanceActive.AlarmText = "COLL AVOID ACTIVE";
            this.alarmCollisionAvoidanceActive.Font = new System.Drawing.Font("04b_03b", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alarmCollisionAvoidanceActive.Location = new System.Drawing.Point(136, 330);
            this.alarmCollisionAvoidanceActive.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.alarmCollisionAvoidanceActive.Name = "alarmCollisionAvoidanceActive";
            this.alarmCollisionAvoidanceActive.Size = new System.Drawing.Size(226, 46);
            this.alarmCollisionAvoidanceActive.TabIndex = 0;
            this.alarmCollisionAvoidanceActive.AlarmEnabledChanged += new System.EventHandler(this.Alarm_AlarmEnabledChanged);
            // 
            // alarmRearLeftPowerCutoff
            // 
            this.alarmRearLeftPowerCutoff.AlarmCode = RoverControl_v3.AlarmCode.RearLeftPowerCutoff;
            this.alarmRearLeftPowerCutoff.AlarmEnabled = false;
            this.alarmRearLeftPowerCutoff.AlarmPriority = RoverControl_v3.PriorityLevel.Medium;
            this.alarmRearLeftPowerCutoff.AlarmSilenced = false;
            this.alarmRearLeftPowerCutoff.AlarmText = "RL PWR CUTOFF";
            this.alarmRearLeftPowerCutoff.Font = new System.Drawing.Font("04b_03b", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alarmRearLeftPowerCutoff.Location = new System.Drawing.Point(20, 330);
            this.alarmRearLeftPowerCutoff.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.alarmRearLeftPowerCutoff.Name = "alarmRearLeftPowerCutoff";
            this.alarmRearLeftPowerCutoff.Size = new System.Drawing.Size(110, 46);
            this.alarmRearLeftPowerCutoff.TabIndex = 0;
            this.alarmRearLeftPowerCutoff.AlarmEnabledChanged += new System.EventHandler(this.Alarm_AlarmEnabledChanged);
            // 
            // alarmFrontRightPowerCutoff
            // 
            this.alarmFrontRightPowerCutoff.AlarmCode = RoverControl_v3.AlarmCode.FrontRightPowerCutoff;
            this.alarmFrontRightPowerCutoff.AlarmEnabled = false;
            this.alarmFrontRightPowerCutoff.AlarmPriority = RoverControl_v3.PriorityLevel.Medium;
            this.alarmFrontRightPowerCutoff.AlarmSilenced = false;
            this.alarmFrontRightPowerCutoff.AlarmText = "FR PWR CUTOFF";
            this.alarmFrontRightPowerCutoff.Font = new System.Drawing.Font("04b_03b", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alarmFrontRightPowerCutoff.Location = new System.Drawing.Point(368, 278);
            this.alarmFrontRightPowerCutoff.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.alarmFrontRightPowerCutoff.Name = "alarmFrontRightPowerCutoff";
            this.alarmFrontRightPowerCutoff.Size = new System.Drawing.Size(110, 46);
            this.alarmFrontRightPowerCutoff.TabIndex = 0;
            this.alarmFrontRightPowerCutoff.AlarmEnabledChanged += new System.EventHandler(this.Alarm_AlarmEnabledChanged);
            // 
            // alarmFrontLeftPowerCutoff
            // 
            this.alarmFrontLeftPowerCutoff.AlarmCode = RoverControl_v3.AlarmCode.FrontLeftPowerCutoff;
            this.alarmFrontLeftPowerCutoff.AlarmEnabled = false;
            this.alarmFrontLeftPowerCutoff.AlarmPriority = RoverControl_v3.PriorityLevel.Medium;
            this.alarmFrontLeftPowerCutoff.AlarmSilenced = false;
            this.alarmFrontLeftPowerCutoff.AlarmText = "FL PWR CUTOFF";
            this.alarmFrontLeftPowerCutoff.Font = new System.Drawing.Font("04b_03b", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alarmFrontLeftPowerCutoff.Location = new System.Drawing.Point(20, 278);
            this.alarmFrontLeftPowerCutoff.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.alarmFrontLeftPowerCutoff.Name = "alarmFrontLeftPowerCutoff";
            this.alarmFrontLeftPowerCutoff.Size = new System.Drawing.Size(110, 46);
            this.alarmFrontLeftPowerCutoff.TabIndex = 0;
            this.alarmFrontLeftPowerCutoff.AlarmEnabledChanged += new System.EventHandler(this.Alarm_AlarmEnabledChanged);
            // 
            // alarmHighVoltageBusUndervolt
            // 
            this.alarmHighVoltageBusUndervolt.AlarmCode = RoverControl_v3.AlarmCode.LowVoltageBusUndervolt;
            this.alarmHighVoltageBusUndervolt.AlarmEnabled = false;
            this.alarmHighVoltageBusUndervolt.AlarmPriority = RoverControl_v3.PriorityLevel.Extreme;
            this.alarmHighVoltageBusUndervolt.AlarmSilenced = false;
            this.alarmHighVoltageBusUndervolt.AlarmText = "5.0V BUS UNDERVOLT";
            this.alarmHighVoltageBusUndervolt.Font = new System.Drawing.Font("04b_03b", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alarmHighVoltageBusUndervolt.Location = new System.Drawing.Point(252, 122);
            this.alarmHighVoltageBusUndervolt.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.alarmHighVoltageBusUndervolt.Name = "alarmHighVoltageBusUndervolt";
            this.alarmHighVoltageBusUndervolt.Size = new System.Drawing.Size(226, 46);
            this.alarmHighVoltageBusUndervolt.TabIndex = 0;
            this.alarmHighVoltageBusUndervolt.AlarmEnabledChanged += new System.EventHandler(this.Alarm_AlarmEnabledChanged);
            // 
            // alarmLowVoltageBusUndervolt
            // 
            this.alarmLowVoltageBusUndervolt.AlarmCode = RoverControl_v3.AlarmCode.HighVoltageBusUndervolt;
            this.alarmLowVoltageBusUndervolt.AlarmEnabled = false;
            this.alarmLowVoltageBusUndervolt.AlarmPriority = RoverControl_v3.PriorityLevel.Extreme;
            this.alarmLowVoltageBusUndervolt.AlarmSilenced = false;
            this.alarmLowVoltageBusUndervolt.AlarmText = "3.3V BUS UNDERVOLT";
            this.alarmLowVoltageBusUndervolt.Font = new System.Drawing.Font("04b_03b", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alarmLowVoltageBusUndervolt.Location = new System.Drawing.Point(20, 122);
            this.alarmLowVoltageBusUndervolt.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.alarmLowVoltageBusUndervolt.Name = "alarmLowVoltageBusUndervolt";
            this.alarmLowVoltageBusUndervolt.Size = new System.Drawing.Size(226, 46);
            this.alarmLowVoltageBusUndervolt.TabIndex = 0;
            this.alarmLowVoltageBusUndervolt.AlarmEnabledChanged += new System.EventHandler(this.Alarm_AlarmEnabledChanged);
            // 
            // alarmStallRight
            // 
            this.alarmStallRight.AlarmCode = RoverControl_v3.AlarmCode.StallRight;
            this.alarmStallRight.AlarmEnabled = false;
            this.alarmStallRight.AlarmPriority = RoverControl_v3.PriorityLevel.Severe;
            this.alarmStallRight.AlarmSilenced = false;
            this.alarmStallRight.AlarmText = "STALL RIGHT";
            this.alarmStallRight.Font = new System.Drawing.Font("04b_03b", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alarmStallRight.Location = new System.Drawing.Point(368, 226);
            this.alarmStallRight.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.alarmStallRight.Name = "alarmStallRight";
            this.alarmStallRight.Size = new System.Drawing.Size(110, 46);
            this.alarmStallRight.TabIndex = 0;
            this.alarmStallRight.AlarmEnabledChanged += new System.EventHandler(this.Alarm_AlarmEnabledChanged);
            // 
            // alarmOvercurrentWarningRight
            // 
            this.alarmOvercurrentWarningRight.AlarmCode = RoverControl_v3.AlarmCode.OvercurrentWarningRight;
            this.alarmOvercurrentWarningRight.AlarmEnabled = false;
            this.alarmOvercurrentWarningRight.AlarmPriority = RoverControl_v3.PriorityLevel.High;
            this.alarmOvercurrentWarningRight.AlarmSilenced = false;
            this.alarmOvercurrentWarningRight.AlarmText = "OVC WARN RIGHT";
            this.alarmOvercurrentWarningRight.Font = new System.Drawing.Font("04b_03b", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alarmOvercurrentWarningRight.Location = new System.Drawing.Point(368, 174);
            this.alarmOvercurrentWarningRight.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.alarmOvercurrentWarningRight.Name = "alarmOvercurrentWarningRight";
            this.alarmOvercurrentWarningRight.Size = new System.Drawing.Size(110, 46);
            this.alarmOvercurrentWarningRight.TabIndex = 0;
            this.alarmOvercurrentWarningRight.AlarmEnabledChanged += new System.EventHandler(this.Alarm_AlarmEnabledChanged);
            // 
            // alarmOvercurrentImminentRight
            // 
            this.alarmOvercurrentImminentRight.AlarmCode = RoverControl_v3.AlarmCode.OvercurrentImminentRight;
            this.alarmOvercurrentImminentRight.AlarmEnabled = false;
            this.alarmOvercurrentImminentRight.AlarmPriority = RoverControl_v3.PriorityLevel.Severe;
            this.alarmOvercurrentImminentRight.AlarmSilenced = false;
            this.alarmOvercurrentImminentRight.AlarmText = "OVC IMM RIGHT";
            this.alarmOvercurrentImminentRight.Font = new System.Drawing.Font("04b_03b", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alarmOvercurrentImminentRight.Location = new System.Drawing.Point(252, 174);
            this.alarmOvercurrentImminentRight.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.alarmOvercurrentImminentRight.Name = "alarmOvercurrentImminentRight";
            this.alarmOvercurrentImminentRight.Size = new System.Drawing.Size(110, 46);
            this.alarmOvercurrentImminentRight.TabIndex = 0;
            this.alarmOvercurrentImminentRight.AlarmEnabledChanged += new System.EventHandler(this.Alarm_AlarmEnabledChanged);
            // 
            // alarmOvercurrentImminentLeft
            // 
            this.alarmOvercurrentImminentLeft.AlarmCode = RoverControl_v3.AlarmCode.OvercurrentImminentLeft;
            this.alarmOvercurrentImminentLeft.AlarmEnabled = false;
            this.alarmOvercurrentImminentLeft.AlarmPriority = RoverControl_v3.PriorityLevel.Severe;
            this.alarmOvercurrentImminentLeft.AlarmSilenced = false;
            this.alarmOvercurrentImminentLeft.AlarmText = "OVC IMM LEFT";
            this.alarmOvercurrentImminentLeft.Font = new System.Drawing.Font("04b_03b", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alarmOvercurrentImminentLeft.Location = new System.Drawing.Point(136, 174);
            this.alarmOvercurrentImminentLeft.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.alarmOvercurrentImminentLeft.Name = "alarmOvercurrentImminentLeft";
            this.alarmOvercurrentImminentLeft.Size = new System.Drawing.Size(110, 46);
            this.alarmOvercurrentImminentLeft.TabIndex = 0;
            this.alarmOvercurrentImminentLeft.AlarmEnabledChanged += new System.EventHandler(this.Alarm_AlarmEnabledChanged);
            // 
            // alarmCollisionWarningFront
            // 
            this.alarmCollisionWarningFront.AlarmCode = RoverControl_v3.AlarmCode.None;
            this.alarmCollisionWarningFront.AlarmEnabled = false;
            this.alarmCollisionWarningFront.AlarmPriority = RoverControl_v3.PriorityLevel.High;
            this.alarmCollisionWarningFront.AlarmSilenced = false;
            this.alarmCollisionWarningFront.AlarmText = "COLL WARN FRONT";
            this.alarmCollisionWarningFront.Font = new System.Drawing.Font("04b_03b", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alarmCollisionWarningFront.Location = new System.Drawing.Point(136, 278);
            this.alarmCollisionWarningFront.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.alarmCollisionWarningFront.Name = "alarmCollisionWarningFront";
            this.alarmCollisionWarningFront.Size = new System.Drawing.Size(226, 46);
            this.alarmCollisionWarningFront.TabIndex = 0;
            this.alarmCollisionWarningFront.AlarmEnabledChanged += new System.EventHandler(this.Alarm_AlarmEnabledChanged);
            // 
            // alarmCollisionImminentFront
            // 
            this.alarmCollisionImminentFront.AlarmCode = RoverControl_v3.AlarmCode.CollisionImminentFront;
            this.alarmCollisionImminentFront.AlarmEnabled = false;
            this.alarmCollisionImminentFront.AlarmPriority = RoverControl_v3.PriorityLevel.Severe;
            this.alarmCollisionImminentFront.AlarmSilenced = false;
            this.alarmCollisionImminentFront.AlarmText = "COLL IMM FRONT";
            this.alarmCollisionImminentFront.Font = new System.Drawing.Font("04b_03b", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alarmCollisionImminentFront.Location = new System.Drawing.Point(136, 226);
            this.alarmCollisionImminentFront.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.alarmCollisionImminentFront.Name = "alarmCollisionImminentFront";
            this.alarmCollisionImminentFront.Size = new System.Drawing.Size(226, 46);
            this.alarmCollisionImminentFront.TabIndex = 0;
            this.alarmCollisionImminentFront.AlarmEnabledChanged += new System.EventHandler(this.Alarm_AlarmEnabledChanged);
            // 
            // alarmStallLeft
            // 
            this.alarmStallLeft.AlarmCode = RoverControl_v3.AlarmCode.StallLeft;
            this.alarmStallLeft.AlarmEnabled = false;
            this.alarmStallLeft.AlarmPriority = RoverControl_v3.PriorityLevel.Severe;
            this.alarmStallLeft.AlarmSilenced = false;
            this.alarmStallLeft.AlarmText = "STALL LEFT";
            this.alarmStallLeft.Font = new System.Drawing.Font("04b_03b", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alarmStallLeft.Location = new System.Drawing.Point(20, 226);
            this.alarmStallLeft.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.alarmStallLeft.Name = "alarmStallLeft";
            this.alarmStallLeft.Size = new System.Drawing.Size(110, 46);
            this.alarmStallLeft.TabIndex = 0;
            this.alarmStallLeft.AlarmEnabledChanged += new System.EventHandler(this.Alarm_AlarmEnabledChanged);
            // 
            // alarmOvercurrentWarningLeft
            // 
            this.alarmOvercurrentWarningLeft.AlarmCode = RoverControl_v3.AlarmCode.OvercurrentWarningLeft;
            this.alarmOvercurrentWarningLeft.AlarmEnabled = false;
            this.alarmOvercurrentWarningLeft.AlarmPriority = RoverControl_v3.PriorityLevel.High;
            this.alarmOvercurrentWarningLeft.AlarmSilenced = false;
            this.alarmOvercurrentWarningLeft.AlarmText = "OVC WARN LEFT";
            this.alarmOvercurrentWarningLeft.Font = new System.Drawing.Font("04b_03b", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alarmOvercurrentWarningLeft.Location = new System.Drawing.Point(20, 174);
            this.alarmOvercurrentWarningLeft.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.alarmOvercurrentWarningLeft.Name = "alarmOvercurrentWarningLeft";
            this.alarmOvercurrentWarningLeft.Size = new System.Drawing.Size(110, 46);
            this.alarmOvercurrentWarningLeft.TabIndex = 0;
            this.alarmOvercurrentWarningLeft.AlarmEnabledChanged += new System.EventHandler(this.Alarm_AlarmEnabledChanged);
            // 
            // alarmRightMotorOvercurrent
            // 
            this.alarmRightMotorOvercurrent.AlarmCode = RoverControl_v3.AlarmCode.OvercurrentLeft;
            this.alarmRightMotorOvercurrent.AlarmEnabled = false;
            this.alarmRightMotorOvercurrent.AlarmPriority = RoverControl_v3.PriorityLevel.Extreme;
            this.alarmRightMotorOvercurrent.AlarmSilenced = false;
            this.alarmRightMotorOvercurrent.AlarmText = "RIGHT MOTOR OVERCURRENT";
            this.alarmRightMotorOvercurrent.Font = new System.Drawing.Font("04b_03b", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alarmRightMotorOvercurrent.Location = new System.Drawing.Point(252, 70);
            this.alarmRightMotorOvercurrent.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.alarmRightMotorOvercurrent.Name = "alarmRightMotorOvercurrent";
            this.alarmRightMotorOvercurrent.Size = new System.Drawing.Size(226, 46);
            this.alarmRightMotorOvercurrent.TabIndex = 0;
            this.alarmRightMotorOvercurrent.AlarmEnabledChanged += new System.EventHandler(this.Alarm_AlarmEnabledChanged);
            // 
            // alarmLeftMotorOvercurrent
            // 
            this.alarmLeftMotorOvercurrent.AlarmCode = RoverControl_v3.AlarmCode.OvercurrentLeft;
            this.alarmLeftMotorOvercurrent.AlarmEnabled = false;
            this.alarmLeftMotorOvercurrent.AlarmPriority = RoverControl_v3.PriorityLevel.Extreme;
            this.alarmLeftMotorOvercurrent.AlarmSilenced = false;
            this.alarmLeftMotorOvercurrent.AlarmText = "LEFT MOTOR OVERCURRENT";
            this.alarmLeftMotorOvercurrent.Font = new System.Drawing.Font("04b_03b", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alarmLeftMotorOvercurrent.Location = new System.Drawing.Point(20, 70);
            this.alarmLeftMotorOvercurrent.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.alarmLeftMotorOvercurrent.Name = "alarmLeftMotorOvercurrent";
            this.alarmLeftMotorOvercurrent.Size = new System.Drawing.Size(226, 46);
            this.alarmLeftMotorOvercurrent.TabIndex = 0;
            this.alarmLeftMotorOvercurrent.AlarmEnabledChanged += new System.EventHandler(this.Alarm_AlarmEnabledChanged);
            // 
            // timerUpdate
            // 
            this.timerUpdate.Enabled = true;
            this.timerUpdate.Tick += new System.EventHandler(this.timerUpdate_Tick);
            // 
            // FormAnnunciatorPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 446);
            this.Controls.Add(this.alarmCommunicationFailure);
            this.Controls.Add(this.alarmBatteryFailure);
            this.Controls.Add(this.alarmRoverOff);
            this.Controls.Add(this.alarmRoverIdle);
            this.Controls.Add(this.alarmRoverRun);
            this.Controls.Add(this.alarmRoverError);
            this.Controls.Add(this.alarmRearRightPowerCutoff);
            this.Controls.Add(this.alarmCollisionAvoidanceActive);
            this.Controls.Add(this.alarmRearLeftPowerCutoff);
            this.Controls.Add(this.alarmFrontRightPowerCutoff);
            this.Controls.Add(this.alarmFrontLeftPowerCutoff);
            this.Controls.Add(this.alarmHighVoltageBusUndervolt);
            this.Controls.Add(this.alarmLowVoltageBusUndervolt);
            this.Controls.Add(this.alarmStallRight);
            this.Controls.Add(this.alarmOvercurrentWarningRight);
            this.Controls.Add(this.alarmOvercurrentImminentRight);
            this.Controls.Add(this.alarmOvercurrentImminentLeft);
            this.Controls.Add(this.alarmCollisionWarningFront);
            this.Controls.Add(this.alarmCollisionImminentFront);
            this.Controls.Add(this.alarmStallLeft);
            this.Controls.Add(this.alarmOvercurrentWarningLeft);
            this.Controls.Add(this.alarmRightMotorOvercurrent);
            this.Controls.Add(this.alarmLeftMotorOvercurrent);
            this.Controls.Add(this.shapeContainer1);
            this.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Location = new System.Drawing.Point(25, 405);
            this.MaximizeBox = false;
            this.Name = "FormAnnunciatorPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Annuciator Panel";
            this.Load += new System.EventHandler(this.FormAnnunciatorPanel_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private AlarmButton alarmLeftMotorOvercurrent;
        private AlarmButton alarmRightMotorOvercurrent;
        private AlarmButton alarmLowVoltageBusUndervolt;
        private AlarmButton alarmHighVoltageBusUndervolt;
        private AlarmButton alarmOvercurrentWarningLeft;
        private AlarmButton alarmOvercurrentImminentLeft;
        private AlarmButton alarmOvercurrentImminentRight;
        private AlarmButton alarmOvercurrentWarningRight;
        private AlarmButton alarmCollisionWarningFront;
        private AlarmButton alarmCollisionImminentFront;
        private AlarmButton alarmStallLeft;
        private AlarmButton alarmStallRight;
        private AlarmButton alarmFrontLeftPowerCutoff;
        private AlarmButton alarmFrontRightPowerCutoff;
        private AlarmButton alarmRearLeftPowerCutoff;
        private AlarmButton alarmRearRightPowerCutoff;
        private AlarmButton alarmCollisionAvoidanceActive;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ToolTip toolTip;
        private AlarmButton alarmRoverOff;
        private AlarmButton alarmRoverIdle;
        private AlarmButton alarmRoverRun;
        private AlarmButton alarmRoverError;
        private AlarmButton alarmCommunicationFailure;
        private AlarmButton alarmBatteryFailure;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape1;
        private System.Windows.Forms.Timer timerUpdate;



    }
}