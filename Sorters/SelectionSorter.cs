namespace SortingAlgos.Sorters
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// A sorter implemeting the Selection Sort algorithm.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class SelectionSorter<T> : Sorter<T>
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

            #region Selection
            
            while (beg < end)
            {
                #region Min
                var min = beg;
                for (var next = beg + step; next <= end; next += step)
                {
                    if (comparer.Compare(list[next], list[min]) < 0)
                        min = next;
                }
                if (min != beg)
                {
                    Swap(list, beg, min);
                    ++swap;
                }
                ++pass;
                ++beg;
                #endregion

                #region Max
                //var max = end;
                //for (var next = end - step; next >= beg; next -= step)
                //{
                //    if (comparer.Compare(list[next], list[max]) > 0)
                //        max = next;
                //}
                //if (max != end)
                //{
                //    Swap(list, beg, max);
                //    ++swap;
                //}
                //--end; 
                #endregion
            }
            
            #endregion

            #region Bingo (For Duplicate entry)
            /*
            T maxValue = list[end];
            for (int curr = end - step; curr >= beg; curr -= step)
            {
                if (comparer.Compare(list[curr], maxValue) > 0)
                    maxValue = list[curr];
            }
            end = RemoveDup(list, beg, end, comparer, maxValue);

            while (beg < end)
            {
                T value = maxValue;
                maxValue = list[end];
                for (int curr = end - step; curr >= beg; curr -= step)
                {
                    if (comparer.Compare(list[curr], value) == 0)
                    {
                        Swap(list, curr, end);
                        ++swap;
                        --end;
                    }
                    else if (comparer.Compare(list[curr], maxValue) > 0)
                        maxValue = list[curr];
                }
                end = RemoveDup(list, beg, end, comparer, maxValue);
            }
            */
            #endregion

            Console.WriteLine("pass :" + pass);
            Console.WriteLine("swap :" + swap);
        }

/*
        private static int RemoveDup(IList<T> list, int beg, int end, IComparer<T> comparer, T maxValue)
        {
            while (beg < end && comparer.Compare(list[end], maxValue) == 0)
                --end;
            return end;
        }
*/

    }
}