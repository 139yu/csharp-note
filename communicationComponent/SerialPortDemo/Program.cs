using System;
using System.Collections.ObjectModel;
using System.IO.Ports;
using System.Text;
using System.Threading;

namespace SerialPortDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            SerialPort sp = new SerialPort();
            sp.PortName = "COM1";
            sp.BaudRate = 9600;
            sp.DataBits = 8;
            sp.Parity = Parity.None;
            sp.StopBits = StopBits.One;
            sp.Open();
            string msg = "fuck man";
            var bytes = Encoding.UTF8.GetBytes(msg);
            sp.Write(bytes,0,bytes.Length);

            while (sp.BytesToRead < 100)    
            {
                Thread.Sleep(500);
                Console.WriteLine(sp.BytesToRead);
            }
        }
    }
}