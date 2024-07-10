using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.List
{
    internal class MyLinkedList<T> : IList<T> where T : IComparable<T>
    {
        protected ListNode<T> _head = null;
        protected int _len = 0;

        public MyLinkedList() { }
        public MyLinkedList(List<T> arr)
        {

            for (int i = 0; i < arr.Count; i++)
            {
                AddLast(arr[i]);
            }

        }

        public MyLinkedList(int size, T value)
        {
            _head = new ListNode<T>(value);
            ListNode<T> aux = _head;
            _len++;
            for (int i = 1; i < size; i++)
            {
                aux.next = new ListNode<T>(value);
                aux = aux.next;
                _len++;
            }
        }

        public void AddFirst(T value)
        {
            if (_len == 0)
            {
                _head = new ListNode<T>(value);
            }
            else
            {
                ListNode<T> aux = _head;
                _head = new ListNode<T>(value);
                _head.next = aux;
            }
            _len++;
        }

        public void AddLast(T value)
        {
            if (_len == 0)
            {
                _head = new ListNode<T>(value);
            }
            else
            {
                ListNode<T> aux = _head;
                while (aux.next != null)
                {
                    aux = aux.next;
                }
                aux.next = new ListNode<T>(value);
            }

            _len++;
        }

        public T GetValue(int index)
        {
            if (_len <= index || index < 0)
            {
                throw new IndexOutOfRangeException();
            }

            ListNode<T> aux = _head;
            for (int i = 0; i < index; i++)
            {
                aux = aux.next;
            }

            return aux.Value;
        }

        public void SetValue(int  index, T value)
        {
            if (index < 0 || index >= _len)
            {
                throw new IndexOutOfRangeException();
            }
            ListNode<T> aux = _head;
            for (int i = 0; i < index; i++)
            {
                aux = aux.next;
            }
            aux.Value = value;
        }

        public int GetIndex(T value)
        {
            if (_len == 0)
            {
                return -1;
            }

            ListNode<T> aux = _head;
            ListNode<T> trg = new ListNode<T>(value);
            for (int i = 0; i < _len; i++)
            {
                if (aux == trg)
                {
                    return i;
                }

                aux = aux.next;
            }

            return -1;
        }

        public void Clear()
        {
            _head = null;
            _len = 0;
        }

        public void DeleteFirst()
        {

            if (_len == 0)
            {
                return;
            }

            _head = _head.next;
            _len--;
        }

        public void DeleteLast()
        {
            if (_len == 0)
            {
                return;
            }

            ListNode<T> aux = _head;
            for (int i = 0; i < _len - 1; i++)
            {
                aux = aux.next;
            }

            aux.next = null;
            _len--;
        }
        public void Write()
        {
            if (_len == 0)
            {
                Console.WriteLine("Empty list");
            }
            ListNode<T> aux = _head;
            for (int i = 0; i < _len; i++)
            {
                Console.Write($"{aux.Value} ");
                aux = aux.next;
            }
            Console.WriteLine();
        }

        public List<T> GetArray()
        {
            if (_len == 0)
            {
                return new List<T>();
            }

            List<T> array = new List<T>();
            ListNode<T> aux = _head;
            for (int i = 0; i < _len; i++)
            {
                array.Add(aux.Value);
                aux = aux.next;
            }
            return array;
        }

        public int GetLength()
        {
            return _len;
        }

        public T this[int index]
        {
            get
            {
                return GetValue(index);
            }
            set
            {
                SetValue(index, value);
            }
        }
    }
}
