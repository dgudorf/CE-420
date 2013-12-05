using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace RoverReceiver
{
    public partial class FormMain : Form
    {
        private AlarmCode AlarmState    = AlarmCode.None;
        private UdpClient TxClient      = null;
        private UdpClient RxClient      = null;

        public FormMain()
        {
            InitializeComponent();
        }

        private void timerUpdate_Tick(object sender, EventArgs e)
        {
            // the byte buffers
            Byte[]      motor_update        = new Byte[1 + 8 + 8 + 8 + 8 + 8 + 8];
            Byte[]      status_update       = new Byte[1 + 8 + 8 + 8];
            Byte[]      alarm_update        = new Byte[1 + 4];
            IPEndPoint  target_end_point    = new IPEndPoint(IPAddress.Parse(textIPAddress.Text), Convert.ToInt32(numericTargetPort.Value));
            // save the motor update components
            motor_update[0]     = ((Byte)('m'));
            Array.Copy(BitConverter.GetBytes(Convert.ToDouble(numericLeftCurrent.Value)), 0, motor_update, 1, 8);
            Array.Copy(BitConverter.GetBytes(Convert.ToDouble(numericRightCurrent.Value)), 0, motor_update, 9, 8);
            Array.Copy(BitConverter.GetBytes(Convert.ToInt64(numericLeftForwardTicks.Value)), 0, motor_update, 17, 8);
            Array.Copy(BitConverter.GetBytes(Convert.ToInt64(numericLeftReverseTicks.Value)), 0, motor_update, 25, 8);
            Array.Copy(BitConverter.GetBytes(Convert.ToInt64(numericRightForwardTicks.Value)), 0, motor_update, 33, 8);
            Array.Copy(BitConverter.GetBytes(Convert.ToInt64(numericRightReverseTicks.Value)), 0, motor_update, 41, 8);
            // save the status update components
            status_update[0]    = ((Byte)('g'));
            Array.Copy(BitConverter.GetBytes(Convert.ToDouble(numericDistance.Value)), 0, status_update, 1, 8);
            Array.Copy(BitConverter.GetBytes(Convert.ToDouble(numericLatitude.Value)), 0, status_update, 9, 8);
            Array.Copy(BitConverter.GetBytes(Convert.ToDouble(numericLongitude.Value)), 0, status_update, 17, 8);
            // save the alarm update components
            alarm_update[0]     = ((Byte)('a'));
            Array.Copy(BitConverter.GetBytes(Convert.ToUInt32(AlarmState)), 0, alarm_update, 1, 4);
            // determine if the client is connected
            if (TxClient != null)
            {
                // it is
                // print the arrays
                foreach (Byte value in motor_update)    { Debug.Write(String.Format("{0:X2}", value)); }
                Debug.WriteLine("");
                foreach (Byte value in status_update)   { Debug.Write(String.Format("{0:X2}", value)); }
                Debug.WriteLine("");
                foreach (Byte value in alarm_update)    { Debug.Write(String.Format("{0:X2}", value)); }
                Debug.WriteLine("");
                // send the arrays
                Debug.WriteLine(TxClient.Send(motor_update, motor_update.Length));
                Debug.WriteLine(TxClient.Send(status_update, status_update.Length));
                Debug.WriteLine(TxClient.Send(alarm_update, alarm_update.Length));
            }
        }
        private void timerPoll_Tick(object sender, EventArgs e)
        {
            Byte[] incoming_data = null;
            IPEndPoint listen_end_point = new IPEndPoint(IPAddress.Any, 0);
            // determine if the rx client is available
            if (RxClient != null)
            {
                // it is
                // determine if there is any data
                if (RxClient.Available > 1)
                {
                    // there is
                    labelStatus.Text = RxClient.Available.ToString();
                    // get a packet
                    incoming_data = RxClient.Receive(ref listen_end_point);
                    // determine if the packet is valid
                    if (incoming_data != null)
                    {
                        // it is
                        // determine the type of packet
                        switch ((Char)(incoming_data[0]))
                        {
                            case 'M':
                                // this is a motor control packet
                                // get the left motor power
                                numericLeftPower.Value  = (incoming_data[2] == 0xFF) ? incoming_data[1] : -incoming_data[1];
                                // get the right motor power
                                numericRightPower.Value = (incoming_data[4] == 0xFF) ? incoming_data[3] : -incoming_data[3];
                                // break out
                                break;
                            case 'S':
                                // this is a servo control packet
                                // get the pan servo angle
                                numericPanAngle.Value   = incoming_data[1];
                                // get the tilt servo angle
                                numericTiltAngle.Value  = incoming_data[2];
                                // break out
                                break;
                            case 'C':
                                // this is a camera control packet
                                // break out
                                break;
                        }
                    }
                }
            }
        }

        private void linkSelectImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // create an openfiledialog
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                // set the properties of the dialog
                dialog.Title = "Select Image...";
                dialog.Filter = "JPEG Images (*.jpg, *.jpeg)|*.jpg;*.jpeg";
                // show the dialog
                switch (dialog.ShowDialog())
                {
                    case DialogResult.OK:
                        // the user selected an image
                        // save the path
                        textImage.Text = dialog.FileName;
                        // break out
                        break;
                    default:
                        // the user did not select an image
                        // do nothing
                        // break out
                        break;
                }
            }
        }

        private void linkSendImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // the target end point
            IPEndPoint end_point = new IPEndPoint(IPAddress.Parse(textIPAddress.Text), Convert.ToInt32(numericTargetPort.Value));
            // read the image
            Byte[] image_data   = null;
            // the packet data
            Byte[] packet       = null;
            // create a binaryreader
            using (BinaryReader reader = new BinaryReader(new FileStream(textImage.Text, FileMode.Open, FileAccess.Read, FileShare.Read)))
            {
                // get the image data
                image_data = reader.ReadBytes(Convert.ToInt32(reader.BaseStream.Length));
            }
            // determine if the client is connected
            if (TxClient != null)
            {
                // it is
                // loop
                for (int index = 0; index < image_data.Length; index += 512)
                {
                    // create the packet
                    packet      = new Byte[513];
                    // set the packet code
                    packet[0]   = (Byte)('i');
                    // copy the image data to the packet
                    Array.Copy(image_data, index, packet, 1, Math.Min(512, image_data.Length - index));
                    // send this packet
                    Debug.WriteLine(TxClient.Send(packet, packet.Length));
                }
            }
        }

        private void UpdateFlags(Boolean flag_state, AlarmCode flag_value)
        {
            switch (flag_state)
            {
                case true:
                    switch (AlarmState.HasFlag(flag_value))
                    {
                        case true:
                            // do nothing
                            // break out
                            break;
                        case false:
                            // update the alarm state
                            AlarmState |= flag_value;
                            // break out
                            break;
                    }
                    // break out
                    break;
                case false:
                    switch (AlarmState.HasFlag(flag_value))
                    {
                        case true:
                            // remove the alarm state
                            AlarmState -= flag_value;
                            // break out
                            break;
                        case false:
                            // do nothing
                            // break out
                            break;
                    }
                    // break out
                    break;  
            }
        }

        private void linkToggleConnection_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // determine if there is already a transmitting client
            if (TxClient != null && TxClient.Client != null)
            {
                // there is
                // disable the timers
                timerPoll.Enabled = false;
                timerUpdate.Enabled = false;
                // close the client
                TxClient.Close();
                // destroy the client
                TxClient  = null;
            }
            // determine if there is already a receiving client
            if (RxClient != null && RxClient.Client != null)
            {
                // there is
                // disable the timer
                timerPoll.Enabled = false;
                timerUpdate.Enabled = false;
                // close the client
                RxClient.Close();
                // destroy the client
                RxClient = null;
            }
            // create new clients
            TxClient                    = new UdpClient(Convert.ToInt32(numericTargetPort.Value));
            RxClient                    = new UdpClient(Convert.ToInt32(numericListenPort.Value));
            // connect the client
            TxClient.Connect(new IPEndPoint(IPAddress.Parse(textIPAddress.Text), 
                                            Convert.ToInt32(numericTargetPort.Value)));
            // enable the timers
            timerPoll.Enabled = true;
            timerUpdate.Enabled = true;
        }

        private void checkCommunicationFailure_CheckedChanged(object sender, EventArgs e)
        {
            UpdateFlags((sender as CheckBox).Checked, AlarmCode.CommunicationFailure);
            Debug.WriteLine(Convert.ToUInt32(AlarmState) + " : " + AlarmState.ToString());
        }

        private void checkRearLeftPowerCutoff_CheckedChanged(object sender, EventArgs e)
        {
            UpdateFlags((sender as CheckBox).Checked, AlarmCode.RearLeftPowerCutoff);
            Debug.WriteLine(Convert.ToUInt32(AlarmState) + " : " + AlarmState.ToString());
        }

        private void checkFrontRightPowerCutoff_CheckedChanged(object sender, EventArgs e)
        {
            UpdateFlags((sender as CheckBox).Checked, AlarmCode.FrontRightPowerCutoff);
            Debug.WriteLine(Convert.ToUInt32(AlarmState) + " : " + AlarmState.ToString());
        }

        private void checkFrontLeftPowerCutoff_CheckedChanged(object sender, EventArgs e)
        {
            UpdateFlags((sender as CheckBox).Checked, AlarmCode.FrontLeftPowerCutoff);
            Debug.WriteLine(Convert.ToUInt32(AlarmState) + " : " + AlarmState.ToString());
        }

        private void checkCollisionWarningFront_CheckedChanged(object sender, EventArgs e)
        {
            UpdateFlags((sender as CheckBox).Checked, AlarmCode.CollisionWarningFront);
            Debug.WriteLine(Convert.ToUInt32(AlarmState) + " : " + AlarmState.ToString());
        }

        private void checkCollisionImminentFront_CheckedChanged(object sender, EventArgs e)
        {
            UpdateFlags((sender as CheckBox).Checked, AlarmCode.CollisionImminentFront);
            Debug.WriteLine(Convert.ToUInt32(AlarmState) + " : " + AlarmState.ToString());
        }

        private void checkStallRight_CheckedChanged(object sender, EventArgs e)
        {
            UpdateFlags((sender as CheckBox).Checked, AlarmCode.StallRight);
            Debug.WriteLine(Convert.ToUInt32(AlarmState) + " : " + AlarmState.ToString());
        }

        private void checkStallLeft_CheckedChanged(object sender, EventArgs e)
        {
            UpdateFlags((sender as CheckBox).Checked, AlarmCode.StallLeft);
            Debug.WriteLine(Convert.ToUInt32(AlarmState) + " : " + AlarmState.ToString());
        }

        private void checkOvercurrentImminentRight_CheckedChanged(object sender, EventArgs e)
        {
            UpdateFlags((sender as CheckBox).Checked, AlarmCode.OvercurrentImminentRight);
            Debug.WriteLine(Convert.ToUInt32(AlarmState) + " : " + AlarmState.ToString());
        }

        private void checkOvercurrentImminentLeft_CheckedChanged(object sender, EventArgs e)
        {
            UpdateFlags((sender as CheckBox).Checked, AlarmCode.OvercurrentImminentLeft);
            Debug.WriteLine(Convert.ToUInt32(AlarmState) + " : " + AlarmState.ToString());
        }

        private void checkOvercurrentRight_CheckedChanged(object sender, EventArgs e)
        {
            UpdateFlags((sender as CheckBox).Checked, AlarmCode.OvercurrentRight);
            Debug.WriteLine(Convert.ToUInt32(AlarmState) + " : " + AlarmState.ToString());
        }

        private void checkOvercurrentLeft_CheckedChanged(object sender, EventArgs e)
        {
            UpdateFlags((sender as CheckBox).Checked, AlarmCode.OvercurrentLeft);
            Debug.WriteLine(Convert.ToUInt32(AlarmState) + " : " + AlarmState.ToString());
        }

        private void checkOvercurrentWarningRight_CheckedChanged(object sender, EventArgs e)
        {
            UpdateFlags((sender as CheckBox).Checked, AlarmCode.OvercurrentWarningRight);
            Debug.WriteLine(Convert.ToUInt32(AlarmState) + " : " + AlarmState.ToString());
        }

        private void checkOvercurrentWarningLeft_CheckedChanged(object sender, EventArgs e)
        {
            UpdateFlags((sender as CheckBox).Checked, AlarmCode.OvercurrentWarningLeft);
            Debug.WriteLine(Convert.ToUInt32(AlarmState) + " : " + AlarmState.ToString());
        }

        private void checkCollisionAvoidanceActive_CheckedChanged(object sender, EventArgs e)
        {
            UpdateFlags((sender as CheckBox).Checked, AlarmCode.CollisionAvoidanceActive);
            Debug.WriteLine(Convert.ToUInt32(AlarmState) + " : " + AlarmState.ToString());
        }

        private void checkRoverRun_CheckedChanged(object sender, EventArgs e)
        {
            UpdateFlags((sender as CheckBox).Checked, AlarmCode.RoverRun);
            Debug.WriteLine(Convert.ToUInt32(AlarmState) + " : " + AlarmState.ToString());
        }

        private void checkRoverError_CheckedChanged(object sender, EventArgs e)
        {
            UpdateFlags((sender as CheckBox).Checked, AlarmCode.RoverError);
            Debug.WriteLine(Convert.ToUInt32(AlarmState) + " : " + AlarmState.ToString());
        }

        private void checkRoverIdle_CheckedChanged(object sender, EventArgs e)
        {
            UpdateFlags((sender as CheckBox).Checked, AlarmCode.RoverIdle);
            Debug.WriteLine(Convert.ToUInt32(AlarmState) + " : " + AlarmState.ToString());
        }

        private void checkRoverOff_CheckedChanged(object sender, EventArgs e)
        {
            UpdateFlags((sender as CheckBox).Checked, AlarmCode.RoverOff);
            Debug.WriteLine(Convert.ToUInt32(AlarmState) + " : " + AlarmState.ToString());
        }

        private void checkHighVoltageUndervolt_CheckedChanged(object sender, EventArgs e)
        {
            UpdateFlags((sender as CheckBox).Checked, AlarmCode.HighVoltageBusUndervolt);
            Debug.WriteLine(Convert.ToUInt32(AlarmState) + " : " + AlarmState.ToString());
        }

        private void checkLowVoltageUndervolt_CheckedChanged(object sender, EventArgs e)
        {
            UpdateFlags((sender as CheckBox).Checked, AlarmCode.LowVoltageBusUndervolt);
            Debug.WriteLine(Convert.ToUInt32(AlarmState) + " : " + AlarmState.ToString());
        }

        private void checkBatteryFailure_CheckedChanged(object sender, EventArgs e)
        {
            UpdateFlags((sender as CheckBox).Checked, AlarmCode.BatteryFailure);
            Debug.WriteLine(Convert.ToUInt32(AlarmState) + " : " + AlarmState.ToString());
        }

        private void checkRearRightPowerCutoff_CheckedChanged(object sender, EventArgs e)
        {
            UpdateFlags((sender as CheckBox).Checked, AlarmCode.RearRightPowerCutoff);
            Debug.WriteLine(Convert.ToUInt32(AlarmState) + " : " + AlarmState.ToString());
        }
    }
    [Flags]
    public enum AlarmCode
    {
        None                        = 0x00000000,
        CommunicationFailure        = 0x00000001,
        BatteryFailure              = 0x00000002,
        OvercurrentLeft             = 0x00000004,
        OvercurrentRight            = 0x00000008,
        HighVoltageBusUndervolt     = 0x00000010,
        LowVoltageBusUndervolt      = 0x00000020,
        OvercurrentImminentLeft     = 0x00000040,
        OvercurrentImminentRight    = 0x00000080,
        StallLeft                   = 0x00000100,
        StallRight                  = 0x00000200,
        CollisionImminentFront      = 0x00000400,
        OvercurrentWarningLeft      = 0x00000800,
        OvercurrentWarningRight     = 0x00001000,
        CollisionWarningFront       = 0x00002000,
        FrontLeftPowerCutoff        = 0x00004000,
        FrontRightPowerCutoff       = 0x00008000,
        RearLeftPowerCutoff         = 0x00010000,
        RearRightPowerCutoff        = 0x00020000,
        CollisionAvoidanceActive    = 0x00040000,
        RoverOff                    = 0x00080000,
        RoverIdle                   = 0x00100000,
        RoverError                  = 0x00200000,
        RoverRun                    = 0x00400000,
    }
}
