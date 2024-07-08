using DSA.test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Security.Cryptography;

namespace DSA.Sorting.tests
{
    public class SortingTests : Tester
    {
        private static object locker = new object();
        override public void RunAll()
        {
            Console.WriteLine("\n*** TEST FOR SORTING ***\n");
            TestFindMin();
            TestBubbleSort();
            TestSelectSort();
            TestInsertSort();
            TestMergeSortWithRec();
            TestQuickSortWithRec();
            TestBinarySearch();
            Console.WriteLine("\n*** *** *** *** ***\n");
        }

        public void ParallelTests()
        {
            List<int> arr = _RandomArr(0, 100);
            Thread[] threads = new Thread[4];
            threads[0] = new Thread(new ParameterizedThreadStart(TestBubbleSort));
            threads[1] = new Thread(new ParameterizedThreadStart(TestSelectSort));
            threads[2] = new Thread(new ParameterizedThreadStart(TestInsertSort));
            threads[3] = new Thread(new ParameterizedThreadStart(TestMergeSortWithRec));
            for (int i = 0; i < 4; i++)
            { 
                threads[i].Start(arr);
            }
        }

        public void TestFindMin(object input_arr=null)
        {
            List<int> arr = InitArrFromParam((List<int>)input_arr, 0, 100);
            int min = Sort.FindMin(arr);
            MyAssert(MethodBase.GetCurrentMethod().Name, min == 0);
         }

        public void TestBubbleSort(object input_arr = null)
        {
            List<int> arr = InitArrFromParam((List<int>)input_arr, 0, 100);
            List<int> test_arr = _CreateArrByOrderOfNumber(from: 0, to: 100);
            List<int> ouptut_arr = Sort.BubbleSort(arr);
            MyAssert(MethodBase.GetCurrentMethod().Name, test_arr.SequenceEqual(ouptut_arr));
        }

        public void TestSelectSort(object input_arr = null)
        {
            List<int> arr = InitArrFromParam((List<int>)input_arr, 0, 100);
            List<int> test_arr = _CreateArrByOrderOfNumber(from: 0, to: 100);
            List<int> ouptut_arr = Sort.SelectionSortWithShifting(arr);
            MyAssert(MethodBase.GetCurrentMethod().Name, test_arr.SequenceEqual(ouptut_arr));
        }

        public void TestInsertSort(object input_arr = null)
        {
            List<int> arr = InitArrFromParam((List<int>)input_arr, 0, 100);
            List<int> test_arr = _CreateArrByOrderOfNumber(from: 0, to: 100);
            List<int> ouptut_arr = Sort.SelectionSortWithShifting(arr);
            MyAssert(MethodBase.GetCurrentMethod().Name, test_arr.SequenceEqual(ouptut_arr));
        }

        public void TestMergeSortWithRec(object input_arr = null)
        {
            List<int> arr = InitArrFromParam((List<int>)input_arr, 0, 100);
            List<int> test_arr = _CreateArrByOrderOfNumber(from: 0, to: 100);
            List<int> output_arr = Sort.MergeSortWithRec(arr);
            MyAssert(MethodBase.GetCurrentMethod().Name, test_arr.SequenceEqual(output_arr));
        }

        public void TestQuickSortWithRec(object input_arr = null)
        {
            List<int> arr = InitArrFromParam((List<int>)input_arr, 0, 100);
            List<int> test_arr = _CreateArrByOrderOfNumber(from: 0, to: 100);
            List<int> output_arr = Sort.QuickSortwithRec(arr);
            MyAssert(MethodBase.GetCurrentMethod().Name, test_arr.SequenceEqual(output_arr));
            Console.WriteLine();
        }
        
        public void TestBinarySearch()
        {
            List<int> arr = _CreateArrByOrderOfNumber(from: 0, to: 100);
            MyAssert($"{MethodBase.GetCurrentMethod().Name}1", 0==Sort.BinarySearch(arr, 0));
            MyAssert($"{MethodBase.GetCurrentMethod().Name}1", 99 == Sort.BinarySearch(arr, 99));
            MyAssert($"{MethodBase.GetCurrentMethod().Name}1", 73 == Sort.BinarySearch(arr, 73));
            arr[12] = 11;
            MyAssert($"{MethodBase.GetCurrentMethod().Name}1", -1 == Sort.BinarySearch(arr, -1));
            MyAssert($"{MethodBase.GetCurrentMethod().Name}1", -1 == Sort.BinarySearch(arr, 12));
            MyAssert($"{MethodBase.GetCurrentMethod().Name}1", -1 == Sort.BinarySearch(arr, 101));

        }
        private List<int> InitArrFromParam(List<int> input_test, int from, int to)
        {
            List<int> arr;
            if(input_test == null)
            {
                arr = _RandomArr(0, 100);
            }
            else 
            {
                arr = new List<int>(input_test);
            }
            return arr;
        }

    }
}
