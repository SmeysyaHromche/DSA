using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DSA.List
{
    public class ListNode<T> where T : IComparable<T>
    {
        protected T _value;
        public T Value { get { return _value; } set { _value = value; } }
        public ListNode<T> next = null;

        public ListNode(T value)
        {
            _value = value;
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            else if (obj is ListNode<T> node)
            {
                return _value.CompareTo(node.Value) == 0;
            }
            else if (obj is T value)
            {
                return _value.Equals(value);
            }
            return false;
        }

        private static void CheckArg(ListNode<T> left, object right)
        {
            if (ReferenceEquals(left, null))
            {
                throw new ArgumentNullException(nameof(left));
            }
            if (right == null)
            {
                throw new ArgumentNullException(nameof(right));
            }

        }

        public static bool operator ==(ListNode<T> left, ListNode<T> right)
        {
            if (ReferenceEquals(left, null))
            {
                return ReferenceEquals(right, null);
            }
            return left.Equals(right);

        }
        public static bool operator !=(ListNode<T> left, ListNode<T> right)
        {
            return !(left == right);
        }

        public static bool operator ==(ListNode<T> left, T right)
        {
            if (ReferenceEquals(left, null))
            {
                return false;
            }
            return left.Value.Equals(right);
        }
        public static bool operator !=(ListNode<T> left, T right)
        {
            return !(left == right);
        }

        public static bool operator <(ListNode<T> left, ListNode<T> right)
        {
            CheckArg(left, right);
            return left.Value.CompareTo(right.Value) < 0;
        }
        public static bool operator >(ListNode<T> left, ListNode<T> right)
        {
            CheckArg(left, right);
            return left.Value.CompareTo(right.Value) > 0;
        }
        public static bool operator <=(ListNode<T> left, ListNode<T> right)
        {
            CheckArg(left, right);
            return left.Value.CompareTo(right.Value) <= 0;
        }
        public static bool operator >=(ListNode<T> left, ListNode<T> right)
        {
            CheckArg(left, right);
            return left.Value.CompareTo(right.Value) > 0;
        }
        public static bool operator <(ListNode<T> left, T right)
        {
            CheckArg(left, right);
            return left.Value.CompareTo(right) < 0;
        }
        public static bool operator >(ListNode<T> left, T right)
        {
            CheckArg(left, right);
            return left.Value.CompareTo(right) > 0;
        }
        public static bool operator <=(ListNode<T> left, T right)
        {
            CheckArg(left, right);
            return left.Value.CompareTo(right) <= 0;
        }
        public static bool operator >=(ListNode<T> left, T right)
        {
            CheckArg(left, right);
            return left.Value.CompareTo(right) >= 0;
        }





    }
}
