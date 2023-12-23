
using Microsoft.ML;
using Refinity.ML.Models;

namespace Refinity.ML;

public static class MLUtility{
    /// <summary>
    /// Trains a linear regression model using the specified CSV dataset and ML model configuration.
    /// </summary>
    /// <typeparam name="T">The type of the input data.</typeparam>
    /// <param name="pathToCSVDataset">The path to the CSV dataset file.</param>
    /// <param name="mLModel">The ML model configuration.</param>
    public static void LinearRegressionModel<T>(string pathToCSVDataset, MLModels mLModel){
        // Create MLContext to be shared across the model creation workflow objects 
        // Set a random seed for repeatable/deterministic results across multiple trainings.
        MLContext mlContext = new MLContext(seed: 1);

        // STEP 1: Common data loading configuration
        var trainingDataView = mlContext.Data.LoadFromTextFile<T>(pathToCSVDataset, hasHeader: true, separatorChar: ',');

        // STEP 2: Common data process configuration with pipeline data transformations
        var dataProcessPipeline = mlContext.Transforms.Concatenate(mLModel.FeatureColumnName, mLModel.Features);
        
        // STEP 3: Set the training algorithm, then create and config the modelBuilder                            
        var trainer = mlContext.Regression.Trainers.Sdca(labelColumnName: mLModel.LabelColumnName, featureColumnName: mLModel.FeatureColumnName);
        var trainingPipeline = dataProcessPipeline.Append(trainer);

        // STEP 4: Train the model fitting to the DataSet
        ITransformer trainedModel = trainingPipeline.Fit(trainingDataView);

        // STEP 5: Evaluate the model and show accuracy stats
        var predictions = trainedModel.Transform(trainingDataView);
        var metrics = mlContext.Regression.Evaluate(predictions, labelColumnName: mLModel.LabelColumnName, scoreColumnName: mLModel.ScoreColumnName);

        Console.WriteLine($"*************************************************");
        Console.WriteLine($"*       Model quality metrics evaluation         ");
        Console.WriteLine($"*------------------------------------------------");
        Console.WriteLine($"*       RSquared Score:      {metrics.RSquared:0.##}");
        Console.WriteLine($"*       Root Mean Squared Error:      {metrics.RootMeanSquaredError:#.##}");
    }
}