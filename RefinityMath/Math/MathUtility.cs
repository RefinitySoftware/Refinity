using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace RefinityMath;
/// <summary>
/// Represents a mathematical utility class.
/// </summary>
public static class MathUtility
{
    /// <summary>
    /// Calculates the factorial of a non-negative integer.
    /// </summary>¯¯
    /// <param name="n">The non-negative integer.</param>
    /// <returns>The factorial of the input integer.</returns>
    public static int Factorial(this int n)
    {
        if (n < 0)
            throw new ArgumentException("Factorial is not defined for negative numbers.");

        int result = 1;
        for (int i = 2; i <= n; i++)
        {
            result *= i;
        }

        return result;
    }

    /// <summary>
    /// Determines whether the specified number is a prime number.
    /// </summary>
    /// <param name="n">The number to check.</param>
    /// <returns><c>true</c> if the number is prime; otherwise, <c>false</c>.</returns>
    public static bool IsPrime(this int n)
    {
        if (n < 2)
            return false;

        for (int i = 2; i < n; i++)
        {
            if (n % i == 0)
                return false;
        }

        return true;
    }

    /// <summary>
    /// Determines whether the specified number is a prime number.
    /// </summary>
    /// <param name="n">The number to check.</param>
    /// <returns><c>true</c> if the number is prime; otherwise, <c>false</c>.</returns>
    public static bool IsPrime(this double n)
    {
        if (n < 2)
            return false;

        for (int i = 2; i < n; i++)
        {
            if (n % i == 0)
                return false;
        }

        return true;
    }

    /// <summary>
    /// Determines whether the specified integer is even.
    /// </summary>
    /// <param name="n">The integer to check.</param>
    /// <returns>true if the integer is even; otherwise, false.</returns>
    public static bool IsEven(this int n)
    {
        return n % 2 == 0;
    }

    /// <summary>
    /// Determines whether the specified integer is odd.
    /// </summary>
    /// <param name="n">The integer to check.</param>
    /// <returns>true if the specified integer is odd; otherwise, false.</returns>
    public static bool IsOdd(this int n)
    {
        return n % 2 != 0;
    }

    /// <summary>
    /// Determines whether an integer is divisible by a given divisor.
    /// </summary>
    /// <param name="n">The integer to check for divisibility.</param>
    /// <param name="divisor">The divisor to check against.</param>
    /// <returns>True if the integer is divisible by the divisor, otherwise false.</returns>
    public static bool IsDivisibleBy(this int n, int divisor)
    {
        return n % divisor == 0;
    }

    /// <summary>
    /// Determines whether an integer is divisible by a given divisor and calculates the quotient.
    /// </summary>
    /// <param name="n">The integer to check for divisibility.</param>
    /// <param name="divisor">The divisor to check against.</param>
    /// <param name="quotient">The calculated quotient if the integer is divisible by the divisor.</param>
    /// <returns>True if the integer is divisible by the divisor, false otherwise.</returns>
    public static bool IsDivisibleBy(this int n, int divisor, out int quotient)
    {
        quotient = n / divisor;
        return n % divisor == 0;
    }

    /// <summary>
    /// Calculates the greatest common divisor (GCD) of two integers.
    /// </summary>
    /// <param name="a">The first integer.</param>
    /// <param name="b">The second integer.</param>
    /// <returns>The greatest common divisor of the two integers.</returns>
    public static int GreatestCommonDivisor(this int a, int b)
    {
        int remainder;
        while (b != 0)
        {
            remainder = a % b;
            a = b;
            b = remainder;
        }

        return a;
    }

    /// <summary>
    /// Calculates the least common multiple (LCM) of two integers.
    /// </summary>
    /// <param name="a">The first integer.</param>
    /// <param name="b">The second integer.</param>
    /// <returns>The least common multiple of the two integers.</returns>
    public static int LeastCommonMultiple(this int a, int b)
    {
        return a * b / a.GreatestCommonDivisor(b);
    }

    /// <summary>
    /// Converts an integer to its binary representation in base 2.
    /// </summary>
    /// <param name="n">The integer to convert.</param>
    /// <returns>The binary representation of the input integer.</returns>
    public static int ConvertToBaseBinary(this int n)
    {
        int binary = 0;
        int baseValue = 1;

        while (n > 0)
        {
            int remainder = n % 2;
            n = n / 2;
            binary += remainder * baseValue;
            baseValue *= 10;
        }

        return binary;
    }

