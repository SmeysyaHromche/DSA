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
                Console.WriteLine($"{MethodBase.GetCurrentMethod().Name}: pass");
            }
            else
            {
                Console.ForegroundColor= ConsoleColor.Green;
                Console.WriteLine($"{MethodBase.GetCurrentMethod().Name}: pass");
            }
            Console.ResetColor();
        }

        protected int[] _CreateArrByOrderOfNumber(int size, bool flagByDeValue = false, int value = 0, bool flagReverse = false)
        {
            int[] arr;
            int v;
            if (size < 0)
            {
                arr = new int[0];
            }
            else
            {
                arr = new int[size];
            }
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
                    arr[i] = v;
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
                    arr[i] = v;
                }
            }
            return arr;
        }
        protected int[] _CreateArrByOrderOfNumber(int from, int to, bool flagReverse=false)
        {
            if(from > to || from == to)
            {
                return new int[0];
            }

            int[] arr = new int[to - from + 1];
            int v;
            
            if (!flagReverse)
            {
                v = from;
                for(int i = 0; i < to - from + 1; i++)
                {
                    arr[i] = v++;
                }
            }
            else
            {
                v = to;
                for (int i = 0; i < to - from + 1; i++)
                {
                    arr[i] = v--;
                }
            }
            return arr;
        }
        protected int[] _RandomArr(int from, int to)
        {
            int[] arr = _CreateArrByOrderOfNumber(from, to);
            if(!(arr.Length < 2))
            {
                Random random = new Random();
                for (int i = arr.Length - 1; i > 0; i--)
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
