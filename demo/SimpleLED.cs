using System;
using System.Threading;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

namespace demo_led
{
    public class SimpleLed
    {
        private readonly OutputPort _led = new OutputPort(Pins.GPIO_PIN_D4, false);
        private bool _isOn;

        public void Start()
        {
            while (true)
            {
                _led.Write(_isOn);
                _isOn = !_isOn;

                Thread.Sleep(500);
            }
        }   
        
        
    }
}
