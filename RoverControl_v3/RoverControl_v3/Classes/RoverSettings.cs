using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoverControl_v3
{
    public static class RoverSettings
    {
        public static Int32     ControllerInterval      { get; set; }
        public static Int32     NetworkInterval         { get; set; }
        public static Int32     TimedCaptureInterval    { get; set; }
        public static Int32     VideoCaptureRate        { get; set; }
        public static Int32     MaximumFileCount        { get; set; }
        public static Int32     MaximumFileSize         { get; set; }
        public static String    ImageOutputLocation     { get; set; }
        public static Boolean   UseMaximumFileCount     { get; set; }
        public static Boolean   UseMaximumFileSize      { get; set; }

        public static void Initialize()
        {
            // set the defaults
            ControllerInterval      = 25;
            NetworkInterval         = 100;
            TimedCaptureInterval    = 2500;
            VideoCaptureRate        = 10;
            MaximumFileCount        = 500;
            MaximumFileSize         = 500;
            UseMaximumFileCount     = true;
            UseMaximumFileSize      = false;
            ImageOutputLocation     = "";
        }
    }
}
