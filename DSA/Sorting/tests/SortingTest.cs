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
            Console.WriteLine("\n*** *** *** *** ***\n");
        }

        public void ParallelTests()
        {
            int[] arr = _RandomArr(0, 100);
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
            int[] arr = InitArrFromParam((int[])input_arr, 0, 100);
            int min = Sort.FindMin(ref arr);
            lock (locker)
            {
                MyAssert(MethodBase.GetCurrentMethod().Name, min == 0);
            }
         }

        public void TestBubbleSort(object input_arr = null)
        {
            int[] arr = InitArrFromParam((int[])input_arr, 0, 100);
            int[] test_arr = _CreateArrByOrderOfNumber(from: 0, to: 100);
            Sort.BubbleSort(ref arr);
            lock (locker)
            {
                MyAssert(MethodBase.GetCurrentMethod().Name, test_arr.SequenceEqual(arr));
            }
        }

        public void TestSelectSort(object input_arr = null)
        {
            int[] arr = InitArrFromParam((int[])input_arr, 0, 100);
            int[] test_arr = _CreateArrByOrderOfNumber(from: 0, to: 100);
            Sort.SelectionSortWithShifting(ref arr);
            lock (locker)
            {
                MyAssert(MethodBase.GetCurrentMethod().Name, test_arr.SequenceEqual(arr));
            }
        }

        public void TestInsertSort(object input_arr = null)
        {
            int[] arr = InitArrFromParam((int[])input_arr, 0, 100);
            int[] test_arr = _CreateArrByOrderOfNumber(from: 0, to: 100);
            Sort.SelectionSortWithShifting(ref arr);
            lock (locker)
            {
                MyAssert(MethodBase.GetCurrentMethod().Name, test_arr.SequenceEqual(arr));
            }
        }

        public void TestMergeSortWithRec(object input_arr = null)
        {
            int[] arr = InitArrFromParam((int[])input_arr, 0, 100);
            int[] test_arr = _CreateArrByOrderOfNumber(from: 0, to: 100);
            Sort.MergeSortWithRec(ref arr);
            lock (locker)
            {
                MyAssert(MethodBase.GetCurrentMethod().Name, test_arr.SequenceEqual(arr));
            }
        }

        public void TestQuickSort()
        {
            int[] arr = _RandomArr(0, 100);
            int[] test_arr = _CreateArrByOrderOfNumber(from: 0, to: 100);
            Sort.QuickSort(ref arr);
            lock (locker)
            {
                MyAssert(MethodBase.GetCurrentMethod().Name, test_arr.SequenceEqual(arr));
            }
        }

        private int[] InitArrFromParam(int[] input_test, int from, int to)
        {
            int[] arr;
            if(input_test == null)
            {
                arr = _RandomArr(0, 100);
            }
            else 
            {
                arr = new int[input_test.Length];
                input_test.CopyTo(arr, 0);
            }
            return arr;
        }
    }
}
