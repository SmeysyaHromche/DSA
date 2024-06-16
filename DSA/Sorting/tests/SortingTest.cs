using DSA.test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DSA.Sorting.tests
{
    public class SortingTests : Tester
    {
        override public void RunAll()
        {
            Console.WriteLine("\n*** TEST FOR SORTING ***\n");
            TestFindMin();
            TestBubbleSort();
            TestSelectSort();
            TestInsertSort();
            Console.WriteLine("\n*** *** *** *** ***\n");
        }

        public void TestFindMin()
        {
            int[] not_sort_arr = _RandomArr(0, 100);
            int min = Sort.FindMin(ref not_sort_arr);
            MyAssert(MethodBase.GetCurrentMethod().Name, min == 0);
        }

        public void TestBubbleSort()
        {
            int[] arr = _RandomArr(0, 100);
            int[] test_arr = _CreateArrByOrderOfNumber(from: 0, to: 100);
            Sort.BubbleSort(ref arr);
            MyAssert(MethodBase.GetCurrentMethod().Name, test_arr.SequenceEqual(arr));
        }

        public void TestSelectSort()
        {
            int[] arr = _RandomArr(0, 100);
            int[] test_arr = _CreateArrByOrderOfNumber(from: 0, to: 100);
            Sort.SelectionSortWithShifting(ref arr);
            MyAssert(MethodBase.GetCurrentMethod().Name, test_arr.SequenceEqual(arr));   
        }

        public void TestInsertSort()
        {
            int[] arr = _RandomArr(0, 100);
            int[] test_arr = _CreateArrByOrderOfNumber(from: 0, to: 100);
            Sort.SelectionSortWithShifting(ref arr);
            MyAssert(MethodBase.GetCurrentMethod().Name, test_arr.SequenceEqual(arr));
        }
    }
}
