using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
namespace DSA.test
{


    public abstract class Tester
    {
        protected class ExceptionTestFail : Exception
        {
            public ExceptionTestFail() { }
            public ExceptionTestFail(string message) : base(message) { }
        }
        public abstract void RunAll();

        protected void MyAssert(string test_name, bool a, bool b = true)
        {
            if (a != b)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{test_name}: fail");
            }
            else
            {
                Console.ForegroundColor= ConsoleColor.Green;
                Console.WriteLine($"{test_name}: pass");
            }
            Console.ResetColor();
        }

        protected List<int> _CreateArrByOrderOfNumber(int size, bool flagByDeValue = false, int value = 0, bool flagReverse = false)
        {
            List<int> arr = new List<int>();
            int v;
            
            if (!flagReverse)
            {
                for (int i = 0; i < size; i++)
                {
                    if (flagByDeValue)
                    {
                        v = value;
                    }
                    else
                    {
                        v = i;
                    }
                    arr.Add(v);
                }
            }
            else
            {
                for (int i = size - 1; i >= size; i--)
                {
                    if (flagByDeValue)
                    {
                        v = value;
                    }
                    else
                    {
                        v = i;
                    }
                    arr.Insert(i, v);
                }
            }
            return arr;
        }
        protected List<int> _CreateArrByOrderOfNumber(int from, int to, bool flagReverse=false)
        {
            if(from > to || from == to)
            {
                return new List<int>();
            }

            List<int> arr = new List<int>();
            int v;
            
            if (!flagReverse)
            {
                v = from;
                for(int i = 0; i < to - from + 1; i++)
                {
                    arr.Add(v++);
                }
            }
            else
            {
                v = to;
                for (int i = 0; i < to - from + 1; i++)
                {
                    arr.Add(v--);
                }
            }
            return arr;
        }
        protected List<int> _RandomArr(int from, int to)
        {
            List<int> arr = _CreateArrByOrderOfNumber(from, to);
            if(!(arr.Count < 2))
            {
                Random random = new Random();
                for (int i = arr.Count - 1; i > 0; i--)
                {
                    int j = random.Next(0, i + 1);
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }
            return arr;
        }

    }
}
