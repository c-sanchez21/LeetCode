using System;

namespace _997._Find_the_Town_Judge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


        }

        public static int FindJudge(int n, int[][] trust)
        {
            //Everyone trusts the judge else no judge
            if (trust.Length < n - 1) return -1;


            int[] indegrees = new int[n + 1];//Edges coming in
            int[] outdegrees = new int[n + 1];//Edges going out

            foreach(int[] relation in trust)
            {
                outdegrees[relation[0]]++;
                indegrees[relation[1]]++;
            }

            //Find the Judge 
            for (int i = 1; i <= n; i++)
                //Everyone trusts the Judge and the judge trust no one.
                if (indegrees[i] == n - 1 && outdegrees[i] == 0)
                    return i;

            return -1;
        }
    }
}
