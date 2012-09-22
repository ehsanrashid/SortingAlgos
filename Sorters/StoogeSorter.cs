namespace SortingAlgos.Sorters
{
    using System;
    using System.Collections.Generic;

    public sealed class StoogeSorter<T> : Sorter<T>
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
            if (list.Count <= 1)
                return;
            var beg = 0;
            var end = list.Count - 1;
            Sort(list, beg, end, comparer);
        }

        public static void Sort(IList<T> list, int beg, int end, IComparer<T> comparer)
        {
            if (beg < 0) beg = 0;
            if (end >= list.Count) end = list.Count - 1;
            if (beg > end) beg = end;
            if (comparer.Compare(list[beg], list[end]) > 0)
                Swap(list, beg, end);
            var size = end - beg + 1;

            if (size >= 3)
            {
                var trd = size/3;
                Sort(list, beg, end - trd, comparer);
                Sort(list, beg + trd, end, comparer);
                Sort(list, beg, end - trd, comparer);
            }
        }

    }
}