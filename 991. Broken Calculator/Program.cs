using System;
using System.Collections.Generic;

namespace _991._Broken_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
           Console.WriteLine(BrokenCalc(2, 3));
           Console.WriteLine(BrokenCalc(5, 8));
           Console.WriteLine(BrokenCalc(3, 10));
        }

        public static int BrokenCalc(int startValue, int target)
        {
            int ans = 0;
            //Work backwards
            while(target > startValue)
            {
                ans++;
                //Make target even
                if (target % 2 == 1)
                    target++;
                else target /= 2; //Greedily divide by 2
            }
            return ans + (startValue - target);
        }


    }
}
