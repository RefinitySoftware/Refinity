namespace Refinity.Math
{
    /// <summary>
    /// Represents a linear regression model.
    /// </summary>
    public class LinearRegressionModel
    {
        private double m;
        private double b;
        private double r;

        /// <summary>
        /// Initializes a new instance of the <see cref="LinearRegressionModel"/> class.
        /// </summary>
        /// <param name="m">The slope of the linear regression model.</param>
        /// <param name="b">The intercept of the linear regression model.</param>
        /// <param name="r">The correlation coefficient of the linear regression model.</param>
        public LinearRegressionModel(double m, double b, double r)
        {
            this.m = m;
            this.b = b;
            this.r = r;
        }

        /// <summary>
        /// Gets or sets the slope of the linear regression model.
        /// </summary>
        public double Slope { get; set; }

        /// <summary>
        /// Gets or sets the intercept of the linear regression model.
        /// </summary>
        public double Intercept { get; set; }

        /// <summary>
        /// Gets or sets the correlation coefficient of the linear regression model.
        /// </summary>
        public double Correlation { get; set; }
    }
}
