using System;
using System.Collections.Generic;

namespace _284._Peeking_Iterator
{
    class Program
    {
        //https://leetcode.com/problems/peeking-iterator/submissions/
        static void Main(string[] args)
        {
        }

        class PeekingIterator
        {
            List<int> values;
            int idx;
            // iterators refers to the first element of the array.
            public PeekingIterator(IEnumerator<int> iterator)
            {
                // initialize any member here.
                values = new List<int>();
                idx = -1;
                if (iterator != null)
                {
                    values.Add(iterator.Current);
                    while (iterator.MoveNext())
                    {
                        values.Add(iterator.Current);
                    }
                }
            }

            // Returns the next element in the iteration without advancing the iterator.
            public int Peek()
            {
                return values[idx + 1];                
            }

            // Returns the next element in the iteration and advances the iterator.
            public int Next()
            {
                idx++;
                return values[idx];
            }

            // Returns false if the iterator is refering to the end of the array of true otherwise.
            public bool HasNext()
            {
                return idx < values.Count - 1;
            }
        }
    }
}
