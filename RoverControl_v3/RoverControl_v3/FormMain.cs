using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RoverControl_v3
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            // required for designer support
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            // a dialogresult
            DialogResult    dialog_result       = DialogResult.None;
            // a controller found flag
            Boolean         controller_found    = false;
            // loop while a controller cannot be found
            while (!(controller_found = ControllerMonitor.Initialize()))
            {
                // warn the user 
                dialog_result   = MessageBox.Show("A controller could not be found! Please connect a wired XBOX 360 controller to the computer!\n\n" +
                                                  "Click 'Retry' to try again or click 'Cancel' to close the program.",
                                                  "Rover Control", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                // determine the result
                if (dialog_result != DialogResult.Retry)
                {
                    // the user wants to cancel
                    // break out of the loop
                    break;
                }
            }
            // determine if a controller was found
            switch (controller_found)
            {
                case false:
                    // a controller could not be found
                    // close the form
                    this.Close();
                    // break out
                    break;
            }
            // initialize the log settings
            LogSettings.Initialize();
            // initialize the log controller
            LogController.Initialize();
            // initialize the rover settings
            RoverSettings.Initialize();
            // initialize the rover controller
            RoverController.Initialize();
            // initialize the network settings
            NetworkSettings.Initialize();
            // initialize the network controller
            NetworkController.Initialize(NetworkSettings.TargetPort, NetworkSettings.ListenPort);

        }
        private Boolean SearchArray(Byte[] block, Byte high_byte, Byte low_byte)
        {
            // the result
            Boolean result = false;
            // look through the array
            for (int index = 0; index < block.Length; index++)
            {
                // determine if this location holds the desired flag
                if (block[index] == low_byte && block[index - 1] == high_byte)
                {
                    // it does
                    // save the result
                    result = true;
                    // break out
                    break;
                }
            }
            // return the result
            return result;
        }

        private void menuControlInterface_Click(object sender, EventArgs e)
        {
            // create the control interface form
            FormControlInterface    interface_form  = new FormControlInterface();
            // create the controller status form
            FormControllerStatus    status_form     = new FormControllerStatus();
            // the annunciator panel
            FormAnnunciatorPanel    alarm_form      = new FormAnnunciatorPanel();
            // set the properties of the forms
            interface_form.MdiParent                = this;
            status_form.MdiParent                   = this;
            alarm_form.MdiParent                    = this;
            // show the forms
            interface_form.Show();
            status_form.Show();
            alarm_form.Show();
        }

        private void menuSettings_Click(object sender, EventArgs e)
        {
            // create a new configuration form
            FormConfiguration form = new FormConfiguration();
            // set the properties of the form
            form.MdiParent = this;
            // show the form
            form.Show();
        }
    }
}
