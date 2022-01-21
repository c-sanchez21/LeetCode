using System;

namespace _134._Gas_Station
{
    class Program
    {
        //https://leetcode.com/problems/gas-station/
        static void Main(string[] args)
        {
            int[] gas = new int[] { 1, 2, 3, 4, 5 };
            int[] cost = new int[] { 3, 4, 5, 1, 2 };
            Console.WriteLine(CanCompleteCircuit(gas, cost));
        }

        public static int CanCompleteCircuit(int[] gas, int[] cost)
        {
            //Check for Invalid input
            if (gas.Length == 0 || cost.Length == 0) return -1;
            if (gas.Length != cost.Length) return -1;

            //Initiate Varibables
            int count = gas.Length;
            int totTank = 0;
            int curTank = 0;
            int startIdx = 0; //Starting index/location

            for(int i =0; i < count; i++)
            {
                //Subtract cost of gas for each iteration
                totTank += gas[i] - cost[i];
                curTank += gas[i] - cost[i];

                //If tank falls below zero 
                //then reset tank and update starting location. 
                if (curTank < 0)
                {
                    startIdx = i + 1;
                    curTank = 0;
                }             
            }

            //If possible to loop return starting index
            //otherwise return -1
            return totTank >= 0 ? startIdx : -1;
        }
    }
}
