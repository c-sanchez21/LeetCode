using System;
using System.Collections.Generic;
using System.Text;

namespace _1282._Group_the_People
{
    class Program
    {
        //https://leetcode.com/problems/group-the-people-given-the-group-size-they-belong-to/
        static void Main(string[] args)
        {
            //Example 
            IList<IList<int>> results = GroupThePeople(new int[] { 3, 3, 3, 3, 3, 1, 3 });
            PrintResults(results);
        }

        private static void PrintResults(IList<IList<int>> results)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append('[');
            foreach (IList<int> list in results)
            {
                sb.Append('[');
                foreach (int i in list)
                {
                    sb.Append(i);
                    sb.Append(',');
                }
                sb.Length--; //Remove the last char
                sb.Append(']');
            }
            sb.Append(']');
            Console.WriteLine(sb.ToString());
        }

        public static IList<IList<int>> GroupThePeople(int[] groupSizes)
        {
            IList<IList<int>> results = new List<IList<int>>();
           
            //Check Invalid input
            if (groupSizes == null || groupSizes.Length == 0) return results;

            //Iterate thru the groupSizes array - and map people by group size
            Dictionary<int, List<int>> groups = new Dictionary<int, List<int>>();
            int key;
            for (int i = 0; i < groupSizes.Length; i++)
            {
                //Map people by group size
                key = groupSizes[i];
                if (!groups.ContainsKey(key))
                    groups.Add(key, new List<int>());
                groups[key].Add(i);

                //Check if the group is at max capacity
                if (groups[key].Count == groupSizes[i])
                {
                    //If so, add the results and clear
                    //for another possible group of the same size
                    results.Add(new List<int>(groups[key].ToArray()));
                    groups[key].Clear();
                }
            }
            return results;
        }
    }
}
