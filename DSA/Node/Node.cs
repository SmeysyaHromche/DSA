using DSA.List;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.Node
{
    public class Node<T> where T: IComparable<T>
    {
        protected T _value;
        public T Value { get => _value; set => _value = value; }

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
            else if (obj is Node<T> node)
            {
                return _value.CompareTo(node.Value) == 0;
            }
            else if (obj is T value)
            {
                return _value.Equals(value);
            }
            return false;
        }

        protected static void CheckArg(Node<T> left, object right)
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

        public static bool operator ==(Node<T> left, Node<T> right)
        {
            if (ReferenceEquals(left, null))
            {
                return ReferenceEquals(right, null);
            }
            return left.Equals(right);

        }
        public static bool operator !=(Node<T> left, Node<T> right)
        {
            return !(left == right);
        }

        public static bool operator ==(Node<T> left, T right)
        {
            if (ReferenceEquals(left, null))
            {
                return false;
            }
            return left.Value.Equals(right);
        }
        public static bool operator !=(Node<T> left, T right)
        {
            return !(left == right);
        }

        public static bool operator <(Node<T> left, Node<T> right)
        {
            CheckArg(left, right);
            return left.Value.CompareTo(right.Value) < 0;
        }
        public static bool operator >(Node<T> left, Node<T> right)
        {
            CheckArg(left, right);
            return left.Value.CompareTo(right.Value) > 0;
        }
        public static bool operator <=(Node<T> left, Node<T> right)
        {
            CheckArg(left, right);
            return left.Value.CompareTo(right.Value) <= 0;
        }
        public static bool operator >=(Node<T> left, Node<T> right)
        {
            CheckArg(left, right);
            return left.Value.CompareTo(right.Value) > 0;
        }
        public static bool operator <(Node<T> left, T right)
        {
            CheckArg(left, right);
            return left.Value.CompareTo(right) < 0;
        }
        public static bool operator >(Node<T> left, T right)
        {
            CheckArg(left, right);
            return left.Value.CompareTo(right) > 0;
        }
        public static bool operator <=(Node<T> left, T right)
        {
            CheckArg(left, right);
            return left.Value.CompareTo(right) <= 0;
        }
        public static bool operator >=(Node<T> left, T right)
        {
            CheckArg(left, right);
            return left.Value.CompareTo(right) >= 0;
        }

    }
}
