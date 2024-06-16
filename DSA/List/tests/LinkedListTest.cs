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
            TestGetLength();
            Console.WriteLine("\n*** *** *** *** ***\n");
        }
        public void TestInitEmpty()
        {
            MyLinkedList l = new MyLinkedList();
            int[] test_arr = _CreateArrByOrderOfNumber(0);
            int[] out_arr = l.GetArray();
            MyAssert(MethodBase.GetCurrentMethod().Name, test_arr.SequenceEqual(out_arr));
        }

        public void TestInitByArr()
        {
            int[] test_arr = _CreateArrByOrderOfNumber(10);
            MyLinkedList l = new MyLinkedList(ref test_arr);
            int[] out_arr = l.GetArray();
            MyAssert(MethodBase.GetCurrentMethod().Name, test_arr.SequenceEqual(out_arr));
        }

        public void TestInitByAddFirst()
        {
            int[] test_arr = _CreateArrByOrderOfNumber(10);
            MyLinkedList l = new MyLinkedList();
            for (int i = 0; i < test_arr.Length; i++)
            {
                l.AddFirst(test_arr[i]);
            }
            int[] out_arr = l.GetArray();
            Array.Reverse(test_arr);
            MyAssert(MethodBase.GetCurrentMethod().Name, test_arr.SequenceEqual(out_arr));
        }

        public void TestInitByAddLast()
        {
            int[] test_arr = _CreateArrByOrderOfNumber(10);
            MyLinkedList l = new MyLinkedList();
            for (int i = 0; i < test_arr.Length; i++)
            {
                l.AddLast(test_arr[i]);
            }
            int[] out_arr = l.GetArray();
            MyAssert(MethodBase.GetCurrentMethod().Name, test_arr.SequenceEqual(out_arr));
        }

        public void TestInitByStaticValue()
        {
            MyLinkedList l = new MyLinkedList(100, 0);
            int[] test_arr = _CreateArrByOrderOfNumber(100, true);
            int[] out_arr = l.GetArray();
            MyAssert(MethodBase.GetCurrentMethod().Name, test_arr.SequenceEqual(out_arr)); 
        }

        public void TestClear()
        {
            MyLinkedList l = new MyLinkedList(100);
            l.Clear();
            int[] test_arr = { };
            int[] out_arr = l.GetArray();
            MyAssert(MethodBase.GetCurrentMethod().Name, test_arr.SequenceEqual(out_arr));
        }

        public void TestGetValue()
        {
            MyLinkedList l = new MyLinkedList();
            for(int i = 0; i < 100; i++)
            {
                l.AddLast(i);
            }
            MyAssert(MethodBase.GetCurrentMethod().Name, l.GetValue(99) == 99);
        }
        public void TestGetIndex()
        {
            MyLinkedList l = new MyLinkedList();
            for (int i = 0; i < 100; i++)
            {
                l.AddLast(i);
            }
            MyAssert(MethodBase.GetCurrentMethod().Name, l.GetIndex(99) == 99);
        }

        public void TestDeleteFirst()
        {
            MyLinkedList l = new MyLinkedList();
            for (int i = 0; i < 100; i++)
            {
                l.AddLast(i);
            }
            l.DeleteFirst();
            int[] out_arr = l.GetArray();
            int[] test_arr = _CreateArrByOrderOfNumber(from:1, to:99);
            MyAssert(MethodBase.GetCurrentMethod().Name, test_arr.SequenceEqual(out_arr));
        }

        public void TestDeleteLast()
        {
            MyLinkedList l = new MyLinkedList();
            for (int i = 0; i < 100; i++)
            {
                l.AddLast(i);
            }
            l.DeleteLast();
            int[] out_arr = l.GetArray();
            int[] test_arr = _CreateArrByOrderOfNumber(0, 98);
            MyAssert(MethodBase.GetCurrentMethod().Name, test_arr.SequenceEqual(out_arr));
        }

        public void TestGetLength()
        {
            MyLinkedList l = new MyLinkedList();
            for (int i = 0; i < 100; i++)
            {
                l.AddLast(i);
            }
            MyAssert(MethodBase.GetCurrentMethod().Name, l.GetLength() == 100);
        }
    }
}
