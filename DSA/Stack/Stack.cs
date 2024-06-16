using DSA.List;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.Stack
{
    public class ExceptionEmptyStack: Exception
    {
        public ExceptionEmptyStack() { }
        public ExceptionEmptyStack(string message) : base(message) { }
    }
    public class MyStack
    {
        private int _top;
        private MyLinkedList _stackBody;
        public MyStack()
        { 
            _top = -1;
            _stackBody = new MyLinkedList();
        }
        
        public void Push(int value)
        {
            _top++;
            _stackBody.AddLast(value);
        }

        public int Pop()
        {
            if (_top == -1)
            {
                throw new ExceptionEmptyStack();
            }
            int value = _stackBody.GetValue(_top--);
            _stackBody.DeleteLast();
            return value;
        }

        public int Top()
        {

            return _stackBody.GetValue(_top);
        
        }

        public bool IsEmpty()
        {
            if(_top == -1)
            {
                return true;
            }
            return false;
        }

    }
}
