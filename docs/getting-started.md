# 🌟 Getting Started with Refinity

Welcome to your first steps with Refinity, your go-to library for enhancing your C# coding experience! Let's dive into how to get Refinity set up and explore its capabilities through hands-on examples. 🎉

## Initializing Refinity in Your Project 🔨

Include Refinity in your project like so:

```cs
using Refinity;
```

## Usage Examples 📖

Here are various examples to showcase the power and versatility of Refinity in action.

### String Enhancements

```cs
using Refinity.Strings;

class Program
{
    static void Main()
    {
        string htmlString = "<p>This is a <b>bold</b> paragraph.</p>";
        string result = htmlString.RemoveHTMLTags();

        Console.WriteLine("Original String: " + htmlString); // <p>This is a <b>bold</b> paragraph.</p>
        Console.WriteLine("String after removing HTML tags: " + result); // This is a bold paragraph.
    }
}
```

### Date Operations

```cs
using Refinity.Date;

class Program
{
    static void Main()
    {
        DateTime date = new DateTime(2023, (int)EnumMonths.June, 10);
        date.GetWeekNumber(); // 20
    }
}
```

### Advanced Use Cases

```cs
using Refinity.Finance;
using Refinity.Math;

class Program
{
    static void Main()
    {
        int value1 = 50;
        int value2 = 30;

        double differencePercentage = value1.DifferencePercentage(value2);

        Console.WriteLine($"The percentage difference between {value1} and {value2} is: {differencePercentage}%");  // 66,66666666666666%
        differencePercentage = differencePercentage.ToStringPercentage(); // 66,67%
    }
}
```

## Troubleshooting Tips 🛠️

Running into issues? Here's a quick guide to common problems and their solutions.

## Additional Resources 📚

For more detailed tutorials, visit our [documentation](../api/Refinity.html).

## Community and Support 🤗

Connect with our community on platforms like [GitHub](https://github.com/InfinitySoftware-House/Refinity) for support, sharing, and contributions.

Let Refinity elevate your coding journey! 💻
