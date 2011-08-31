using System;
using System.Threading;
using Microsoft.SPOT;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

namespace demo_led
{
    public class Tmp
    {
        private readonly AnalogInput _port;
        private Timer _read;

        public Tmp()
        {
            _port = new AnalogInput(Pins.GPIO_PIN_A0);
            
        }

        public Double GetTemp()
        {
            var val = _port.Read();
            var voltage = val * 3.3 / 1024;
            Debug.Print(voltage.ToString());
            return (voltage*100) - 50;
        }


        public void Start()
        {
            _read = new Timer(
                ReadTemp,
                null,
                200,
                200);
        }

        public void ReadTemp(object o)
        {
            Debug.Print(GetTemp().ToString());
        }
    }
}
