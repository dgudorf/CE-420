namespace RoverControl_v3
{
    partial class FormConfiguration
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numericListenPort = new DGCustomControls.NumericUpDownImpl(this.components);
            this.numericTargetPort = new DGCustomControls.NumericUpDownImpl(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textRoverIPAddress = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericControllerInterval = new DGCustomControls.NumericUpDownImpl(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.numericNetworkInterval = new DGCustomControls.NumericUpDownImpl(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textExportLogLocation = new System.Windows.Forms.TextBox();
            this.linkSelectExportLogLocation = new System.Windows.Forms.LinkLabel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.checkIncludeCaptureMode = new System.Windows.Forms.CheckBox();
            this.checkIncludeAlarmStates = new System.Windows.Forms.CheckBox();
            this.checkIncludeMotorEncoders = new System.Windows.Forms.CheckBox();
            this.checkIncludeMotorSetpoints = new System.Windows.Forms.CheckBox();
            this.checkIncludeMotorCurrents = new System.Windows.Forms.CheckBox();
            this.checkIncludeGpsCoordinates = new System.Windows.Forms.CheckBox();
            this.checkIncludeIRDistance = new System.Windows.Forms.CheckBox();
            this.checkIncludeServoSetpoints = new System.Windows.Forms.CheckBox();
            this.checkIncludeServoInputs = new System.Windows.Forms.CheckBox();
            this.checkIncludeMotorInputs = new System.Windows.Forms.CheckBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.textImageOutputLocation = new System.Windows.Forms.TextBox();
            this.linkSelectImageOutputLocation = new System.Windows.Forms.LinkLabel();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.numericTimedCaptureInterval = new DGCustomControls.NumericUpDownImpl(this.components);
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.numericVideoCaptureRate = new DGCustomControls.NumericUpDownImpl(this.components);
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.radioSizeMode = new System.Windows.Forms.RadioButton();
            this.radioCountMode = new System.Windows.Forms.RadioButton();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.numericMaximumFileSize = new DGCustomControls.NumericUpDownImpl(this.components);
            this.numericMaximumFileCount = new DGCustomControls.NumericUpDownImpl(this.components);
            this.linkSave = new System.Windows.Forms.LinkLabel();
            this.linkClose = new System.Windows.Forms.LinkLabel();
            this.linkClearAll = new System.Windows.Forms.LinkLabel();
            this.linkInvertAll = new System.Windows.Forms.LinkLabel();
            this.linkSelectAll = new System.Windows.Forms.LinkLabel();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.numericCommitInterval = new DGCustomControls.NumericUpDownImpl(this.components);
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericListenPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericTargetPort)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericControllerInterval)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericNetworkInterval)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericTimedCaptureInterval)).BeginInit();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericVideoCaptureRate)).BeginInit();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericMaximumFileSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMaximumFileCount)).BeginInit();
            this.groupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericCommitInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numericListenPort);
            this.groupBox1.Controls.Add(this.numericTargetPort);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textRoverIPAddress);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(8, 3, 8, 3);
            this.groupBox1.Size = new System.Drawing.Size(545, 45);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "NETWORK SETTINGS";
            // 
            // numericListenPort
            // 
            this.numericListenPort.ExponentBase = "";
            this.numericListenPort.Format = DGCustomControls.NumericUpDownImpl.FormatMode.None;
            this.numericListenPort.FormatString = "";
            this.numericListenPort.Location = new System.Drawing.Point(471, 19);
            this.numericListenPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericListenPort.Name = "numericListenPort";
            this.numericListenPort.Size = new System.Drawing.Size(58, 20);
            this.numericListenPort.TabIndex = 3;
            this.numericListenPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericListenPort.UnitPlural = "";
            this.numericListenPort.UnitSingle = "";
            this.numericListenPort.Value = new decimal(new int[] {
            44401,
            0,
            0,
            0});
            // 
            // numericTargetPort
            // 
            this.numericTargetPort.ExponentBase = "";
            this.numericTargetPort.Format = DGCustomControls.NumericUpDownImpl.FormatMode.None;
            this.numericTargetPort.FormatString = "";
            this.numericTargetPort.Location = new System.Drawing.Point(293, 19);
            this.numericTargetPort.Margin = new System.Windows.Forms.Padding(3, 3, 8, 3);
            this.numericTargetPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericTargetPort.Name = "numericTargetPort";
            this.numericTargetPort.Size = new System.Drawing.Size(58, 20);
            this.numericTargetPort.TabIndex = 3;
            this.numericTargetPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericTargetPort.UnitPlural = "";
            this.numericTargetPort.UnitSingle = "";
            this.numericTargetPort.Value = new decimal(new int[] {
            44400,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(362, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "LISTEN ON PORT #";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(196, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "SEND TO PORT #";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "ROVER IP:";
            // 
            // textRoverIPAddress
            // 
            this.textRoverIPAddress.Location = new System.Drawing.Point(77, 19);
            this.textRoverIPAddress.Margin = new System.Windows.Forms.Padding(3, 3, 8, 3);
            this.textRoverIPAddress.Name = "textRoverIPAddress";
            this.textRoverIPAddress.Size = new System.Drawing.Size(108, 20);
            this.textRoverIPAddress.TabIndex = 0;
            this.textRoverIPAddress.Text = "192.168.1.200";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.numericControllerInterval);
            this.groupBox2.Location = new System.Drawing.Point(12, 63);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(8, 3, 8, 3);
            this.groupBox2.Size = new System.Drawing.Size(270, 45);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "CONTROLLER INPUT POLL INTERVAL";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(196, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "MSECS";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "UPDATE STATE EVERY";
            // 
            // numericControllerInterval
            // 
            this.numericControllerInterval.ExponentBase = "";
            this.numericControllerInterval.Format = DGCustomControls.NumericUpDownImpl.FormatMode.None;
            this.numericControllerInterval.FormatString = "";
            this.numericControllerInterval.Location = new System.Drawing.Point(132, 19);
            this.numericControllerInterval.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericControllerInterval.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericControllerInterval.Name = "numericControllerInterval";
            this.numericControllerInterval.Size = new System.Drawing.Size(58, 20);
            this.numericControllerInterval.TabIndex = 3;
            this.numericControllerInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericControllerInterval.UnitPlural = "";
            this.numericControllerInterval.UnitSingle = "";
            this.numericControllerInterval.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.numericNetworkInterval);
            this.groupBox3.Location = new System.Drawing.Point(287, 63);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(8, 3, 8, 3);
            this.groupBox3.Size = new System.Drawing.Size(270, 45);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "NETWORK UPDATE INTERVAL";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(196, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "MSECS";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "UPDATE STATE EVERY";
            // 
            // numericNetworkInterval
            // 
            this.numericNetworkInterval.ExponentBase = "";
            this.numericNetworkInterval.Format = DGCustomControls.NumericUpDownImpl.FormatMode.None;
            this.numericNetworkInterval.FormatString = "";
            this.numericNetworkInterval.Location = new System.Drawing.Point(132, 19);
            this.numericNetworkInterval.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericNetworkInterval.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericNetworkInterval.Name = "numericNetworkInterval";
            this.numericNetworkInterval.Size = new System.Drawing.Size(58, 20);
            this.numericNetworkInterval.TabIndex = 3;
            this.numericNetworkInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericNetworkInterval.UnitPlural = "";
            this.numericNetworkInterval.UnitSingle = "";
            this.numericNetworkInterval.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textExportLogLocation);
            this.groupBox4.Location = new System.Drawing.Point(12, 114);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(8, 3, 8, 3);
            this.groupBox4.Size = new System.Drawing.Size(270, 45);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "EXPORT LOG OUTPUT LOCATION";
            // 
            // textExportLogLocation
            // 
            this.textExportLogLocation.Location = new System.Drawing.Point(11, 19);
            this.textExportLogLocation.Name = "textExportLogLocation";
            this.textExportLogLocation.Size = new System.Drawing.Size(248, 20);
            this.textExportLogLocation.TabIndex = 0;
            this.textExportLogLocation.TextChanged += new System.EventHandler(this.textExportLogLocation_TextChanged);
            // 
            // linkSelectExportLogLocation
            // 
            this.linkSelectExportLogLocation.AutoSize = true;
            this.linkSelectExportLogLocation.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkSelectExportLogLocation.Location = new System.Drawing.Point(185, 162);
            this.linkSelectExportLogLocation.Name = "linkSelectExportLogLocation";
            this.linkSelectExportLogLocation.Size = new System.Drawing.Size(97, 13);
            this.linkSelectExportLogLocation.TabIndex = 3;
            this.linkSelectExportLogLocation.TabStop = true;
            this.linkSelectExportLogLocation.Text = "SELECT LOCATION";
            this.linkSelectExportLogLocation.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkSelectExportLogLocation_LinkClicked);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.checkIncludeCaptureMode);
            this.groupBox5.Controls.Add(this.checkIncludeAlarmStates);
            this.groupBox5.Controls.Add(this.checkIncludeMotorEncoders);
            this.groupBox5.Controls.Add(this.checkIncludeMotorSetpoints);
            this.groupBox5.Controls.Add(this.checkIncludeMotorCurrents);
            this.groupBox5.Controls.Add(this.checkIncludeGpsCoordinates);
            this.groupBox5.Controls.Add(this.checkIncludeIRDistance);
            this.groupBox5.Controls.Add(this.checkIncludeServoSetpoints);
            this.groupBox5.Controls.Add(this.checkIncludeServoInputs);
            this.groupBox5.Controls.Add(this.checkIncludeMotorInputs);
            this.groupBox5.Location = new System.Drawing.Point(12, 178);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(545, 93);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "EXPORT LOG FIELDS";
            // 
            // checkIncludeCaptureMode
            // 
            this.checkIncludeCaptureMode.Location = new System.Drawing.Point(379, 36);
            this.checkIncludeCaptureMode.Name = "checkIncludeCaptureMode";
            this.checkIncludeCaptureMode.Size = new System.Drawing.Size(146, 17);
            this.checkIncludeCaptureMode.TabIndex = 1;
            this.checkIncludeCaptureMode.Text = "CAPTURE MODE";
            this.checkIncludeCaptureMode.UseVisualStyleBackColor = true;
            this.checkIncludeCaptureMode.CheckedChanged += new System.EventHandler(this.LogInclude_CheckedChanged);
            // 
            // checkIncludeAlarmStates
            // 
            this.checkIncludeAlarmStates.Location = new System.Drawing.Point(379, 19);
            this.checkIncludeAlarmStates.Name = "checkIncludeAlarmStates";
            this.checkIncludeAlarmStates.Size = new System.Drawing.Size(146, 17);
            this.checkIncludeAlarmStates.TabIndex = 1;
            this.checkIncludeAlarmStates.Text = "ALARM STATES";
            this.checkIncludeAlarmStates.UseVisualStyleBackColor = true;
            this.checkIncludeAlarmStates.CheckedChanged += new System.EventHandler(this.LogInclude_CheckedChanged);
            // 
            // checkIncludeMotorEncoders
            // 
            this.checkIncludeMotorEncoders.Location = new System.Drawing.Point(11, 70);
            this.checkIncludeMotorEncoders.Name = "checkIncludeMotorEncoders";
            this.checkIncludeMotorEncoders.Size = new System.Drawing.Size(146, 17);
            this.checkIncludeMotorEncoders.TabIndex = 0;
            this.checkIncludeMotorEncoders.Text = "MOTOR ENCODER VALUES";
            this.checkIncludeMotorEncoders.UseVisualStyleBackColor = true;
            this.checkIncludeMotorEncoders.CheckedChanged += new System.EventHandler(this.LogInclude_CheckedChanged);
            // 
            // checkIncludeMotorSetpoints
            // 
            this.checkIncludeMotorSetpoints.Location = new System.Drawing.Point(11, 53);
            this.checkIncludeMotorSetpoints.Name = "checkIncludeMotorSetpoints";
            this.checkIncludeMotorSetpoints.Size = new System.Drawing.Size(146, 17);
            this.checkIncludeMotorSetpoints.TabIndex = 0;
            this.checkIncludeMotorSetpoints.Text = "MOTOR SETPOINTS";
            this.checkIncludeMotorSetpoints.UseVisualStyleBackColor = true;
            this.checkIncludeMotorSetpoints.CheckedChanged += new System.EventHandler(this.LogInclude_CheckedChanged);
            // 
            // checkIncludeMotorCurrents
            // 
            this.checkIncludeMotorCurrents.Location = new System.Drawing.Point(11, 36);
            this.checkIncludeMotorCurrents.Name = "checkIncludeMotorCurrents";
            this.checkIncludeMotorCurrents.Size = new System.Drawing.Size(146, 17);
            this.checkIncludeMotorCurrents.TabIndex = 0;
            this.checkIncludeMotorCurrents.Text = "MOTOR CURRENTS";
            this.checkIncludeMotorCurrents.UseVisualStyleBackColor = true;
            this.checkIncludeMotorCurrents.CheckedChanged += new System.EventHandler(this.LogInclude_CheckedChanged);
            // 
            // checkIncludeGpsCoordinates
            // 
            this.checkIncludeGpsCoordinates.Location = new System.Drawing.Point(195, 70);
            this.checkIncludeGpsCoordinates.Name = "checkIncludeGpsCoordinates";
            this.checkIncludeGpsCoordinates.Size = new System.Drawing.Size(146, 17);
            this.checkIncludeGpsCoordinates.TabIndex = 0;
            this.checkIncludeGpsCoordinates.Text = "GPS COORDINATES";
            this.checkIncludeGpsCoordinates.UseVisualStyleBackColor = true;
            this.checkIncludeGpsCoordinates.CheckedChanged += new System.EventHandler(this.LogInclude_CheckedChanged);
            // 
            // checkIncludeIRDistance
            // 
            this.checkIncludeIRDistance.Location = new System.Drawing.Point(195, 53);
            this.checkIncludeIRDistance.Name = "checkIncludeIRDistance";
            this.checkIncludeIRDistance.Size = new System.Drawing.Size(146, 17);
            this.checkIncludeIRDistance.TabIndex = 0;
            this.checkIncludeIRDistance.Text = "IR DISTANCE";
            this.checkIncludeIRDistance.UseVisualStyleBackColor = true;
            this.checkIncludeIRDistance.CheckedChanged += new System.EventHandler(this.LogInclude_CheckedChanged);
            // 
            // checkIncludeServoSetpoints
            // 
            this.checkIncludeServoSetpoints.Location = new System.Drawing.Point(195, 36);
            this.checkIncludeServoSetpoints.Name = "checkIncludeServoSetpoints";
            this.checkIncludeServoSetpoints.Size = new System.Drawing.Size(146, 17);
            this.checkIncludeServoSetpoints.TabIndex = 0;
            this.checkIncludeServoSetpoints.Text = "SERVO SETPOINTS";
            this.checkIncludeServoSetpoints.UseVisualStyleBackColor = true;
            this.checkIncludeServoSetpoints.CheckedChanged += new System.EventHandler(this.LogInclude_CheckedChanged);
            // 
            // checkIncludeServoInputs
            // 
            this.checkIncludeServoInputs.Location = new System.Drawing.Point(195, 19);
            this.checkIncludeServoInputs.Name = "checkIncludeServoInputs";
            this.checkIncludeServoInputs.Size = new System.Drawing.Size(146, 17);
            this.checkIncludeServoInputs.TabIndex = 0;
            this.checkIncludeServoInputs.Text = "SERVO INPUTS";
            this.checkIncludeServoInputs.UseVisualStyleBackColor = true;
            this.checkIncludeServoInputs.CheckedChanged += new System.EventHandler(this.LogInclude_CheckedChanged);
            // 
            // checkIncludeMotorInputs
            // 
            this.checkIncludeMotorInputs.Location = new System.Drawing.Point(11, 19);
            this.checkIncludeMotorInputs.Name = "checkIncludeMotorInputs";
            this.checkIncludeMotorInputs.Size = new System.Drawing.Size(146, 17);
            this.checkIncludeMotorInputs.TabIndex = 0;
            this.checkIncludeMotorInputs.Text = "MOTOR INPUTS";
            this.checkIncludeMotorInputs.UseVisualStyleBackColor = true;
            this.checkIncludeMotorInputs.CheckedChanged += new System.EventHandler(this.LogInclude_CheckedChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.textImageOutputLocation);
            this.groupBox6.Location = new System.Drawing.Point(233, 348);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(8, 3, 8, 3);
            this.groupBox6.Size = new System.Drawing.Size(324, 64);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "CAMERA IMAGE OUTPUT LOCATION";
            // 
            // textImageOutputLocation
            // 
            this.textImageOutputLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textImageOutputLocation.Location = new System.Drawing.Point(11, 19);
            this.textImageOutputLocation.Multiline = true;
            this.textImageOutputLocation.Name = "textImageOutputLocation";
            this.textImageOutputLocation.Size = new System.Drawing.Size(302, 39);
            this.textImageOutputLocation.TabIndex = 0;
            this.textImageOutputLocation.TextChanged += new System.EventHandler(this.textImageOutputLocation_TextChanged);
            // 
            // linkSelectImageOutputLocation
            // 
            this.linkSelectImageOutputLocation.AutoSize = true;
            this.linkSelectImageOutputLocation.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkSelectImageOutputLocation.Location = new System.Drawing.Point(460, 415);
            this.linkSelectImageOutputLocation.Margin = new System.Windows.Forms.Padding(3, 0, 3, 8);
            this.linkSelectImageOutputLocation.Name = "linkSelectImageOutputLocation";
            this.linkSelectImageOutputLocation.Size = new System.Drawing.Size(97, 13);
            this.linkSelectImageOutputLocation.TabIndex = 3;
            this.linkSelectImageOutputLocation.TabStop = true;
            this.linkSelectImageOutputLocation.Text = "SELECT LOCATION";
            this.linkSelectImageOutputLocation.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkSelectImageOutputLocation_LinkClicked);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label9);
            this.groupBox7.Controls.Add(this.label8);
            this.groupBox7.Controls.Add(this.numericTimedCaptureInterval);
            this.groupBox7.Location = new System.Drawing.Point(12, 297);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(215, 45);
            this.groupBox7.TabIndex = 5;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "TIMED CAPTURE INTERVAL";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(172, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "MSECS";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "CAPTURE EVERY";
            // 
            // numericTimedCaptureInterval
            // 
            this.numericTimedCaptureInterval.ExponentBase = "";
            this.numericTimedCaptureInterval.Format = DGCustomControls.NumericUpDownImpl.FormatMode.None;
            this.numericTimedCaptureInterval.FormatString = "";
            this.numericTimedCaptureInterval.Location = new System.Drawing.Point(108, 19);
            this.numericTimedCaptureInterval.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericTimedCaptureInterval.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericTimedCaptureInterval.Name = "numericTimedCaptureInterval";
            this.numericTimedCaptureInterval.Size = new System.Drawing.Size(58, 20);
            this.numericTimedCaptureInterval.TabIndex = 3;
            this.numericTimedCaptureInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericTimedCaptureInterval.UnitPlural = "";
            this.numericTimedCaptureInterval.UnitSingle = "";
            this.numericTimedCaptureInterval.Value = new decimal(new int[] {
            2500,
            0,
            0,
            0});
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.label10);
            this.groupBox8.Controls.Add(this.label11);
            this.groupBox8.Controls.Add(this.numericVideoCaptureRate);
            this.groupBox8.Location = new System.Drawing.Point(233, 297);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(324, 45);
            this.groupBox8.TabIndex = 5;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "VIDEO CAPTURE RATE";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(163, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(109, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "FRAMES PER SECOND";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 23);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(85, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "CAPTURE UP TO";
            // 
            // numericVideoCaptureRate
            // 
            this.numericVideoCaptureRate.ExponentBase = "";
            this.numericVideoCaptureRate.Format = DGCustomControls.NumericUpDownImpl.FormatMode.None;
            this.numericVideoCaptureRate.FormatString = "";
            this.numericVideoCaptureRate.Location = new System.Drawing.Point(99, 19);
            this.numericVideoCaptureRate.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericVideoCaptureRate.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericVideoCaptureRate.Name = "numericVideoCaptureRate";
            this.numericVideoCaptureRate.Size = new System.Drawing.Size(58, 20);
            this.numericVideoCaptureRate.TabIndex = 3;
            this.numericVideoCaptureRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericVideoCaptureRate.UnitPlural = "";
            this.numericVideoCaptureRate.UnitSingle = "";
            this.numericVideoCaptureRate.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.radioSizeMode);
            this.groupBox9.Controls.Add(this.radioCountMode);
            this.groupBox9.Controls.Add(this.label12);
            this.groupBox9.Controls.Add(this.label13);
            this.groupBox9.Controls.Add(this.numericMaximumFileSize);
            this.groupBox9.Controls.Add(this.numericMaximumFileCount);
            this.groupBox9.Location = new System.Drawing.Point(12, 348);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(215, 64);
            this.groupBox9.TabIndex = 5;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "IMAGE STORAGE SETTINGS";
            // 
            // radioSizeMode
            // 
            this.radioSizeMode.AutoSize = true;
            this.radioSizeMode.Location = new System.Drawing.Point(17, 39);
            this.radioSizeMode.Name = "radioSizeMode";
            this.radioSizeMode.Size = new System.Drawing.Size(85, 17);
            this.radioSizeMode.TabIndex = 4;
            this.radioSizeMode.Text = "SAVE UP TO";
            this.radioSizeMode.UseVisualStyleBackColor = true;
            this.radioSizeMode.CheckedChanged += new System.EventHandler(this.ImageStorageMode_CheckedChanged);
            // 
            // radioCountMode
            // 
            this.radioCountMode.AutoSize = true;
            this.radioCountMode.Checked = true;
            this.radioCountMode.Location = new System.Drawing.Point(17, 21);
            this.radioCountMode.Name = "radioCountMode";
            this.radioCountMode.Size = new System.Drawing.Size(85, 17);
            this.radioCountMode.TabIndex = 4;
            this.radioCountMode.TabStop = true;
            this.radioCountMode.Text = "SAVE UP TO";
            this.radioCountMode.UseVisualStyleBackColor = true;
            this.radioCountMode.CheckedChanged += new System.EventHandler(this.ImageStorageMode_CheckedChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(172, 42);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(19, 13);
            this.label12.TabIndex = 2;
            this.label12.Text = "MB";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(172, 23);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(37, 13);
            this.label13.TabIndex = 2;
            this.label13.Text = "FILES";
            // 
            // numericMaximumFileSize
            // 
            this.numericMaximumFileSize.Enabled = false;
            this.numericMaximumFileSize.ExponentBase = "";
            this.numericMaximumFileSize.Format = DGCustomControls.NumericUpDownImpl.FormatMode.None;
            this.numericMaximumFileSize.FormatString = "";
            this.numericMaximumFileSize.Location = new System.Drawing.Point(108, 38);
            this.numericMaximumFileSize.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericMaximumFileSize.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericMaximumFileSize.Name = "numericMaximumFileSize";
            this.numericMaximumFileSize.Size = new System.Drawing.Size(58, 20);
            this.numericMaximumFileSize.TabIndex = 3;
            this.numericMaximumFileSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericMaximumFileSize.UnitPlural = "";
            this.numericMaximumFileSize.UnitSingle = "";
            this.numericMaximumFileSize.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // numericMaximumFileCount
            // 
            this.numericMaximumFileCount.ExponentBase = "";
            this.numericMaximumFileCount.Format = DGCustomControls.NumericUpDownImpl.FormatMode.None;
            this.numericMaximumFileCount.FormatString = "";
            this.numericMaximumFileCount.Location = new System.Drawing.Point(108, 19);
            this.numericMaximumFileCount.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericMaximumFileCount.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericMaximumFileCount.Name = "numericMaximumFileCount";
            this.numericMaximumFileCount.Size = new System.Drawing.Size(58, 20);
            this.numericMaximumFileCount.TabIndex = 3;
            this.numericMaximumFileCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericMaximumFileCount.UnitPlural = "";
            this.numericMaximumFileCount.UnitSingle = "";
            this.numericMaximumFileCount.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // linkSave
            // 
            this.linkSave.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkSave.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkSave.Location = new System.Drawing.Point(244, 443);
            this.linkSave.Margin = new System.Windows.Forms.Padding(3, 0, 16, 0);
            this.linkSave.Name = "linkSave";
            this.linkSave.Size = new System.Drawing.Size(203, 15);
            this.linkSave.TabIndex = 3;
            this.linkSave.TabStop = true;
            this.linkSave.Text = "SAVE ROVER CONFIGURATION";
            this.linkSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.linkSave.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkSave_LinkClicked);
            // 
            // linkClose
            // 
            this.linkClose.AutoSize = true;
            this.linkClose.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkClose.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkClose.Location = new System.Drawing.Point(466, 443);
            this.linkClose.Name = "linkClose";
            this.linkClose.Size = new System.Drawing.Size(91, 15);
            this.linkClose.TabIndex = 3;
            this.linkClose.TabStop = true;
            this.linkClose.Text = "CLOSE WINDOW";
            this.linkClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.linkClose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkClose_LinkClicked);
            // 
            // linkClearAll
            // 
            this.linkClearAll.AutoSize = true;
            this.linkClearAll.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkClearAll.Location = new System.Drawing.Point(496, 274);
            this.linkClearAll.Name = "linkClearAll";
            this.linkClearAll.Size = new System.Drawing.Size(61, 13);
            this.linkClearAll.TabIndex = 3;
            this.linkClearAll.TabStop = true;
            this.linkClearAll.Text = "CLEAR ALL";
            this.linkClearAll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkClearAll_LinkClicked);
            // 
            // linkInvertAll
            // 
            this.linkInvertAll.AutoSize = true;
            this.linkInvertAll.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkInvertAll.Location = new System.Drawing.Point(418, 274);
            this.linkInvertAll.Margin = new System.Windows.Forms.Padding(3, 0, 8, 0);
            this.linkInvertAll.Name = "linkInvertAll";
            this.linkInvertAll.Size = new System.Drawing.Size(67, 13);
            this.linkInvertAll.TabIndex = 3;
            this.linkInvertAll.TabStop = true;
            this.linkInvertAll.Text = "INVERT ALL";
            this.linkInvertAll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkInvertAll_LinkClicked);
            // 
            // linkSelectAll
            // 
            this.linkSelectAll.AutoSize = true;
            this.linkSelectAll.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkSelectAll.Location = new System.Drawing.Point(340, 274);
            this.linkSelectAll.Margin = new System.Windows.Forms.Padding(3, 0, 8, 0);
            this.linkSelectAll.Name = "linkSelectAll";
            this.linkSelectAll.Size = new System.Drawing.Size(67, 13);
            this.linkSelectAll.TabIndex = 3;
            this.linkSelectAll.TabStop = true;
            this.linkSelectAll.Text = "SELECT ALL";
            this.linkSelectAll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkSelectAll_LinkClicked);
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.label15);
            this.groupBox10.Controls.Add(this.label14);
            this.groupBox10.Controls.Add(this.numericCommitInterval);
            this.groupBox10.Location = new System.Drawing.Point(287, 114);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(270, 45);
            this.groupBox10.TabIndex = 6;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "LOG COMMIT INTERVAL";
            // 
            // numericCommitInterval
            // 
            this.numericCommitInterval.ExponentBase = "";
            this.numericCommitInterval.Format = DGCustomControls.NumericUpDownImpl.FormatMode.None;
            this.numericCommitInterval.FormatString = "";
            this.numericCommitInterval.Location = new System.Drawing.Point(132, 19);
            this.numericCommitInterval.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericCommitInterval.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericCommitInterval.Name = "numericCommitInterval";
            this.numericCommitInterval.Size = new System.Drawing.Size(58, 20);
            this.numericCommitInterval.TabIndex = 3;
            this.numericCommitInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericCommitInterval.UnitPlural = "";
            this.numericCommitInterval.UnitSingle = "";
            this.numericCommitInterval.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(35, 22);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(91, 13);
            this.label14.TabIndex = 2;
            this.label14.Text = "SAVE LOG EVERY";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(196, 22);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(49, 13);
            this.label15.TabIndex = 2;
            this.label15.Text = "ENTRIES";
            // 
            // FormConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 467);
            this.Controls.Add(this.groupBox10);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.linkClose);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.linkSave);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.linkSelectImageOutputLocation);
            this.Controls.Add(this.linkSelectAll);
            this.Controls.Add(this.linkInvertAll);
            this.Controls.Add(this.linkClearAll);
            this.Controls.Add(this.linkSelectExportLogLocation);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormConfiguration";
            this.Text = "Rover Control Configuration";
            this.Load += new System.EventHandler(this.FormConfiguration_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericListenPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericTargetPort)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericControllerInterval)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericNetworkInterval)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericTimedCaptureInterval)).EndInit();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericVideoCaptureRate)).EndInit();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericMaximumFileSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMaximumFileCount)).EndInit();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericCommitInterval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private DGCustomControls.NumericUpDownImpl numericListenPort;
        private DGCustomControls.NumericUpDownImpl numericTargetPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textRoverIPAddress;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private DGCustomControls.NumericUpDownImpl numericControllerInterval;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private DGCustomControls.NumericUpDownImpl numericNetworkInterval;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textExportLogLocation;
        private System.Windows.Forms.LinkLabel linkSelectExportLogLocation;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox checkIncludeMotorInputs;
        private System.Windows.Forms.CheckBox checkIncludeMotorEncoders;
        private System.Windows.Forms.CheckBox checkIncludeMotorSetpoints;
        private System.Windows.Forms.CheckBox checkIncludeMotorCurrents;
        private System.Windows.Forms.CheckBox checkIncludeGpsCoordinates;
        private System.Windows.Forms.CheckBox checkIncludeIRDistance;
        private System.Windows.Forms.CheckBox checkIncludeServoSetpoints;
        private System.Windows.Forms.CheckBox checkIncludeServoInputs;
        private System.Windows.Forms.CheckBox checkIncludeAlarmStates;
        private System.Windows.Forms.CheckBox checkIncludeCaptureMode;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox textImageOutputLocation;
        private System.Windows.Forms.LinkLabel linkSelectImageOutputLocation;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private DGCustomControls.NumericUpDownImpl numericTimedCaptureInterval;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private DGCustomControls.NumericUpDownImpl numericVideoCaptureRate;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.RadioButton radioSizeMode;
        private System.Windows.Forms.RadioButton radioCountMode;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private DGCustomControls.NumericUpDownImpl numericMaximumFileSize;
        private DGCustomControls.NumericUpDownImpl numericMaximumFileCount;
        private System.Windows.Forms.LinkLabel linkSave;
        private System.Windows.Forms.LinkLabel linkClose;
        private System.Windows.Forms.LinkLabel linkClearAll;
        private System.Windows.Forms.LinkLabel linkInvertAll;
        private System.Windows.Forms.LinkLabel linkSelectAll;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private DGCustomControls.NumericUpDownImpl numericCommitInterval;
    }
}