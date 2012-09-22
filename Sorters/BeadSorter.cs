namespace SortingAlgos.Sorters
{
    using System;
    using System.Collections.Generic;

    public sealed class BeadSorter : Sorter<int>
    {
        private readonly int _max;

        public BeadSorter(int max)
        {
            _max = max;
        }

        public override void Sort(IList<int> list, IComparer<int> comparer)
        {
            if (null == list) throw new ArgumentNullException("list");
            if (null == comparer) throw new ArgumentNullException("comparer");
            if (1 >= list.Count) return;

            var beg = 0;
            var end = list.Count - 1;
            Sort(list, beg, end, _max);
        }

        public static void Sort(IList<int> list, int beg, int end, int max)
        {
            if (beg < 0) beg = 0;
            if (end >= list.Count) end = list.Count - 1;
            if (beg > end) beg = end;

            var buckets = new int[max];

            var index = beg;
            for (; index <= end; ++index)
            {
                ++buckets[list[index]];
            }

            index = beg;
            for (var value = 0; (value < max) && (index <= end); ++value)
            {
                Fill(list, index, index + buckets[value], value);
                ////for (var i = buckets[value]; i > 0; --i)
                //for (var i = 0; i < buckets[value]; ++i)
                //{
                //    list[index] = value;
                //    ++index;
                //}
            }
        }

    }
}