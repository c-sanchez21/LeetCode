using System;
using System.Collections.Generic;

namespace Number_of_Connected_Components_in_an_Undirected_Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int CountComponents(int n, int[][] edges)
        {
            Dictionary<int, List<int>> edgeMap = new Dictionary<int, List<int>>();
            int key;
            int node; 
            foreach(int[] edge in edges)
            {
                key = edge[0];
                node = edge[1];
                if (!edgeMap.ContainsKey(key))
                    edgeMap.Add(key, new List<int>());
                if (!edgeMap.ContainsKey(node))
                    edgeMap.Add(node, new List<int>());
                edgeMap[key].Add(node);
                edgeMap[node].Add(key);
            }

            int count = 0;
            List<int> unvisited = new List<int>();
            for (int i = 0; i < n; i++)
                unvisited.Add(i);

            while(unvisited.Count > 0)
            {
                count++;
                key = unvisited[0];
                unvisited.RemoveAt(0);
                if(edgeMap.ContainsKey(key))
                {
                    foreach(int i in edgeMap[key])
                    {
                        if(unvisited.Contains(i))
                            DFS(i, unvisited, edgeMap);
                    }

                }
            }
            return count;
        }

        private static void DFS(int key, List<int> unvisited, Dictionary<int, List<int>> edgeMap)
        {
            if (unvisited.Contains(key))
                unvisited.Remove(key);
            if(edgeMap.ContainsKey(key))
            {
                foreach(int i in edgeMap[key])
                {
                    if(unvisited.Contains(i))
                        DFS(i, unvisited, edgeMap);
                }
            }
        }
    }
}
