using System;
using System.Collections.Generic;
using System.Linq;

namespace _3Sum_With_Multiplicity
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = new int[] { 1, 1, 2, 2, 3, 3, 4, 4, 5, 5 };
            int[] arr2 = new int[] { 1, 1, 2, 2, 2, 2 };
            Console.WriteLine(ThreeSumMulti(arr1, 8)); //20
            Console.WriteLine(ThreeSumMulti(arr2, 5)); //12
        }

        public static int ThreeSumMulti(int[] arr, int target)
        {
            long resCount = 0; //Results Count

            //Invalid parameter check
            if (arr == null || arr.Length < 3) return 0;

            //Sort our array
            Array.Sort(arr);

            //Store the frequency of our numbers in a HashTable
            Dictionary<int, long> frq = new Dictionary<int, long>();
            foreach (int i in arr)
                if (frq.ContainsKey(i))
                    frq[i]++;
                else frq.Add(i, 1);

            //Put the unique values into an array
            int[] keys = arr.Distinct<int>().ToArray();

            int l, r, curVal, sum, lo, hi;
            for (int i = 0; i < keys.Length; i++)
            {
                curVal = keys[i];
                l = i;
                r = keys.Length - 1;
                while (l <= r)
                {
                    lo = keys[l]; //Lower Value
                    hi = keys[r]; //Higher Value
                    sum = curVal + lo + hi;
                    if (sum == target) //If target found
                    {
                        //We do the multiplicity
                        if (curVal < lo && lo < hi) //All Different
                            resCount += frq[curVal] * frq[lo] * frq[hi];
                        else if (curVal == lo && lo < hi)
                            resCount += frq[curVal] * (frq[curVal] - 1) / 2 * frq[hi];
                        else if (curVal < lo && lo == hi)
                            resCount += frq[curVal] * frq[lo] * (frq[lo] - 1) / 2;
                        else //All Equal 
                            resCount += frq[curVal] * (frq[curVal] - 1) * (frq[curVal] - 2) / 6;

                        resCount %= 1000000007;
                        l++;
                        r--;
                    }
                    else if (sum < target)
                        l++;
                    else r--;
                }
            }
            return (int)resCount;
        }
    }
}
