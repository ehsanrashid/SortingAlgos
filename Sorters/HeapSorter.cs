namespace SortingAlgos.Sorters
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// An sorter for the Heap Sort algorithm.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class HeapSorter<T> : Sorter<T>
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

            Sort(list, beg, end, comparer);
        }

        public static void Sort(IList<T> list, int beg, int end, IComparer<T> comparer)
        {
            if (beg < 0) beg = 0;
            if (end >= list.Count) end = list.Count - 1;
            if (beg > end) beg = end;

            // TODO : Make this a real Heap Sort and not use the provided Heap<T> data structure.
            //Heap<T> heap = new Heap<T>(HeapType.MinHeap, list, comparer);
            //for (int index = beg; index <= end; ++index)
            //{
            //    list[index] = heap.RemoveRoot();
            //}
            // ------------------------------------------------

            Heapify(list, beg, end, comparer);
            SortDown(list, beg, end, comparer);
        }

        private static void Heapify(IList<T> list, int beg, int end, IComparer<T> comparer)
        {
            var count = end - beg + 1;
            for (var root = (count >> 1) - 1; root >= 0; --root)
            {
                Sink(list, root, end, comparer);
            }
        }

        private static void SortDown(IList<T> list, int beg, int end, IComparer<T> comparer)
        {
            // Put top to bottom
            while (beg < end)
            {
                Swap(list, beg, end);
                --end;
                Sink(list, beg, end, comparer);
            }
        }

        private static void Sink(IList<T> list, int beg, int end, IComparer<T> comparer) // HeapDown
        {
            if (beg > (end >> 1)) return;

            // --------------------------------------
            /*
            T item = list[beg];
            while (beg <= (end >> 1))
            {
                var lChild = LeftChild(beg);
                if (lChild > end) return;
                var rChild = lChild + 1;
                var xChild = (rChild <= end && comparer.Compare(list[rChild], list[lChild]) > 0) ?
                                rChild :
                                lChild;
                if (comparer.Compare(item, list[xChild]) > 0) return;
             
                list[beg] = list[xChild]; // Swap
                beg = xChild;
            }
            list[beg] = item;
            */
            // --------------------------------------

            var lChild = LeftChild(beg);
            if (lChild > end) return;
            var rChild = RightChild(beg);
            var xChild = (rChild <= end && comparer.Compare(list[rChild], list[lChild]) > 0) ?
                            rChild :
                            lChild;

            var item = list[beg];
            if (comparer.Compare(item, list[xChild]) > 0) return;
            list[beg] = list[xChild];
            list[xChild] = item;
            Sink(list, xChild, end, comparer);

            // --------------------------------------
        }

        private static int Parent(int lChild) { return (lChild - 1) >> 1; }
        private static int LeftChild(int parent) { return (parent << 1) + 1; }
        private static int RightChild(int parent) { return (parent << 1) + 2; }

    }
}