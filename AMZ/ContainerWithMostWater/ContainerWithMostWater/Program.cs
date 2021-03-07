using System;

namespace ContainerWithMostWater
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] inputs = new int[][]
                { new int[] {1,8,6,2,5,4,8,3,7 }, new int[] {1,1 }, new int[] {4,3,2,1,4 }, new int[] {1,2,1 } };
            foreach (int[] input in inputs)
                Console.WriteLine(MaxArea(input));
        }

        public static int MaxArea(int[] height)
        {
            int i = 0;
            int j = height.Length - 1;
            int lh;//Left Height
            int rh;//Right Height
            int h;//The lowest height
            int max = 0;
            while(i < j)
            {
                lh = height[i];
                rh = height[j];
                h = Math.Min(lh, rh); //Lowest Height
                max =  Math.Max(max, (j - i) * h); //Max Area
                if (lh < rh) //Find a taller height; 
                {
                    while (i < j && lh >= height[i])
                        i++;
                }
                else
                {
                    while (j > i && rh >= height[j])
                        j--;
                }
            }
            return max;
        }
    }
}
