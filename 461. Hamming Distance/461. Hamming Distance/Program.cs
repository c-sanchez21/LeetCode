using System;

namespace _461._Hamming_Distance
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(HammingDistance(2, 1));//2
            Console.WriteLine(HammingDistance(1, 4));//2
            Console.WriteLine(HammingDistance(3, 1));//1
        }
        
        //HammingDistance - Number of different bits
        public static int HammingDistance(int x, int y)
        {
            int val = x ^ y; //Xor x and y
            int count = 0;
            while(val > 0)
            {
                if ((val & 1) == 1) //Count the right most bits if = 1
                    count++;
                val = val >> 1; //Shift the bits right
            }
            return count; //Return the count
        }
    }
}
