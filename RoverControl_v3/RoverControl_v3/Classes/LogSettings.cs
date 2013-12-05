using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoverControl_v3
{
    public static class LogSettings
    {
        public static String        OutputFolder        { get; set; }
        public static Int32         CommitInterval      { get; set; }
        public static LogFields     LogFields           { get; set; }

        public static void Initialize()
        {
            // set the defaults
            OutputFolder    = @"C:\";
            CommitInterval  = 100;
            LogFields       = LogFields.All;
        }

    }

    [Flags]
    public enum LogFields
    {
        None                = 0x0000,
        MotorInputs         = 0x0001,
        MotorCurrents       = 0x0002,
        MotorSetpoints      = 0x0004,
        MotorEncoders       = 0x0008,
        ServoInputs         = 0x0010,
        ServoSetpoints      = 0x0020,
        IRDistance          = 0x0040,
        GpsCoordinates      = 0x0080,
        AlarmStates         = 0x0100,
        CaptureMode         = 0x0200,
        All                 = 0x03FF
    }
}
