using System;
using System.Collections.Generic;

namespace _1345._Jump_Game_IV
{
    class Program
    {
        //https://leetcode.com/problems/jump-game-iv/
        static void Main(string[] args)
        {
            int[] arr = new int[] { 100, -23, -23, 404, 100, 23, 23, 23, 3, 404 };
            Console.WriteLine(MinJumps(arr)); //3
            //You need 3 jumps from index 0-- > 4-- > 3-- > 9.Note that index 9 is the last index of the array.
        }

        //Graph - Breadth First Search
        public static int MinJumps(int[] arr)
        {
            //Base case - Null, Empty Set, 1 Element
            if (arr == null) return 0;
            int n = arr.Length;
            if (n <= 1) return 0;

            //Graph for edges - By Value
            Dictionary<int, HashSet<int>> graph = new Dictionary<int, HashSet<int>>();
            for (int i = 0; i < n; i++)
            {
                if (!graph.ContainsKey(arr[i]))
                    graph.Add(arr[i], new HashSet<int>());
                graph[arr[i]].Add(i); //Value arr[i] goes to idx i
            }

            //Breadth First Search
            List<int> cur = new List<int>(); //Current layer
            cur.Add(0); //Start with 0 idx
            HashSet<int> visited = new HashSet<int>(); //Track visited indexes
            int steps = 0; //Number of steps 
            while(cur.Count > 0)
            {
                List<int> next = new List<int>(); //Next layer to search

                //Iterate thru the cur layer
                foreach(int idx in cur)
                {
                    //Check if end reached
                    if (idx == n - 1) return steps;

                    //For each possible jump 
                    foreach(int dest in graph[arr[idx]])
                    {
                        //If not already visited/searched
                        if(!visited.Contains(dest))
                        {//Then add to our next search layer
                            visited.Add(dest);
                            next.Add(dest);
                        }
                    }

                    //Remove repetitve searches/cycles
                    graph[arr[idx]].Clear(); 

                    //Add neighbors idx+1
                    if(idx +1 < n && !visited.Contains(idx+1))
                    {
                        visited.Add(idx + 1);
                        next.Add(idx + 1);
                    }

                    //Add neighbors idx-1
                    if(idx-1 >= 0 && !visited.Contains(idx-1))
                    {
                        visited.Add(idx - 1);
                        next.Add(idx - 1);
                    }
                }
                cur = next;
                steps++;
            }

            return -1;
        }

    }
}
