using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace RoverControl_v3
{
    public static class RoverController
    {
        /* constants ------------------------------------------------------------- */
        private const Double            TicksToCentimeters              = 1.88495559;
        private const Double            TicksPerRevolution              = 333.00;
        private const Int32             LocationBufferCapacity          = 10;
        /* the rover initialized flag -------------------------------------------- */
        public static Boolean           RoverInitialized                { get; set; }
        /* the rover details ----------------------------------------------------- */
        public static String            InstanceID                      { get; set; }
        /* the alarm state ------------------------------------------------------- */
        /* values sent from the rover -------------------------------------------- */
        public static AlarmCode         AlarmFlags                      { get; set; }
        /* the alarm flags ------------------------------------------------------- */
        public static Boolean           CommunicationFailure
        { 
            get { return AlarmFlags.HasFlag(AlarmCode.CommunicationFailure); } 
            private set { } 
        }
        public static Boolean           BatteryFailure
        { 
            get { return AlarmFlags.HasFlag(AlarmCode.BatteryFailure); } 
            private set { } 
        }
        public static Boolean           MotorOvercurrent
        {
            get { return AlarmFlags.HasFlag(AlarmCode.OvercurrentLeft); }
            private set { }
        }
        public static Boolean           BusAUndervolt
        {
            get { return AlarmFlags.HasFlag(AlarmCode.HighVoltageBusUndervolt); }
            private set { }
        }
        public static Boolean           BusBUndervolt
        {
            get { return AlarmFlags.HasFlag(AlarmCode.LowVoltageBusUndervolt); }
            private set { }
        }
        public static Boolean           OvercurrentImminentLeft
        {
            get { return AlarmFlags.HasFlag(AlarmCode.OvercurrentImminentLeft); }
            private set { }
        }
        public static Boolean           OvercurrentImminentRight
        {
            get { return AlarmFlags.HasFlag(AlarmCode.OvercurrentImminentRight); }
            private set { }
        }
        public static Boolean           StallLeft
        {
            get { return AlarmFlags.HasFlag(AlarmCode.StallLeft); }
            private set { }
        }
        public static Boolean           StallRight
        {
            get { return AlarmFlags.HasFlag(AlarmCode.StallRight); }
            private set { }
        }
        public static Boolean           CollisionImminentFront
        {
            get { return AlarmFlags.HasFlag(AlarmCode.CollisionImminentFront); }
            private set { }
        }
        public static Boolean           OvercurrentWarningLeft
        {
            get { return AlarmFlags.HasFlag(AlarmCode.OvercurrentWarningLeft); }
            private set { }
        }
        public static Boolean           OvercurrentWarningRight
        {
            get { return AlarmFlags.HasFlag(AlarmCode.OvercurrentWarningRight); }
            private set { }
        }
        public static Boolean           CollisionWarningFront
        {
            get { return AlarmFlags.HasFlag(AlarmCode.CollisionWarningFront); }
            private set { }
        }
        public static Boolean           FrontLeftPowerCutoff
        {
            get { return AlarmFlags.HasFlag(AlarmCode.FrontLeftPowerCutoff); }
            private set { }
        }
        public static Boolean           FrontRightPowerCutoff
        {
            get { return AlarmFlags.HasFlag(AlarmCode.FrontRightPowerCutoff); }
            private set { }
        }
        public static Boolean           RearLeftPowerCutoff
        {
            get { return AlarmFlags.HasFlag(AlarmCode.RearLeftPowerCutoff); }
            private set { }
        }
        public static Boolean           RearRightPowerCutoff
        {
            get { return AlarmFlags.HasFlag(AlarmCode.RearRightPowerCutoff); }
            private set { }
        }
        public static Boolean           CollisionAvoidanceActive
        {
            get { return AlarmFlags.HasFlag(AlarmCode.CollisionAvoidanceActive); }
            private set { }
        }
        public static Boolean           RoverOff
        {
            get { return AlarmFlags.HasFlag(AlarmCode.RoverOff); }
            private set { }
        }
        public static Boolean           RoverIdle
        {
            get { return AlarmFlags.HasFlag(AlarmCode.RoverIdle); }
            private set { }
        }
        public static Boolean           RoverError
        {
            get { return AlarmFlags.HasFlag(AlarmCode.RoverError); }
            private set { }
        }
        public static Boolean           RoverRun
        {
            get { return AlarmFlags.HasFlag(AlarmCode.RoverRun); }
            private set { }
        }
        /* left motor properties ------------------------------------------------- */
        /* values sent to the rover ---------------------------------------------- */
        // the magnitude of the left motor's power
        public static Byte              LeftMotorPower                  { get; set; }
        // the direction of the left motor's power
        public static Boolean           LeftMotorDirection              { get; set; }
        // the last left motor power value sent to the rover
        public static Byte              LeftMotorPowerSetpoint          { get; set; }
        // the last left motor direction value sent to the rover
        public static Boolean           LeftMotorDirectionSetpoint      { get; set; }
        /* values sent fron the rover -------------------------------------------- */
        // the amount of current reported by the motor driver board
        public static UInt16            LeftMotorCurrent                { get; set; }
        // the amount of ticks reported while moving forwards
        public static Int64             LeftMotorForwardTicks           { get; set; }
        // the amount of ticks reported while moving in reverse
        public static Int64             LeftMotorReverseTicks           { get; set; }   
        // the number of forward ticks minus the number of reverse ticks
        public static Int64             LeftMotorDisplacementTicks      
        {
            get { return LeftMotorForwardTicks - LeftMotorReverseTicks; } 
            private set { } 
        }
        // the number of forward ticks plus the number of reverse ticks
        public static Int64             LeftMotorDistanceTicks          
        {
            get { return LeftMotorForwardTicks + LeftMotorReverseTicks; } 
            private set { } 
        }
        // the difference in the initial and current location
        public static Double            LeftMotorDisplacement           
        {
            get { return (LeftMotorDisplacementTicks / TicksPerRevolution) * TicksToCentimeters; }
            private set { }
        }
        // the total amount of distance traveled by the left motors
        public static Double            LeftMotorDistance               
        {
            get { return (LeftMotorDistanceTicks / TicksPerRevolution) * TicksToCentimeters; }
            private set { }
        }   
        /* right motor properties ------------------------------------------------ */
        /* values sent to the rover ---------------------------------------------- */
        // the magnitude of the right motor's power
        public static Byte              RightMotorPower                 { get; set; }
        // the direction of the right motor's power
        public static Boolean           RightMotorDirection             { get; set; }
        // the last left motor power value sent to the rover
        public static Byte              RightMotorPowerSetpoint         { get; set; }
        // the last left motor direction value sent to the rover
        public static Boolean           RightMotorDirectionSetpoint     { get; set; }
        /* values sent from the rover -------------------------------------------- */
        // the amount of current reported by the motor driver board
        public static UInt16            RightMotorCurrent               { get; set; }
        // the amount of ticks reported while moving forwards
        public static Int64             RightMotorForwardTicks          { get; set; }
        // the amount of ticks reported while moving in reverse
        public static Int64             RightMotorReverseTicks          { get; set; }   
        // the number of forward ticks minus the number of reverse ticks
        public static Int64             RightMotorDisplacementTicks     
        { 
            get { return RightMotorForwardTicks - RightMotorReverseTicks; } 
            private set { } 
        }
        // the number of forward ticks plus the number of reverse ticks
        public static Int64             RightMotorDistanceTicks         
        { 
            get { return RightMotorForwardTicks + RightMotorReverseTicks; } 
            private set { } 
        }
        // the difference in the initial and current position
        public static Double            RightMotorDisplacement          
        {
            get { return (RightMotorDisplacementTicks / TicksPerRevolution) * TicksToCentimeters; }
            private set { }
        }
        // the total amount of distance traveled by the right motors
        public static Double            RightMotorDistance              
        {
            get { return (RightMotorDistanceTicks / TicksPerRevolution) * TicksToCentimeters; }
            private set { }
        }   
        /* servo properties ------------------------------------------------------ */
        // the servo hold flag
        public static Boolean           ServoHoldEnabled                { get; set; }
        /* pan servo properties -------------------------------------------------- */
        /* values used to countermand the pan servo inputs ----------------------- */
        // the angle to hold the pan servo at
        public static Byte              PanServoHoldAngle               { get; set; }
        /* values sent to the rover ---------------------------------------------- */
        // the angle of the pan servo
        public static Byte              PanServoAngle                   { get; set; }
        // the last pan servo angle sent to the rover
        public static Byte              PanServoAngleSetpoint           { get; set; }
        /* tilt servo properties ------------------------------------------------- */
        /* values used to countermand the tilt servo inputs ---------------------- */   
        // the angle to hold the tilt servo at
        public static Byte              TiltServoHoldAngle              { get; set; }
        /* values sent to the rover ---------------------------------------------- */
        // the angle of the tilt servo
        public static Byte              TiltServoAngle                  { get; set; }
        // the last pan servo angle sent to the rover
        public static Byte              TiltServoAngleSetpoint          { get; set; }
        /* gps module properties ------------------------------------------------- */
        /* values sent from the rover -------------------------------------------- */
        // a buffer of gps coordinates
        public static LocationBuffer    Locations                       { get; set; }   
        /* ir module properties -------------------------------------------------- */
        /* values sent from the rover -------------------------------------------- */
        // the distance between an object and the front infrared sensor
        public static UInt16            Distance                        { get; set; }   
        /* camera module properties ---------------------------------------------- */
        /* values sent to the rover                                                */
        public static Boolean           ImageRequested                  { get; set; }
        public static CaptureMode       CaptureMode                     { get; set; }
        /* values sent from the rover -------------------------------------------- */
        // a flag which indicates that there is an image on the camera's ram
        public static Boolean           ImageAvailable                  { get; set; }
        // the size of the image in bytes
        public static UInt32            ImageSize                       { get; set; }
        // a which which indicates that an image has been completely received
        public static Boolean           ImageCompleted                  { get; set; }
        // the stream which holds the incoming camera image
        public static MemoryStream      ImageStream                     { get; set; }
        // the writer which writes image data to the memory stream
        private static BinaryWriter     ImageWriter                     { get; set; }   
        /* constants ------------------------------------------------------------- */

        public static void Initialize()
        {
            // create the location buffer
            Locations           = new LocationBuffer(LocationBufferCapacity, 1000);
            // create the instance id
            InstanceID          = UuidGenerator.Generate();
            // set the defaults
            LeftMotorDirection  = true;
            RightMotorDirection = true;
        }

        public static void InitializeImageStream()
        {
            // create a new memorystream
            ImageStream = new MemoryStream();
            // create the streamwriter
            ImageWriter = new BinaryWriter(ImageStream);
        }

        public static ImageResult AddImageBlock(Byte[] block, Int32 block_length)
        {
            // the result
            ImageResult result          = ImageResult.None;
            // the "start flag found" flag
            Boolean     start_found     = false;
            // the "end flag found" flag
            Boolean     end_found       = false;
            // the start flag index
            Int32       start_index     = 0;
            // the end flag index
            Int32       end_index       = 0;
            // determine if the block is the right length
            if (block.Length == block_length)
            {
                // it is
                // look for the start of image flag
                start_found = (block[0] == 0xFF && block[1] == 0xD8);
                // look for the end of image flag
                end_found   = (block[block_length - 2] == 0xFF && block[block_length - 1] == 0xD9);
                // determine which flags were found
                if (start_found == true && end_found == false)
                {
                    // the start flag was found
                    // save the result
                    result = ImageResult.ImageInitialized;
                    // initialize the image stream
                    InitializeImageStream();
                    // write the start block to the image stream
                    ImageWriter.Write(block, start_index, block_length - start_index);
                }
                else
                if (start_found == false && end_found == true)
                {
                    // the end flag was found
                    // save the result
                    result = ImageResult.ImageCompleted;
                    // write the end block to the image stream
                    ImageWriter.Write(block, 0, end_index + 1);
                    // finalize the image
                    FinalizeImageStream();
                }
                else
                if (start_found == false && end_found == false)
                {
                    // neither flag was found
                    // save the result
                    result = ImageResult.ImageBlockAdded;
                    // add the block
                    ImageWriter.Write(block, 0, block_length);
                }
                else
                {
                    // both flags were found
                    // save the result
                    result = ImageResult.Error;
                }
            }
            // return the result
            return result;
        }

        public static Image FinalizeImageStream()
        {
            // the result
            Image           result          = null;
            // a temporary array
            Byte[]          temp_array      = null;
            // an image converter
            ImageConverter  converter       = new ImageConverter();
            // flush the writer
            ImageWriter.Flush();
            // create a binaryreader
            using (BinaryReader reader = new BinaryReader(ImageStream))
            {
                // seek
                reader.BaseStream.Seek(0, SeekOrigin.Begin);
                // read the stream
                temp_array  = reader.ReadBytes(Convert.ToInt32(reader.BaseStream.Length));
                // create the result
                result      = (Image)(converter.ConvertFrom(temp_array));
            }
            // close the writer and the stream
            ImageWriter.Close();
            // return the result
            return result;
        }

        private static Boolean SearchArray(Byte[] block, Byte high_byte, Byte low_byte, out Int32 flag_index)
        {
            // the result
            Boolean     result  = false;
            // save the default flag index
            flag_index          = 0;
            // look through the array
            for (int index = 1; index < block.Length; index++)
            {
                // determine if this location holds the desired flag
                if (block[index] == low_byte && block[index - 1] == high_byte)
                {
                    // it does
                    // save the result
                    result      = true;
                    // save the index
                    flag_index  = index;   
                    // break out
                    break;
                }
            }
            // return the result
            return result;
        }
    }
    public enum CaptureMode
    {
        None                = 0x00,
        OnDemandCapture     = 0x01,
        TimedCapture        = 0x02,
        VideoCapture        = 0x03
    }
    public enum ImageResult
    {
        None                = 0x00,
        ImageInitialized    = 0x01,
        ImageBlockAdded     = 0x02,
        ImageCompleted      = 0x03,
        Error               = 0x04
    }
    public class LocationBuffer : List<Coordinates>
    {
        public 
            LocationBuffer(Int32 capacity, Int32 min_interval)
        {
            // save the default last entry time
            this.LastEntryTime      = DateTime.MinValue;
            // set the properties of the buffer
            this.Capacity           = capacity;
            this.MinimumInterval    = min_interval;
        }
        private Int32 MinimumInterval { get; set; }
        private DateTime LastEntryTime { get; set; }
        public Coordinates Current  
        { 
            get 
            { 
                // return the current location
                return (this.Count > 1) ? (this[this.Count - 1] ?? Coordinates.Empty) : Coordinates.Empty; 
            } 
            private set { } 
        }
        public Double CurrentLatitude
        {
            get { return Current.Latitude; }
            private set { }
        }
        public Double CurrentLongitude
        {
            get { return Current.Longitude; }
            private set { }
        }
        public Coordinates Previous 
        { 
            get
            {
                // return the previous location
                return (this.Count > 2) ? (this[this.Count - 2] ?? Coordinates.Empty) : Coordinates.Empty; 
            } 
            private set { } 
        }
        public Double PreviousLatitude
        {
            get { return Previous.Latitude; }
            private set { }
        }
        public Double PreviousLongitude
        {
            get { return Previous.Longitude; }
            private set { }
        }
        public Coordinates Change   
        { 
            get 
            { 
                // return the change in location
                return (this.Count > 2) ? (this[this.Count - 1] - this[this.Count - 2]) ?? Coordinates.Empty : Coordinates.Empty; 
            } 
            private set { } 
        }
        public Double LatitudeChange
        {
            get { return Change.Latitude; }
            private set { }
        }
        public Double LongitudeChange
        {
            get { return Change.Longitude; }
            private set { }
        }

        public void 
            AddCoordinates(Coordinates coordinates)
        {
            // the timespan
            TimeSpan time_elapsed = DateTime.Now.Subtract(LastEntryTime);
            // determine if the minimum interval has elapsed
            if (time_elapsed.TotalMilliseconds > MinimumInterval)
            {
                // it has
                // determine if the capacity has been reached
                if (this.Count == this.Capacity)
                {
                    // it has
                    // remove the first entry
                    this.RemoveAt(0);
                    // add the new entry
                    this.Add(coordinates);
                }
                else
                {
                    // it has not
                    // add the new entry
                    this.Add(coordinates);
                }
                // save the entry time
                LastEntryTime   = DateTime.Now;
            }
        }
        public void 
            AddCoordinates(Double latitude, Double longitude)
        {
            // a set of coordinates
            Coordinates coordinates = new Coordinates { Latitude = latitude, Longitude = longitude };
            // save the coordinates
            this.AddCoordinates(coordinates);
        }
        public Coordinates 
            CompareLastValues()
        {
            // the result
            Coordinates result = null;
            // determine if there are enough values
            if (this.Count >= 2)
            {
                // there are
                // get the result
                result = this[this.Count - 1] - this[this.Count - 2];
            }
            // return the result
            return result;
        }
    }
    public class Coordinates
    {
        public Double   
            Latitude    { get; set; }
        public Double   
            Longitude   { get; set; }

        public static Coordinates operator - (Coordinates a, Coordinates b)
        {
            // the result
            Coordinates result = new Coordinates
            {
                Latitude    = a.Latitude - b.Latitude,
                Longitude   = a.Longitude - b.Longitude
            };
            // return the result
            return result;
        }
        public static Coordinates Empty 
        { 
            get 
            {
                return new Coordinates { Latitude = 0.00, Longitude = 0.00 };
            } 
            private set 
            { 
            } 
        }
    }
}
