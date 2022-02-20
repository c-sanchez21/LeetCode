using System;
using System.Collections.Generic;

namespace _1675._Minimize_Deviation_in_Array
{
    class Program
    {
        //Difficulty Rating : Hard
        //https://leetcode.com/problems/minimize-deviation-in-array/
        static void Main(string[] args)
        {
            //Example
            Console.WriteLine(MinimumDeviation(new int[] { 8, 5, 1, 6 }));
            Console.WriteLine(MinimumDeviation(new int[] { 1, 2, 3, 4 }));
            Console.WriteLine(MinimumDeviation(new int[] { 4, 1, 5, 20,3 }));
            Console.WriteLine(MinimumDeviation(new int[] { 2, 10, 8}));
        }

        public static int MinimumDeviation(int[] nums)
        {
            //Compute all possibilities for each number
            List<int[]> pos = new List<int[]>();//Possible
            
            //Foreach number add it's possible [value,index]
            int num;
            for(int i=0; i < nums.Length; i++)
            {
                //Even Numbers
                if(nums[i] % 2 ==0)
                {
                    //Add number and divide by 2 until odd number is reached 
                    num = nums[i];
                    pos.Add(new int[] { num, i });
                    while(num % 2 ==0)
                    {
                        num /= 2;
                        pos.Add(new int[] { num, i });
                    }
                }
                //Odd Numbers
                else
                {   //Odd numbers can only multiply once 
                    //So add both possibilities 
                    pos.Add(new int[] { nums[i], i });
                    pos.Add(new int[] { nums[i] * 2, i });
                }
            }

            //Sort Possibilities by Value
            pos.Sort((x, y) => x[0].CompareTo(y[0]));
            //Example 1 := [[1,0],[1,2],[2,2],[3,3],[4,0],[5,1],[6,3],[8,0],[10,1]]

            int minDeviation = int.MaxValue; //Min deviation
            int need = nums.Length; //Indexes needed
            int start = 0;  //Start Index

            //Initiate need list to all needed
            int[] needList = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
                needList[i] = 1;

            int val, idx;//Value and Index

            //Begin sliding window
            foreach(int[] cur in pos)
            {
                val = cur[0]; //Value of Current
                idx = cur[1]; //Index of Current
                needList[idx] -= 1; //Mark Index as not needed
                if (needList[idx] == 0)
                    need -= 1; //One less index needed

                //If all indexes are inlcuded in the sliding window
                if (need == 0)
                {
                    //While numbers are included more than once increment left index; 
                    while (needList[pos[start][1]] < 0)
                    {
                        needList[pos[start][1]] += 1;
                        start += 1;
                    }

                    //update minDevaviation
                    if (minDeviation > (val - pos[start][0]))
                        minDeviation = (val - pos[start][0]);
                    
                    //Increment left index and repeat process 
                    needList[pos[start][1]] += 1;
                    start++;
                    need++;
                }
            }

            //Return results
            return minDeviation;         
        }
    }
}
