namespace Refinity.Math;

public class LinearRegressionModel
{
    private double m;
    private double b;
    private double r;

    public LinearRegressionModel(double m, double b, double r)
    {
        this.m = m;
        this.b = b;
        this.r = r;
    }

    public double Slope { get; set; }
    public double Intercept { get; set; }
    public double Correlation { get; set; }
}
