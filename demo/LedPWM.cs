using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

namespace demo_led
{
    public class LedPWM
    {
        const int PwmPeriod = 20;
        const uint MaxDutyCyle = 100;

        bool _buttonState;
        int _pwmDutyCycle;
        int _pwmIncrement;
        InterruptPort _button;
        PWM _led;
        private Timer _pwmTimer;

        public LedPWM()
        {
            _pwmDutyCycle = 0;
            _pwmIncrement = 1;
            _buttonState = false;

            _led = new PWM(Pins.GPIO_PIN_D5);

            _button = new InterruptPort(
                Pins.ONBOARD_SW1,
                false,
                Port.ResistorMode.Disabled,
                Port.InterruptMode.InterruptEdgeBoth);

            _button.OnInterrupt += OnClick;
        }

        public void Start()
        {
            _pwmTimer = new Timer(
                PwmTimerCallback,
                null,
                PwmPeriod,
                PwmPeriod);
        }

        public void PwmTimerCallback(Object obj)
        {
            if (true != _buttonState) return;

         
            _pwmDutyCycle += _pwmIncrement;
            _led.SetDutyCycle((uint)_pwmDutyCycle);

            

            if ((_pwmDutyCycle == MaxDutyCyle) || (_pwmDutyCycle == 0))
            {
                _pwmIncrement = -_pwmIncrement;
            }
        }

        public void OnClick(UInt32 data1, UInt32 data2, DateTime time)
        {
           // _button.DisableInterrupt();

            _buttonState = (0 == data2);

            //_button.EnableInterrupt();
        }

    
    }
}
