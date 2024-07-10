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
        public static T FindMin<T>(List<T> arr) where T : IComparable<T>
        {
            T min_val = arr[0];

            for (int i = 1; i < arr.Count; i++)
            {
                if (arr[i].CompareTo(min_val) < 0)
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
        public static List<T> BubbleSort<T>(List<T> arr) where T : IComparable<T>
        {

            int len = arr.Count;
            if (len < 2)
            {
                return arr;
            }
            List<T> ret = new List<T>(arr);
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len - i - 1; j++)
                {
                    if (ret[j].CompareTo(ret[j+1]) > 0)
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
        public static List<T> SelectionSortWithShifting<T>(List<T> arr) where T : IComparable<T>
        {

            int len = arr.Count;
            if (len < 2)
            {
                return arr;
            }
            List<T> ret = new List<T>(arr);
            for (int i = 0; i < len; i++)
            {
                int index_min = i;
                for (int j = i; j < len; j++)
                {
                    if (ret[j].CompareTo(ret[index_min]) < 0)
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
        public static List<T> InsertSort<T>(List<T> arr) where T : IComparable<T>
        {

            int len = arr.Count;
            if (len < 2)
            {
                return arr;
            }
            List<T> ret = new List<T>(arr);
            for (int i = 1; i < len; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (ret[j - 1].CompareTo(ret[j]) > 0)
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
        public static List< T> MergeSortWithRec<T>(List<T> arr) where T : IComparable<T>
        {
            int len = arr.Count;
            List<T> ret = new List<T>(arr);
            List<T> aux = new List<T>(arr);
            MergeSortWithRecCut(ref ret, aux, 0, len);
            return ret;
        }
        private static void MergeSortWithRecCut<T>(ref List<T> arr, List<T> aux, int from, int to) where T : IComparable<T>
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

        private static void MergeSortWithRecMerging<T>(ref List<T> arr, List<T> aux, int from, int middle, int to) where T : IComparable<T>
        {
            int i = from, j = middle;
            for (int k = from; k < to; k++)
            {
                if (i < middle && j >= to)
                {
                    aux[k] = arr[i++];
                }
                else if (i < middle && arr[i].CompareTo(arr[j]) <= 0)
                {
                    aux[k] = arr[i++];
                }
                else
                {
                    aux[k] = arr[j++];
                }
            }

            arr = new List<T>(aux);

        }
        // ********************************************************

        // ********************************************************
        //                     QUIC  PART
        // ********************************************************

        public static List<T> QuickSortwithRec<T>(List<T> arr) where T : IComparable<T>
        {
            int arr_len = arr.Count;
            if (arr_len < 2)
            {
                return arr;
            }
            T pivot = arr[arr_len / 2];
            List<T> left = new List<T>();
            List<T> middle = new List<T>();
            List<T> right = new List<T>();
            foreach (T i in arr)
            {
                if (i.CompareTo(pivot) < 0)
                {
                    left.Add(i);
                }
                else if (i.CompareTo(pivot) == 0)
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

        static public int BinarySearch<T>(List<T> arr, T trg) where T : IComparable<T>
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
                if (arr[middle].CompareTo(trg) == 0 )
                {
                    return middle;
                }
                else if (arr[middle].CompareTo(trg) > 0)
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
        private static void ArrWrite<T>(bool input, List<T> arr) where T : IComparable<T>
        {
            if (input == true)
            {
                Console.WriteLine("Input: ");
            }
            else
            {
                Console.WriteLine("Output: ");
            }
            foreach (T i in arr)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
        }

        private static void Swap<T>(List<T> arr, int i1, int i2) where T : IComparable<T>
        {
            if (arr.Count <= i1 || arr.Count <= i2)
            {
                Console.WriteLine("Warning! Incorrect index for array");
                return;
            }

            T tmp = arr[i1];
            arr[i1] = arr[i2];
            arr[i2] = tmp;
        
        }

    }
}
