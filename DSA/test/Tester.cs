using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        
        protected static void MyAssert(string test_name, bool a, bool b)
        {
            if (a != b)
            {
                throw new ExceptionTestFail($"{test_name} : fail");
            }
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
            int[] arr;
            int v;
            if(from > to || from == to)
            {
                return new int[0];
            }
            arr = new int[to - from + 1];
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
    }
}
