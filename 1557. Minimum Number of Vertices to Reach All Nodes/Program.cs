using System;
using System.Collections.Generic;

namespace _1557._Minimum_Number_of_Vertices_to_Reach_All_Nodes
{
    class Program
    {
        //https://leetcode.com/problems/minimum-number-of-vertices-to-reach-all-nodes/
        static void Main(string[] args)
        {

        }

        public IList<int> FindSmallestSetOfVertices(int n, IList<IList<int>> edges)
        {
            HashSet<int> canVisit = new HashSet<int>();
            foreach(IList<int> edge in edges)
                canVisit.Add(edge[1]);
            List<int> results = new List<int>();
            for (int i = 0; i < n; i++)
                if (!canVisit.Contains(i))
                    results.Add(i);
            return results;
     
        }
    }
}
