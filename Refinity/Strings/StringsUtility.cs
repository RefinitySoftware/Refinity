using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Refinity.Strings;

/// <summary>
/// Provides utility methods for manipulating strings.
/// </summary>
public static class StringsUtility
{
    /// <summary>
    /// Removes all whitespace characters from the input string.
    /// </summary>
    /// <param name="input">The string to remove whitespace from.</param>
    /// <returns>A new string with all whitespace characters removed.</returns>
    public static string RemoveWhitespace(this string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            throw new ArgumentException("Input string cannot be null or empty.");
        }
        else
        {
            return new string(input.ToCharArray()
                .Where(c => !char.IsWhiteSpace(c))
                .ToArray());
        }
    }

    /// <summary>
    /// Removes tabs and optionally new lines from a string.
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <param name="removeNewLines">A boolean value indicating whether to remove new lines.</param>
    /// <returns>The modified string with tabs and new lines removed.</returns>
    public static string RemoveTabs(this string input, bool removeNewLines)
    {
        if (removeNewLines)
        {
            return new string(input.ToCharArray()
                .Where(c => !char.IsWhiteSpace(c) && !char.IsControl(c))
                .ToArray());
        }
        else
        {
            return new string(input.ToCharArray()
                .Where(c => !char.IsWhiteSpace(c))
                .ToArray());
        }
    }

    /// <summary>
    /// Removes HTML tags from a string.
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <returns>The string with HTML tags removed.</returns>
    public static string RemoveHTMLTags(this string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            throw new ArgumentException("Input string cannot be null or empty.");
        }
        else
        {
            return Regex.Replace(input, "<.*?>", string.Empty);
        }
    }

    /// <summary>
    /// Reverses the characters in a string.
    /// </summary>
    /// <param name="input">The string to be reversed.</param>
    /// <returns>The reversed string.</returns>
    public static string Reverse(this string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            throw new ArgumentException("Input string cannot be null or empty.");
        }
        char[] charArray = input.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    /// <summary>
    /// Truncates a string to the specified maximum length.
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <param name="maxLength">The maximum length to truncate the string.</param>
    /// <returns>The truncated string.</returns>
    public static string Truncate(this string input, int maxLength)
    {
        if (string.IsNullOrEmpty(input))
        {
            throw new ArgumentException("Input string cannot be null or empty.");
        }
        else if (maxLength < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(maxLength), "The maximum length cannot be less than zero.");
        }

        if (input.Length <= maxLength)
        {
            return input;
        }
        else
        {
            return input[..maxLength];
        }
    }

    /// <summary>
    /// Determines whether a string is a palindrome.
    /// </summary>
    /// <param name="input">The string to check.</param>
    /// <returns>True if the string is a palindrome; otherwise, false.</returns>
    public static bool IsPalindrome(this string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            throw new ArgumentException("Input string cannot be null or empty.");
        }
        string reversed = input.Reverse();
        return input.Equals(reversed, StringComparison.OrdinalIgnoreCase);
    }

    /// <summary>
    /// Splits a camel case string into an array of strings.
    /// </summary>
    /// <param name="input">The camel case string to split.</param>
    /// <returns>An array of strings representing the split camel case string.</returns>
    public static string[] SplitCamelCase(this string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            throw new ArgumentException("Input string cannot be null or empty.");
        }
        return Regex.Split(input, @"(?<!^)(?=[A-Z])");
    }

    /// <summary>
    /// Converts the specified string to title case.
    /// </summary>
    /// <param name="input">The string to convert.</param>
    /// <returns>The specified string converted to title case.</returns>
    public static string ToPascalCase(this string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            throw new ArgumentException("Input string cannot be null or empty.");
        }
        return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
    }

    /// <summary>
    /// Converts a string to its Base64 representation.
    /// </summary>
    /// <param name="text">The string to convert.</param>
    /// <returns>The Base64 representation of the input string.</returns>
    public static string ToBase64(this string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            throw new ArgumentException("Input string cannot be null or empty.");
        }
        byte[] textBytes = Encoding.UTF8.GetBytes(text);
        return Convert.ToBase64String(textBytes);
    }

    /// <summary>
    /// Converts a base64 encoded string to its original UTF-8 representation.
    /// </summary>
    /// <param name="base64">The base64 encoded string to convert.</param>
    /// <returns>The original UTF-8 representation of the base64 encoded string.</returns>
    public static string FromBase64(this string base64)
    {
        if (string.IsNullOrEmpty(base64))
        {
            throw new ArgumentException("Input string cannot be null or empty.");
        }
        byte[] base64Bytes = Convert.FromBase64String(base64);
        return Encoding.UTF8.GetString(base64Bytes);
    }

    /// <summary>
    /// Converts a string to its Base64 representation using the specified encoding.
    /// </summary>
    /// <param name="text">The string to convert.</param>
    /// <param name="encoding">The encoding to use.</param>
    /// <returns>The Base64 representation of the input string.</returns>
    public static string ToBase64(this string text, Encoding encoding)
    {
        if (string.IsNullOrEmpty(text))
        {
            throw new ArgumentException("Input string cannot be null or empty.");
        }
        byte[] textBytes = encoding.GetBytes(text);
        return Convert.ToBase64String(textBytes);
    }

    /// <summary>
    /// Converts a Base64 encoded string to its original form using the specified encoding.
    /// </summary>
    /// <param name="base64">The Base64 encoded string to convert.</param>
    /// <param name="encoding">The encoding to use for decoding the Base64 string.</param>
    /// <returns>The original string represented by the Base64 encoded string.</returns>
    public static string FromBase64(this string base64, Encoding encoding)
    {
        if (string.IsNullOrEmpty(base64))
        {
            throw new ArgumentException("Input string cannot be null or empty.");
        }
        byte[] base64Bytes = Convert.FromBase64String(base64);
        return encoding.GetString(base64Bytes);
    }
}