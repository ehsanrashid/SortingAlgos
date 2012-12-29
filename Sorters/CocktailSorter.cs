using System;
using System.Collections.Generic;

namespace SortingAlgos.Sorters
{
    
    /// <summary>
    /// A Bi-Directional Bubble sorter.  
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class CocktailSorter<T> : Sorter<T>
    {
        /// <summary>
        /// Sorts the specified list.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="comparer">The comparer.</param>
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
            if (beg < 0) beg = 0;
            if (end >= list.Count) end = list.Count - 1;
            if (beg > end) beg = end;
            if (step <= 0) step = 1;

            while (beg < end)
            {
                var max = beg;

                var swapped = false;
                for (var index = beg; index < end; index += step)
                {
                    if (comparer.Compare(list[index], list[index + step]) > 0)
                    {
                        Swap(list, index, index + step);
                        max = index;
                        swapped = true;
                    }
                }
                if (!swapped)
                    break;
                //--end;
                end = max;

                var min = max;
                swapped = false;
                for (var index = end; index > beg; index -= step)
                {
                    if (comparer.Compare(list[index], list[index - step]) < 0)
                    {
                        Swap(list, index, index - step);
                        min = index;
                        swapped = true;
                    }
                }
                if (!swapped)
                    break;
                //++beg;
                beg = min;
            }

        }
    }
}