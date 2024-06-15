using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.List
{
    internal class MyLinkedList: IList
    {
        protected ListNode _head = null;  
        protected int _len = 0;

        public MyLinkedList() 
        { 
        }

        public MyLinkedList(ref int[] arr)
        {
            
            for (int i = 0; i < arr.Length; i++)
            {
                AddLast(arr[i]);  
            }

        }

        public MyLinkedList(int size, int value=0) 
        {
            _head = new ListNode(value);
            ListNode aux = _head;
            _len++;
            for (int i = 1; i < size; i++)
            {
                aux.next = new ListNode(value);
                aux = (ListNode)aux.next;
                _len++;
            }
        }

        public void AddFirst(int value)
        {
            if (_len == 0)
            { 
                _head = new ListNode(value);
            }
            else
            {
                ListNode aux = _head;
                _head = new ListNode(value);
                _head.next = aux;
            }
            _len++;
        }

        public void AddLast(int value)
        {
            if (_len == 0)
            {
                _head = new ListNode(value);
            }
            else
            {
                ListNode aux = _head;
                while (aux.next != null)
                {
                    aux = (ListNode)aux.next;
                }
                aux.next = new ListNode(value);
            }

            _len++;
        }

        public int GetValue(int index)
        {
            if (_len <= index || index <= 0)
            { 
                throw new IndexOutOfRangeException();
            }

            ListNode aux = _head;
            for (int i = 0; i < index; i++)
            {
                aux = (ListNode)aux.next;
            }
            
            return aux.GetValue();
        }

        public int GetIndex(int value)
        {
            if (_len == 0)
            {  
                return -1;
            }
            
            ListNode aux = _head;
            for (int i = 0; i < _len; i++)
            {
                if (aux.GetValue() == value)
                {
                    return i;
                }

                aux = (ListNode)aux.next;
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

            ListNode aux = _head;
            for (int i = 0; i < _len-1; i++)
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
            ListNode aux = _head;
            for (int i = 0; i < _len; i++)
            { 
                Console.Write($"{aux.GetValue()} ");
                aux = (ListNode)aux.next;
            }
            Console.WriteLine();
        }

        public int[] GetArray()
        {
            if (_len == 0)
            {
                return new int[0];
            }

            int[] array = new int[ _len ];
            ListNode aux = _head;
            for (int i = 0; i < _len; i++)
            {
                array[i] = aux.GetValue();
                aux = aux.next;
            }
            return array;
        }

    }
}
