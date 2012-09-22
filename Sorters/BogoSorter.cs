namespace SortingAlgos.Sorters
{
    using System;
    using System.Collections.Generic;

    public sealed class BogoSorter<T> : Sorter<T>
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

        public static void Sort(IList<T> list, int beg, int end, IComparer<T> comparer)
        {
            while (!IsSorted(list, beg, end, comparer))
                Shuffle(list, beg, end);
        }

        static bool IsSorted(IList<T> list, int beg, int end, IComparer<T> comparer)
        {
            if (beg < 0) beg = 0;
            if (end >= list.Count) end = list.Count - 1;
            if (beg > end) beg = end;
            var size = end - beg + 1;
            if (size <= 1) return true;
            for (var index = beg + 1; index <= end; ++index)
                if (comparer.Compare(list[index - 1], list[index]) > 0)
                    return false;
            return true;
        }

        static void Shuffle(IList<T> list, int beg, int end)
        {
            if (beg < 0) beg = 0;
            if (end >= list.Count) end = list.Count - 1;
            if (beg > end) beg = end;
            var size = end - beg + 1;
            var seed = DateTime.Now.Millisecond;
            var random = new Random(seed);
            for (var index = beg; index <= end; ++index)
            {
                var indexSwap = beg + random.Next(size);
                Swap(list, index, indexSwap);
            }
        }
    }
}