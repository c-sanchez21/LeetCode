using System;

namespace Minimum_Operations_to_Make_Array_Equal
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MinOperations(3));
            Console.WriteLine(MinOperations(6));
        }

        /// <summary>
        /// Minimum Operations to make array equal
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int MinOperations(int n)
        {
            //MinOperations =
            //(n-1)+(n-3)+(n-5)+...1 or 0
            int sum = 0;
            while(n > 0)
            {
                sum += n - 1;
                n -= 2;
            }
            return sum;
        }
    }
}