    /// <summary>
    /// Converts an integer to its octal representation.
    /// </summary>
    /// <param name="n">The integer to be converted.</param>
    /// <returns>The octal representation of the input integer.</returns>
    public static int ConvertToBaseOctal(this int n)
    {
        int octal = 0;
        int baseValue = 1;

        while (n > 0)
        {
            int remainder = n % 8;
            n = n / 8;
            octal += remainder * baseValue;
            baseValue *= 10;
        }

        return octal;
    }

    /// <summary>
    /// Converts an integer to its hexadecimal representation.
    /// </summary>
    /// <param name="n">The integer to convert.</param>
    /// <returns>The hexadecimal representation of the input integer.</returns>
    public static int ConvertToBaseHexadecimal(this int n)
    {
        int hexadecimal = 0;
        int baseValue = 1;

        while (n > 0)
        {
            int remainder = n % 16;
            n = n / 16;

            if (remainder < 10)
            {
                hexadecimal += remainder * baseValue;
            }
            else
            {
                char hexChar = (char)('A' + (remainder - 10));
                hexadecimal += (int)hexChar * baseValue;
            }

            baseValue *= 10;
        }

        return hexadecimal;
    }

    /// <summary>
    /// Calculates the Fibonacci number for a given integer.
    /// </summary>
    /// <param name="n">The input integer.</param>
    /// <returns>The Fibonacci number.</returns>
    public static int Fibonacci(this int n)
    {
        if (n < 0)
            throw new ArgumentException("Fibonacci is not defined for negative numbers.");

        if (n == 0)
            return 0;

        if (n == 1)
            return 1;

        return Fibonacci(n - 1) + Fibonacci(n - 2);
    }

    /// <summary>
    /// Calculates the mean and standard deviation of an array of integers.
    /// </summary>
    /// <param name="values">The array of integers.</param>
    /// <returns>A tuple containing the mean and standard deviation.</returns>
    public static (double mean, double standardDeviation) GetStandardDeviation(this int[] values)
    {
        double[] valuesDouble = values.Select(Convert.ToDouble).ToArray();
        return valuesDouble.GetStandardDeviation();
    }

    /// <summary>
    /// Calculates the mean and standard deviation of an array of doubles.
    /// </summary>
    /// <param name="values">The array of doubles.</param>
    /// <returns>A tuple containing the mean and standard deviation.</returns>
    public static (double mean, double standardDeviation) GetStandardDeviation(this double[] values)
    {
        double mean = values.Average();
        double sumOfSquaresOfDifferences = values.Select(val => (val - mean) * (val - mean)).Sum();
        double standardDeviation = System.Math.Sqrt(sumOfSquaresOfDifferences / (values.Length - 1));
        return (mean, standardDeviation);
    }

    /// <summary>
    /// Performs linear regression on the given arrays of x and y values.
    /// </summary>
    /// <param name="x">The array of x values.</param>
    /// <param name="y">The array of y values.</param>
    /// <returns>An object containing the slope (m), y-intercept (b), and correlation coefficient (r).</returns>
    public static LinearRegressionModel PerformLinearRegression(this double[] x, double[] y)
    {
        if (x.Length != y.Length)
            throw new ArgumentException("The number of elements in the x array must be equal to the number of elements in the y array.");

        double sumX = x.Sum();
        double sumY = y.Sum();
        double sumXY = x.Zip(y, (a, b) => a * b).Sum();
        double sumX2 = x.Select(a => a * a).Sum();
        double sumY2 = y.Select(a => a * a).Sum();

        double n = x.Length;
        double m = (n * sumXY - sumX * sumY) / (n * sumX2 - sumX * sumX);
        double b = (sumY - m * sumX) / n;
        double r = (n * sumXY - sumX * sumY) / System.Math.Sqrt((n * sumX2 - sumX * sumX) * (n * sumY2 - sumY * sumY));

        return new LinearRegressionModel(m, b, r);
    }

    /// <summary>
    /// Performs linear regression on the given arrays of x and y values.
    /// </summary>
    /// <param name="x">The array of x values.</param>
    /// <param name="y">The array of y values.</param>
    /// <returns>An object containing the slope (m), y-intercept (b), and correlation coefficient (r).</returns>
    public static LinearRegressionModel PerformLinearRegression(this int[] x, int[] y)
    {
        if (x.Length != y.Length)
            throw new ArgumentException("The number of elements in the x array must be equal to the number of elements in the y array.");

        double[] doubleX = x.Select(Convert.ToDouble).ToArray();
        double[] doubleY = y.Select(Convert.ToDouble).ToArray();

        return PerformLinearRegression(doubleX, doubleY);
    }

