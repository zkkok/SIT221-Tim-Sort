using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector
{
    class TimSort : ISorter
    {
        private void InsertionSort<K>(K[] array, int index, int num, IComparer<K> comparer) where K : IComparable<K>
        {
            for (int i = index + 1; i < num; i++)
            {
                int k = comparer.Compare(array[i - 1], array[i]);
                if (k < 0)
                {
                    continue;
                }
                else
                {
                    for (int j = i; j > index; j--)
                    {
                        k = comparer.Compare(array[j - 1], array[j]);
                        if (k > 0)
                        {
                            K temp = array[j];
                            array[j] = array[j - 1];
                            array[j - 1] = temp;
                        }
                        else
                        {
                            break;
                        }
                    }
                }

            }
        }

        private void Merge<K>(K[] array1, K[] array2, K[] mainarray, IComparer<K> comparer,int start) where K : IComparable<K>
        {
            int j = 0;
            int i = 0;
            int z = start;
            

            while (i + j < array1.Length + array2.Length)
            {
                if (i == array1.Length || (j < array2.Length && comparer.Compare(array1[i], array2[j]) > 0))
                {
                    mainarray[z] = array2[j];
                    j++;
                    z++;
                }
                else
                {
                    mainarray[z] = array1[i];
                    i++;
                    z++;
                }
            }
        }

        private void MergeSort<K>(K[] array, int index, IComparer<K> comparer, int size) where K : IComparable<K>
        {
            //Partition the arrays into half with m representing the number of elements in each partition
            int m = size;

            //Partition the arrays base on m
            K[] array1 = array.Skip(index).Take(m).ToArray();
            K[] array2 = array.Skip(m+index).Take(m).ToArray();


            //Perform merge operations on the two partitioned arrays
            Merge(array1, array2, array, comparer,index);
        }

        public void Sort<K>(K[] array, int index, int num, IComparer<K> comparer) where K : IComparable<K>
        {
            int runsize = 32;
            int k = 0;

            for(int i = 0; i < array.Length; i += runsize)
            {
                if(i + runsize > array.Length)
                {
                    k = array.Length;
                }
                else
                {
                    k = i + runsize;
                }

                InsertionSort(array,i, k, comparer);
            }

            for (int j = runsize; j < array.Length; j *= 2)
            {
                for (int i = 0; i < array.Length; i += j * 2)
                {
                    MergeSort(array, i, comparer, j);
                }
            }
        }



    }
}
