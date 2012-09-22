namespace SortingAlgos.Sorters
{
    using System;
    using System.Collections.Generic;

    public sealed class BubbleSorter<T> : Sorter<T>
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
            if (beg < 0) beg = 0;
            if (end >= list.Count) end = list.Count - 1;
            if (beg > end) beg = end;
            if (step <= 0) step = 1;

            var pass = 0;
            var swap = 0;

            while (beg < end)
            {
                #region Old

                //var swapped = false;
                //for (var index = beg; index < end; index += step)
                //{
                //    if (comparer.Compare(list[index], list[index + step]) <= 0) continue;

                //    Swap(list, index, index + step);
                //    swapped = true;
                //}
                //if (!swapped)
                //    break;
                //--end;

                #endregion

                // ------------------------------- min to top

                var max = end;
                for (var curr = max - step; curr >= beg; curr -= step)
                {
                    var next = curr + step;
                    if (comparer.Compare(list[curr], list[next]) <= 0) continue;

                    Swap(list, curr, next);
                    max = next;
                    ++swap;
                }
                beg = max;

                // ------------------------------- max to bottom

                //var min = beg;
                //for (var curr = min + step; curr <= end; curr += step)
                //{
                //    var next = curr - step;
                //    if (comparer.Compare(list[next], list[curr]) <= 0) continue;

                //    Swap(list, next, curr);
                //    min = next;
                //    ++swap;
                //}
                //end = min;

                // -------------------------------
                ++pass;
            }

            //Console.WriteLine("swap :" + swap);
        }

    }
}