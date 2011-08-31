using System;
using System.Threading;
using Microsoft.SPOT;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

namespace demo_led
{
    public class DistansDetector
    {
        private readonly AnalogInput _port;
        const float Y0 = 3;
        const float X0 = 315;
        const float Y1 = 30;
        const float X1 = 30;
        const float C = (Y1 - Y0) / (1 / X1 - 1 / X0);

        public DistansDetector()
        {
            _port = new AnalogInput(Pins.GPIO_PIN_A1);
            _port.SetRange(0, 100);
        }

        public float GetDistance()
        {
            Debug.Print(_port.Read().ToString());
            return C / (_port.Read() + (float).001) - (C / X0) + Y0;
        }


        public int GetValue()
        {
            Debug.Print(_port.Read().ToString());
            return _port.Read();
        }

        public void Start()
        {
            while(true)
            {
                
                Debug.Print(GetDistance().ToString());
                Thread.Sleep(200);
            }
        }



        

    }
}
