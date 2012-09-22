namespace System.Collections
{
    using System;

    static class Sorter
    {

        //Find the smallest element in the array, and put it in the proper place. Repeat until array is sorted.
        internal static void SelectionSort(Int64[] array, Int32 beg, Int32 end)
        {
            if (beg < 0) beg = 0;
            while (beg < end)
            {
                #region Min
                // ---------------------------------------------
                // find minimum value
                // ---------------------------------------------

                #region Old
                //Int32 min = beg;
                //for (Int32 next = beg + 1; next <= end; ++next)
                //{
                //    if (array[next] < array[min])
                //        min = next;
                //}

                //Swap(array, beg, min);
                //++beg; 
                #endregion

                //Int32 min = beg; Int64 minValue = array[min];
                //for (Int32 next = beg + 1; next <= end; ++next)
                //{
                //    if (array[next] < minValue)
                //    {
                //        min = next;
                //        minValue = array[min];
                //    }
                //}

                //if (min != beg)
                //{
                //    array[min] = array[beg];
                //    array[beg] = minValue;
                //}
                //++beg;

                #endregion

                #region Max
                // ---------------------------------------------
                // find maximum value
                // ---------------------------------------------

                #region Old
                //Int32 max = end;
                //for (Int32 next = end - 1; next >= beg; --next)
                //    if (array[next] > array[max])
                //        max = next;

                //Swap(array, beg, max);
                //--end; 
                #endregion

                Int32 max = end; Int64 maxValue = array[max];
                for (Int32 next = end - 1; next >= beg; --next)
                {
                    if (array[next] > maxValue)
                    {
                        max = next;
                        maxValue = array[max];
                    }
                }

                if (max != end)
                {
                    array[max] = array[end];
                    array[end] = maxValue;
                }
                --end;
                #endregion
            }
        }

        //Find the smallest & largest element in the array, and put it in the proper place. Repeat until array is sorted.
        internal static void BiSelectionSort(Int64[] array, Int32 beg, Int32 end)
        {
            if (beg < 0) beg = 0;
            while (beg < end)
            {
                Int32 min = beg; Int64 minValue = array[min];
                Int32 max = end; Int64 maxValue = array[max];
                for (Int32 next = beg; next <= end; ++next)
                {
                    Int64 nextValue = array[next];
                    if (nextValue < minValue)
                    {
                        min = next;
                        minValue = array[min];
                    }
                    else if (nextValue > maxValue)
                    {
                        max = next;
                        maxValue = array[max];
                    }
                }

                Int64 lastValue = array[end];
                if (min != beg)
                {
                    array[min] = array[beg];
                    array[beg] = minValue;
                }
                if (max != end)
                {
                    array[max] = lastValue;
                    array[end] = maxValue;
                }

                ++beg;
                --end;
            }
        }

        //Exchange two adjacent elements if they are out of order. Repeat until array is sorted.
        internal static void BubbleSort(Int64[] array, Int32 beg, Int32 end, Int32 step)
        {
            if (beg < 0) beg = 0;
            if (step <= 0) step = 1;
            while (beg < end)
            {
                // ---------------------------------------------
                // bubble values
                // ---------------------------------------------

                #region Min

                //Int32 firstMax = end;
                //for (Int32 next = end; next - step >= beg; next -= step)
                //{
                //    Int64 value = array[next];
                //    if (value < array[next - step])
                //    {
                //        //Swap(array, next, next - step);
                //        array[next] = array[next - step];
                //        array[next - step] = value;
                //        firstMax = next;
                //    }
                //}
                //beg = firstMax;
                #endregion

                #region Max

                #region isSorted

                //bool isSorted = true;
                //for (Int32 next = beg; next + step <= end; next += step)
                //{
                //    if (array[next] > array[next + step])
                //    {
                //        Swap(array, next, next + step);
                //        isSorted = false;
                //    }
                //}
                //if (isSorted)
                //    break;
                //--end;
                #endregion

                Int32 lastMin = beg;

                //for (Int32 next = beg; next + step <= end; next += step)
                //{
                //    Int64 value = array[next];
                //    if (value > array[next + step])
                //    {
                //        //Swap(array, next, next + step);
                //        array[next] = array[next + step];
                //        array[next + step] = value;
                //        lastMin = next;
                //    }
                //}

                Int32 idx1 = beg;
                Int32 idx2 = idx1 + step;
                while (idx2 <= end)
                {
                    Int64 value1 = array[idx1];
                    Int64 value2 = array[idx2];
                    if (value1 > value2)
                    {
                        //Swap(array, idx1, idx2);
                        array[idx1] = value2;
                        array[idx2] = value1;
                        lastMin = idx1;
                    }
                    idx1 = idx2;
                    idx2 += step;
                }

                end = lastMin;
                #endregion
            }
        }
        internal static void BubbleSort(Int64[] array, Int32 beg, Int32 end)
        {
            BubbleSort(array, beg, end, 1);
        }

        //Scan successive elements for out of order item, then insert the item in the proper place.
        internal static void InsertionSort(Int64[] array, Int32 beg, Int32 end, Int32 step)
        {
            if (beg < 0) beg = 0;
            if (step <= 0) step = 1;
            for (Int32 index = beg + step; index <= end; ++index)
            {
                Int64 value = array[index];

                Int32 min = index - step;
                for (; min >= beg && value < array[min]; min -= step)
                {
                    array[min + step] = array[min];
                }
                array[min + step] = value;
            }
        }
        internal static void InsertionSort(Int64[] array, Int32 beg, Int32 end)
        {
            InsertionSort(array, beg, end, 1);
        }

        //Sort every Nth element in an array using insertion sort. Repeat using smaller h values, until h = 1.
        internal static void ShellSort(Int64[] array, Int32 beg, Int32 end)
        {
            if (beg < 0) beg = 0;

            #region Array
            //Int32[] H = 
            //    {
            //        1, 3, 7, 21, 48, 112, 336, 861, 1968, 4592,
            //        13776, 86961, 198768, 463792, 1391376, 4174128,
            //    };

            //    {
            //        1, 5, 19, 41, 109, 209, 505, 929, 2161, 3905, 8929, 
            //        16001, 36289, 64769, 146305, 260609, 587521, 1045505,
            //        2354689, 4188161, 9427969, 16764929, 37730305, 67084289, 
            //        150958081, 268386305, 603906049, 1073643521
            //    };

            //Int32 size;
            //for( size = 0; beg + H[ size ] <= end; ++size ) ;

            //while( --size >= 0 )
            //{
            //    Int32 h = H[ size ];
            //    InsertionSort(array, beg, end, h); 
            //}
            #endregion

            #region Loop

            //Int32 h = 1;
            //while (h < end / 3)
            //    h = 3 * h + 1;  // {1, 4, 13, 40, 121, ...}

            //while (h > 0)
            //{
            //    //BubbleSort(array, beg, end, h);
            //    InsertionSort(array, beg, end, h);
            //    h = (h - 1) / 3;
            //}


            Int32 h = end - beg + 1;
            do
            {
                if (h < 5)
                {
                    h = 1;
                }
                else
                {
                    //h = h / 2;
                    h = (5 * h - 1) / 11;
                }
                //BubbleSort(array, beg, end, h);
                InsertionSort(array, beg, end, h);
            }
            while (h > 1);

            #endregion
        }

        internal static void CountingSort(Int64[] array, Int32 beg, Int32 end)
        {
            Int64 minValue = array[beg];
            Int64 maxValue = array[beg];
            for (Int32 index = beg; index <= end; ++index)
            {
                if (array[index] < minValue)
                {
                    minValue = array[index];
                }
                else if (array[index] > maxValue)
                {
                    maxValue = array[index];
                }
            }

            #region MyRegion
            //Int32 range = (Int32) (maxValue - minValue + 1);
            //Int32[] next = new Int32[rangeValue + 1];
            //for (Int32 key = 0; key <= rangeValue; key++)
            //    next[key] = key * (end + 1);


            //Int64[] output = new Int64[rangeValue * (end + 1) + 1];
            //for (Int32 i = beg; i <= end; i++)
            //{
            //    output[next[array[i]]++] = array[i];
            //} 
            #endregion

            Int32[] counts = new Int32[maxValue - minValue + 1];
            for (Int32 index = beg; index <= end; ++index)
            {
                ++counts[array[index] - minValue];
            }

            Int32 k = beg;
            for (Int64 value = minValue; value <= maxValue; ++value)
            {
                for (Int32 repeat = 0; repeat < counts[value - minValue]; ++repeat)
                {
                    array[k++] = value;
                }
            }
        }

        internal static void BucketSort(Int32[] array, Int32 n)
        {
            const Int32 MAX = 100;
            Int32[] buckets = new Int32[MAX];
            for (Int32 j = 0; j < MAX; ++j)
            {
                buckets[j] = 0;
            }

            for (Int32 i = 0; i < n; ++i)
            {
                ++buckets[array[i]];
            }

            for (Int32 i = 0, j = 0; j < MAX; ++j)
            {
                for (Int32 k = buckets[j]; k > 0; --k)
                {
                    array[i++] = j;
                }
            }
        }

        #region Heap Sort
        internal static void HeapSort(Int64[] array, Int32 beg, Int32 end)
        {
            if (beg < 0) beg = 0;
            Heapify(array, beg, end);
            SortDown(array, beg, end);
        }

        // Build Heap
        private static void Heapify(Int64[] array, Int32 beg, Int32 end)
        {
            Int32 length = end - beg + 1;
            for (Int32 root = (length >> 1) - 1; root >= beg; --root)
                Sink(array, root, end);
        }

        // Shift large values towards the root of the tree and small values toward the leaves
        private static void Sink(Int64[] array, Int32 root, Int32 bottom)
        {
            #region Loops

            Int64 rootValue = array[root];
            while (true) //(root < (bottom << 1))
            {
                #region //maxChild
                //Int32 maxChild = (root * 2 + 1);
                //if (maxChild > bottom) break;

                //if (array[maxChild] < array[maxChild + 1])
                //    ++maxChild; 
                #endregion

                #region leftChild & rightChild

                Int32 leftChild = (root << 1) + 1;
                if (leftChild > bottom)
                    break;
                Int32 rightChild = leftChild + 1;

                Int32 maxChild =
                    //(rightChild > bottom) ?
                    //    leftChild :
                    //    (array[leftChild] > array[rightChild]) ?
                    //        leftChild :
                    //        rightChild;
                    (rightChild <= bottom && (array[leftChild] < array[rightChild])) ?
                        rightChild :
                        leftChild;

                #endregion

                if (rootValue < array[maxChild])
                {
                    //#1
                    //Swap(array, root, maxChild);
                    //root = maxChild;

                    //#2
                    array[root] = array[maxChild];
                }
                else
                    break;

                //#2
                root = maxChild;
            }
            //#2
            array[root] = rootValue;

            #endregion

            #region //Recursive

            //Int32 leftChild = (root << 1) + 1;
            //if (leftChild > bottom) return;
            //Int32 rightChild = leftChild + 1;

            //Int32 maxChild =
            //    //(rightChild > bottom) ?
            //    //    leftChild :
            //    //    (array[leftChild] > array[rightChild]) ?
            //    //        leftChild :
            //    //        rightChild;
            //    (rightChild <= bottom && (array[leftChild] < array[rightChild])) ?
            //        rightChild :
            //        leftChild;

            //if (array[root] >= array[maxChild])
            //    return;

            //Swap(array, root, maxChild);
            //Sink(array, maxChild, bottom); 
            #endregion
        }

        private static void SortDown(Int64[] array, Int32 beg, Int32 end)
        {
            // Put maximum to bottom
            while (beg < end)
            {
                Swap(array, beg, end);
                Sink(array, beg, --end);
            }
            // ----------------------------------------------
            // todo::
            //// Put maximum to top
            //while (beg < end)
            //{
            //    Swap(array, ++beg, end);
            //    for (int i = end; i > beg; --i)
            //    {
            //        HeapUp(array, end);
            //    }

            //    //Swap(array, ++beg, end);
            //    //Sink(array, beg, end);
            //}
        }

        private static void HeapUp(Int64[] array, Int32 index)//, Int32 beg)//, Int32 end)
        {
            //Int32 length = end - beg + 1;
            //if (index >= length) return;
            Int64 item = array[index];
            bool isSwaped = false;
            while (index > 0)
            {
                int parent = (index - 1) >> 1;
                //if (parent < 0) break;
                if (array[parent] > item)
                    break;
                array[index] = array[parent];
                isSwaped = true;
                index = parent;
            }
            if (isSwaped)
                array[index] = item;
        }
        #endregion

        #region Merge Sort

        internal static void MergeSort(Int64[] array, Int32 beg, Int32 end)
        {
            if (beg < 0) beg = 0;

            if (beg < end)
            {
                Int32 mid = (beg + end) / 2;
                MergeSort(array, beg, mid);
                MergeSort(array, mid + 1, end);
                Merge(array, beg, mid, end);
            }
        }

        private static void Merge(Int64[] array, Int32 beg, Int32 mid, Int32 end)
        {
            #region Full Copy
            //Int64[] merge = new Int64[end - beg + 1];
            //// Copy Both Halves
            //for (Int32 index = beg; index <= end; ++index)
            //    merge[index - beg] = array[index];

            //Int32 left = beg;
            //Int32 right = mid + 1;

            //Int32 i = beg;

            //#region //Simple

            ////while ((left <= mid) && (right <= end))
            ////{
            ////    if (array[left] <= array[right])
            ////    {
            ////        merge[i++ - beg] = array[left++];
            ////    }
            ////    else
            ////    {
            ////        merge[i++ - beg] = array[right++];
            ////    }
            ////}

            ////if (left > mid)
            ////{
            ////    for (int32 k = right; k <= end; ++k)
            ////    {
            ////        merge[i++ - beg] = array[k];
            ////    }
            ////}
            ////else
            ////{
            ////    for (int32 k = left; k <= mid; ++k)
            ////    {
            ////        merge[i++ - beg] = array[k];
            ////    }
            ////}

            ////// Copy Back 
            ////for (Int32 index = beg; index <= end; ++index)
            ////{
            ////    array[index] = merge[index - beg];
            ////}
            //#endregion


            //#region Straight forward

            ////while (left <= mid && right <= end)
            ////{
            ////    if (merge[left - beg] <= merge[right - beg])
            ////        array[i++] = merge[left++ - beg];
            ////    else
            ////        array[i++] = merge[right++ - beg];
            ////}

            ////while (left <= mid)
            ////{
            ////    array[i++] = merge[left++ - beg];
            ////}
            //#endregion 
            #endregion

            #region Bitonic

            //Int64[] merge = new Int64[end - beg + 1];

            //Int32 left = beg;
            //Int32 right = end;
            //Int32 i = 0;

            //while (i <= mid - beg)
            //{
            //    merge[i++] = array[left++];
            //}

            //// copy second half of array a to auxiliary array b, but in opposite order
            //while (mid < right)
            //{
            //    merge[i++] = array[right--];
            //}

            //left = beg;
            //right = end - beg;
            //i = 0;
            //// copy back next-greatest element at each time
            //while (i <= right)
            //{
            //    if (merge[i] <= merge[right])
            //        array[left++] = merge[i++];
            //    else
            //        array[left++] = merge[right--];
            //}
            #endregion

            #region Half Copy

            Int64[] merge = new Int64[(end - beg) / 2 + 1];

            Int32 i = 0;

            Int32 left = beg;
            Int32 right = beg;
            // copy first half of array a to auxiliary array b
            while (right <= mid)
            {
                merge[i++] = array[right++];
            }

            i = 0;
            // copy back next-greatest element at each time
            while (left < right && right <= end)
            {
                if (merge[i] <= array[right])
                {
                    array[left++] = merge[i++];
                }
                else
                {
                    array[left++] = array[right++];
                }
            }

            // copy back remaining elements of first half (if any)
            while (left < right)
            {
                array[left++] = merge[i++];
            }

            #endregion
        }
        #endregion

        #region Quick Sort
        //an arbitrary limit to when we call Selection/Insertion Sort
        private static Int32 CutOff = 4;

        // Combo Sort
        internal static void QuickSort(Int64[] array, Int32 beg, Int32 end)
        {
            if (beg < end)
            {
                if (end - beg <= CutOff)
                {
                    // manual sort if data <= 3
                    //ManualSort(array, beg, end);
                    //SelectionSort(array, beg, end);
                    InsertionSort(array, beg, end);
                }
                else
                {
                    // split and sort partitions
                    Int32 pivotIndex =
                        //beg;
                        MedianOf3(array, beg, end);
                    Int32 split = Partition(array, beg, end, pivotIndex);

                    QuickSort(array, beg, split - 1);
                    QuickSort(array, split + 1, end);
                }
            }
        }

        // for size <= 3
        internal static void ManualSort(Int64[] array, Int32 beg, Int32 end)
        {
            Int32 size = end - beg + 1;
            if (size <= 1)
                return; // no sort necessary
            if (size == 2)
            { // 2-sort left and right
                if (array[beg] > array[end])
                {
                    Swap(array, beg, end);
                }
                return;
            }
            else // size is 3
            { // 3-sort left, center, & right
                if (array[beg] > array[end - 1])
                {
                    Swap(array, beg, end - 1); // left, center
                }
                if (array[beg] > array[end])
                {
                    Swap(array, beg, end); // left, right
                }
                if (array[end - 1] > array[end])
                {
                    Swap(array, end - 1, end); // center, right
                }
            }
        }

        internal static Int32 Partition(Int64[] array, Int32 beg, Int32 end, Int32 pivot)
        {
            #region //Mid without using pivot
            //Int32 mid = (beg + end) / 2;
            //Int64 midValue = array[mid];

            //if (midValue < array[beg])
            //{
            //    Swap(array, beg, mid);
            //}
            //if (array[end] < array[beg])
            //{
            //    Swap(array, beg, end);
            //}
            //if (array[end] < midValue)
            //{
            //    Swap(array, mid, end);
            //}

            //Int64 pivotValue = array[mid];
            //Swap(array, mid, end);

            //Int32 i, j;
            //for (i = beg, j = end; ; )
            //{
            //    while (i <= j && array[i++] < pivotValue) ;

            //    while (i <= j && pivotValue < array[j--]) ;

            //    if (i < j)
            //        Swap(array, i, j);
            //    else
            //        break;
            //}
            //Swap(array, i, end);
            //return i; 
            #endregion

            #region MyRegion 1

            //Int64 pivotValue = array[pivot];
            //Swap(array, pivot, end);
            //Int32 mark = beg;
            //for (Int32 index = beg; index < end; ++index)
            //{
            //    if (array[index] < pivotValue)
            //    {
            //        Swap(array, index, mark);
            //        ++mark;
            //    }
            //}
            //Swap(array, end, mark);
            //return mark; 
            #endregion

            #region MyRegion 2

            //Int32 left = beg + 1;
            //Int32 right = end;

            //Int64 pivotValue = array[pivot];

            //while (left <= right)
            //{
            //    // find item out of place
            //    while (left <= right && array[left] > pivotValue)
            //        ++left;
            //    while (left <= right && array[right] <= pivotValue)
            //        --right;

            //    if (left < right)
            //    {
            //        Swap(array, left, right);
            //        ++left;
            //        --right;
            //    }
            //}
            //Swap(array, beg, right);
            //return right;

            Int32 left = beg;      // end of first elem
            Int32 right = end - 1; // beg of pivot
            Int64 pivotValue = array[pivot];
            while (left < right)
            {
                while (array[++left] < pivotValue) ;  // find bigger

                while (array[--right] > pivotValue) ; // find smaller

                if (left < right)
                {
                    Swap(array, left, right); // swap elements
                }
            }
            Swap(array, left, end - 1); // restore pivot
            return left; // return pivot location
            #endregion
        }

        internal static Int32 MedianOf3(Int64[] array, Int32 beg, Int32 end)
        {
            Int32 mid = (beg + end) / 2;
            // order left & center
            if (array[beg] > array[mid])
            {
                Swap(array, beg, mid);
            }
            // order left & right
            if (array[beg] > array[end])
            {
                Swap(array, beg, end);
            }
            // order center & right
            if (array[mid] > array[end])
            {
                Swap(array, mid, end);
            }

            Swap(array, mid, end - 1); // put pivot on right
            return end - 1;            // return median index
        }
        #endregion


        #region Swaping

        private static void Swap<T>(T[] array, Int32 idx1, Int32 idx2)
        {
            if (idx1 != idx2)
            {
                T tmp = array[idx1];
                array[idx1] = array[idx2];
                array[idx2] = tmp;
            }
        }

        private static void Swap<T>(ref T value1, ref T value2)
        {
            //if (value1 != value2)
            {
                T tmp = value1;
                value1 = value2;
                value2 = tmp;
            }
        }
        #endregion

    }
}