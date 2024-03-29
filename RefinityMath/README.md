# Refinity

Welcome to Refinity, a comprehensive C# library designed to boost developer productivity. Our library is packed with a wide range of extension methods, each crafted to streamline your coding experience and enhance your projects.

## Features

- Wide Range of Extension Methods: Covering various aspects of C# programming to make your code more efficient and readable.
- Easy Integration: Seamlessly integrates with existing C# projects, requiring minimal setup.
- High-Quality Code: Written with best practices in mind, ensuring reliability and performance.
- Regular Updates: Continuously evolving with new methods and improvements based on community feedback.

## Installation

To use Refinity in your project, follow these steps:

- Add the Refinity package to your project via NuGet:

		dotnet add package Refinity

- Import the library in your C# files:

## Usage

Refinity is designed to be intuitive. Here’s a quick example of how you can use one of the extension methods:

## Math

```cs
using Refinity.Math;
int a = 10;
a.Fibonacci(); // 55
```

## Finance

```cs
using Refinity.Math;
using Refinity.Finance;

double start = 1020.0;
double end = 1000.0;
double difference = start.DifferencePercentage(end); // 2
string diffString = difference.ToStringPercentage(); // "2,00%"
```

## License

Refinity is released under the MIT License. See the LICENSE file for more details.

## Contact

For support or queries, reach out to us on this GitHub Repository!

Refinity is more than just a library; it’s a tool to empower developers to write better, more efficient code. Join us in making the C# world a more productive place!
