using Microsoft.ML.Data;

public class CustomModel
{
    [LoadColumn(0)]
    public int Years_of_Experience { get; set; }
    [LoadColumn(1)]
    public int Age { get; set; }
    [LoadColumn(2)]
    public string Education_Level { get; set; }
    [LoadColumn(3)]
    public string Location { get; set; }
    [LoadColumn(4)]
    public double Salary { get; set; }
}
