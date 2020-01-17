using System;
using System.IO.Ports;

namespace Test
{
    internal class Program
    {
        public static void Main(string[] args)
        {            
            SerialPort s = new SerialPort();
            s.PortName = "COM40";
            s.BaudRate = 115200;
            s.Open();
            s.WriteLine("/get");
            var p = s.ReadLine();
            s.Close();
            s.Dispose();
            Console.WriteLine(p);

        }
    }
}