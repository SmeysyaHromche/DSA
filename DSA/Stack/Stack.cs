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
    public class MyStack<T> where T : IComparable<T>
    {
        private int _top;
        private MyLinkedList<T> _stackBody;
        public MyStack()
        { 
            _top = -1;
            _stackBody = new MyLinkedList<T>();
        }
        
        public void Push(T value)
        {
            _top++;
            _stackBody.AddLast(value);
        }

        public T Pop()
        {
            if (_top == -1)
            {
                throw new ExceptionEmptyStack();
            }
            T value = _stackBody[_top--];
            _stackBody.DeleteLast();
            return value;
        }

        public T Top()
        {

            return _stackBody[_top];
        
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
