using Refinity.Logging;
using Refinity.Strings;
using Refinity.Math;

public static partial class Program
{
    public static void Main()
    {
        try
        {
            string htmlTest = "<html><head><title>Test </title></head> <body><h1> Test</h1></body></html>";
            var result = htmlTest.RemoveHTMLTags().RemoveWhitespace();
            Console.WriteLine(200.0.DegreesToHMSString());
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
