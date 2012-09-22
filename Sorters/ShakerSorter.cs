namespace SortingAlgos.Sorters
{
    using System;
    using System.Collections.Generic;

    public sealed class ShakerSorter<T> : Sorter<T>
    {
        public override void Sort(IList<T> list, IComparer<T> comparer)
        {
            if (null == list) throw new ArgumentNullException("list");
            if (null == comparer) throw new ArgumentNullException("comparer");
            if (list.Count <= 1) return;
            var beg = 0;
            var end = list.Count - 1;
            Sort(list, beg, end, comparer);
        }

        public static void Sort(IList<T> list, int beg, int end, IComparer<T> comparer)
        {
            if (0 > beg) beg = 0;
            if (end >= list.Count) end = list.Count - 1;
            if (beg > end) beg = end;

            while (beg < end)
            {
                // -------------------------------------------------
                //var min = beg;
                //var max = beg;
                //for (var cnt = beg + 1; cnt <= end; ++cnt)
                //{
                //    if (comparer.Compare(list[cnt], list[min]) < 0)
                //        min = cnt;
                //    if (comparer.Compare(list[cnt], list[max]) > 0)
                //        max = cnt;
                //}
                // -------------------------------------------------
                var min = beg;
                var max = end;
                for (var cnt = 1; cnt <= end - beg; ++cnt)
                {
                    if (comparer.Compare(list[beg + cnt], list[min]) < 0)
                        min = beg + cnt;
                    if (comparer.Compare(list[end - cnt], list[max]) > 0)
                        max = end - cnt;
                }
                // -------------------------------------------------
                //Swap(list, min, beg);
                //Swap(list, (max == beg) ? min : max, end);
                if (max == beg && min == end)
                    Swap(list, min, max);
                else if (max == beg)
                {
                    Swap(list, max, end);
                    Swap(list, min, beg);
                }
                else
                {
                    Swap(list, min, beg);
                    Swap(list, max, end);
                }
                ++beg;
                --end;
            }
        }
    }
}