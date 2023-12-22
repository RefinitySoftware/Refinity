using Refinity.Math;

try
{
    // var result = 10.20.Normalize(0, 20);
    var percentage = 10000050.0.ToScientificNotation();
    Console.WriteLine(percentage);
    var mode = MathUtility.Mode(1, 2, 3, 4, 5, 5, 6, 6, 7, 8, 9);
    Console.WriteLine(mode);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}