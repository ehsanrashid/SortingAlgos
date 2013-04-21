using System;
using System.Collections.Generic;
using SortingAlgos.Sorters;

namespace SortingAlgos
{
    static class Program
    {
        static void Main(string[] args)
        {
            Sorter<int> sorter = new
                //BubbleSorter<int>();
            SelectionSorter<int>();
            //BiSelectionSorter<int>();    
            //InsertionSorter<int>();
            //ShellSorter<int>();
            //HeapSorter<int>();
            //GnomeSorter<int>();
            //CombSorter<int>();
            //CocktailSorter<int>();
            //MergeSorter<int>();
            //OddEvenTransportSorter<int>();
            //QuickSorter<int>();
            //ShakerSorter<int>();
            //StoogeSorter<int>();
            //CountingSorter();
            //BucketSorter();
            TestSorter(sorter);
            Console.Read();
        }

        static void TestSorter(ISorter<int> sorter)
        {
            var arr = new[] 
            { 8, 4, 3, 2, 5, 9, 6, 7, 1 };
            //{ 1, 2, 3, 4, 5, 7, 8, 9 };
            //{ 3, 2, 1, 9, 8, 7 };
            //{1, 6, 5, 5, 2, 1, 2, 6, 5, 5, 6};

            var list = new List<int>(arr);

            foreach (var i in list)
                Console.Write(" " + i);

            Console.WriteLine();

            sorter.Sort(list);

            foreach (var i in list)
                Console.Write(" " + i);
            /*
            // Test Reverse sequential list
            list = GetReverseSequentialTestList();
            sorter.Sort(list);
            AssertGeneralTestListSorted(list);
            */
            /*
            // Test allready sorted list
            list = GetSortedList();
            sorter.Sort(list);
            AssertGeneralTestListSorted(list);
            */
            // Test half sequential list
            //list = GetHalfSequentialList();
            //sorter.Sort(list);
            //AssertGeneralTestListSorted(list);
            /*
            // Test double numbers
            //list = GetDoubleNumbers();
            //sorter.Sort(list);
            //AssertDoubleNumbersList(list);
            */
        }
    }
}