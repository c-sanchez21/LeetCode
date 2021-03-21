using System;

namespace Generate_Random_Point_in_a_Circle
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution sol = new Solution(10, 0, 0);
            double[] res;
            for (int i = 0; i < 3; i++)
            {
                res = sol.RandPoint();
                Console.WriteLine("X = {0},\t Y = {1}",res[0], res[1]);
            }
        }

        public class Solution
        {
            double Radius { get; set; }
            double X { get; set; }
            double Y { get; set; }
            public Solution(double radius, double x_center, double y_center)
            {
                this.Radius = radius;
                this.X = x_center;
                this.Y = y_center;
            }

            public double[] RandPoint()
            {
                double x, y;
                double distance = Radius + 1;
                Random rand = new Random();
                double[] pt1, pt2;
                pt1 = new double[]{ X,Y};
                pt2 = new double[] { 0, 0 };
                while (distance > Radius)
                {
                    x = rand.NextDouble() * Radius;
                    if (rand.Next(0, 100) < 50) x *= -1; //Chance for negative
                    x += this.X;
                    y = rand.NextDouble() * Radius;
                    if (rand.Next(0, 100) < 50) y *= -1; //Chance for negative
                    y += this.Y;
                    pt2 = new double[] { x, y };
                    distance = DistanceFromPoint(pt1, pt2);
                }
                return pt2;
            }
            private double DistanceFromPoint(double[] p1, double[] p2)
            {
                //Distance Formula:
                //Sqrt( (x2-x1)^2 + (y2-y1)^2 )
                double distance;
                distance = (p2[0] - p1[0]) * (p2[0] - p1[0]);
                distance += (p2[1] - p1[1]) * (p2[1] - p1[1]);
                return Math.Sqrt(distance);
            }
        }

    }
}
