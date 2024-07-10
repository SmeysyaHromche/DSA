using DSA.List;
using DSA.Stack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.Queue
{
    public class ExceptionEmptyQueue : Exception
    {
        public ExceptionEmptyQueue() { }
        public ExceptionEmptyQueue(string message) : base(message) { }
    }

    public class MyQueue<T> where T : IComparable<T>
    {

        private MyLinkedList<T> _queueBody;
        public MyQueue()
        {
            _queueBody = new MyLinkedList<T>();
        }

        public void Enqueue(T value)
        {
            _queueBody.AddLast(value);
        }

        public T Dequeue()
        {
            if (_queueBody.GetLength() == 0)
            {
                throw new ExceptionEmptyStack();
            }
            T value = _queueBody[0];
            _queueBody.DeleteFirst();
            return value;
        }

        public T Head()
        {

            return _queueBody[0];

        }

        public bool IsEmpty()
        {
            if (_queueBody.GetLength() == 0)
            {
                return true;
            }
            return false;
        }
    }
}
