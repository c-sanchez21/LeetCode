using System;
using System.Collections.Generic;

namespace _216._Combination_Sum_III
{
    class Program
    {
        //Medium
        //https://leetcode.com/problems/combination-sum-iii/
        static void Main(string[] args)
        {
            //***Example 1***
            //Input: k = 3, n = 9
            //3 Numbers that add up to 9
            //Output:[[1,2,6], [1,3,5], [2,3,4]] 
            IList<IList<int>> res = CombinationSum3(3, 9);
            foreach (IList<int> combo in res)
            {
                foreach (int i in combo)
                {
                    Console.Write("{0} ", i);
                }
                Console.WriteLine();
            }

            //**Example 2***
            //Input: k = 2, n = 12
            //2 Numbers that add up to 12
            //Output: [[3,9], [4,8], [5,7]]
            res = CombinationSum3(2, 12);
            foreach (IList<int> combo in res)
            {
                foreach (int i in combo)
                {
                    Console.Write("{0} ", i);
                }
                Console.WriteLine();
            }
        }

        //Find all valid combinations of k numbers that sum up to n such that the following conditions are true:
        //Only numbers 1 through 9 are used.
        //Each number is used at most once.
        public static IList<IList<int>> CombinationSum3(int k, int n)
        {
            //Variables to hold results
            List<IList<int>> results = new List<IList<int>>();
            List<int> combo = new List<int>();

            //Base Case - Only 1 number
            if (k == 1) 
            {
                combo.Add(n); //1 number adds up to n - i.e n
                results.Add(combo); //Add combo to results 
                return results; //Return results
            }

            return CombinationSum3(1, k, n);
        }

        public static IList<IList<int>> CombinationSum3(int min, int k, int n)
        {
            //Results
            List<IList<int>> res = new List<IList<int>>();

            if (k == 2) //When only two numbers are needed
            {
                int compare = n - min; //Note: compare + min = n

                List<int> combo; //List to hold combination

                //All numbers from min to compare
                while (compare > min) //avoids duplicates combos
                {
                    combo = new List<int>();
                    //All numbers less than 10 that add up n 
                    if (compare < 10)
                    {
                        //Note: compare + min = n
                        combo.Add(min);
                        combo.Add(compare);
                        res.Add(combo);
                    }
                    compare = n - ++min; //compare + min = n
                }
            }
            else //When more than 2 numbers are needed
            {
                List<IList<int>> combos = new List<IList<int>>();
                do
                {
                    //Starts with a min of 1 and progressively increment,
                    //while decrementing the required numbers. 
                    combos = (List<IList<int>>)CombinationSum3(min + 1, k - 1, n - min);
                    if (combos.Count > 0) //If combinations found add them to the results
                        foreach (IList<int> list in combos)
                        {
                            list.Add(min);
                            res.Add(list);
                        }
                    min++; //increment the starting number
                }
                while (min < n - min);
            }
            return res; //Return the results
        }
    }
}
