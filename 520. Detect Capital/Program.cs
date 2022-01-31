using System;

namespace _520._Detect_Capital
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DetectCapitalUse("USA"));
            Console.WriteLine(DetectCapitalUse("FlaG"));
            Console.WriteLine(DetectCapitalUse("Programming"));
            Console.WriteLine(DetectCapitalUse("assembly"));
        }

        public static bool DetectCapitalUse(string word)
        {
            //Check for invalid input
            if (string.IsNullOrEmpty(word)) return false; 

            //All lowercase
            string lowerCase = word.ToLower();
            if (word.CompareTo(lowerCase) == 0) return true;

            //All uppercase
            string upperCase = word.ToUpper();
            if (word.CompareTo(upperCase) == 0) return true;

            //First letter capitalized and the rest lowercase 
            int length = word.Length;
            if (word[0] == upperCase[0] && word.Substring(1, length - 1).CompareTo(lowerCase.Substring(1, length - 1)) == 0)
                return true;

            //Invalid capital use
            return false;
        }
    }
}
