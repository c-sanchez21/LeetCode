using System;

namespace _849._Maximize_Distance_to_Closest_Person
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MaxDistToClosest(new int[] { 1, 0, 0, 0, 1, 0, 1 }));
            Console.WriteLine(MaxDistToClosest(new int[] { 1, 0, 0, 0 }));
            Console.WriteLine(MaxDistToClosest(new int[] { 0, 1 }));
        }

        public static int MaxDistToClosest(int[] seats)
        {
            //Scores to hold the distance
            int[] scores = new int[seats.Length];
            
            //Initialize scores to max value
            for (int i = 0; i < scores.Length; i++)
                scores[i] = int.MaxValue;

            //Calculate scores Left to Right
            int val = int.MaxValue;//Score Value
            for(int i = 0;i < seats.Length; i++)
            {
                if (seats[i] == 1)//If person seated
                    val = 0; //Reset Score to Zero 
                else if (val < int.MaxValue)
                    val++;//Else increment score
                scores[i] = Math.Min(scores[i], val);
            }

            //Repeate Process from Right to Left
            val = int.MaxValue;
            for(int i = seats.Length-1; i >= 0; i--)
            {
                if (seats[i] == 1)
                    val = 0;
                else if (val < int.MaxValue)
                    val++;
                scores[i] = Math.Min(scores[i], val);
            }

            val = int.MinValue;
            for (int i = 0; i < scores.Length; i++)
                val = Math.Max(scores[i], val);

            return val;
        }
    }
}
