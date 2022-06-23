using System;
using System.Collections.Generic;

namespace _630._Course_Schedule_III
{
    class Program
    {
        //https://leetcode.com/problems/course-schedule-iii/
        static void Main(string[] args)
        {
            Console.WriteLine(ScheduleCourse(
                new int[][] { new int[] { 100, 200 },new int[] { 200, 1300 },
                new int[]{1000, 1250 }, new int[] {2000, 3200 } }));
        }

        public static int ScheduleCourse(int[][] courses)
        {
            List<int[]> list = new List<int[]>();
            foreach (int[] course in courses)
                list.Add(new int[] { course[0], course[1] });
            list.Sort((a, b) => a[1].CompareTo(b[1]));
            int time = 0;
            int count = 0;
            int[] c; 
            for(int i =0; i < list.Count; i++)
            {
                c = list[i]; 
                if(time + c[0] <= c[1])
                {
                    time += list[i][0];
                    count++;
                }
                else
                {
                    int[] cj;
                    int maxIdx = i;
                    for(int j = 0; j < i; j++)
                    {
                        cj = list[j];
                        if (cj[0] > c[0])
                        {
                            maxIdx = j;
                            c = list[j];
                        }
                    }
                    if (list[maxIdx][0] > list[i][0])
                        time += list[i][0] - list[maxIdx][0];
                    list[maxIdx][0] = -1;
                }

            }
            return count;
        }
    }
}
