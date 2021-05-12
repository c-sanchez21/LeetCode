using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Construct_Target_Array_With_Multiple_Sums
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IsPossible(new int[] { 9, 3, 5 }));
            Console.WriteLine(IsPossible(new int[] { 1, 1, 1, 2 }));
            Console.WriteLine(IsPossible(new int[] { 8, 5 }));
            Console.WriteLine(IsPossible(new int[] { 13, 7, 1, 43 }));
            Console.ReadKey();

        }
        public static bool IsPossible(int[] target)
        {
            //Base case
            if (target.Length == 1) return target[0] == 1;

            //Utilize a Priority Queue / Max Heap
            SortedSet<int> pq = new SortedSet<int>();
            int sum = 0;

            //Add up elements and insert them into the max heap
            for(int i = 0; i < target.Length; i++)
            {
                sum += target[i];
                pq.Add(target[i]);
            }

            int max = pq.Max;
            int x;
            //Try to make the array all into 1's moving backwards 
            while(max > 1)
            {
                x = max - (sum - max);
                //If a number is less than 1 then the target array is not possible. 
                if (x < 1) return false;
                pq.Remove(max);
                pq.Add(x); 
                sum = sum - max + x; //Recalculate sum; 
                max = pq.Max; //Get the next Max number
            }
           
            return true; 

        }
    }
}
