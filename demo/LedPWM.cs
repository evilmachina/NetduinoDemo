using System;
using System.Threading;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

namespace DemoNetduino
{
    public class LedPWM
    {
        private const int PwmPeriod = 20;
        private const uint MaxDutyCyle = 100;
        private readonly InterruptPort _button;
        private readonly PWM _led;

        private bool _buttonState;
        private int _pwmDutyCycle;
        private int _pwmIncrement;
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
            _led.SetDutyCycle((uint) _pwmDutyCycle);


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