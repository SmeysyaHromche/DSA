using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.Sorting
{
    public class Sort
    {
        public static void TestSort()
        {
            int[] arr = { 7, 22, 9, 10, 15, 3 };

            Console.WriteLine("\n\n");
            Console.WriteLine("Test differents type of sorting");
            int[] arr_serch_min = new int[arr.Length];
            arr.CopyTo(arr_serch_min, 0);
            FindMin(ref arr_serch_min);
            Console.WriteLine("\n\n");
            int[] arr_bubble = new int[arr.Length];
            arr.CopyTo(arr_bubble, 0);
            BubbleSort(ref arr_bubble);
            Console.WriteLine("\n\n");
            int[] arr_select = new int[arr.Length];
            arr.CopyTo(arr_select, 0);
            SelectionSortWithShifting(ref arr_select);
            Console.WriteLine("\n\n");
            int[] arr_insert = new int[arr.Length];
            arr.CopyTo(arr_insert, 0);
            InsertSort(ref arr_insert);
            Console.WriteLine("\n\n");
        }

        public static int FindMin(ref int[] arr)
        {
            int min_val = arr[0];
            
            ArrWrite(true, ref arr);

            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] < min_val)
                { 
                    min_val = arr[i];
                }
            }

            Console.WriteLine($"Find minumum: {min_val}");
            
            return min_val;
        }

        public static void BubbleSort(ref int[] arr)
        {
            Console.WriteLine("Bubble sort (O(n^2))");

            
            ArrWrite(true, ref arr);

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
            
            ArrWrite(false, ref arr);
        }

        
        public static void SelectionSortWithShifting(ref int[] arr)
        {
            Console.WriteLine("Selection sorting\nO(n/2*2) == O(n^2)");
            ArrWrite(true, ref arr);

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

            ArrWrite(false, ref arr);

        }

        public static void InsertSort(ref int[] arr)
        {
            Console.WriteLine("Insert sorting\nO(n/2*2) == O(n^2)");
            ArrWrite(true, ref arr);

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
            ArrWrite(false, ref arr);
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
