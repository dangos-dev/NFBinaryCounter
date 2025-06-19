using System;
using System.Device.Gpio;
using System.Threading;

namespace NFBinaryCounter {
    public abstract class Program {

        // GPIO Pins
        private readonly static int[] LedPins = { 4, 5, 6, 7, 15, 16, 17, 18 };
        private const int ButtonPin = 14;

        // Globals
        private static GpioController _sGpioController;
        private static GpioPin[] _sLedPins;
        private static GpioPin _sButtonPin;
        private static int _sCounter;

        public static void Main() {
            Console.WriteLine("Starting Binary Counter");

            // Initialize GPIO controller
            _sGpioController = new GpioController();

            // Configure LED pins as outputs
            _sLedPins = new GpioPin[LedPins.Length];

            for (int i = 0; i < LedPins.Length; i++) {
                _sLedPins[i] = _sGpioController.OpenPin(LedPins[i], PinMode.Output);
            }

            // Configure button pin as input with PULL-UP resistor
            _sButtonPin = _sGpioController.OpenPin(ButtonPin, PinMode.InputPullUp);

            UpdateLedDisplay();

            while (true) {

                // Wait for a button press
                if (_sButtonPin.Read() == PinValue.Low) {

                    // Increment counter
                    _sCounter++;

                    // If the counter exceeds 255, reset to 0
                    if (_sCounter > 255) {
                        _sCounter = 0;
                    }

                    Console.WriteLine($"Button pressed. New value: {_sCounter}");
                    UpdateLedDisplay(); // Update LEDs with new value

                    // DEBOUNCE
                    while (_sButtonPin.Read() == PinValue.Low) {
                        Thread.Sleep(50);
                    }
                }

                Thread.Sleep(20);
            }
        }

        /// <summary>
        /// Updates the 8 LEDs to display the 's_counter' value in binary.
        /// </summary>
        private static void UpdateLedDisplay() {
            for (int i = 0; i < _sLedPins.Length; i++) {
                // Check the i-th bit of the counter
                // Uses bitwise operator: (s_counter >> i) shifts the bit to the last position
                // & 1 isolates it. The result is 1 or 0.
                bool isBitOne = ((_sCounter >> i) & 1) == 1;

                // COMMON ANODE LED
                _sLedPins[i].Write(isBitOne ? PinValue.Low : PinValue.High);
            }
        }
    }
}
