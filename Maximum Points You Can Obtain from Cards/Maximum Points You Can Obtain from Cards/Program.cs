using System;

namespace Maximum_Points_You_Can_Obtain_from_Cards
{
    class Program
    {
        //https://leetcode.com/explore/challenge/card/may-leetcoding-challenge-2021/599/week-2-may-8th-may-14th/3739/
        static void Main(string[] args)
        { 
            /*
            Console.WriteLine(MaxScore(new int[] { 1, 2, 3, 4, 5, 6, 1 }, 3));//12
            Console.WriteLine(MaxScore(new int[] { 2, 2, 2 }, 2));//4
            Console.WriteLine(MaxScore(new int[] { 9, 7, 7, 9, 7, 7, 9 }, 7));//55
            Console.WriteLine(MaxScore(new int[] { 1, 1000, 1 }, 1));//1
            Console.WriteLine(MaxScore(new int[] { 1, 79, 80, 1, 1, 1, 200, 1 }, 3));//202
            Console.WriteLine(MaxScore(new int[] { 100, 40, 17, 9, 73, 75 }, 3));//248
            */
            Console.WriteLine(MaxScore(new int[] { 11, 49, 100, 20, 86, 29, 72 }, 4));//232
        }

        public static int MaxScore(int[] cardPoints, int k)
        {
            int r, l; //Left and Right index
            int maxR, maxL; //Max Points from the Left and from the Right
            int score = 0;

            //Case where k = cardPoints Length or Invalid k
            if (cardPoints.Length <= k)
            {
                for (int i = 0; i < cardPoints.Length; i++)
                    score += cardPoints[i];
                return score;
            }

            maxL = 0; //Max Score possible if all cards taken starting from the left. 
            for (l = 0; l < k; l++)
                maxL += cardPoints[l];

            maxR = 0; //Max Score possible if all cards taken starting from the right. 
            for (r = cardPoints.Length - 1; r >= (cardPoints.Length - k); r--)
                maxR += cardPoints[r];

            //Take cards from the left or right depending on highest possible attainable score
            int cardsRemaining = k;

            l = 0; r = cardPoints.Length-1; //Reset indexes
            int li = k-1;
            int ri = cardPoints.Length - k;
            while(cardsRemaining > 0)
            {
                if(maxL > maxR)
                {
                    score += cardPoints[l];
                    maxL -= cardPoints[l++];
                    maxR -= cardPoints[ri++];
                }
                else
                {
                    score += cardPoints[r];
                    maxR -= cardPoints[r--];
                    maxL -= cardPoints[li--];
                }
                cardsRemaining--;
            }
            return score;
        }
    }
}
