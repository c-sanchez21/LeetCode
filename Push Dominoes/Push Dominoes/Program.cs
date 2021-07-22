using System;
using System.Text;

namespace Push_Dominoes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(PushDominoes(".L.R...LR..L..")); //"LL.RR.LLRRLL.."
        }

        public static string PushDominoes(string dominoes)
        {
            int n = dominoes.Length;
            int[] forces = new int[n];

            int f = 0; //Force
            //Check forces left to right
            for(int i = 0; i < n; i++)
            {
                if (dominoes[i] == 'R')
                    f = n;
                else if (dominoes[i] == 'L')
                    f = 0;
                else f = Math.Max(f - 1, 0);
                forces[i] += f; 
            }

            //Check forces right to left 
            f = 0;
            for(int i = n-1; i >= 0; i--)
            {
                if (dominoes[i] == 'L')
                    f = n;
                else if (dominoes[i] == 'R')
                    f = 0;
                else f = Math.Max(f - 1, 0);
                forces[i] -= f;
            }

            //Calculate answer
            StringBuilder s = new StringBuilder();
            foreach (int x in forces)
            {
                if (x > 0)
                    s.Append('R');
                else if (x < 0)
                    s.Append('L');
                else //x == 0
                    s.Append('.');
            }
            return s.ToString();
        }
    }
}
