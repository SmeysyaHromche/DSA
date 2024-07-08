using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.List
{
     public class ListNode
    {
        protected int _value = 0;
        public int Value { get { return _value; } set { _value = value ;} }
        public ListNode next = null;

        public ListNode(int value)
        {
            _value = value;   
        }
    }
}
