using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RoverControl_v3
{
    public enum LogEvents
    {
        None        = 0x00,
        Receive     = 0x01,
        Transmit    = 0x02
    }

    public static class UuidGenerator
    {
        public static String Generate()
        {
            string characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string ticks = DateTime.UtcNow.Ticks.ToString();
            var code = "";
            for (var i = 0; i < characters.Length; i += 2)
            {
                if ((i + 2) <= ticks.Length)
                {
                    var number = int.Parse(ticks.Substring(i, 2));
                    if (number > characters.Length - 1)
                    {
                        var one = double.Parse(number.ToString().Substring(0, 1));
                        var two = double.Parse(number.ToString().Substring(1, 1));
                        code += characters[Convert.ToInt32(one)];
                        code += characters[Convert.ToInt32(two)];
                    }
                    else
                        code += characters[number];
                }
            }
            return code;
        }
    }
    public static class LogController
    {
        // the "is enabled" flag
        private static Boolean          IsEnabled           { get; set; }
        // the "new log" flag
        private static Boolean          NewLog              { get; set; }
        // the time at which the first log entry was received
        private static DateTime         StartTime           { get; set; }
        // the time at which the last log entry was received
        private static DateTime         LastTimeIndex       { get; set; }
        // the output folder
        private static String           OutputFolder        { get; set; }
        // the output path
        private static String           OutputPath          { get; set; }
        // the contents of the log file
        private static List<String>     Contents            { get; set; }

        public static void Initialize()
        {
            // create the output folder
            OutputFolder    = LogSettings.OutputFolder + @"\" + RoverController.InstanceID;
            // create the output path
            OutputPath      = OutputFolder + @"\ROVER CONTROL LOG " + DateTime.Now.ToBinary() + ".csv";
            // initialize the contents list
            Contents        = new List<String>();
            // set the new log flag
            NewLog          = true;
        }

        public static void EnableLog(Boolean save_existing)
        {
            // determine if the user wants to save the existing log
            if (save_existing == true)
            {
                // they do
                // commit the log
                CommitLog();
            }
            // reinitialize the contents list
            Contents        = new List<String>();
            // save the start time
            StartTime       = DateTime.Now;
            // set the log enabled flag
            IsEnabled       = true;
            // set the new log flag
            NewLog          = true;
        }
        public static void DisableLog()
        {
            // clear the log enabled flag
            IsEnabled       = false;
        }
        public static void CommitLog()
        {
            // a filestream
            FileStream  file_stream     = new FileStream(OutputPath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
            // the contents of the file
            String      file_contents   = String.Empty;
            // create a streamreader
            using (StreamReader reader = new StreamReader(file_stream))
            {
                // read the contents 
                file_contents           = reader.ReadToEnd().Trim();
            }
            // close the stream
            file_stream.Close();
            // reopen the stream
            file_stream                 = new FileStream(OutputPath, FileMode.Create, FileAccess.ReadWrite, FileShare.Read);
            // create a streamwriter
            using (StreamWriter writer = new StreamWriter(file_stream))
            {
                // write the existing contents of the log to the file stream
                writer.WriteLine(file_contents);
                // write the log contents to the file stream
                Contents.ForEach(entity => writer.WriteLine(entity));
                // flush the writer
                writer.Flush();
            }
            // close the stream
            file_stream.Close();
            // create a new list
            Contents = new List<String>();
        }

        public static void RecordState(LogEvents event_type)
        {
            // the state entry
            String      state_entry         = String.Empty;
            String      header_entry        = String.Empty;
            // the fields
            String[]    state_fields        = new String[CountFields()];
            String[]    header_fields       = new String[CountFields()];
            // the field index
            Int32       field_index         = 0;
            // save the time
            header_fields[field_index]      = "Time (msecs)";
            state_fields[field_index++]     = DateTime.Now.Subtract(StartTime).TotalMilliseconds.ToString();
            // save the event
            header_fields[field_index]      = "Event Type";
            state_fields[field_index++]     = Convert.ToInt32(event_type).ToString();
            // determine if the motor inputs s hould be included
            if (LogSettings.LogFields.HasFlag(LogFields.MotorInputs))
            {
                // it should
                // save the left motor input
                header_fields[field_index]  = "Left Motor Input";
                state_fields[field_index++] = ((RoverController.LeftMotorDirection)
                                                ? RoverController.LeftMotorPower
                                                : RoverController.LeftMotorPower * -1).ToString();
                // save the right motor input
                header_fields[field_index]  = "Right Motor Input";
                state_fields[field_index++] = ((RoverController.RightMotorDirection)
                                                ? RoverController.RightMotorPower
                                                : RoverController.RightMotorPower * -1).ToString();
            }
            // determine if the motor currents should be included
            if (LogSettings.LogFields.HasFlag(LogFields.MotorCurrents))
            {
                // it should
                // save the left motor current
                header_fields[field_index]  = "Left Motor Current";
                state_fields[field_index++] = RoverController.LeftMotorCurrent.ToString("F3");
                // save the right motor current
                header_fields[field_index]  = "Right Motor Current";
                state_fields[field_index++] = RoverController.RightMotorCurrent.ToString("F3");

            }
            // determine if the motor setpoints should be included
            if (LogSettings.LogFields.HasFlag(LogFields.MotorSetpoints))
            {
                // it should
                // save the left motor setpoint
                header_fields[field_index]  = "Left Motor Setpoint";
                state_fields[field_index++] = ((RoverController.LeftMotorDirectionSetpoint)
                                                ? (RoverController.LeftMotorPowerSetpoint).ToString()
                                                : (-RoverController.LeftMotorPowerSetpoint).ToString());
                // save the right motor setpoint
                header_fields[field_index]  = "Right Motor Setpoint";
                state_fields[field_index++] = ((RoverController.RightMotorDirectionSetpoint)
                                                ? (RoverController.RightMotorPowerSetpoint).ToString()
                                                : (-RoverController.RightMotorPowerSetpoint).ToString());
            }
            // determine if the motor encoder values should be included
            if (LogSettings.LogFields.HasFlag(LogFields.MotorEncoders))
            {
                // it should
                // save the left motor's encoder values
                header_fields[field_index]  = "Left Motor Forward Ticks";
                state_fields[field_index++] = RoverController.LeftMotorForwardTicks.ToString();
                header_fields[field_index]  = "Left Motor Reverse Ticks";
                state_fields[field_index++] = RoverController.LeftMotorReverseTicks.ToString();
                header_fields[field_index]  = "Left Motor Distance";
                state_fields[field_index++] = RoverController.LeftMotorDistance.ToString();
                header_fields[field_index]  = "Left Motor Displacement";
                state_fields[field_index++] = RoverController.LeftMotorDisplacement.ToString();
                // save the right motor's encoder values
                header_fields[field_index]  = "Right Motor Forward Ticks";
                state_fields[field_index++] = RoverController.RightMotorForwardTicks.ToString();
                header_fields[field_index]  = "Right Motor Reverse Ticks";
                state_fields[field_index++] = RoverController.RightMotorReverseTicks.ToString();
                header_fields[field_index]  = "Right Motor Distance";
                state_fields[field_index++] = RoverController.RightMotorDistance.ToString();
                header_fields[field_index]  = "Right Motor Displacement";
                state_fields[field_index++] = RoverController.RightMotorDisplacement.ToString();
            } 
            // determine if the servo inputs should be included
            if (LogSettings.LogFields.HasFlag(LogFields.ServoInputs))
            {
                // it should
                // save the pan servo input
                header_fields[field_index]  = "Pan Servo Angle";
                state_fields[field_index++] = RoverController.PanServoAngle.ToString();
                // save the tilt servo input
                header_fields[field_index]  = "Tilt Servo Angle";
                state_fields[field_index++] = RoverController.TiltServoAngle.ToString();
            }
            // determine if the servo setpoints should be included
            if (LogSettings.LogFields.HasFlag(LogFields.ServoSetpoints))
            {
                // it should
                // save the pan servo input
                header_fields[field_index]  = "Pan Servo Angle Setpoint";
                state_fields[field_index++] = RoverController.PanServoAngleSetpoint.ToString();
                // save the tilt servo input
                header_fields[field_index] = "Tilt Servo Angle Setpoint";
                state_fields[field_index++] = RoverController.TiltServoAngleSetpoint.ToString();
            }
            // determine if the ir distance should be included
            if (LogSettings.LogFields.HasFlag(LogFields.IRDistance))
            {
                // it should
                // save the ir distance
                header_fields[field_index]  = "IR Sensor Distance";
                state_fields[field_index++] = RoverController.Distance.ToString();
            }
            // determine if the gps coordinates should be included
            if (LogSettings.LogFields.HasFlag(LogFields.GpsCoordinates))
            {
                // it should
                // save the gps coordinates
                header_fields[field_index]  = "Current Latitude";
                state_fields[field_index++] = RoverController.Locations.CurrentLatitude.ToString("F6");
                header_fields[field_index]  = "Current Longitude";
                state_fields[field_index++] = RoverController.Locations.CurrentLongitude.ToString("F6");
            }
            // determine if the alarm states should be included
            if (LogSettings.LogFields.HasFlag(LogFields.AlarmStates))
            {
                // it should
                // save the alarm state
                header_fields[field_index]  = "Alarm State";
                state_fields[field_index++] = Convert.ToInt32(RoverController.AlarmFlags).ToString();
            }
            // determine if the capture mode should be included
            if (LogSettings.LogFields.HasFlag(LogFields.CaptureMode))
            {
                // it should
                // save the capture mode
                header_fields[field_index]  = "Capture Mode";
                state_fields[field_index++] = Convert.ToInt32(RoverController.CaptureMode).ToString();
            }
            // iterate through the state fields
            foreach (String state_field in state_fields)
            {
                // save this field
                state_entry    += state_field + ", ";
            }
            // trim the entry
            state_entry         = state_entry.Trim();
            // determine if there is a trailing comma
            if (state_entry.EndsWith(","))
            {
                // there is
                // remove it
                state_entry = state_entry.Remove(state_entry.Length - 1);
            }
            // determine if this is a new log
            if (NewLog == true)
            {
                // it is
                // save the header

            }
            // determine if enough time has elapsed and if the log is enabled
            if (DateTime.Now.Subtract(LastTimeIndex).TotalMilliseconds > 25 && IsEnabled)
            {
                // enough time has elapsed
                // save this state entry
                Contents.Add(state_entry);
                // update the last entry time
                LastTimeIndex = DateTime.Now;
            }
            // determine if the commit interval has been reached
            if (Contents.Count % LogSettings.CommitInterval == 0)
            {
                // it has
                // save the file
                CommitLog();
            }
        }

        private static Int32 CountFields()
        {
            // the number of fields, including the time and the event
            Int32 result = 2;
            // determine which field flags are active
            result += (LogSettings.LogFields.HasFlag(LogFields.AlarmStates)) ? 1 : 0;
            result += (LogSettings.LogFields.HasFlag(LogFields.CaptureMode)) ? 1 : 0;
            result += (LogSettings.LogFields.HasFlag(LogFields.GpsCoordinates)) ? 2 : 0;
            result += (LogSettings.LogFields.HasFlag(LogFields.IRDistance)) ? 1 : 0;
            result += (LogSettings.LogFields.HasFlag(LogFields.MotorCurrents)) ? 2 : 0;
            result += (LogSettings.LogFields.HasFlag(LogFields.MotorEncoders)) ? 8 : 0;
            result += (LogSettings.LogFields.HasFlag(LogFields.MotorInputs)) ? 2 : 0;
            result += (LogSettings.LogFields.HasFlag(LogFields.MotorSetpoints)) ? 2 : 0;
            result += (LogSettings.LogFields.HasFlag(LogFields.ServoInputs)) ? 2 : 0;
            result += (LogSettings.LogFields.HasFlag(LogFields.ServoSetpoints)) ? 2 : 0;
            // return the result
            return result;
        }
    }
}
