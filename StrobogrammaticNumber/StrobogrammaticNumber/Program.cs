using System;

namespace StrobogrammaticNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputs = new string[] { "69", "88", "962", "1", "1001" };
            foreach (string input in inputs)
                Console.WriteLine("{0} = {1}", input, IsStrobogrammatic(input));
        }

        public static bool IsStrobogrammatic(string num)
        {
            string flipped = "";
            for (int i = num.Length - 1; i >= 0; i--)
            {
                switch (num[i])
                {
                    case '1':
                    case '0':
                    case '8':
                        flipped += num[i];
                        break;
                    case '6':
                    case '9':
                        flipped += num[i] == '6' ? "9" : "6";
                        break;
                    default:
                        return false;
                }
            }
            return flipped.CompareTo(num) == 0;
        }
    }
}
