using System.Globalization;
using Refinity.ML;
using Refinity.ML.Models;
using Refinity.Math;

public static partial class Program
{
    public static void Main()
    {
        try
        {
            string[] features = {"Years_of_Experience","Age","Education_Level","Location","Salary"};
            string labelColumnName = "Salary";
            string featureColumnName = "Features";
            string outputColumnName = "Salary";
            string inputColumnName = "Features";
            string scoreColumnName = "Score";
            MLModels mLModels = new MLModels(features, labelColumnName, featureColumnName, outputColumnName, inputColumnName, scoreColumnName);
            MLUtility.LinearRegressionModel<CustomModel>(@"C:\Users\gasto\Desktop\Progetti\Refinity\Testing\data\salary_regression_dataset.csv", mLModels);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static int testMethod()
    {
        return 10.Factorial();
    }
}
