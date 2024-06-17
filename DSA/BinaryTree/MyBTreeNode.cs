using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.BinaryTree
{
    public class MyBTreeNode
    {
        private int _value;
        public MyBTreeNode leftN;
        public MyBTreeNode rightN;
        public MyBTreeNode(int value)
        {
            _value = value;
            leftN = null;
            rightN = null;
        }

        public int GetValue()
        {
            return _value;
        }


    }
}
