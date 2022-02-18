using System;
using System.Collections.Generic;

namespace _39._Combination_Sum
{
    class Program
    {
        //https://leetcode.com/problems/combination-sum/
        static void Main(string[] args)
        {
            //Example 1 - Find all the combinations that add up to 7
            IList<IList<int>> results = CombinationSum(new int[] { 2, 3, 6, 7 }, 7);
            PrintResults(results);
        }

        static IList<IList<int>> results;
        static void PrintResults(IList<IList<int>> lists)
        {
            Console.Write("[");
            foreach (IList<int> list in results)
                Console.Write("["+String.Join(" ", new List<int>(list).ConvertAll(i => i.ToString()).ToArray())+"]");
            Console.Write("]");
        }

        public static IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            results = new List<IList<int>>();
            //Call recursive function to compute results
            CombinationSum(candidates, 0, target, new List<int>());
            return results;
        }


        public static void CombinationSum(int[] candidates,int start, int target, List<int> list)
        {
            //If Target Found then add to results and return
            if(target == 0)
            {
                results.Add(new List<int>(list.ToArray()));
                return;
            }
            else if (target < 0) return; //If over extended then break recursion

            //From start to end use recursion to find all combinations that add up to target value
            for(int i = start; i < candidates.Length; i++)
            {
                list.Add(candidates[i]);
                CombinationSum(candidates,i, target - candidates[i], list);
                list.RemoveAt(list.Count - 1);
            }
        }
    }
}
