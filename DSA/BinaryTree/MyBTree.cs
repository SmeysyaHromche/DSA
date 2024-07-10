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
    public class MyBTree<T> where T : IComparable<T>
    {
        private MyBTreeNode<T> _root;
        public MyBTree()
        {
            _root = null;
        }

        public void Insert(T value)
        {
            if (_root == null)
            {
                _root = new MyBTreeNode<T>(value);
                return;
            }

            MyBTreeNode<T> aux = _root;
            for (; ; )
            {
                if (aux == value)
                {
                    Console.WriteLine($"value {value} already exist in tree");
                    return;
                }
                else if (aux > value)
                {
                    if (aux.leftN == null)
                    {
                        aux.leftN = new MyBTreeNode<T>(aux.Value);
                        return;
                    }
                    aux = aux.leftN;
                }
                else
                {
                    if (aux.rightN == null)
                    {
                        aux.rightN = new MyBTreeNode<T>(aux.Value);
                        return;
                    }
                    aux = aux.rightN;
                }
            }
        }

        public void RemoveByIter(T value)
        {
            if(_root == null)
            { return; }
            MyBTreeNode<T> aux = _root;
            while (_root != null)
            {
                if (aux == value)
                {
                    _Remover(ref aux);
                }
                else if(aux < value)
                {
                    aux = aux.rightN;
                }
                else
                {
                    aux = aux.leftN;
                }
            }
        }
        public void RemoveByRec(T value)
        {
            
            RemoveByRec(ref _root, value);
        }
        public void RemoveByRec(ref MyBTreeNode<T> node, T value)
        {
            if (node == null)
            {
                return;
            }
            if (node == value)
            {
                _Remover(ref node);
            }
            else if (node < value)
            {
                RemoveByRec(ref node.rightN, value);
            }
            else
            {
                RemoveByRec(ref node.leftN, value);
            }
        }

        private void _Remover(ref MyBTreeNode<T> node)
        {
            if (node == null)
            {
                return;
            }
            if(node.leftN != null && node.rightN != null)
            {
                MyBTreeNode<T> aux = FindMin(ref node);
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
        private MyBTreeNode<T> FindMin(ref MyBTreeNode<T> node)
        {
            if (node == null)
            {
                return node;
            }

            MyBTreeNode<T> aux = node;
            MyBTreeNode<T> min = node;
            while(aux != null)
            {
                if(aux < min)
                {
                    min = aux;
                    aux = aux.leftN;
                }
            }
            return min;
        }


        public bool Find(T value)
        {
            MyBTreeNode<T> aux = _root;
            while (aux != null)
            {
                if (aux == value)
                {
                    return true;
                }
                else if (aux > value)
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

        public List<T> PreOrderRec()
        {
            List<T> ret = new List<T>();
            PreOrderRec(ret, _root);
            return ret;
        }
        public void PreOrderRec(List<T> ret, MyBTreeNode<T> aux)
        {
            if (aux == null)
            {
                return;
            }
            ret.Add(aux.Value);
            PreOrderRec(ret, aux.leftN);
            PreOrderRec(ret, aux.rightN);
        }
        public List<T> InOrderRec()
        {
            List<T> ret = new List<T>();
            InOrderRec(ret, _root);
            return ret;
        }
        public void InOrderRec(List<T> ret, MyBTreeNode<T> aux)
        {
            if (aux == null)
            {
                return;
            }
            InOrderRec(ret, aux.leftN);
            ret.Add(aux.Value);
            InOrderRec(ret, aux.rightN);
        }
        public List<T> PostOrder()
        {
            List<T> ret = new List<T>();
            InOrderRec(ret, _root);
            return ret;
        }
        public void PostOrder(List<T> ret, MyBTreeNode<T> aux)
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

        public int GetDepth(MyBTreeNode<T> aux)
        {
            if(aux == null)
            {
                return 0;
            }
            return Math.Max(GetDepth(aux.leftN), GetDepth(aux.rightN))+1;
        }
    }
}
