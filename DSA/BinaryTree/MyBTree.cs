using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.BinaryTree
{
    public abstract class AMyBTree
    {
        private MyBTreeNode _root;
        public AMyBTree()
        {
            _root = null;
        }
        public abstract void Insert(int value);
        public abstract void Remove();
        public abstract void Clear();
        public abstract int[] PreOrder();
        public abstract int[] InOrder();
        public abstract int[] PostOrder();
        public abstract bool Find(int value);
        public abstract int GetDepth();
    }
}
