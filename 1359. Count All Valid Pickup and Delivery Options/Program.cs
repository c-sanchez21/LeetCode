using System;

namespace _1359._Count_All_Valid_Pickup_and_Delivery_Options
{
    class Program
    {
        //Hard
        //https://leetcode.com/problems/count-all-valid-pickup-and-delivery-options/
        static void Main(string[] args)
        {
            for (int i = 1; i <= 10; i++)
                Console.WriteLine("n = {0}\t=> {1}", i, CountOrders(i));
        }

        public static int CountOrders(int n)
        {
            if (n <= 0) return 0;

            long modulo = 1000000007;
            long ans = 1;

            //For pickups the number of possibilites is n! (i.e 3*2*1)
            //for the first delivery only 1 choice (After) P1P2P3D3
            //for the second delivery three choices P1P2_P3_D3_ (i.e Before or After P3, or after D3)
            //similarly the third delivery has 5 choices P1_P2_P3_D3_D2_
            //Formula:  n! * ∏(2*i-1) from 1 to n
            for (int i = 1; i <= n; i++)
            {
                ans = ans * i; //n!
                ans = ans * (2 * i - 1);
                ans %= modulo; //Avoid overflow
            }
            return (int)ans;
        }
    }
}
