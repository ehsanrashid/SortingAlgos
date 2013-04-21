namespace SortingAlgos.Sorters
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// A sorter implemeting the Selection Sort algorithm.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class BiSelectionSorter<T> : Sorter<T>
    {
        /// <summary>
        /// Sorts the specified list.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="comparer">The comparer to use in comparing items.</param>
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

            var pass = 0;
            var swap = 0;

            while (beg < end)
            {
                var min = beg;
                var max = end;
                for (var index = beg; index <= end; index += step)
                {
                    if (comparer.Compare(list[index], list[min]) < 0) min = index;
                    if (comparer.Compare(list[index], list[max]) > 0) max = index;
                }
                if (min != beg) { Swap(list, min, beg); ++swap; }
                if (max != end) { Swap(list, max, end); ++swap; }
                ++beg;
                --end;
                ++pass;
            }

            Console.WriteLine("pass :" + pass);
            Console.WriteLine("swap :" + swap);
        }
    }
}