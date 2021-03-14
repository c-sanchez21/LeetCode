using System;

namespace IntegerToEnglishWords
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 100, 101, 1010, 321, 10042, 1000000, 1000000000, 2000000001, 50868};
            foreach(int num in nums)
               Console.WriteLine("{0} = {1}", num, NumberToWords(num));
        }

        public static string NumberToWords(int num)
        {
            if (num == 0) return "Zero";
            string ans = "";
            string[] values = new string[] { "", " Thousand ", " Million ", " Billion " };
            int valIdx = 0;
            string valStr = values[valIdx];
            string tmpStr;
            while(num > 0)
            {
                tmpStr = NumToWords(num % 1000);
                valStr = (tmpStr.Length > 0) ? values[valIdx] : "";
                valIdx++;
                ans = tmpStr.Trim() + valStr + ans.Trim();
                num = num / 1000;
            }
            return ans.Trim();
        }

        public static string NumToWords(int num)
        {
            if (num >= 100)
                return NumToWords(num / 100) + " Hundred " + NumToWords(num % 100);
            else if (num >= 90)
                return "Ninety " + NumToWords(num % 10);
            else if (num >= 80)
                return "Eighty " + NumToWords(num % 10);
            else if (num >= 70)
                return "Seventy " + NumToWords(num % 10);
            else if (num >= 60)
                return "Sixty " + NumToWords(num % 10);
            else if (num >= 50)
                return "Fifty " + NumToWords(num % 10);
            else if (num >= 40)
                return "Forty " + NumToWords(num % 10);
            else if(num >= 30)
                return "Thirty " + NumToWords(num % 10);
            else if(num >= 20)
                return "Twenty " + NumToWords(num % 10);
            else switch(num)
                {
                    case 18:
                        return "Eighteen";
                    case 19:
                    case 17:
                    case 16:
                    case 14:
                        return NumToWords(num % 10) + "teen";
                    case 15:
                        return "Fifteen";
                    case 13:
                        return "Thirteen";
                    case 12:
                        return "Twelve";
                    case 11:
                        return "Eleven";
                    case 10:
                        return "Ten";
                    case 9:
                        return "Nine";
                    case 8:
                        return "Eight";
                    case 7:
                        return "Seven";
                    case 6:
                        return "Six";
                    case 5:
                        return "Five";
                    case 4:
                        return "Four";
                    case 3:
                        return "Three";
                    case 2:
                        return "Two";
                    case 1:
                        return "One";
                    default:
                        return "";
                }
        }
    }
}
