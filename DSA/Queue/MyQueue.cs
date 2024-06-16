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

    public class MyQueue{

        private MyLinkedList _queueBody;
        public MyQueue()
        {
            _queueBody = new MyLinkedList();
        }

        public void Enqueue(int value)
        {
            _queueBody.AddLast(value);
        }

        public int Dequeue()
        {
            if (_queueBody.GetLength() == 0)
            {
                throw new ExceptionEmptyStack();
            }
            int value = _queueBody.GetValue(0);
            _queueBody.DeleteFirst();
            return value;
        }

        public int Head()
        {

            return _queueBody.GetValue(0);

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
