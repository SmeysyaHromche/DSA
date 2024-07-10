using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSA.Node;

namespace DSA.BinaryTree
{
    public class MyBTreeNode<T>: Node<T> where T: IComparable<T>
    {
        public MyBTreeNode<T> leftN;
        public MyBTreeNode<T> rightN;
        public MyBTreeNode(T value)
        {
            _value = value;
            leftN = null;
            rightN = null;
        }


    }
}