    /// <summary>
    /// Performs numerical integration using Simpson's rule.
    /// </summary>
    /// <param name="function">The function to integrate.</param>
    /// <param name="a">The lower limit of integration.</param>
    /// <param name="b">The upper limit of integration.</param>
    /// <param name="n">The number of intervals.</param>
    /// <returns>The approximate value of the integral.</returns>
    public static double SimpsonRuleIntegration(Func<double, double> function, double a, double b, int n)
    {
        if (n % 2 != 0)
            throw new ArgumentException("The number of intervals must be even.");

        double h = (b - a) / n;
        double sum = function(a) + function(b);

        for (int i = 1; i < n; i++)
        {
            double x = a + i * h;
            sum += i % 2 == 0 ? 2 * function(x) : 4 * function(x);
        }

        return (h / 3) * sum;
    }

    /// <summary>
    /// Finds the next prime number greater than the specified number.
    /// </summary>
    /// <param name="n">The number to find the next prime number after.</param>
    /// <returns>The next prime number greater than <paramref name="n"/>.</returns>
    public static double NextPrime(this double n)
    {
        if (n < 2)
            return 2;

        if (n == 2)
            return 3;

        double x = System.Math.Floor(n);
        if (x % 2 == 0)
            x--;

        while (true)
        {
            x += 2;
            if (x.IsPrime())
                return x;
        }
    }

    /// <summary>
    /// Finds the next prime number greater than the specified number.
    /// </summary>
    /// <param name="n">The number to find the next prime number after.</param>
    /// <returns>The next prime number greater than <paramref name="n"/>.</returns>
    public static int NextPrime(this int n)
    {
        if (n < 2)
            return 2;

        if (n == 2)
            return 3;

        int x = n;
        if (x % 2 == 0)
            x++;

        while (true)
        {
            x += 2;
            if (x.IsPrime())
                return x;
        }
    }

    /// <summary>
    /// Calculates the percentage of a value relative to another value.
    /// </summary>
    /// <param name="value">The value to calculate the percentage of.</param>
    /// <param name="otherValue">The value to calculate the percentage relative to.</param>
    /// <returns>The percentage of the value relative to the other value.</returns>
    public static double PercentageOf(this double value, double otherValue)
    {
        return value / otherValue * 100;
    }

    /// <summary>
    /// Calculates the percentage of a value relative to another value.
    /// </summary>
    /// <param name="value">The value to calculate the percentage of.</param>
    /// <param name="otherValue">The value to calculate the percentage relative to.</param>
    /// <returns>The percentage of the value relative to the other value.</returns>
    public static double PercentageOf(this int value, int otherValue)
    {
        return value / otherValue * 100;
    }

    /// <summary>
    /// Determines whether the specified value is approximately equal to the other value within the given tolerance.
    /// </summary>
    /// <param name="value">The value to compare.</param>
    /// <param name="otherValue">The other value to compare.</param>
    /// <param name="tolerance">The tolerance within which the values are considered equal.</param>
    /// <returns><c>true</c> if the values are approximately equal; otherwise, <c>false</c>.</returns>
    public static bool IsApproximatelyEqualTo(this double value, double otherValue, double tolerance)
    {
        return System.Math.Abs(value - otherValue) < tolerance;
    }

    /// <summary>
    /// Clamps a value between a minimum and maximum value.
    /// </summary>
    /// <param name="value">The value to clamp.</param>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <returns>The clamped value.</returns>
    public static double Clamp(this double value, double min, double max)
    {
        return System.Math.Min(System.Math.Max(value, min), max);
    }

    /// <summary>
    /// Returns an array of divisors for the given integer.
    /// </summary>
    /// <param name="n">The integer for which to find divisors.</param>
    /// <returns>An array of divisors.</returns>
    public static int[] Divisors(this int n)
    {
        List<int> divisors = new List<int>();
        for (int i = 1; i <= n; i++)
        {
            if (n % i == 0)
                divisors.Add(i);
        }

        return divisors.ToArray();
    }

