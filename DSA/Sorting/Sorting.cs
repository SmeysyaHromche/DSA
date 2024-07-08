using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DSA.Sorting
{
    public class Sort
    {


        // ********************************************************
        //                     FINDING MINIMUM
        // ********************************************************
        public static int FindMin(List<int> arr)
        {
            int min_val = arr[0];

            for (int i = 1; i < arr.Count; i++)
            {
                if (arr[i] < min_val)
                {
                    min_val = arr[i];
                }
            }

            return min_val;
        }
        // ********************************************************

        // ********************************************************
        //                      BUBBLE SORT
        // ********************************************************
        public static List<int> BubbleSort(List<int> arr)
        {

            int len = arr.Count;
            if (len < 2)
            {
                return arr;
            }
            List<int> ret = new List<int>(arr);
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len - i - 1; j++)
                {
                    if (ret[j] > ret[j + 1])
                    {
                        Swap(ret, j, j + 1);
                    }
                }
            }
            return ret;

        }
        // ********************************************************


        // ********************************************************
        //                      SELECTION SORT
        // ********************************************************
        public static List<int> SelectionSortWithShifting(List<int> arr)
        {

            int len = arr.Count;
            if (len < 2)
            {
                return arr;
            }
            List<int> ret = new List<int>(arr);
            for (int i = 0; i < len; i++)
            {
                int index_min = i;
                for (int j = i; j < len; j++)
                {
                    if (ret[j] < ret[index_min])
                    {
                        index_min = j;
                    }
                }

                Swap(ret, index_min, i);
            }
            return ret;

        }
        // ********************************************************


        // ********************************************************
        //                   INSERTION SORT
        // ********************************************************
        public static List<int> InsertSort(List<int> arr)
        {

            int len = arr.Count;
            if (len < 2)
            {
                return arr;
            }
            List<int> ret = new List<int>(arr);
            for (int i = 1; i < len; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (ret[j - 1] > ret[j])
                    {
                        Swap(ret, j - 1, j);
                        continue;
                    }

                    break;
                }
            }
            return ret;
        }
        // ********************************************************


        // ********************************************************
        //                      MERGE SORT
        // ********************************************************
        public static List<int> MergeSortWithRec(List<int> arr)
        {
            int len = arr.Count;
            List<int> ret = new List<int>(arr);
            List<int> aux = new List<int>(arr);
            MergeSortWithRecCut(ref ret, aux, 0, len);
            return ret;
        }
        private static void MergeSortWithRecCut(ref List<int> arr, List<int> aux, int from, int to)
        {
            if (to - from < 2)
            {
                return;
            }
            int middle = (to + from) / 2;
            MergeSortWithRecCut(ref arr, aux, from, middle);
            MergeSortWithRecCut(ref arr, aux, middle, to);
            MergeSortWithRecMerging(ref arr, aux, from, middle, to);

        }

        private static void MergeSortWithRecMerging(ref List<int> arr, List<int> aux, int from, int middle, int to)
        {
            int i = from, j = middle;
            for (int k = from; k < to; k++)
            {
                if (i < middle && j >= to)
                {
                    aux[k] = arr[i++];
                }
                else if (i < middle && arr[i] <= arr[j])
                {
                    aux[k] = arr[i++];
                }
                else
                {
                    aux[k] = arr[j++];
                }
            }

            arr = new List<int>(aux);

        }
        // ********************************************************

        // ********************************************************
        //                     QUIC  PART
        // ********************************************************

        public static List<int> QuickSortwithRec(List<int> arr)
        {
            int arr_len = arr.Count;
            if (arr_len < 2)
            {
                return arr;
            }
            int pivot = arr[arr_len / 2];
            List<int> left = new List<int>();
            List<int> middle = new List<int>();
            List<int> right = new List<int>();
            foreach (int i in arr)
            {
                if (i < pivot)
                {
                    left.Add(i);
                }
                else if (i == pivot)
                {
                    middle.Add(i);
                }
                else
                {
                    right.Add(i);
                }
            }
            return QuickSortwithRec(left).Concat(middle).Concat(QuickSortwithRec(right)).ToList();
        }


        // ********************************************************
        // ********************************************************
        //                     BINARY SEARCH PART
        // ********************************************************

        static public int BinarySearch(List<int> arr, int trg)
        {
            int len = arr.Count;
            if (len == 0)
            {
                return -1;
            }
            int left = 0;
            int right = len-1;
            while (left <= right)
            {
                int middle = left + (right - left) / 2;
                if (arr[middle] == trg)
                {
                    return middle;
                }
                else if (arr[middle] > trg)
                {
                    right = middle - 1;
                }
                else
                {
                    left = middle + 1;
                }
            }
            return -1;
        }



        // ********************************************************


        // ********************************************************
        //                     HELPFULL PART
        // ********************************************************
        private static void ArrWrite(bool input, List<int> arr)
        {
            if (input == true)
            {
                Console.WriteLine("Input: ");
            }
            else
            {
                Console.WriteLine("Output: ");
            }
            foreach (int i in arr)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
        }

        private static void Swap(List<int> arr, int i1, int i2)
        {
            if (arr.Count <= i1 || arr.Count <= i2)
            {
                Console.WriteLine("Warning! Incorrect index for array");
                return;
            }

            int tmp = arr[i1];
            arr[i1] = arr[i2];
            arr[i2] = tmp;
        
        }

    }
}
