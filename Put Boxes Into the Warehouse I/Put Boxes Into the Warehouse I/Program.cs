using System;

//https://leetcode.com/explore/challenge/card/may-leetcoding-challenge-2021/599/week-2-may-8th-may-14th/3735/
namespace Put_Boxes_Into_the_Warehouse_I
{
    class Program
    {
        static void Main(string[] args)
        {
            //Sample case
            Console.WriteLine(MaxBoxesInWarehouse(new int[] { 4, 3, 4, 1 }, new int[] { 5, 3, 3, 4, 1 }));//3
        }

        public static int MaxBoxesInWarehouse(int[] boxes, int[] warehouse)
        {
            //Check for invalid input. 
            if (warehouse == null || warehouse.Length == 0) return 0;
            if (boxes == null || boxes.Length == 0) return 0;

            //We make note and keep track of the biggest box size that will fit 
            //the back of the warehouse. 
            int[] biggestFit = new int[warehouse.Length];
            biggestFit[0] = warehouse[0];
            for(int i =1; i < warehouse.Length; i++) //Take the smaller of the two - size of warehouse or size of box. 
                biggestFit[i] = warehouse[i] < biggestFit[i - 1] ? warehouse[i] : biggestFit[i - 1];

            //Sort the boxes from smallest to biggest. 
            Array.Sort(boxes);


            int idx = 0; //The index also serves as the number of boxes that fit. 

            //Start from the back of the warehouse (where the smallest box will fit). 
            for (int i = biggestFit.Length - 1; i >= 0; i--)
            { 
                //if the box fits push it in and increment idx/count. 
                if(boxes[idx] <= biggestFit[i])
                {
                    idx++;
                    if (idx >= boxes.Length) break;//If all boxes have been placed then stop. 
                }
            }
            return idx; //return the count. 
        }
    }
}