    /// <summary>
    /// Normalizes a value within a specified range.
    /// </summary>
    /// <param name="value">The value to be normalized.</param>
    /// <param name="min">The minimum value of the range.</param>
    /// <param name="max">The maximum value of the range.</param>
    /// <returns>The normalized value.</returns>
    public static double Normalize(this double value, double min, double max)
    {
        if (min >= max)
        {
            throw new ArgumentException("min must be less than max");
        }
        if (value < min || value > max)
        {
            throw new ArgumentException("value must be between min and max");
        }
        return (value - min) / (max - min); ;
    }

    /// <summary>
    /// Calculates the logarithm of a specified value in a specified base.
    /// </summary>
    /// <param name="value">The value for which to calculate the logarithm.</param>
    /// <param name="n">The base of the logarithm.</param>
    /// <returns>The logarithm of the specified value in the specified base.</returns>
    public static double LogBaseN(this double value, double n)
    {
        if (value > 1)
        {
            throw new ArgumentException("value must be greater than 1");
        }

        return System.Math.Log(value) / System.Math.Log(n);
    }

    /// <summary>
    /// Determines whether the specified value is within the specified range.
    /// </summary>
    /// <param name="value">The value to check.</param>
    /// <param name="min">The minimum value of the range.</param>
    /// <param name="max">The maximum value of the range.</param>
    /// <returns>true if the value is within the range; otherwise, false.</returns>
    public static bool IsInRange(this double value, double min, double max)
    {
        return value >= min && value <= max;
    }

    /// <summary>
    /// Formats a double value as a percentage string.
    /// </summary>
    /// <param name="value">The double value to format.</param>
    /// <param name="decimalPlaces">The number of decimal places to include in the formatted string. Default is 2.</param>
    /// <returns>A string representation of the double value formatted as a percentage.</returns>
    public static string ToStringPercentage(this double value, int decimalPlaces = 2)
    {
        return $"{value.ToString($"F{decimalPlaces}")}%";
    }

    /// <summary>
    /// Converts a number to scientific notation.
    /// </summary>
    /// <param name="number">The number to convert.</param>
    /// <returns>The number in scientific notation.</returns>
    public static string ToScientificNotation(this double number)
    {
        return number.ToString("0.###E+0");
    }

    /// <summary>
    /// Calculates the sum of an arithmetic series up to a given number of terms.
    /// </summary>
    /// <param name="value">The first term of the series.</param>
    /// <param name="n">The number of terms in the series.</param>
    /// <returns>The sum of the arithmetic series.</returns>
    public static double SumTo(this double value, double n)
    {
        return n / 2 * (2 * value + (n - 1) * value);
    }

    /// <summary>
    /// Calculates the sum of an arithmetic series up to a given number of terms.
    /// </summary>
    /// <param name="value">The first term of the series.</param>
    /// <param name="n">The number of terms in the series.</param>
    /// <returns>The sum of the arithmetic series.</returns>
    public static double SumTo(this int value, int n)
    {
        return n / 2 * (2 * value + (n - 1) * value);
    }

    /// <summary>
    /// Inverts the specified value.
    /// </summary>
    /// <param name="value">The value to invert.</param>
    /// <returns>The inverted value.</returns>
    public static double Invert(this double value)
    {
        return 1 / value;
    }

    /// <summary>
    /// Inverts the specified integer value.
    /// </summary>
    /// <param name="value">The value to invert.</param>
    /// <returns>The inverted value.</returns>
    public static double Invert(this int value)
    {
        return 1 / value;
    }

    /// <summary>
    /// Converts the given degrees to a string representation in hours, minutes, and seconds format.
    /// </summary>
    /// <param name="degrees">The degrees to convert.</param>
    /// <returns>A string representation of the degrees in hours, minutes, and seconds format.</returns>
    public static string DegreesToHMSString(this double degrees)
    {
        (int hours, int minutes, double seconds) = DegreesToHMS(degrees);
        return $"{hours}h {minutes}m {seconds.ToString("F2")}s";
    }

    /// <summary>
    /// Converts degrees to hours, minutes, and seconds.
    /// </summary>
    /// <param name="degrees">The degrees to convert.</param>
    /// <returns>A tuple containing the hours, minutes, and seconds.</returns>
    public static (int hours, int minutes, double seconds) DegreesToHMS(double degrees)
    {
        // Ensure the value is in the range [0, 360)
        degrees = degrees % 360;
        if (degrees < 0) degrees += 360;

        // Convert degrees to hours (1 hour = 15 degrees)
        double totalHours = degrees / 15;

        // Extract hours
        int hours = (int)totalHours;

        // Convert the fraction to minutes (1 minute = 1/60 hour)
        double totalMinutes = (totalHours - hours) * 60;
        int minutes = (int)totalMinutes;

        // Convert the fraction to seconds (1 second = 1/60 minute)
        double seconds = (totalMinutes - minutes) * 60;
        return (hours, minutes, seconds);
    }

