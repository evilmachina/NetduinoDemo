using System;
using System.Threading;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

namespace DemoNetduino
{
    internal class Stepper
    {
        private readonly InterruptPort _button = new InterruptPort(Pins.ONBOARD_SW1, false, Port.ResistorMode.Disabled,
                                                                   Port.InterruptMode.InterruptEdgeHigh);

        private readonly OutputPort enablePort;
        private readonly OutputPort stepperPort;

        public Stepper()
        {
            stepperPort = new OutputPort(Pins.GPIO_PIN_D2, false); 
            enablePort = new OutputPort(Pins.GPIO_PIN_D3, true);
        }

        public void Start()
        {
            _button.OnInterrupt += button_OnInterrupt;
        }

        internal void Stepp(int stepps)
        {
            enablePort.Write(false);
            for (int i = 0; i < stepps; i++)
            {
                stepperPort.Write(true);
                stepperPort.Write(false);
                Thread.Sleep(20);
            }
            enablePort.Write(true);
        }

        private void button_OnInterrupt(uint data1, uint data2, DateTime time)
        {
            if (data2 == 0)
            {
                Stepp(20);
            }
        }
    }
}