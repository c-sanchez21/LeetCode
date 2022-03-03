using System;

namespace _413._Arithmetic_Slices
{
    class Program
    {
        //https://leetcode.com/problems/arithmetic-slices/
        static void Main(string[] args)
        {
            //Examples
            Console.WriteLine(NumberOfArithmeticSlices(new int[] { 1, 2, 3, 4 }));
            Console.WriteLine(NumberOfArithmeticSlices(new int[] { 1, 2, 3, 4, 5 }));
            Console.WriteLine(NumberOfArithmeticSlices(new int[] { 1 }));
            Console.WriteLine(NumberOfArithmeticSlices(new int[] { 1, 2, 3, 5, 7 }));//2
            Console.WriteLine(NumberOfArithmeticSlices(new int[] { 7, 7, 7, 7 }));//3

        }

        public static int NumberOfArithmeticSlices(int[] A)
        {
            //Check base case 
            if (A == null || A.Length < 3) return 0;
            
            int prev = A[0] - A[1];
            int totSlices = 0;
            int count = 0;
            
            //Iterate thru all values
            for(int j, i = 1; i < A.Length; i++)
            {
                j = i;
                if (j < A.Length - 1)
                {
                    //If the difference are the same
                    if (A[j] - A[j + 1] == prev)
                    {
                        //While differences are the same and j is not out of bounds 
                        while (j < A.Length - 1 && A[j] - A[j + 1] == prev)
                        {
                            j++;
                            count++; //Count the number of times differences are the same
                        }

                        //Gauss formula to calcuate Slices 
                        totSlices += (count * (count +1))/2;
                        count = 0;//Reset Count
                        i = j - 1;
                    }
                    else prev = A[j] - A[j + 1];//New difference
                } 
            }
            return totSlices; //Return results
        }
    }
}
