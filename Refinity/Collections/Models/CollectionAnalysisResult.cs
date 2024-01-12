using System;
using Refinity.Enums;

namespace Refinity.Collections.Models
{
    /// <summary>
    /// Represents the result of a collection analysis.
    /// </summary>
    public class CollectionsAnalysisResult
    {
        /// <summary>
        /// Gets or sets the sorted array.
        /// </summary>
        public dynamic? Sorted { get; set; }
        /// <summary>
        /// Gets or sets the maximum value in the collection.
        /// </summary>
        public double Max { get; set; }

        /// <summary>
        /// Gets or sets the minimum value in the collection.
        /// </summary>
        public double Min { get; set; }

        /// <summary>
        /// Gets or sets the sum of all values in the collection.
        /// </summary>
        public double Sum { get; set; }

        /// <summary>
        /// Gets or sets the average value of the collection.
        /// </summary>
        public double Average { get; set; }

        /// <summary>
        /// Gets or sets the median value of the collection.
        /// </summary>
        public double Median { get; set; }

        /// <summary>
        /// Gets or sets the mode value of the collection.
        /// </summary>
        public double Mode { get; set; }
    }
}