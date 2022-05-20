using System;

namespace _1540._Can_Convert_String_in_K_Moves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CanConvertString("input", "ouput", 9));
            Console.WriteLine(CanConvertString("abc", "bcd", 10));
            Console.WriteLine(CanConvertString("aab", "bbb", 27));
        }

        public static bool CanConvertString(string s, string t, int k)
        {
            if (string.IsNullOrEmpty(s)) return false;
            if (string.IsNullOrEmpty(t)) return false;
            if (s.Length != t.Length) return false;

            int[] arr = new int[27];
            int div = k / 26;
            int mod = k % 26; 
            for(int i =1; i < arr.Length;i++)
            {
                arr[i] += div;
                if (i <= mod)
                    arr[i]++;
            }
            int shift;
            for(int i = 0; i < s.Length; i++)
            {
                shift = t[i] - s[i];
                if (shift == 0) continue;
                if (shift < 0) shift += 26;
                arr[shift]--;
                if (arr[shift] < 0) return false;
            }
            return true;
        }
    }
}
