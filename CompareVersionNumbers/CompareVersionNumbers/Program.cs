using System;
using System.Linq;

namespace CompareVersionNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CompareVersion("0.1", "1.1"));
            Console.WriteLine(CompareVersion("1.0.1", "1"));
            Console.WriteLine(CompareVersion("7.5.2.4", "7.5.3"));
            Console.WriteLine(CompareVersion("1.01", "1.001"));
            Console.WriteLine(CompareVersion("1.0", "1.0.0"));
        }

        public static int CompareVersion(string version1, string version2)
        {
            string[] s1 = version1.Split(".");
            string[] s2 = version2.Split(".");
            int max = s1.Length > s2.Length ? s1.Length : s2.Length;
            string vs1, vs2;
            int v1, v2; 
            for (int i = 0; i < max; i++)
            {
                vs1 = i > s1.Length - 1 ? null : s1[i];
                vs2 = i > s2.Length - 1 ? null : s2[i];

                v1 = vs1 == null ? 0 : int.Parse(vs1);
                v2 = vs2 == null ? 0 : int.Parse(vs2);

                if (v1 > v2) return 1;
                if (v1 < v2) return -1;
            }
            return 0;
        }
    }
}
