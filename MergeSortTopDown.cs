using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector
{
    class MergeSortTopDown : ISorter
    {
        //Merge two arrays together in a specified order
        private void Merge<K>(K[] array1, K[] array2, K[]mainarray, IComparer<K> comparer) where K : IComparable<K>
        {
            int j = 0;
            int i = 0;
            //Compile array1 and array2 into mainarray
            while(i+j < mainarray.Length)
            {
                //If array1 has all of its elements populated into mainarray or when array1[i] element is larger than array2[j] whilej has remaining elements
                //Else populate the current index with element from array1
                if(i == array1.Length || (j < array2.Length && comparer.Compare(array1[i],array2[j]) > 0))
                {
                    mainarray[i + j] = array2[j];
                    j++;
                }
                else
                {
                    mainarray[i + j] = array1[i];
                    i++;
                }
            }
        }

        public void Sort<K>(K[] array, int index, int num, IComparer<K> comparer) where K : IComparable<K>
        {
            double len = array.Length;
            //When the partition procedes to the smallest possible length then stop partitioning and return to the previous call
            if (len < 2)
            {
                return;
            }

            //Partition the arrays into half with m representing the number of elements in each partition
            int m = Convert.ToInt32(Math.Ceiling(len / 2));
            //If m is not an even number then add 1 to make sure we have at least pairs that we could work on
            if (m % 2 != 0 && m != 1)
            {
                m += 1;
            }

            //Partition the arrays base on m
            K[] array1 = array.Take(m).ToArray();
            K[] array2 = array.Skip(m).ToArray();

            //Recursive calls on the partitions
            Sort(array1, 0, m, comparer);
            Sort(array2, m+1,num , comparer);

            //Perform merge operations on the two partitioned arrays
            Merge(array1, array2,array, comparer);
        }
    }
}
