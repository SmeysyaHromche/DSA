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
            FindMin(ref arr);
            Console.WriteLine("\n\n");
            BubbleSort(ref arr);
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

        /**
         * 
         *   1. Go through the array, one value at a time.
         *   2. For each value, compare the value with the next value.
         *   3. If the value is higher than the next one, swap the values so that the highest value comes last.
         *   4. Go through the array as many times as there are values in the array.
         *
         *   O(n^2)
         */
        public static void BubbleSort(ref int[] arr)
        {
            int len = arr.Length;
            Console.WriteLine("Bubble sort (O(n^2))");
            
            ArrWrite(true, ref arr);
            
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len-1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    { 
                        int tmp = arr[j];
                        arr[j] = arr[j+1];
                        arr[j+1] = tmp;
                    }
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
    }
}
