using System;
using System.Collections.Generic;

namespace Course_Schedule
{
    class Program
    {
        //https://leetcode.com/problems/course-schedule/
        static void Main(string[] args)
        {
            int[][] prerequisites = new int[][] { new int[2] { 1, 0 }, new int[2] { 0, 1 } };
            Console.WriteLine(CanFinish(2, prerequisites));

            int[][] prerequisites2 = new int[][] { new int[2] { 0, 10 },new int[2] { 3, 18 },
            new int[2]{5,5 },new int[2]{6,11 },new int[2]{11,14 },new int[2]{13,1 },new int[2]{15,1 },new int[2]{17,4 } };
            Console.WriteLine(CanFinish(20, prerequisites2));
        }

        //Checks to see if all prerequisites can be satisfied
        public static bool CanFinish(int numCourses, int[][] prerequisites)
        {
            //Rrerequisites - Edges 
            Dictionary<int, HashSet<int>> prq = new Dictionary<int, HashSet<int>>();
            
            //Course 1, Course 2
            int c1, c2;

            //Iterate thru all Prerequisites - and add edges
            foreach(int[] p in prerequisites)
            {
                //"To take course1 p[0] need to take course2 p[1] first"
                c1 = p[0]; //Course1
                c2 = p[1]; //Course2
                if (c1 == c2) return false; 

                //Add edge
                if (!prq.ContainsKey(c2))
                    prq.Add(c2, new HashSet<int>());
                prq[c2].Add(c1);
            }

            HashSet<int> visited = new HashSet<int>();
            HashSet<int> check = new HashSet<int>();

            //Check for cycles
            for (int i = 0; i < numCourses; i++)
                if (HasCycle(prq, i, visited,check))
                    return false;

            return true;
        }

        public static bool HasCycle(Dictionary<int, HashSet<int>> prq, int c, HashSet<int> visited, HashSet<int> check)
        {
            if (check.Contains(c)) return false; //If already checked return false;
            if (visited.Contains(c)) return true;
            if (!prq.ContainsKey(c)) return false;

            //Backtracking
            visited.Add(c);
            bool result = false;
            foreach(int i in prq[c])//Iterate thru all the prerequisites/edges
            {
                result = HasCycle(prq, i, visited, check);
                if (result == true) break;//Cycle detected
            }
            visited.Remove(c);
            check.Add(c); //Mark as already checked to avoid re-checking
            return result;          
        }
    }
}
