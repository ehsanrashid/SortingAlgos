/*
 * Adapted from CSSorters : http://web6.codeproject.com/cs/algorithms/cssorters.asp
 */

namespace SortingAlgos.Sorters
{
    using System;
    using System.Collections.Generic;

    public sealed class MergeSorter<T> : Sorter<T>
    {
        public override void Sort(IList<T> list, IComparer<T> comparer)
        {
            if (null == list) throw new ArgumentNullException("list");
            if (null == comparer) throw new ArgumentNullException("comparer");
            if (1 >= list.Count) return;

            var beg = 0;
            var end = list.Count - 1;
            MergeSort(list, beg, end, comparer);
        }

        static void MergeSort(IList<T> list, int beg, int end, IComparer<T> comparer)
        {
            if (0 > beg) beg = 0;
            if (end >= list.Count) end = list.Count - 1;
            if (beg > end) beg = end;
            if (beg >= end) return;
            var mid = (beg + end) >> 1;
            MergeSort(list, beg, mid, comparer);
            MergeSort(list, mid + 1, end, comparer);
            Merge(list, beg, mid, end, comparer);
        }

        static void Merge(IList<T> list, int beg, int mid, int end, IComparer<T> comparer)
        {
            while ((mid + 1) <= end && beg <= mid)
            {
                if (comparer.Compare(list[beg], list[mid + 1]) < 0)
                    ++beg;
                else
                {
                    var currentItem = list[mid + 1];
                    for (var curr = mid; curr >= beg; --curr)
                        list[curr + 1] = list[curr];
                    list[beg] = currentItem;
                    ++beg;
                    ++mid;
                }
            }
        }
    }
}