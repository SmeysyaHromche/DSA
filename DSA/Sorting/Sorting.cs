using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.Sorting
{
    public class Sort
    {
        
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

        public static void BubbleSort(ref int[] arr)
        {
            
            int len = arr.Length;
            if (len < 2)
            {
                return;
            }

            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len-1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        Swap(ref arr, j, j + 1);
                    }
                }
            }
            
        }

        
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
