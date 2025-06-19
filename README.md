# Binary Counter with .NET nanoFramework

![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white)
![MIT](https://img.shields.io/badge/License-MIT-green.svg?style=for-the-badge)

## Description

This project implements a binary counter using 8 LEDs controlled by GPIO on a ESP32S3. The counter is incremented using a button and displays the current value (0-255) in binary format through the LEDs.
![demo.gif](assets/demo.gif)

## Features

- 8-bit binary counter (0–255)
- Control of eight LEDs to display the value in binary
- Counter increment via push button
- Button debounce protection
- Compatible with microcontrollers that support .NET nanoFramework

## Required Hardware

- Board compatible with .NET nanoFramework (ESP32, STM32, etc.)
- 8 LEDs (configured as common anode in this project)
- 8 resistors for LEDs (330Ω recommended)
- 1 push button
- 1 resistor for the button (10kΩ recommended)
- Connection wires

## Connections

- LEDs: GPIO pins 4, 5, 6, 7, 15, 16, 17, 18
- Button: GPIO pin 14 (configured with internal pull-up resistor)

## Software Requirements

- Visual Studio with nanoFramework extension
- [.NET nanoFramework](https://www.nanoframework.net/)
- NuGet Packages:
  - nanoFramework.CoreLibrary (v1.17.11)
  - nanoFramework.Runtime.Events (v1.11.32)
  - nanoFramework.System.Device.Gpio (v1.1.57)

## Installation and Usage

1. Clone this repository
2. Open the solution in Visual Studio
3. Connect your nanoFramework compatible device
4. Compile and upload the program to the device
5. Use the button to increment the counter and observe the LEDs

## Operation

Each time the button is pressed, the counter increments by one, and the LEDs display the current value in binary. When the counter reaches 255, it starts over from 0.

## License

This project is licensed under the MIT License—see the LICENSE file for details.

## Additional Resources

- [Official .NET nanoFramework Documentation](https://docs.nanoframework.net/)
- [nanoFramework Community Forum](https://forums.nanoframework.net/)
- [nanoFramework Project Examples](https://github.com/nanoframework/Samples)