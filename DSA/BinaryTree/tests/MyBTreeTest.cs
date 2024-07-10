using System;
using DSA.test;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.BinaryTree.tests
{
    public class MyBTreeTest : Tester
    {
        public override void RunAll()
        {

            Console.WriteLine("\n*** TEST FOR  BINARY TREE ***\n");
            PreOrderTest();
            InOrderTest();
            PostOrderTest();
            Console.WriteLine("\n*** *** *** *** ***\n");
        }

        public void PreOrderTest()
        {

            List<int> arr = _CreateArrByOrderOfNumber(10);
            MyBTree<int> tree = new MyBTree<int>();
            
            
        }
        public void InOrderTest()
        {

        }

        public void PostOrderTest()
        {

        }
    }
}
