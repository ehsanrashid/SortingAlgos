namespace SortingAlgos.Sorters
{
    using System;
    using System.Collections.Generic;

    public sealed class CountingSorter : Sorter<int>
    {
        public override void Sort(IList<int> list, IComparer<int> comparer)
        {
            if (null == list) throw new ArgumentNullException("list");
            if (null == comparer) throw new ArgumentNullException("comparer");
            if (1 >= list.Count) return;

            var beg = 0;
            var end = list.Count - 1;
            Sort(list, beg, end, comparer);
        }

        public static void Sort(IList<int> list, int beg, int end, IComparer<int> comparer)
        {
            if (beg < 0) beg = 0;
            if (end >= list.Count) end = list.Count - 1;
            if (beg > end) beg = end;
            // T = int
            int minValue, maxValue;
            FindMinMaxValues(list, beg, end, comparer, out minValue, out maxValue);
            var size = maxValue - minValue + 1;
            var counts = new int[size];
            CountValues(list, counts, beg, end, minValue);
            // --------------------------------------------
            PlaceValues(list, counts, beg, end, minValue);
            // --------------------------------------------
            //ScratchFill(list, counts, beg, end, minValue);
            // --------------------------------------------
        }

        static void CountValues(IList<int> list, IList<int> counts, int beg, int end, int minValue)
        {
            for (var index = beg; index <= end; ++index)
                ++counts[list[index] - minValue];
        }

        static void PlaceValues(IList<int> list, IList<int> counts, int beg, int end, int minValue)
        {
            var index = beg;
            // --------------------------------------------
            //var value = minValue; // T
            //while (index <= end)  // (value <= maxValue)
            //{
            //    while (counts[value - minValue]-- > 0)
            //    {
            //        list[index++] = value;
            //    }
            //    ++value;
            //}
            // --------------------------------------------
            //for (var i = 0; i < counts.Count; ++i)
            //{
            //    while (counts[i]-- > 0)
            //    {
            //        list[index++] = minValue++;
            //    }
            //}
            // --------------------------------------------
            foreach (var cnt in counts)
            {
                if (cnt > 0)
                {
                    Fill(list, index, index + cnt, minValue);
                    index += cnt;
                }
                ++minValue;
            }
            // --------------------------------------------
        }

/*
        static void ScratchFill(IList<int> list, IList<int> counts, int beg, int end, int minValue)
        {
            var size = counts.Count;
            for (var i = 1; i < size; ++i)
                counts[i] += counts[i - 1];
            var scratch = new List<int>(list);
            //for (var index = end; index >= beg; --index)
            for (var index = beg; index <= end; ++index)
                scratch[--counts[list[index] - minValue]] = list[index];
            for (var index = beg; index <= end; ++index)
                list[index] = scratch[index];
        }
*/

    }
}