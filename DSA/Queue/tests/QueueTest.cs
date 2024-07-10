using System;
using DSA.test;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSA.Stack;
using System.Reflection;

namespace DSA.Queue.tests
{
    public class QueueTest: Tester
    {
        override public void RunAll()
        {
            Console.WriteLine("\n*** TEST FOR QUEUE ***\n");
            TestInitEmptyQueue();
            TestEnqueue();
            TestDequeue();
            TestHead();
            TestMultiEnqueueDequeue();
            Console.WriteLine("\n*** *** *** *** ***\n");
        }

        public void TestInitEmptyQueue()
        {
            MyQueue<int> queue = new MyQueue<int>();
            MyAssert(MethodBase.GetCurrentMethod().Name, queue.IsEmpty());
        }
        public void TestEnqueue()
        {
            MyQueue<int> queue = new MyQueue<int>();
            queue.Enqueue(1);
            MyAssert(MethodBase.GetCurrentMethod().Name, !queue.IsEmpty());
        }

        public void TestDequeue()
        {
            MyQueue<int> queue = new MyQueue<int>();
            queue.Enqueue(1);
            int result = queue.Dequeue();
            MyAssert(MethodBase.GetCurrentMethod().Name, result == 1);
        }

        public void TestHead()
        {
            MyQueue<int> queue = new MyQueue<int>();
            for (int i = 0; i < 100; i++)
            {
                queue.Enqueue(i);
            }
            MyAssert(MethodBase.GetCurrentMethod().Name, queue.Head() == 0);
        }

        public void TestMultiEnqueueDequeue()
        {
            MyQueue<int> queue = new MyQueue<int>();
            for (int i = 0; i < 100; i++)
            {
                queue.Enqueue(i);
            }
            for (int i = 0; i < 100; i++)
            {
                queue.Dequeue();
            }
            MyAssert(MethodBase.GetCurrentMethod().Name, queue.IsEmpty());
        }

    }
}
