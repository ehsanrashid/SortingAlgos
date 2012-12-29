namespace SortingAlgos.Sorters
{
    using System;
    using System.Collections.Generic;

    public sealed class OddEvenTransportSorter<T> : Sorter<T>
    {
        public override void Sort(IList<T> list, IComparer<T> comparer)
        {
            if (null == list) throw new ArgumentNullException("list");
            if (null == comparer) throw new ArgumentNullException("comparer");
            if (1 >= list.Count) return;

            var beg = 0;
            var end = list.Count - 1;
            Sort(list, beg, end, comparer);
        }

        static void Sort(IList<T> list, int beg, int end, IComparer<T> comparer)
        {
            if (beg < 0) beg = 0;
            if (end >= list.Count) end = list.Count - 1;
            if (beg > end) beg = end;
            var size = end - beg + 1;
            for (var i = 0; i < size/2; ++i)
            {
                var swapped = false;
                int oeindex;
                for (oeindex = beg; oeindex + 1 <= end; oeindex += 2)
                    if (comparer.Compare(list[oeindex], list[oeindex + 1]) > 0)
                    {
                        Swap(list, oeindex, oeindex + 1);
                        swapped = true;
                    }
                for (oeindex = beg + 1; oeindex + 1 <= end; oeindex += 2)
                    if (comparer.Compare(list[oeindex], list[oeindex + 1]) > 0)
                    {
                        Swap(list, oeindex, oeindex + 1);
                        swapped = true;
                    }
                if (!swapped)
                    break;
            }
        }
    }
}