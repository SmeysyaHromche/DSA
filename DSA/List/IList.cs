using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.List
{
    public interface IList<T> where T : IComparable<T>
    {
        void AddFirst(T value);

        void AddLast(T value);

        T GetValue(int index);

        int GetIndex(T value);

        void Clear();

        void DeleteFirst();

        void DeleteLast();
        
        void Write();

        List<T> GetArray();
    }
}
