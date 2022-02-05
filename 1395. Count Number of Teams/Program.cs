using System;

namespace _1395._Count_Number_of_Teams
{
    class Program
    {
        //https://leetcode.com/problems/count-number-of-teams/
        static void Main(string[] args)
        {
            //Example 1: = 3 
            Console.WriteLine(NumTeams(new int[] { 2, 5, 3, 4, 1 }));

            //Example 2: = 0 
            Console.WriteLine(NumTeams(new int[] { 2, 1, 3 }));

            //Example 3: = 0
            Console.WriteLine(NumTeams(new int[] { 1, 2, 3, 4 }));
        }

        //Check for the number of possible teams with increased/decreased ratings
        public static int NumTeams(int[] rating)
        {
            int teams = 0;

            //Check for increase rating
            for (int i = 0; i < rating.Length - 2; i++)
                for (int j = i + 1; j < rating.Length - 1; j++)
                    if (rating[j] > rating[i])
                        for (int z = j + 1; z < rating.Length; z++)
                            if (rating[z] > rating[j])
                                teams++;

            //Check for decrease rating
            for (int i = 0; i < rating.Length - 2; i++)
            {
                if (rating[i] < 2)
                    continue;

                for (int j = i + 1; j < rating.Length - 1; j++)
                {
                    if (rating[j] >= rating[i] || rating[j] < 1)
                        continue;

                    for (int z = j + 1; z < rating.Length; z++)
                    {
                        if (rating[z] < rating[j])
                            teams++;
                    }
                }
            }

            return teams;
        }
    }
}
