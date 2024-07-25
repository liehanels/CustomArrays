using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomArrays
{
    internal class TravelList<T>
    {
        private T[] innerArray;
        private int c;

        public TravelList(int size)
        {
            innerArray = new T[size];
            c = 0;
        }
        public int C => c;
        public void Add(T item)
        {
            if (c >= innerArray.Length)
            {
                throw new InvalidOperationException("Array full");
            }
            innerArray[c] = item;
            c++;
        }
        public void Resize()
        {
            T[] newArray = new T[innerArray.Length + 1];
            Array.Copy(innerArray, newArray, newArray.Length);
            innerArray = newArray;
        }
        public void AddResize(T item)
        {
            if (c >= innerArray.Length)
            {
                Resize();
            }
            innerArray[c] = item;
            c++;
        }
        public T Get(int index)
        {
            if (index <0 || index >= c)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }
            return innerArray[index];
        }
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= c)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }
            for (int i = index; i < c - 1; i++)
            {
                innerArray[i] = innerArray[i + 1];
            }
            innerArray[c - 1] = default(T);
            c--;
        }
        public int Search(T item)
        {
            for (int i = 0; i < c; i++)
            {
                if (innerArray[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }
        public void Print()
        {
            for(int i = 0;i < c;i++)
            {
                Console.WriteLine((i + 1) + ". " + innerArray[i]);
            }
            Console.WriteLine("Item Count: " + c);
        }
    }
}
