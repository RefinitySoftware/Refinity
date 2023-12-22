using Refinity.Math;

try
{
    // var result = 10.20.Normalize(0, 20);
    var percentage = 10.PercentageOf(100);
    Console.WriteLine(percentage);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}