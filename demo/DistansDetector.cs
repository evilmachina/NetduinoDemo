using System.Threading;
using Microsoft.SPOT;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

namespace DemoNetduino
{
    public class DistansDetector
    {
        private const float Y0 = 3;
        private const float X0 = 315;
        private const float Y1 = 30;
        private const float X1 = 30;
        private const float C = (Y1 - Y0)/(1/X1 - 1/X0);
        private readonly AnalogInput _port;

        public DistansDetector()
        {
            _port = new AnalogInput(Pins.GPIO_PIN_A1);
            _port.SetRange(0, 100);
        }

        public float GetDistance()
        {
            Debug.Print(_port.Read().ToString());
            return C/(_port.Read() + (float) .001) - (C/X0) + Y0;
        }


        public int GetValue()
        {
            Debug.Print(_port.Read().ToString());
            return _port.Read();
        }

        public void Start()
        {
            while (true)
            {
                Debug.Print(GetDistance().ToString());
                Thread.Sleep(200);
            }
        }
    }
}