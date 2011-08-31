using System;
using System.Threading;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

namespace DemoNetduino
{
    internal class LedDistance
    {
        private const int PwmPeriod = 20;
        private readonly DistansDetector distansDetector = new DistansDetector();
        private PWM _led;
        private int _pwmDutyCycle;
        private Timer _pwmTimer;

        public void Start()
        {
            _pwmDutyCycle = 0;

            _led = new PWM(Pins.GPIO_PIN_D5);

            _pwmTimer = new Timer(
                PwmTimerCallback,
                null,
                PwmPeriod,
                PwmPeriod);
        }

        public void PwmTimerCallback(Object obj)
        {
            _pwmDutyCycle = distansDetector.GetValue();
            _led.SetDutyCycle((uint) _pwmDutyCycle);
        }
    }
}