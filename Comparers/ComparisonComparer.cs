namespace SortingAlgos.Sorters.Comparers
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    ///   A Comparer using a Comparison delegate for comparisons between items.
    /// </summary>
    /// <typeparam name="T"> </typeparam>
    public sealed class ComparisonComparer<T> : IComparer<T>
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="ComparisonComparer&lt;T&gt;" /> class.
        /// </summary>
        /// <param name="comparison"> The comparison. </param>
        public ComparisonComparer(Comparison<T> comparison)
        {
            if (comparison == null)
                throw new ArgumentNullException("comparison");
            _comparison = comparison;
        }

        Comparison<T> _comparison;

        /// <summary>
        ///   Gets or sets the comparison used in this comparer.
        /// </summary>
        /// <value> The comparison used in this comparer. </value>
        public Comparison<T> Comparison
        {
            get { return _comparison; }
            set
            {
                if (null == value) throw new ArgumentNullException("value");
                _comparison = value;
            }
        }

        #region IComparer<T> Members
        /// <summary>
        ///   Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        /// <param name="x"> The first object to compare. </param>
        /// <param name="y"> The second object to compare. </param>
        /// <returns> Value Condition Less than zerox is less than y.Zerox equals y.Greater than zerox is greater than y. </returns>
        public int Compare(T x, T y)
        {
            return _comparison.Invoke(x, y);
        }
        #endregion
    }
}