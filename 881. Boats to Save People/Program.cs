using System;

namespace _881._Boats_to_Save_People
{
    class Program
    {
        //https://leetcode.com/problems/boats-to-save-people/
        static void Main(string[] args)
        {
            //Examples
            Console.WriteLine(NumRescueBoats(new int[] { 1, 2 }, 3));
            Console.WriteLine(NumRescueBoats(new int[] { 3, 2, 2, 1 }, 3));
            Console.WriteLine(NumRescueBoats(new int[] { 3, 5, 3, 4 }, 5));
        }

        public static int NumRescueBoats(int[] people, int limit)
        {
            if (people == null || people.Length == 0) return 0;
            if (people.Length == 1) return 1;
            Array.Sort(people);
            Array.Reverse(people);
            int l = 0;
            int r = people.Length - 1;
            int count = 0;
            int lim; 
            while(l < r)
            {
                lim = limit - people[l];
                l++;
                if (people[r] <= lim)
                    r--;
                count++;
            }
            if (l == r)
                count++;
            return count;
        }
    }
}
