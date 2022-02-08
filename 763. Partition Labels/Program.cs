using System;
using System.Collections.Generic;

namespace _763._Partition_Labels
{
    class Program
    {
        //https://leetcode.com/problems/partition-labels/
        static void Main(string[] args)
        {
            //Exmaple 
            string S = "ababcbacadefegdehijhklij";
            IList<int> results = PartitionLabels(S);
            Console.WriteLine(String.Join(" ", new List<int>(results).ConvertAll(i => i.ToString()).ToArray())); ;
        }

        public static IList<int> PartitionLabels(string S)
        {
            List<int> results = new List<int>();

            //Check for invalid input 
            if (String.IsNullOrEmpty(S)) return results;

            //Variables
            int i = 0;
            int prevLast = 0;
            int lastIdx = 0;
            int idx;

            //Find the last index for each char and update accordingly
            while (i < S.Length)
            {
                idx = S.LastIndexOf(S[i]); //Get last index
                if (idx > lastIdx)
                    lastIdx = idx;//Update partition end. 

                if (i == lastIdx)
                {//Add partition
                    results.Add(lastIdx - prevLast + 1);
                    prevLast = i + 1;
                }
                i++;
            }
            return results;
        }
    }
}
