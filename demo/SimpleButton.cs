using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

namespace demo_led
{
    class SimpleButton
    {
        private readonly OutputPort _led = new OutputPort(Pins.GPIO_PIN_D4, false);
        
        readonly InterruptPort _button = new InterruptPort(Pins.ONBOARD_SW1, false, Port.ResistorMode.Disabled, Port.InterruptMode.InterruptEdgeBoth);

        public void Start()
        {
            _button.OnInterrupt += button_OnInterrupt;
        }

         void button_OnInterrupt(uint data1, uint data2, DateTime time)
        {
            _led.Write(data2 == 0);
        }

    }
}
