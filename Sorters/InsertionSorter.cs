namespace SortingAlgos.Sorters
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Scan successive elements for out of order item, then insert the item in the proper place.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class InsertionSorter<T> : Sorter<T>
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

            // --------------------------------------------------
            //for (var curr = beg + step; curr <= end; curr += step)
            //{
            //    var value = list[curr];
            //    var min = curr - step;
            //    if (comparer.Compare(value, list[min]) >= 0) continue;
            //    while ((min >= beg) && (comparer.Compare(value, list[min]) < 0))
            //    {
            //        list[min + step] = list[min];
            //        min -= step;
            //    }
            //    list[min + step] = value;
            //}
            // --------------------------------------------------

            // sort first 2 index
            var min = beg;
            for (var curr = beg + step; curr <= end; curr += step)
                if (comparer.Compare(list[min], list[curr]) > 0)
                    min = curr;
            
            Swap(list, beg, min);
            ++beg;
            ++swap;

            // list[0]-list[1] sorted
            // list[2]-list[n] not sorted
            for (var curr = beg + step; curr <= end; curr += step)
            {
                var value = list[curr];

                min = curr - step;
                if (comparer.Compare(value, list[min]) >= 0) continue;
                while (min >= 0 && comparer.Compare(value, list[min]) < 0)
                {
                    list[min + step] = list[min];
                    min -= step;
                    ++swap;
                }
                list[min + step] = value;
                ++pass;
            }

            Console.WriteLine("pass :" + pass);
            Console.WriteLine("swap :" + swap);
        }


    }
}
