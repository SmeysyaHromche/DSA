using DSA.List.tests;
using DSA.Sorting.tests;
using DSA.Stack.tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("DSA");

            LinkedListTest linked_list_test = new LinkedListTest();
            linked_list_test.RunAll();

            SortingTests sorting_test = new SortingTests();
            sorting_test.RunAll();

            //StackTest stack_test = new StackTest();
            //stack_test.RunAll();
        }
    }
}
