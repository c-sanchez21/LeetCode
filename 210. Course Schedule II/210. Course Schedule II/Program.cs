using System;
using System.Collections.Generic;

namespace _210._Course_Schedule_II
{
    //https://leetcode.com/problems/course-schedule-ii/
    class Program
    {
        static void Main(string[] args)
        {
            int[][] prerequistesA = new int[][]
            {
                new int[2]{1,0 }
            };
            PrintArray(FindOrder(2, prerequistesA));
        }

        public static void PrintArray(int[] order)
        {
            Console.Write('[');
            foreach (int i in order)
                Console.Write("{0} ",i);
            Console.WriteLine(']');
        }

        public static int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            //Adjacency List
            Dictionary<int, List<int>> adjList = new Dictionary<int, List<int>>();
            int[] deg = new int[numCourses]; //Tracks Degrees - i.e Requirements for each node

            int a, b; //Destination and From

            //Create Adjacency List
            for (int i = 0; i < prerequisites.Length; i++)
            {
                a = prerequisites[i][0]; //Destination
                b = prerequisites[i][1]; //From
                if (adjList.ContainsKey(b))
                    adjList[b].Add(a);
                else adjList.Add(b, new List<int>(new int[] { a }));

                //Degrees for each node
                deg[a] += 1;
            }

            //Add all degree zero's to the Queue - i.e they don't have requirements to complete
            Queue<int> q = new Queue<int>();
            for (int i = 0; i < numCourses; i++)
            {
                if (deg[i] == 0)
                    q.Enqueue(i);
            }

            int[] topologicalOrder = new int[numCourses]; //Possible topological order
            int idx = 0;//Topological Oreder Indexer
            int node;
            while (q.Count > 0)
            {
                node = q.Dequeue();
                topologicalOrder[idx++] = node;

                //Foreach destination reduce degree by 1
                if(adjList.ContainsKey(node))
                    foreach(int dest in adjList[node])
                    {
                        deg[dest] = deg[dest] - 1;
                        //If degree == 0 then all requirements met
                        if (deg[dest] == 0)
                            q.Enqueue(dest);
                    }
            }
            //If Topological Sort possible then return order
            if (idx == numCourses) return topologicalOrder;

            //Else if not possible return empty array
            return new int[0]; 
        }
    }
}
