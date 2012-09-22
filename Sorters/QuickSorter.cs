namespace SortingAlgos.Sorters
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    ///   A Quick Sort sorter.
    /// </summary>
    /// <typeparam name="T"> </typeparam>
    public sealed class QuickSorter<T> : Sorter<T>
    {
        //an arbitrary limit to when we call Selection/Insertion Sort
        const Int32 CutOff = 4;

        /// <summary>
        ///   Sorts the specified list.
        /// </summary>
        /// <param name="list"> The list. </param>
        /// <param name="comparer"> The comparer to use in comparing items. </param>
        public override void Sort(IList<T> list, IComparer<T> comparer)
        {
            if (null == list) throw new ArgumentNullException("list");
            if (null == comparer) throw new ArgumentNullException("comparer");
            if (1 >= list.Count) return;

            var beg = 0;
            var end = list.Count - 1;
            QuickSort(list, beg, end, comparer);
        }

        static void QuickSort(IList<T> list, int beg, int end, IComparer<T> comparer)
        {
            if (beg < 0) beg = 0;
            if (end >= list.Count) end = list.Count - 1;
            if (beg > end) beg = end;
            if (beg < end)
                if (end - beg <= CutOff)
                    if (end - beg + 1 <= 3)
                        // manual sort if data <= 3
                        ManualSort(list, beg, end, comparer);
                    else
                        //SelectionSorter<T>.Sort(list, beg, end, 1, comparer);
                        InsertionSorter<T>.Sort(list, beg, end, 1, comparer);
                else
                {
                    var pivot = GetPivot(list, beg, end, comparer);
                    QuickSort(list, beg, pivot - 1, comparer);
                    QuickSort(list, pivot + 1, end, comparer);
                }
        }

        static int GetPivot(IList<T> list, int beg, int end, IComparer<T> comparer)
        {
            var mid = (beg + end) >> 1;
            if (comparer.Compare(list[beg], list[end]) < 0)
                Swap(list, beg, end);
            if (comparer.Compare(list[mid], list[end]) < 0)
                Swap(list, mid, end);
            if (comparer.Compare(list[beg], list[mid]) > 0)
                Swap(list, beg, mid);
            var pivotIndex = beg;
            var pivot = list[pivotIndex];
            for (var index = beg + 1; index <= end; ++index)
                if (comparer.Compare(list[index], pivot) < 0)
                {
                    ++pivotIndex;
                    Swap(list, pivotIndex, index);
                }
            Swap(list, beg, pivotIndex);
            return pivotIndex;
        }

        // for size <= 3
        static void ManualSort(IList<T> list, int beg, int end, IComparer<T> comparer)
        {
            var size = end - beg + 1;
            switch (size)
            {
                case 1:
                    break;
                case 2: // 2-sort left & right
                    if (comparer.Compare(list[beg], list[end]) > 0)
                        Swap(list, beg, end);
                    break;
                case 3: // 3-sort left, center, right
                    var mid = (beg + end) >> 1;
                    if (comparer.Compare(list[beg], list[mid]) > 0)
                        Swap(list, beg, mid); // left, center
                    if (comparer.Compare(list[beg], list[end]) > 0)
                        Swap(list, beg, end); // left, right
                    if (comparer.Compare(list[mid], list[end]) > 0)
                        Swap(list, mid, end); // center, right
                    break;
            }
        }

    }
}