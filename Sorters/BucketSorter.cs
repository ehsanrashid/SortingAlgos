using System.Linq;

namespace SortingAlgos.Sorters
{
    using System;
    using System.Collections.Generic;

    public sealed class BucketSorter : Sorter<int>
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
            if (0 > beg) beg = 0;
            if (end >= list.Count) end = list.Count - 1;
            if (beg > end) beg = end;

            int minValue, maxValue;
            FindMinMaxValues(list, beg, end, comparer, out minValue, out maxValue);

            #region List

            //Create a temporary "bucket" to store the values in order
            var size = maxValue - minValue + 1;
            var bucket = new List<int>[size];

            var index = beg;
            //Move items to bucket
            for (; index <= end; ++index)
            {
                if (bucket[list[index] - minValue] == default(List<int>))
                    bucket[list[index] - minValue] = new List<int>();
                bucket[list[index] - minValue].Add(list[index]);
            }

            //Move items in the bucket back to the original array in order
            index = beg; //index for original array
            //foreach (var dlst in bucket)
            //    if (dlst != default(List<int>))
            //        foreach (int value in dlst)
            //            list[index++] = value;

            foreach (var value in bucket.Where((lst) => lst != default(List<int>)).SelectMany(lst => lst))
                list[index++] = value;

            #endregion

            #region LinkedList
            ////Create a temporary "bucket" to store the values in order
            //var bucket = new LinkedList<int>[maxValue - minValue + 1];

            //var index = beg;
            ////Move items to bucket
            //for (; index <= end; ++index)
            //{
            //    if (bucket[list[index] - minValue] == null)
            //        bucket[list[index] - minValue] = new LinkedList<int>();
            //    bucket[list[index] - minValue].AddLast(list[index]);
            //}

            ////Move items in the bucket back to the original array in order
            //index = beg; //index for original array
            //foreach (var dlst in bucket.Where((dlst) => null != dlst))
            //{
            //    var node = dlst.First; //start add head of linked list
            //    while (null != node)
            //    {
            //        list[index++] = node.Value; //get value of current linked node
            //        node = node.Next;           //move to next linked node
            //    }
            //}
            #endregion

        }
    }
}