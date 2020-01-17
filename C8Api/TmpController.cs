using System.IO.Ports;
using System.Web.Http;

namespace C8Api
{
    public class TmpController : ApiController
    {
        public object Get()
        {
            SerialPort s = new SerialPort();
            s.PortName = "COM40";
            s.BaudRate = 115200;
            s.Open();
            s.WriteLine("/get");
            var p = s.ReadLine();
            s.Close();
            s.Dispose();
            var wd = p.Between("??????", ",");
            var sd = p.Between(",??????", "\r");
            return new
            {
                wd = wd,
                sd = sd
            };
        }

    }
}