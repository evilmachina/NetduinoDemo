using System;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

namespace DemoNetduino
{
    internal class SimpleButton
    {
        private readonly InterruptPort _button = new InterruptPort(Pins.ONBOARD_SW1, false, Port.ResistorMode.Disabled,
                                                                   Port.InterruptMode.InterruptEdgeBoth);

        private readonly OutputPort _led = new OutputPort(Pins.GPIO_PIN_D4, false);

        public void Start()
        {
            _button.OnInterrupt += button_OnInterrupt;
        }

        private void button_OnInterrupt(uint data1, uint data2, DateTime time)
        {
            _led.Write(data2 == 0);
        }
    }
}