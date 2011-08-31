using System;
using System.Threading;
using Microsoft.SPOT;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

namespace demo_led
{
    class LedDistance
    {
        const int PwmPeriod = 20;
        int _pwmDutyCycle;
        PWM _led;
        private Timer _pwmTimer;
        private DistansDetector distansDetector = new DistansDetector();

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
            _led.SetDutyCycle((uint)_pwmDutyCycle);
       }

       
    }
}