    /// <summary>
    /// Converts degrees to radians.
    /// </summary>
    /// <param name="degrees">The angle in degrees.</param>
    /// <returns>The angle in radians.</returns>
    public static double DegreesToRadians(this double degrees)
    {
        return degrees * System.Math.PI / 180;
    }

    /// <summary>
    /// Converts an angle from radians to degrees.
    /// </summary>
    /// <param name="radians">The angle in radians.</param>
    /// <returns>The angle in degrees.</returns>
    public static double RadiansToDegrees(this double radians)
    {
        return radians * 180 / System.Math.PI;
    }

    /// <summary>
    /// Calculates the median value of an array of numbers.
    /// </summary>
    /// <param name="numbers">The array of numbers.</param>
    /// <returns>The median value.</returns>
    public static double Median(params double[] numbers)
    {
        Array.Sort(numbers);
        int length = numbers.Length;
        int midIndex = length / 2;

        if (length % 2 == 0)
        {
            return (numbers[midIndex - 1] + numbers[midIndex]) / 2;
        }
        else
        {
            return numbers[midIndex];
        }
    }

    /// <summary>
    /// Calculates the mode value of an array of numbers.
    /// </summary>
    /// <param name="numbers">The array of numbers.</param>
    /// <returns>The mode value.</returns>
    public static double Mode(params double[] numbers)
    {
        Dictionary<double, int> frequency = new Dictionary<double, int>();

        foreach (double number in numbers)
        {
            if (frequency.ContainsKey(number))
            {
                frequency[number]++;
            }
            else
            {
                frequency[number] = 1;
            }
        }

        double mode = 0;
        int maxFrequency = 0;

        foreach (KeyValuePair<double, int> pair in frequency)
        {
            if (pair.Value > maxFrequency)
            {
                mode = pair.Key;
                maxFrequency = pair.Value;
            }
        }

        return mode;
    }

