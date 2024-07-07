using Microsoft.Win32;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace DSA.BinaryTree
{
    public class MyBTree
    {
        private MyBTreeNode _root;
        public MyBTree()
        {
            _root = null;
        }

        public void Insert(int value)
        {
            if (_root == null)
            {
                _root = new MyBTreeNode(value);
                return;
            }

            MyBTreeNode aux = _root;
            for (; ; )
            {
                if (aux.Value == value)
                {
                    Console.WriteLine($"value {value} already exist in tree");
                    return;
                }
                else if (aux.Value > value)
                {
                    if (aux.leftN == null)
                    {
                        aux.leftN = new MyBTreeNode(aux.Value);
                        return;
                    }
                    aux = aux.leftN;
                }
                else
                {
                    if (aux.rightN == null)
                    {
                        aux.rightN = new MyBTreeNode(aux.Value);
                        return;
                    }
                    aux = aux.rightN;
                }
            }
        }

        public void RemoveByIter(int value)
        {
            if(_root == null)
            { return; }
            MyBTreeNode aux = _root;
            while (_root != null)
            {
                if (aux.Value == value)
                {
                    _Remover(ref aux);
                }
                else if(aux.Value < value)
                {
                    aux = aux.rightN;
                }
                else
                {
                    aux = aux.leftN;
                }
            }
        }
        public void RemoveByRec(int value)
        {
            
            RemoveByRec(ref _root, value);
        }
        public void RemoveByRec(ref MyBTreeNode node, int value)
        {
            if (node == null)
            {
                return;
            }
            if (node.Value == value)
            {
                _Remover(ref node);
            }
            else if (node.Value < value)
            {
                RemoveByRec(ref node.rightN, value);
            }
            else
            {
                RemoveByRec(ref node.leftN, value);
            }
        }

        private void _Remover(ref MyBTreeNode node)
        {
            if (node == null)
            {
                return;
            }
            if(node.leftN != null && node.rightN != null)
            {
                MyBTreeNode aux = FindMin(ref node);
                node.Value = aux.Value;
                _Remover(ref aux);
            }
            else if(node.leftN != null)
            {
                node = node.leftN;
            }
            else if(node.rightN != null)
            {
                node = node.rightN;
            }
            else
            {
                node = null;
            }
        }
        private MyBTreeNode FindMin(ref MyBTreeNode node)
        {
            if (node == null)
            {
                return node;
            }

            MyBTreeNode aux = node;
            MyBTreeNode min = node;
            while(aux != null)
            {
                if(aux.Value < min.Value)
                {
                    min = aux;
                    aux = aux.leftN;
                }
            }
            return min;
        }


        public bool Find(int value)
        {
            MyBTreeNode aux = _root;
            while (aux != null)
            {
                if (aux.Value == value)
                {
                    return true;
                }
                else if (aux.Value > value)
                {
                    aux = aux.leftN;
                }
                else
                {
                    aux = aux.rightN;
                }
            }
            return false;
        }


        public void Clear()=>_root = null;

        public List<int> PreOrderRec()
        {
            List<int> ret = new List<int>();
            PreOrderRec(ret, _root);
            return ret;
        }
        public void PreOrderRec(List<int> ret, MyBTreeNode aux)
        {
            if (aux == null)
            {
                return;
            }
            ret.Add(aux.Value);
            PreOrderRec(ret, aux.leftN);
            PreOrderRec(ret, aux.rightN);
        }
        public List<int> InOrderRec()
        {
            List<int> ret = new List<int>();
            InOrderRec(ret, _root);
            return ret;
        }
        public void InOrderRec(List<int> ret, MyBTreeNode aux)
        {
            if (aux == null)
            {
                return;
            }
            InOrderRec(ret, aux.leftN);
            ret.Add(aux.Value);
            InOrderRec(ret, aux.rightN);
        }
        public List<int> PostOrder()
        {
            List<int> ret = new List<int>();
            InOrderRec(ret, _root);
            return ret;
        }
        public void PostOrder(List<int> ret, MyBTreeNode aux)
        {
            if (aux == null)
            {
                return;
            }
            InOrderRec(ret, aux.leftN);
            ret.Add(aux.Value);
            InOrderRec(ret, aux.rightN);
        }
        public int GetDepth() => GetDepth(_root);

        public int GetDepth(MyBTreeNode aux)
        {
            if(aux == null)
            {
                return 0;
            }
            return Math.Max(GetDepth(aux.leftN), GetDepth(aux.rightN))+1;
        }
    }
}
