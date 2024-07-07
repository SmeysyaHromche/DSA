using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.List
{
    public interface IList
    {
        void AddFirst(int value);

        void AddLast(int value);

        int GetValue(int index);

        int GetIndex(int value);

        void Clear();

        void DeleteFirst();

        void DeleteLast();
        
        void Write();

        List<int> GetArray();
    }
}
