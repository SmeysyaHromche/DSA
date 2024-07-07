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
            TestSetValue();
            TestGetIndex();
            TestDeleteFirst();
            TestDeleteLast();
            TestGetLength();
            TestAccessByIndex();
            Console.WriteLine("\n*** *** *** *** ***\n");
        }
        public void TestInitEmpty()
        {
            MyLinkedList l = new MyLinkedList();
            List<int> test_arr = _CreateArrByOrderOfNumber(0);
            List<int> out_arr = l.GetArray();
            MyAssert(MethodBase.GetCurrentMethod().Name, test_arr.SequenceEqual(out_arr));
        }

        public void TestInitByArr()
        {
            List<int> test_arr = _CreateArrByOrderOfNumber(10);
            MyLinkedList l = new MyLinkedList(test_arr);
            List<int> out_arr = l.GetArray();
            MyAssert(MethodBase.GetCurrentMethod().Name, test_arr.SequenceEqual(out_arr));
        }

        public void TestInitByAddFirst()
        {
            List<int> test_arr = _CreateArrByOrderOfNumber(10);
            MyLinkedList l = new MyLinkedList();
            for (int i = 0; i < test_arr.Count; i++)
            {
                l.AddFirst(test_arr[i]);
            }
            List<int> out_arr = l.GetArray();
            test_arr.Reverse();
            MyAssert(MethodBase.GetCurrentMethod().Name, test_arr.SequenceEqual(out_arr));
        }

        public void TestInitByAddLast()
        {
            List<int> test_arr = _CreateArrByOrderOfNumber(10);
            MyLinkedList l = new MyLinkedList();
            for (int i = 0; i < test_arr.Count; i++)
            {
                l.AddLast(test_arr[i]);
            }
            List<int> out_arr = l.GetArray();
            MyAssert(MethodBase.GetCurrentMethod().Name, test_arr.SequenceEqual(out_arr));
        }

        public void TestInitByStaticValue()
        {
            MyLinkedList l = new MyLinkedList(100, 0);
            List<int> test_arr = _CreateArrByOrderOfNumber(100, true);
            List<int> out_arr = l.GetArray();
            MyAssert(MethodBase.GetCurrentMethod().Name, test_arr.SequenceEqual(out_arr)); 
        }

        public void TestClear()
        {
            MyLinkedList l = new MyLinkedList(100);
            l.Clear();
            List<int> test_arr = new List<int>();
            List<int> out_arr = l.GetArray();
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
        
        public void TestSetValue()
        {
            MyLinkedList l = new MyLinkedList();
            for (int i = 0; i < 100; i++)
            {
                l.AddLast(i);
            }
            l.SetValue(78, -1);
            MyAssert(MethodBase.GetCurrentMethod().Name, l.GetValue(78) == -1);
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
            List<int> out_arr = l.GetArray();
            List<int> test_arr = _CreateArrByOrderOfNumber(from:1, to:99);
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
            List<int> out_arr = l.GetArray();
            List<int> test_arr = _CreateArrByOrderOfNumber(0, 98);
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

        public void TestAccessByIndex()
        {
            MyLinkedList l = new MyLinkedList();
            for (int i = 0; i < 100; i++)
            {
                l.AddLast(i);
            }
            try
            {
                l[100] = 10;
                int test = l[100];
            }
            catch (IndexOutOfRangeException e)
            { }
            MyAssert(MethodBase.GetCurrentMethod().Name, 0 == l[0]);
        }
    }
}