    /// <summary>
    /// Adds two matrices together.
    /// </summary>
    /// <param name="matrix1">The first matrix.</param>
    /// <param name="matrix2">The second matrix.</param>
    /// <returns>The result of the matrix addition.</returns>
    public static double[,] MatrixAddition(double[,] matrix1, double[,] matrix2)
    {
        if (matrix1.GetLength(0) != matrix2.GetLength(0) || matrix1.GetLength(1) != matrix2.GetLength(1))
        {
            throw new ArgumentException("The matrices must have the same dimensions.");
        }

        int rows = matrix1.GetLength(0);
        int columns = matrix1.GetLength(1);
        double[,] result = new double[rows, columns];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                result[i, j] = matrix1[i, j] + matrix2[i, j];
            }
        }

        return result;
    }

    /// <summary>
    /// Performs subtraction of two matrices.
    /// </summary>
    /// <param name="matrix1">The first matrix.</param>
    /// <param name="matrix2">The second matrix.</param>
    /// <returns>The result of the matrix subtraction.</returns>
    public static double[,] MatrixSubtraction(double[,] matrix1, double[,] matrix2)
    {
        if (matrix1.GetLength(0) != matrix2.GetLength(0) || matrix1.GetLength(1) != matrix2.GetLength(1))
        {
            throw new ArgumentException("The matrices must have the same dimensions.");
        }

        int rows = matrix1.GetLength(0);
        int columns = matrix1.GetLength(1);
        double[,] result = new double[rows, columns];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                result[i, j] = matrix1[i, j] - matrix2[i, j];
            }
        }

        return result;
    }

    /// <summary>
    /// Performs matrix multiplication on two double[,] matrices.
    /// </summary>
    /// <param name="matrix1">The first matrix.</param>
    /// <param name="matrix2">The second matrix.</param>
    /// <returns>The result of the matrix multiplication.</returns>
    public static double[,] MatrixMultiplication(double[,] matrix1, double[,] matrix2)
    {
        if (matrix1.GetLength(1) != matrix2.GetLength(0))
        {
            throw new ArgumentException("The number of columns in the first matrix must be equal to the number of rows in the second matrix.");
        }

        int rows = matrix1.GetLength(0);
        int columns = matrix2.GetLength(1);
        double[,] result = new double[rows, columns];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                result[i, j] = 0;
                for (int k = 0; k < matrix1.GetLength(1); k++)
                {
                    result[i, j] += matrix1[i, k] * matrix2[k, j];
                }
            }
        }

        return result;
    }

    /// <summary>
    /// Performs scalar multiplication on a matrix.
    /// </summary>
    /// <param name="matrix">The matrix to be multiplied.</param>
    /// <param name="scalar">The scalar value to multiply the matrix by.</param>
    /// <returns>The result of the matrix scalar multiplication.</returns>
    public static double[,] MatrixScalarMultiplication(double[,] matrix, double scalar)
    {
        int rows = matrix.GetLength(0);
        int columns = matrix.GetLength(1);
        double[,] result = new double[rows, columns];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                result[i, j] = matrix[i, j] * scalar;
            }
        }

        return result;
    }

    /// <summary>
    /// Transposes a matrix.
    /// </summary>
    /// <param name="matrix">The matrix to transpose.</param>
    /// <returns>The transposed matrix.</returns>
    public static double[,] MatrixTranspose(double[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int columns = matrix.GetLength(1);
        double[,] result = new double[columns, rows];

        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                result[i, j] = matrix[j, i];
            }
        }

        return result;
    }

    /// <summary>
    /// Calculates the determinant of a matrix.
    /// </summary>
    /// <param name="matrix">The matrix for which to calculate the determinant.</param>
    /// <returns>The determinant of the matrix.</returns>
    private static double MatrixDeterminant(double[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int columns = matrix.GetLength(1);
        double result = 0;

        if (rows != columns)
        {
            throw new ArgumentException("The matrix must be square.");
        }

        if (rows == 2)
        {
            result = matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
        }
        else
        {
            for (int i = 0; i < rows; i++)
            {
                double[,] subMatrix = new double[rows - 1, columns - 1];
                for (int j = 1; j < rows; j++)
                {
                    for (int k = 0; k < columns; k++)
                    {
                        if (k < i)
                        {
                            subMatrix[j - 1, k] = matrix[j, k];
                        }
                        else if (k > i)
                        {
                            subMatrix[j - 1, k - 1] = matrix[j, k];
                        }
                    }
                }

                result += System.Math.Pow(-1, i) * matrix[0, i] * MatrixDeterminant(subMatrix);
            }
        }

        return result;
    }

    /// <summary>
    /// Represents a type that can hold values of any type.
    /// </summary>
    public static double[,] MatrixInverse(double[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int columns = matrix.GetLength(1);
        double[,] result = new double[rows, columns];

        if (rows != columns)
        {
            throw new ArgumentException("The matrix must be square.");
        }

        double determinant = MatrixDeterminant(matrix);
        if (determinant == 0)
        {
            throw new ArgumentException("The matrix is not invertible.");
        }

        if (rows == 2)
        {
            result[0, 0] = matrix[1, 1];
            result[0, 1] = -matrix[0, 1];
            result[1, 0] = -matrix[1, 0];
            result[1, 1] = matrix[0, 0];
        }
        else
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {

                }
            }
        }

        return MatrixScalarMultiplication(result, 1 / determinant);
    }

    /// <summary>
    /// Returns the maximum of two integers.
    /// </summary>
    /// <param name="number1">The first integer.</param>
    /// <param name="number2">The second integer.</param>
    /// <returns>The maximum of the two integers.</returns>
    public static int Max(int number1, int number2)
    {
        return number1 > number2 ? number1 : number2;
    }

    /// <summary>
    /// Returns the maximum of two doubles.
    /// </summary>
    /// <param name="number1">The first double.</param>
    /// <param name="number2">The second double.</param>
    /// <returns>The maximum of the two doubles.</returns>
    public static double Max(double number1, double number2)
    {
        return number1 > number2 ? number1 : number2;
    }

    /// <summary>
    /// Returns the minimum of two integers.
    /// </summary>
    /// <param name="number1">The first integer.</param>
    /// <param name="number2">The second integer.</param>
    /// <returns>The minimum of the two integers.</returns>
    public static int Min(int number1, int number2)
    {
        return number1 < number2 ? number1 : number2;
    }

    /// <summary>
    /// Returns the minimum of two doubles.
    /// </summary>
    /// <param name="number1">The first double.</param>
    /// <param name="number2">The second double.</param>
    /// <returns>The minimum of the two doubles.</returns>
    public static double Min(double number1, double number2)
    {
        return number1 < number2 ? number1 : number2;
    }
}