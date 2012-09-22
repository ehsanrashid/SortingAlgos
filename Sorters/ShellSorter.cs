namespace SortingAlgos.Sorters
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    ///   A sorter that implements the Shell Sort algorithm.
    /// </summary>
    /// <typeparam name="T"> </typeparam>
    public sealed class ShellSorter<T> : Sorter<T>
    {
        /// <summary>
        ///   Sorts the specified list.
        /// </summary>
        /// <param name="list"> The list. </param>
        /// <param name="comparer"> The comparer to use in comparing items. </param>
        public override void Sort(IList<T> list, IComparer<T> comparer)
        {
            if (null == list) throw new ArgumentNullException("list");
            if (null == comparer) throw new ArgumentNullException("comparer");
            var beg = 0;
            var end = list.Count - 1;
            Sort(list, comparer, beg, end);
        }

        public static void Sort(IList<T> list, IComparer<T> comparer, int beg, int end)
        {
            if (0 > beg) beg = 0;
            if (end >= list.Count) end = list.Count - 1;
            if (beg > end) beg = end;
            var delta = end - beg + 1; // Count
            do
            {
                delta = (delta/3) + 1;
                //delta = (delta < 5) ? 1 : (5 * delta - 1) / 11;
                for (var del = 0; del < delta; ++del)
                    //(new BubbleSorter<T>()).Sort(list, beg + del, end, delta, comparer);
                    InsertionSorter<T>.Sort(list, beg + del, end, delta, comparer);
            } while (delta > 1);
        }
    }
}