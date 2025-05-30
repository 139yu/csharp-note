using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialPortTools.Helper
{
    public class Faker
    {
        public static List<string> PortNames()
        {
            return new List<string>(SerialPort.GetPortNames());
        }

        public static List<int> BaudRates()
        {
            return new List<int>()
            {
                110,300,600,1200,2400,4800,9600,14400,19200,28800,38400,56000,57600,115200,128000,230400,256000
            };
        }

        public static ICollection DataBits()
        {
            return new List<int>() { 1,2,3,4,5,6,7,8};
        }
    }
}