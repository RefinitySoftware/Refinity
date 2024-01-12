using System;
using System.Collections.ObjectModel;
using System.Linq;
using Refinity.Collections.Models;
using Refinity.Strings;

namespace Refinity.Collections
{
    /// <summary>
    /// Provides utility methods for working with collections.
    /// </summary>
    public static class CollectionsUtility
    {
        /// <summary>
        /// Sorts an array in ascending order using the IComparable interface.
        /// </summary>
        /// <typeparam name="T">The type of elements in the array.</typeparam>
        /// <param name="array">The array to be sorted.</param>
        /// <param name="ascending">Whether to sort in ascending order.</param>
        public static T[] SortArray<T>(T[] array, bool ascending = false) where T : IComparable<T>
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    int comparisonResult = array[i].CompareTo(array[j]);
                    if ((comparisonResult > 0 && ascending) || (comparisonResult < 0 && !ascending))
                    {
                        T temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
            return array;
        }

        private static bool ChecksForArrayAnalysis<T>(T[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }
            if (array.Length == 0)
            {
                throw new ArgumentException("The array must contain at least one element.", nameof(array));
            }
            if (array.Length == 1)
            {
                throw new ArgumentException("The array must contain at least two elements.", nameof(array));
            }
            if (array is not double[] && array is not int[] && array is not float[] && array is not long[] && array is not short[] && array is not decimal[] && array is not byte[] && array is not sbyte[] && array is not uint[] && array is not ulong[] && array is not ushort[])
            {
                throw new ArgumentException("The array must contain numeric elements.", nameof(array));
            }
            return true;
        }

        /// <summary>
        /// Analyzes a collection of array.
        /// </summary>
        /// <param name="array">The collection to be analyzed.</param>
        /// <returns>A CollectionsAnalysisResult object containing the results of the analysis.</returns>

        public static CollectionsAnalysisResult AnalyzeArray<T>(this T[] array) where T : IComparable<T>
        {
            CollectionsAnalysisResult result = new CollectionsAnalysisResult();
            if (ChecksForArrayAnalysis(array))
            {
                // Sort the array
                T[] sortedArray = SortArray(array, true);
                result.Sorted = sortedArray;
                // Get the min and max
                result.Min = Convert.ToDouble(sortedArray[0]);
                result.Max = Convert.ToDouble(sortedArray[sortedArray.Length - 1]);

                // Get the sum
                result.Sum = 0;
                foreach (T item in sortedArray)
                {
                    result.Sum += Convert.ToDouble(item.ToString());
                }

                // Get the average
                result.Average = result.Sum / sortedArray.Length;

                // Get the median
                if (sortedArray.Length % 2 == 0)
                {
                    result.Median = Convert.ToDouble(sortedArray[sortedArray.Length / 2]) + Convert.ToDouble(sortedArray[(sortedArray.Length / 2) - 1]) / 2;
                }
                else
                {
                    result.Median = Convert.ToDouble(sortedArray[sortedArray.Length / 2]);
                }

                // Get the mode
                result.Mode = Convert.ToDouble(sortedArray.GroupBy(x => x).OrderByDescending(x => x.Count()).First().Key);
            }

            return result;
        }
    }
}