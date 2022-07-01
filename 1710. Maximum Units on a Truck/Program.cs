using System;
using System.Collections.Generic;

namespace _1710._Maximum_Units_on_a_Truck
{
    //https://leetcode.com/problems/maximum-units-on-a-truck/
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MaximumUnits(new int[][] { new int[] { 1, 3 }, new int[] { 2, 2 }, new int[] { 3, 1 } },4));
               
        }

        public static int MaximumUnits(int[][] boxTypes, int truckSize)
        {
            List<int[]> boxes = new List<int[]>();
            foreach (int[] boxType in boxTypes)
                boxes.Add(boxType);
            boxes.Sort((a, b) => b[1].CompareTo(a[1]));
            int remaining = truckSize;
            int idx = 0;
            int boxesToAdd;
            int totUnits = 0;
            while(remaining > 0 && idx < boxes.Count)
            {
                boxesToAdd = Math.Min(remaining, boxes[idx][0]);
                totUnits += boxesToAdd * boxes[idx++][1];
                remaining -= boxesToAdd;
            }
            return totUnits;
        }
    }
}
