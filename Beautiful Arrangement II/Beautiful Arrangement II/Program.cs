using System;

namespace Beautiful_Arrangement_II
{
    class Program
    {
        //https://leetcode.com/problems/beautiful-arrangement-ii/
        static void Main(string[] args)
        {
            int[] arr1 = ConstructArray(3, 1);
            int[] arr2 = ConstructArray(3, 2);

            foreach (int i in arr1)
                Console.Write("{0} ", i);

            Console.WriteLine();

            foreach (int i in arr2)
                Console.Write("{0} ", i);
        }

        public static int[] ConstructArray(int n, int k)
        {
            int idx = 0;//Index
            int[] ans = new int[n];

            //if k = 1 then the list is [1,2,3...n-k-1]
            for (int i = 1; i < n - k; i++)
                ans[idx++] = i;

            //For remaining list
            for (int i = 0; i <= k; i++)
            {
                if (i % 2 == 0) //Alternate between bottom and top
                    ans[idx++] = (n - k + i / 2);//Take from bot 
                else ans[idx++] = (n - i / 2); //Take from top
            }
            return ans;
        }
    }
}
