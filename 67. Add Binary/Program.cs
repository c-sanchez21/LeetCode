using System;
using System.Text;

namespace _67._Add_Binary
{
    class Program
    {
        //https://leetcode.com/problems/add-binary/
        static void Main(string[] args)
        {
            Console.WriteLine(AddBinary("11", "1"));
            Console.WriteLine(AddBinary("1111", "11111"));
            Console.WriteLine(AddBinary("1010", "1011"));
        }

        public static string AddBinary(string a, string b)
        {
            //Find the longer and shorter of the strings
            string shorter, longer;
            if(a.Length >= b.Length)
            {
                longer = a;
                shorter = b;
            }
            else
            {
                longer = b;
                shorter = a;
            }
            
            //Compute the results
            StringBuilder res = new StringBuilder(); //Result
            int carry = 0;
            int i = longer.Length-1;
            int j = shorter.Length-1;
            for(; i >= 0; i--)
            {
                if (longer[i] == '1') carry++;
                if (j >= 0 && shorter[j--] == '1') carry++;
                if (carry % 2 == 1) res.Append('1');
                else res.Append('0');
                carry /= 2;
            }
            if (carry == 1) res.Append('1');

            //Reverse string and return answer
            char[] charArray = res.ToString().ToCharArray();
            Array.Reverse(charArray);
            string ans = new string(charArray);
            return ans;
        }
    }
}
