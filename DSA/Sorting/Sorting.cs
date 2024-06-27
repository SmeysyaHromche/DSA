using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DSA.Sorting
{
    public class Sort
    {


        // ********************************************************
        //                     FINDING MINIMUM
        // ********************************************************
        public static int FindMin(ref int[] arr)
        {
            int min_val = arr[0];

            for (int i = 1; i < arr.Length; i++)
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
        public static void BubbleSort(ref int[] arr)
        {

            int len = arr.Length;
            if (len < 2)
            {
                return;
            }

            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        Swap(ref arr, j, j + 1);
                    }
                }
            }

        }
        // ********************************************************


        // ********************************************************
        //                      SELECTION SORT
        // ********************************************************
        public static void SelectionSortWithShifting(ref int[] arr)
        {

            int len = arr.Length;
            if (len < 2)
            {
                return;
            }

            for (int i = 0; i < len; i++)
            {
                int index_min = i;
                for (int j = i; j < len; j++)
                {
                    if (arr[j] < arr[index_min])
                    {
                        index_min = j;
                    }
                }

                Swap(ref arr, index_min, i);
            }

        }
        // ********************************************************


        // ********************************************************
        //                   INSERTION SORT
        // ********************************************************
        public static void InsertSort(ref int[] arr)
        {

            int len = arr.Length;
            if (len < 2)
            {
                return;
            }

            for (int i = 1; i < len; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (arr[j - 1] > arr[j])
                    {
                        Swap(ref arr, j - 1, j);
                        continue;
                    }

                    break;
                }
            }
        }
        // ********************************************************


        // ********************************************************
        //                      MERGE SORT
        // ********************************************************
        public static void MergeSortWithRec(ref int[] arr)
        {
            int len = arr.Length;
            int[] aux = new int[len];
            arr.CopyTo(aux, 0);
            MergeSortWithRecCut(ref arr, ref aux, 0, len);
        }
        private static void MergeSortWithRecCut(ref int[] arr, ref int[] aux, int from, int to)
        {
            if (to - from < 2)
            {
                return;
            }
            int middle = (to + from) / 2;
            MergeSortWithRecCut(ref arr, ref aux, from, middle);
            MergeSortWithRecCut(ref arr, ref aux, middle, to);
            MergeSortWithRecMerging(ref arr, ref aux, from, middle, to);

        }

        private static void MergeSortWithRecMerging(ref int[] arr, ref int[] aux, int from, int middle , int to)
        {
            int i = from, j = middle;
            for (int k = from; k < to; k++)
            {
                if (i < middle && j >= to)
                {
                    aux[k] = arr[i++];
                }
                else if( i < middle && arr[i] <= arr[j])
                {
                    aux[k] = arr[i++];
                }
                else
                {
                    aux[k] = arr[j++];
                }
            }

            aux.CopyTo(arr, 0);

        }
        // ********************************************************

        // ********************************************************
        //                     QUIC  PART
        // ********************************************************

        public static void QuickSort(ref int[]arr)
        {
            QuickSortCore(ref arr, 0, arr.Length);
        }

        private static void QuickSortCore(ref int[] arr, int from, int to)
        {
            if(from < to)
            {
                int p = QuickSortParit(ref arr, from , to);
                QuickSortCore(ref arr, from , p);
                QuickSortCore(ref arr, p, to);
            }
        }

        private static int QuickSortParit(ref int[] arr, int from, int to)
        {
            //int p = arr[];
            return 0;
        }

        // ********************************************************


        // ********************************************************
        //                     HELPFULL PART
        // ********************************************************
        private static void ArrWrite(bool input, ref int[] arr)
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

        private static void Swap(ref int[] arr, int i1, int i2)
        {
            if (arr.Length <= i1 || arr.Length <= i2)
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
