using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace RoverControl_v3
{
    public static class NetworkController
    {
        private const   Int32       CodeSize                = 1;
        private const   Int32       MotorGetBodySize        = 48;
        private const   Int32       ImageGetBodySize        = 512;
        private const   Int32       CameraStatusGetBodySize = 4;
        private const   Int32       StatusGetBodySize       = 24;
        private const   Int32       AlarmGetBodySize        = 4;
        private static  UdpClient   TxClient                = null;
        private static  UdpClient   RxClient                = null;
        private static  IPEndPoint  TargetEndPoint          = null;
        private static  IPEndPoint  ListenEndPoint          = null;
        private static  IPEndPoint  RemoteEndPoint          = null;
        private static  Int32       TargetPort              = 0;
        private static  Int32       ListenPort              = 0;
        private static  Timer       PollingTimer            = null;
        private static  Timer       UpdateTimer             = null;

        public static event EventHandler PacketReceived;
        public static event EventHandler PacketTransmitted;
        
        public static void Initialize(IPAddress address, Int32 target_port, Int32 listen_port)
        {
            // save the target port
            TargetPort                      = target_port;
            // save the listen port
            ListenPort                      = listen_port;
            // create a new endpoint for the client to send to
            TargetEndPoint                  = new IPEndPoint(address, target_port);
            // create a new endpoint for the client to listen to
            ListenEndPoint                  = new IPEndPoint(IPAddress.Any, 0);
            // initialize the polling timer
            PollingTimer                    = new Timer();
            // initialize the update timer
            UpdateTimer                     = new Timer();
            // attach event handlers to the timers
            PollingTimer.Tick              += PollingTimer_Tick;
            UpdateTimer.Tick               += UpdateTimer_Tick;
            // set the properties of the timers
            PollingTimer.Interval           = 100;
            UpdateTimer.Interval            = 100;
            PollingTimer.Enabled            = true;
            UpdateTimer.Enabled             = true;
            // create new clients
            TxClient                        = new UdpClient(TargetPort);
            RxClient                        = new UdpClient(ListenPort);
            // connect to the target endpoint
            TxClient.Connect(TargetEndPoint);
        }

        static void UpdateTimer_Tick(object sender, EventArgs e)
        {
            // determine if there is a transmit client
            if (TxClient != null)
            {
                // there is
                // send the outgoing packets
                SendOutgoingPackets();
            }
        }

        private static void PollingTimer_Tick(object sender, EventArgs e)
        {
            // a packet
            Byte[] packet = null;
            IPEndPoint remote_end_point = null;
            // determine if there is a receive client
            if (RxClient != null)
            {
                // there is
                // determine if there is any available data
                if (RxClient.Available > 0)
                {
                    // there is
                    // receive the packet
                    packet = RxClient.Receive(ref remote_end_point);
                    // determine if there is a packet
                    if (packet != null)
                    {
                        // process the packet
                        ProcessIncomingPacket(packet);
                    }
                }
            }
        }
        
        public static Boolean SendOutgoingPackets()
        {
            // the result
            Boolean result          = false;
            // the motor control packet
            Byte[]  motor_packet    = null;
            Byte[]  servo_packet    = null;
            Byte[]  camera_packet   = null;
            // create the motor packet
            motor_packet    = new Byte[] { (Byte)(PacketCodes.MotorControlPacket), 
                                           RoverController.LeftMotorPower, 
                                           RoverController.LeftMotorDirection ? (Byte)(0xFF) : (Byte)(0x00),
                                           RoverController.RightMotorPower,
                                           RoverController.RightMotorDirection ? (Byte)(0xFF) : (Byte)(0x00) };
            // send the motor packet
            TxClient.Send(motor_packet, motor_packet.Length);
            // save the motor setpoints
            RoverController.LeftMotorPowerSetpoint      = RoverController.LeftMotorPower;
            RoverController.LeftMotorDirectionSetpoint  = RoverController.LeftMotorDirection;
            RoverController.RightMotorPowerSetpoint     = RoverController.RightMotorPower;
            RoverController.RightMotorDirectionSetpoint = RoverController.RightMotorDirection;
            // create the servo packet
            servo_packet    = new Byte[] { (Byte)(PacketCodes.ServoControlPacket),
                                           RoverController.PanServoAngle,
                                           RoverController.TiltServoAngle };
            // send the motor packet
            TxClient.Send(servo_packet, servo_packet.Length);
            // save the servo setpoints
            RoverController.PanServoAngleSetpoint       = RoverController.PanServoAngle;
            RoverController.TiltServoAngleSetpoint      = RoverController.TiltServoAngle;
            // create the camera packet
            camera_packet   = new Byte[] { (Byte)(PacketCodes.CameraControlPacket),
                                           (Byte)(RoverController.CaptureMode) };
            // send the motor packet
            TxClient.Send(camera_packet, camera_packet.Length);
            // determine if the packet transmitted event has a handler
            if (PacketTransmitted != null)
            {
                // it does
                // raise the event
                PacketTransmitted(new Object(), new EventArgs());
            }
            // return the result
            return result;
        }

        public static Boolean ProcessIncomingPacket(Byte[] packet)
        {
            // the result
            Boolean result          = false;
            // an array of bytes
            Byte[]  array           = null;
            // return if there is no data in the packet
            if (packet.Length <= 1) { return (result = false); }
            // determine the packet type
            switch ((PacketCodes)(packet[0]))
            {
                case PacketCodes.MotorStatusPacket:
                    // this is a motor get packet
                    // determine if the packet is the correct length
                    if (packet.Length == (CodeSize + MotorGetBodySize))
                    {
                        // it is
                        // save the result
                        result = true;
                        /* break apart the packet */
                        // save the left motor current
                        RoverController.LeftMotorCurrent        = Tools.MapDoubleToUInt16(BitConverter.ToDouble(packet, 1), 0.000, 5.000, UInt16.MinValue, UInt16.MaxValue, 0);
                        // save the right motor current
                        RoverController.RightMotorCurrent       = Tools.MapDoubleToUInt16(BitConverter.ToDouble(packet, 9), 0.000, 5.000, UInt16.MinValue, UInt16.MaxValue, 0);
                        // save the left motor forward ticks
                        RoverController.LeftMotorForwardTicks   = BitConverter.ToInt64(packet, 17);
                        // save the left motor reverse ticks
                        RoverController.LeftMotorReverseTicks   = BitConverter.ToInt64(packet, 25);
                        // save the right motor forward ticks
                        RoverController.RightMotorForwardTicks  = BitConverter.ToInt64(packet, 33);
                        // save the right motor reverse ticks
                        RoverController.RightMotorReverseTicks  = BitConverter.ToInt64(packet, 41);
                    }
                    // break out
                    break;
                case PacketCodes.ImageBlockPacket:
                    // this is an image get packet
                    // loop through the data in the packet
                    for (int index = 2; index < packet.Length; index++)
                    {
                        // determine if this index contains an end flag
                        if (packet[index - 1] == 0xFF && packet[index] == 0xD9)
                        {
                            // it does
                            // create a new array
                            array = new Byte[index - 1];
                            // copy the data
                            Array.Copy(packet, 1, array, 0, array.Length);
                        }
                        else
                        {
                            // it does not
                            // create a new array
                            array = new Byte[packet.Length - 1];
                            // copy the data
                            Array.Copy(packet, 1, array, 0, array.Length);
                        }
                        // process the data
                        RoverController.AddImageBlock(array, array.Length);
                    }
                    // break out
                    break;
                case PacketCodes.CameraStatusPacket:
                    // this is a camera status get packet
                    // determine if the packet is the correct length
                    // print
                    // break out
                    break;
                case PacketCodes.SensorStatusPacket:
                    // this is a status get packet
                    // determine if the packet is the correct length
                    if (packet.Length == (CodeSize + StatusGetBodySize))
                    {
                        // it is
                        // save the result
                        result = true;
                        /* break apart the packet */
                        // save the distance
                        RoverController.Distance                = Tools.MapDoubleToUInt16(BitConverter.ToDouble(packet, 1), 10.00, 80.00, UInt16.MinValue, UInt16.MaxValue, 0);
                        // save the coordinates
                        RoverController.Locations.AddCoordinates(BitConverter.ToDouble(packet, 9),
                                                                 BitConverter.ToDouble(packet, 17));
                    }
                    // break out
                    break;
                case PacketCodes.AlarmStatusPacket:
                    // this is an alarm get packet
                    // determine if the packet is the correct length
                    if (packet.Length == (CodeSize + AlarmGetBodySize))
                    {
                        // it is
                        // save the result
                        result = true;
                        /* break apart the packet */
                        // save the alarm state
                        RoverController.AlarmFlags = ((AlarmCode)(BitConverter.ToUInt32(packet, 1)));
                    }
                    // break out
                    break;
            }
            // determine if the packet received event has a handler
            if (PacketReceived != null)
            {
                // it does
                // raise the event
                PacketReceived(packet, new EventArgs());
            }
            // return the result
            return result;
        }

        public enum PacketCodes
        {
            MotorControlPacket  = 'M',  // the motor control packet
            ServoControlPacket  = 'S',  // the servo angle
            CameraControlPacket = 'C',  // instructs the camera to capture an image
            MotorStatusPacket   = 'm',  // the motor current and ticks
            ImageBlockPacket    = 'i',  // an image block
            CameraStatusPacket  = 'c',  // the image size
            SensorStatusPacket  = 'g',  // the ir distance and gps coordinates
            AlarmStatusPacket   = 'a'   // the alarm state
        }
    }
}
