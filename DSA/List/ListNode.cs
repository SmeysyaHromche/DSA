using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DSA.Node;

namespace DSA.List
{
    public class ListNode<T>: Node<T> where T: IComparable<T>
    {
        public ListNode<T> next = null;

        public ListNode(T value)
        {
            _value = value;
        }

    }
}
