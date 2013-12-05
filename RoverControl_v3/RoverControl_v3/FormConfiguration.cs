using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace RoverControl_v3
{
    public partial class FormConfiguration : Form
    {
        // a list of checkboxes
        List<CheckBox> IncludeControls = new List<CheckBox>();

        public FormConfiguration()
        {
            // required for designer support
            InitializeComponent();
        }

        private void FormConfiguration_Load(object sender, EventArgs e)
        {
            // add the checkboxes
            IncludeControls.Add(checkIncludeAlarmStates);
            IncludeControls.Add(checkIncludeCaptureMode);
            IncludeControls.Add(checkIncludeGpsCoordinates);
            IncludeControls.Add(checkIncludeIRDistance);
            IncludeControls.Add(checkIncludeMotorCurrents);
            IncludeControls.Add(checkIncludeMotorEncoders);
            IncludeControls.Add(checkIncludeMotorInputs);
            IncludeControls.Add(checkIncludeMotorSetpoints);
            IncludeControls.Add(checkIncludeServoInputs);
            IncludeControls.Add(checkIncludeServoSetpoints);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void linkClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void LogInclude_CheckedChanged(object sender, EventArgs e)
        {
            // get the checkbox which raised the event
            CheckBox    control     = sender as CheckBox;
            // determine the checked state of the checkbox
            control.ForeColor       = (control.Checked) 
                                        ? Color.FromArgb(0, 200, 0) 
                                        : Color.FromArgb(200, 0, 0);
        }

        private void linkSelectAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // iterate through the include checkboxes
            IncludeControls.ForEach(entity => entity.Checked = true);
        }

        private void linkInvertAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // iterate through the include checkboxes
            IncludeControls.ForEach(entity => entity.Checked = !entity.Checked);
        }

        private void linkClearAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // iterate through the include checkboxes
            IncludeControls.ForEach(entity => entity.Checked = false);
        }

        private void linkSelectExportLogLocation_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // create a folderbrowserdialog
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                // set the properties of the dialog
                dialog.Description = "Select a folder to store rover log files in...";
                // show the dialog
                switch (dialog.ShowDialog())
                {
                    case DialogResult.OK:
                        // the user selected a folder
                        // save the selected path
                        textExportLogLocation.Text = dialog.SelectedPath;
                        // break out
                        break;
                    default:
                        // the user did not select a folder
                        // do nothing
                        // break out
                        break;
                }
            }
        }

        private void linkSelectImageOutputLocation_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // create a folderbrowserdialog
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                // set the properties of the dialog
                dialog.Description = "Select a folder to store rover image files in...";
                // show the dialog
                switch (dialog.ShowDialog())
                {
                    case DialogResult.OK:
                        // the user selected a folder
                        // save the selected path
                        textImageOutputLocation.Text = dialog.SelectedPath;
                        // break out
                        break;
                    default:
                        // the user did not select a folder
                        // do nothing
                        // break out
                        break;
                }
            }
        }

        private void ImageStorageMode_CheckedChanged(object sender, EventArgs e)
        {
            // set the state of the image storage controls
            numericMaximumFileCount.Enabled = radioCountMode.Checked;
            numericMaximumFileSize.Enabled  = radioSizeMode.Checked;
        }

        private void textExportLogLocation_TextChanged(object sender, EventArgs e)
        {
            // the textbox
            TextBox control = sender as TextBox;
            // determine if the textbox contains anything
            if (String.IsNullOrWhiteSpace(control.Text))
            {
                // there is nothing in the textbox
                // set the colors of the textbox
                control.ForeColor = Color.Black;
                control.BackColor = Color.FromArgb(255, 255, 255);
            }
            else
            {
                // there is something in the textbox
                // determine if the textbox contains a valid folder path
                if (Directory.Exists(control.Text))
                {
                    // the textbox contains a valid path
                    // set the colors of the textbox
                    control.ForeColor = Color.White;
                    control.BackColor = Color.FromArgb(0, 200, 0);
                }
                else
                {
                    // the textbox does not contain a valid path
                    // set the colors of the textbox
                    control.ForeColor = Color.White;
                    control.BackColor = Color.FromArgb(200, 0, 0);
                }
            }
        }

        private void textImageOutputLocation_TextChanged(object sender, EventArgs e)
        {
            // the textbox
            TextBox control = sender as TextBox;
            // determine if the textbox contains anything
            if (String.IsNullOrWhiteSpace(control.Text))
            {
                // there is nothing in the textbox
                // set the colors of the textbox
                control.ForeColor = Color.Black;
                control.BackColor = Color.FromArgb(255, 255, 255);
            }
            else
            {
                // there is something in the textbox
                // determine if the textbox contains a valid folder path
                if (Directory.Exists(control.Text))
                {
                    // the textbox contains a valid path
                    // set the colors of the textbox
                    control.ForeColor = Color.White;
                    control.BackColor = Color.FromArgb(0, 200, 0);
                }
                else
                {
                    // the textbox does not contain a valid path
                    // set the colors of the textbox
                    control.ForeColor = Color.White;
                    control.BackColor = Color.FromArgb(200, 0, 0);
                }
            }
        }

        private void linkSave_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // an error message
            String error_message = String.Empty;
            // determine if the settings are valid
            switch (CheckInputs(out error_message))
            {
                case true:
                    // the inputs are valid
                    // save the settings
                    // break out
                    break;
                case false:
                    // the inputs are invalid
                    // warn the user
                    MessageBox.Show(error_message, "Rover Control", 
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // break out
                    break;
            }
        }
        private void SaveSettings()
        {
            /* save the network settings    */
            NetworkSettings.RoverIPAddress      = IPAddress.Parse(textRoverIPAddress.Text);
            NetworkSettings.TargetPort          = Convert.ToInt32(numericTargetPort.Value);
            NetworkSettings.ListenPort          = Convert.ToInt32(numericListenPort.Value);
            /* save the rover settings      */
            RoverSettings.ControllerInterval    = Convert.ToInt32(numericControllerInterval.Value);
            RoverSettings.NetworkInterval       = Convert.ToInt32(numericNetworkInterval.Value);
            RoverSettings.TimedCaptureInterval  = Convert.ToInt32(numericTimedCaptureInterval.Value);
            RoverSettings.VideoCaptureRate      = Convert.ToInt32(numericVideoCaptureRate.Value);
            RoverSettings.MaximumFileCount      = Convert.ToInt32(numericMaximumFileCount.Value);
            RoverSettings.MaximumFileSize       = Convert.ToInt32(numericMaximumFileSize.Value);
            RoverSettings.ImageOutputLocation   = textImageOutputLocation.Text;
            RoverSettings.UseMaximumFileCount   = radioCountMode.Checked;
            RoverSettings.UseMaximumFileSize    = radioSizeMode.Checked;
            /* save the log settings        */
            LogSettings.OutputFolder            = textExportLogLocation.Text;
            LogSettings.CommitInterval          = numericCommitInterval.ToInt32();
            LogSettings.LogFields               = GetLogFields();

        }
        private LogFields GetLogFields()
        {
            // the result
            LogFields result = LogFields.None;
            /* get the log field flags */
            result |= checkIncludeAlarmStates.Checked       
                        ? LogFields.AlarmStates         
                        : LogFields.None;
            result |= checkIncludeCaptureMode.Checked
                        ? LogFields.CaptureMode
                        : LogFields.None;
            result |= checkIncludeGpsCoordinates.Checked
                        ? LogFields.GpsCoordinates
                        : LogFields.None;
            result |= checkIncludeIRDistance.Checked
                        ? LogFields.IRDistance
                        : LogFields.None;
            result |= checkIncludeMotorCurrents.Checked
                        ? LogFields.MotorCurrents
                        : LogFields.None;
            result |= checkIncludeMotorEncoders.Checked
                        ? LogFields.MotorEncoders
                        : LogFields.None;
            result |= checkIncludeMotorInputs.Checked
                        ? LogFields.MotorInputs
                        : LogFields.None;
            result |= checkIncludeMotorSetpoints.Checked
                        ? LogFields.MotorSetpoints
                        : LogFields.None;
            result |= checkIncludeServoInputs.Checked
                        ? LogFields.ServoInputs
                        : LogFields.None;
            result |= checkIncludeServoSetpoints.Checked
                        ? LogFields.ServoSetpoints
                        : LogFields.None;
            // return the result
            return result;
        }
        private Boolean CheckInputs(out String error_message)
        {
            // an ipaddress
            IPAddress   address = IPAddress.None;
            // the result
            Boolean     result  = false;
            // determine if the inputs are valid
            if (String.IsNullOrWhiteSpace(textRoverIPAddress.Text) == true)
            {
                // the ip address is invalid
                // save the error message
                error_message   = "The rover's IP address cannot be left blank.";
                // save the result
                result          = false;
            }
            else
            if (IPAddress.TryParse(textRoverIPAddress.Text, out address) == false)
            {
                // the ip address is invalid
                // save the error message
                error_message   = "The rover's IP address is invalid.";
                // save the result
                result          = false;
            }
            else
            if (String.IsNullOrWhiteSpace(textExportLogLocation.Text) == true)
            {
                // the export log location is invalid
                // save the error message
                error_message   = "The export log location cannot be left blank.";
                // save the result
                result          = false;
            }
            else
            if (String.IsNullOrWhiteSpace(textImageOutputLocation.Text) == true)
            {
                // the output image location is invalid
                // save the error message
                error_message   = "The image output location cannot be left blank.";
                // save the result
                result          = false;
            }
            else
            if (Directory.Exists(textExportLogLocation.Text) == false)
            {
                // the export log location is invalid
                // save the error message
                error_message   = "The export log location is invalid.";
                // save the result
                result          = false;
            }
            else
            if (Directory.Exists(textImageOutputLocation.Text) == false)
            {
                // the output image location is invalid
                // save the error message
                error_message   = "The image output location is invalid.";
                // save the result
                result          = false;
            }
            else
            {
                // the inputs are valid
                // save the error message
                error_message   = String.Empty;
                // save the result
                result          = true;
            }
            // return the result
            return result;
        }
    }
}
