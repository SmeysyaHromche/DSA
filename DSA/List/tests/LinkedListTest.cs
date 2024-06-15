using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Reflection;
using System.Security.Policy;
using DSA.test;

namespace DSA.List.tests
{
    class LinkedListTest : Tester
    {
        override public void RunAll()
        {
            Console.WriteLine("\n*** TEST FOR LINKED_LIST ***\n");
            TestInitEmpty();
            TestInitByArr();
            TestInitByAddFirst();
            TestInitByAddLast();
            TestInitByStaticValue();
            TestClear();
            TestGetValue();
            TestGetIndex();
            TestDeleteFirst();
            TestDeleteLast();
            Console.WriteLine("\n*** *** *** *** ***\n");
        }
        public void TestInitEmpty()
        {
            try
            {
                MyLinkedList l = new MyLinkedList();
                int[] test_arr = _CreateArrByOrderOfNumber(0);
                int[] out_arr = l.GetArray();
                MyAssert(MethodBase.GetCurrentMethod().Name, test_arr.SequenceEqual(out_arr), true);
            }
            catch (ExceptionTestFail e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            Console.WriteLine($"{MethodBase.GetCurrentMethod().Name}: pass");

        }

        public void TestInitByArr()
        {
            try
            {
                int[] test_arr = _CreateArrByOrderOfNumber(10);
                MyLinkedList l = new MyLinkedList(ref test_arr);
                int[] out_arr = l.GetArray();
                MyAssert(MethodBase.GetCurrentMethod().Name, test_arr.SequenceEqual(out_arr), true);
            }
            catch (ExceptionTestFail e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            Console.WriteLine($"{MethodBase.GetCurrentMethod().Name}: pass");
        }

        public void TestInitByAddFirst()
        {
            try
            {
                int[] test_arr = _CreateArrByOrderOfNumber(10);
                MyLinkedList l = new MyLinkedList();
                for (int i = 0; i < test_arr.Length; i++)
                {
                    l.AddFirst(test_arr[i]);
                }
                int[] out_arr = l.GetArray();
                Array.Reverse(test_arr);
                MyAssert(MethodBase.GetCurrentMethod().Name, test_arr.SequenceEqual(out_arr), true);
            }
            catch (ExceptionTestFail e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            Console.WriteLine($"{MethodBase.GetCurrentMethod().Name}: pass");
        }

        public void TestInitByAddLast()
        {
            try
            {
                int[] test_arr = _CreateArrByOrderOfNumber(10);
                MyLinkedList l = new MyLinkedList();
                for (int i = 0; i < test_arr.Length; i++)
                {
                    l.AddLast(test_arr[i]);
                }
                int[] out_arr = l.GetArray();
                MyAssert(MethodBase.GetCurrentMethod().Name, test_arr.SequenceEqual(out_arr), true);
            }
            catch (ExceptionTestFail e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            Console.WriteLine($"{MethodBase.GetCurrentMethod().Name}: pass");
        }

        public void TestInitByStaticValue()
        {
            try
            {
                MyLinkedList l = new MyLinkedList(100, 0);
                int[] test_arr = _CreateArrByOrderOfNumber(100, true);
                int[] out_arr = l.GetArray();
                MyAssert(MethodBase.GetCurrentMethod().Name, test_arr.SequenceEqual(out_arr), true);
            }
            catch (ExceptionTestFail e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            Console.WriteLine($"{MethodBase.GetCurrentMethod().Name}: pass");
        }

        public void TestClear()
        {
            try
            {
                MyLinkedList l = new MyLinkedList(100);
                l.Clear();
                int[] test_arr = { };
                int[] out_arr = l.GetArray();
                MyAssert(MethodBase.GetCurrentMethod().Name, test_arr.SequenceEqual(out_arr), true);
            }
            catch(ExceptionTestFail e)
            {
                    Console.WriteLine(e.Message);
                    return;
            }
            Console.WriteLine($"{MethodBase.GetCurrentMethod().Name}: pass");
        }

        public void TestGetValue()
        {
            try
            {
                MyLinkedList l = new MyLinkedList();
                for(int i = 0; i < 100; i++)
                {
                    l.AddLast(i);
                }

                MyAssert(MethodBase.GetCurrentMethod().Name, l.GetValue(99) == 99, true);
            }
            catch (ExceptionTestFail e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            Console.WriteLine($"{MethodBase.GetCurrentMethod().Name}: pass");
        }
        public void TestGetIndex()
        {
            try
            {
                MyLinkedList l = new MyLinkedList();
                for (int i = 0; i < 100; i++)
                {
                    l.AddLast(i);
                }

                MyAssert(MethodBase.GetCurrentMethod().Name, l.GetIndex(99) == 99, true);
            }
            catch (ExceptionTestFail e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            Console.WriteLine($"{MethodBase.GetCurrentMethod().Name}: pass");
        }

        public void TestDeleteFirst()
        {
            try
            {
                MyLinkedList l = new MyLinkedList();
                for (int i = 0; i < 100; i++)
                {
                    l.AddLast(i);
                }
                l.DeleteFirst();
                int[] out_arr = l.GetArray();
                int[] test_arr = _CreateArrByOrderOfNumber(from:1, to:99);
                MyAssert(MethodBase.GetCurrentMethod().Name, test_arr.SequenceEqual(out_arr), true);
            }
            catch (ExceptionTestFail e)
            {  
                Console.WriteLine(e.Message);
                return;
            }
            Console.WriteLine($"{MethodBase.GetCurrentMethod().Name}: pass");
        }

        public void TestDeleteLast()
        {
            try
            {
                MyLinkedList l = new MyLinkedList();
                for (int i = 0; i < 100; i++)
                {
                    l.AddLast(i);
                }
                l.DeleteLast();
                int[] out_arr = l.GetArray();
                int[] test_arr = _CreateArrByOrderOfNumber(0, 98);
                MyAssert(MethodBase.GetCurrentMethod().Name, test_arr.SequenceEqual(out_arr), true);
            }
            catch (ExceptionTestFail e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            Console.WriteLine($"{MethodBase.GetCurrentMethod().Name}: pass");
        }

    }
}
