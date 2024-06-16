using DSA.Sorting;
using DSA.test;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DSA.Stack.tests
{
    public class StackTest: Tester
    {
        override public void RunAll()
        {
            Console.WriteLine("\n*** TEST FOR STACK ***\n");
            TestInitEmptyTest();
            TestPush();
            TestPop();
            TestTop();
            TestMultiPushPop();
            Console.WriteLine("\n*** *** *** *** ***\n");
        }

        public void TestInitEmptyTest()
        {
            MyStack stack = new MyStack();
            MyAssert(MethodBase.GetCurrentMethod().Name, stack.IsEmpty());
        }
        public void TestPush()
        {
            MyStack stack = new MyStack();
            stack.Push(1);
            MyAssert(MethodBase.GetCurrentMethod().Name, !stack.IsEmpty());
        }

        public void TestPop()
        {
            MyStack stack = new MyStack();
            stack.Push(1);
            int result  = stack.Pop();
            MyAssert(MethodBase.GetCurrentMethod().Name, result == 1);
        }

        public void TestTop()
        {
            MyStack stack = new MyStack();
            for (int i = 0; i < 100; i++)
            { 
                stack.Push(i);
            }
            MyAssert(MethodBase.GetCurrentMethod().Name, stack.Top() == 99);
        }

        public void TestMultiPushPop()
        {
            MyStack stack = new MyStack();
            for (int i = 0; i < 100; i++)
            { 
                stack.Push(i);
            }
            for (int i = 0; i < 100; i++)
            {
                stack.Pop();
            }
            MyAssert(MethodBase.GetCurrentMethod().Name, stack.IsEmpty());
        }
        
    }
}
