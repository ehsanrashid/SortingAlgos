namespace SortingAlgos.Sorters
{
    using System;
    using System.Collections.Generic;

    public sealed class GnomeSorter<T> : Sorter<T>
    {
        public override void Sort(IList<T> list, IComparer<T> comparer)
        {
            if (null == list) throw new ArgumentNullException("list");
            if (null == comparer) throw new ArgumentNullException("comparer");
            if (1 >= list.Count) return;

            var beg = 0;
            var end = list.Count - 1;
            var step = 1;

            Sort(list, beg, end, step, comparer);
        }

        public static void Sort(IList<T> list, int beg, int end, int step, IComparer<T> comparer)
        {
            if (0 > beg) beg = 0;
            if (end >= list.Count) end = list.Count - 1;
            if (beg > end) beg = end;
            if (step <= 0) step = 1;

            var index = beg + step;
            var last = 0;
            while (index <= end)
            {
                if (comparer.Compare(list[index - step], list[index]) <= 0)
                {
                    if (last != 0)
                    {
                        index = last;
                        last = 0;
                    }
                    index += step;
                }
                else
                {
                    Swap(list, index - step, index);

                    if (index > beg + step)
                    {
                        if (last == 0)
                            last = index;
                        index -= step;
                    }
                    else
                    {
                        index += step;
                    }
                }
            }
        }
    }
}