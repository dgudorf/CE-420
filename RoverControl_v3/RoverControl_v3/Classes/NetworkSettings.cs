using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace RoverControl_v3
{
    public static class NetworkSettings
    {
        public static IPAddress     RoverIPAddress      { get; set; }
        public static Int32         TargetPort          { get; set; }
        public static Int32         ListenPort          { get; set; }

        public static void Initialize()
        {
            // set the defaults
            RoverIPAddress  = IPAddress.Parse("192.168.1.200");
            TargetPort      = 44400;
            ListenPort      = 44401;
        }
    }
}
