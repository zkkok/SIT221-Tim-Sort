using System;
using System.Collections.Generic;
using System.Text;

namespace Vector
{
    public class Vector<T> where T: IComparable<T>
    {
        private const int DEFAULT_CAPACITY = 10;

        private T[] data;

        public int Count { get; private set; } = 0;

        public int Capacity
        {
            get { return data.Length; }
        }

        public Vector(int capacity)
        {
            data = new T[capacity];
        }

        public Vector() : this(DEFAULT_CAPACITY) { }

        public T this[int index]
        {
            get
            {
                if (index >= Count || index < 0) throw new IndexOutOfRangeException();
                return data[index];
            }
            set
            {
                if (index >= Count || index < 0) throw new IndexOutOfRangeException();
                data[index] = value;
            }
        }

        private void ExtendData(int extraCapacity)
        {
            T[] newData = new T[Capacity + extraCapacity];
            for (int i = 0; i < Count; i++) newData[i] = data[i];
            data = newData;
        }

        public void Add(T element)
        {
            if (Count == Capacity) ExtendData(DEFAULT_CAPACITY);
            data[Count] = element;
            Count++;
        }

        public int IndexOf(T element)
        {
            for (var i = 0; i < Count; i++)
            {
                if (data[i].Equals(element)) return i;
            }
            return -1;
        }

        public void Insert(int index, T element)
        {
            if(Capacity == Count)
            {
                ExtendData(1);
            }

            if(index == Count)
            {
                data[index] = element;
                Count++;
            }
            else if(index >= Count)
            {
                throw new IndexOutOfRangeException("The index is out of range");
            }
            else
            {
                int j = Count - 1;
                for(int i = Count; i >= 0 ; i--)
                {
                    if(i == index)
                    {
                        Count++;
                        continue;
                    }
                    else
                    {
                        data[i] = data[j];
                        j--;
                    }
                }
                data[index] = element;
            }
        }

        public void Clear()
        {
            T[] tempdata = new T[Capacity];
            data = tempdata;
            Count = 0;   
        }

        public bool Contains(T element)
        {
            for(int i = 0; i < Count; i++)
            {
                if(data[i].Equals(element))
                {
                    return true;
                }
            }
            return false;
        }

        public bool Remove(T element)
        {
            int i = IndexOf(element);

            if(i == -1)
            {
                return false;
            }
            else
            {
                RemoveAt(i);
                return true;
            }
        }

        public void RemoveAt(int index)
        {
            if (index >= Count)
            {
                throw new IndexOutOfRangeException("The index is out of range");
            }

            int j = 0;
            for(int i = 0; i< Count; i++)
            {
                if(i == index)
                {
                    continue;
                }
                else
                {
                    data[j] = data[i];
                    j++;
                }
            }
            Count--;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder("[" +  data[Count-1] +"]");

            for(int i = Count- 2; i >= 0; i--)
            {
                result.Insert(1, data[i] + ",");
            }

            
            
            return Convert.ToString(result);
        }

        public void Sort()
        {
            Array.Sort(data,0,Count);
        }

        public void Sort(IComparer<T> comparer)
        {
            Array.Sort(data,0,Count, comparer);
        }

        public void Sort(ISorter algorithm, IComparer<T> comparer)
        {
            if(algorithm == null)
            {
                Sort(comparer);
            }
            else if(comparer == null)
            {
                Sort(algorithm,Comparer<T>.Default);
            }
            else
            {
                algorithm.Sort(data,0,Count,comparer);
            }


        }

    }
}
