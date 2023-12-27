using Refinity.Math;
using Refinity.Finance;

double start = 1020.0;
double end = 1000.0;
double difference = start.DifferencePercentage(end);
string diffString = difference.ToStringPercentage();
Console.WriteLine(diffString);
Console.WriteLine(difference);