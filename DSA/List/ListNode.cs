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
        public ListNode next = null;

        public ListNode(int value)
        {
            _value = value;   
        }

        public int GetValue()
        {
            return _value;
        }

        public void SetValue(int value)
        {
            value = _value;
        }


    }
}
