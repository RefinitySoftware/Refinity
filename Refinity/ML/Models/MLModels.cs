namespace Refinity.ML.Models;

public class MLModels{
    public MLModels(string[] features, string labelColumnName, string featureColumnName, string outputColumnName, string inputColumnName, string scoreColumnName)
    {
        Features = features;
        LabelColumnName = labelColumnName;
        FeatureColumnName = featureColumnName;
        OutputColumnName = outputColumnName;
        InputColumnName = inputColumnName;
        ScoreColumnName = scoreColumnName;
    }
    public string[] Features { get; set; }
    public string LabelColumnName { get; set; }
    public string FeatureColumnName { get; set; }
    public string OutputColumnName { get; set; }
    public string InputColumnName { get; set; }
    public string ScoreColumnName { get; set; }

}