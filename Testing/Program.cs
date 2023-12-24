using Refinity.Logging;
using Refinity.Strings;
using Refinity.Math;

try
{
    var dateTime = "2000-01-18".ToDateTime();
    if (dateTime.HasValue)
    {
        // var dateRange = DateUtility.GetDateRangeFromWeekNumber(12);
        // var age = dateTime.Value.CalculateAge();
        // Console.WriteLine(age);
        // Console.WriteLine(5.Factorial());
        // var hex = 10.Fibonacci();
        // Console.WriteLine(hex);
        // int[] lista = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        // var std = lista.GetStandardDeviation();
        // Console.WriteLine(std.mean);
        // Console.WriteLine(std.standardDeviation);
        DateTime date = DateTime.Now;
        Console.WriteLine(date.SerializeDateTime());
    }
    else
    {
        Console.WriteLine("Invalid date format.");
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}