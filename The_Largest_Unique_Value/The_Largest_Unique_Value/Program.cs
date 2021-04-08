using System;

namespace The_Largest_Unique_Value
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(LargestUniqueNumber(new int[] { 5, 7, 3, 9, 4, 9, 8, 3, 1 }));
            Console.WriteLine(LargestUniqueNumber(new int[] { 9, 9, 8, 8 }));
        }

        /// <summary>
        /// Finds the largest unique value in the array A 
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static int LargestUniqueNumber(int[] A)
        {
            //Count for each value
            int[] valCount = new int[1001];//Largest value of A[i] = 1000;

            //Count each value
            for (int i = 0; i < A.Length; i++)
                valCount[A[i]]++;

            //return the first largest unique value
            for (int i = 1000; i >= 0; i--)
                if (valCount[i] == 1)
                    return i;

            //if no unique value return -1
            return -1;
        }
    }
}
