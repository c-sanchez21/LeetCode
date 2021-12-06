using System;

namespace _1217._Minimum_Cost_to_Move_Chips_to_The_Same_Position
{
    //https://leetcode.com/problems/minimum-cost-to-move-chips-to-the-same-position/
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MinCostToMoveChips(new int[] { 1, 2, 3 }));
            Console.WriteLine(MinCostToMoveChips(new int[] { 2, 2, 2, 3,3 }));
            Console.WriteLine(MinCostToMoveChips(new int[] { 1, 1000000000 }));
        }

        public static int MinCostToMoveChips(int[] position)
        {
            //Since the cost of moving two spaces is free (Odd + 2 = Odd, Even + 2 = Even)
            //The question becomes How many odds vs even - then return the Min between them. 
            int odd = 0;
            int even = 0;
            //Iterate thru entire array and count the odds and evens
            for (int i = 0; i < position.Length; i++)
                if (position[i] % 2 == 0)
                    even++;
                else odd++;
            //Return the Min
            return Math.Min(odd, even);
        }
    }
}
