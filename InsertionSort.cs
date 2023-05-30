using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector
{
    class InsertionSort : ISorter
    {
        public void Sort<K>(K[] array, int index, int num, IComparer<K> comparer) where K : IComparable<K>
        {

            for(int i = index + 1; i < num; i ++)
            {
                int k = comparer.Compare(array[i - 1], array[i]);
                if (k < 0)
                {
                    continue;
                }
                else
                {
                    for(int j = i; j > index ; j--)
                    {
                        k = comparer.Compare(array[j - 1], array[j]);
                        if(k > 0)
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
    }
}
