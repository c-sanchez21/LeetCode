using System;
using System.Collections.Generic;

namespace _1104._Path_In_Zigzag_Labelled_Binary_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (int x in PathInZigZagTree(14))
                Console.Write(" {0} ", x);
        }
        public static IList<int> PathInZigZagTree(int label)
        {
            IList<int> results = new List<int>();
            int rowsNeed = (int)Math.Log2(label) + 1;
            Console.WriteLine("Rows Needed = {0}", rowsNeed);
            int node = 1;
            int nodesNeeded = 1;
            Stack<int> nodeStack = new Stack<int>();
            bool rowEven = false;
            for(int row = 1; row <= rowsNeed; row++)
            {
                rowEven = (row % 2) == 0;
                for(int i = 0; i < nodesNeeded; i++)
                {
                    if (rowEven)
                        nodeStack.Push(node);
                    else results.Add(node);
                    if (node == label)
                        break;
                    node++;
                }
                while (nodeStack.Count > 0)
                    results.Add(nodeStack.Pop());
                nodesNeeded *= 2;
            }
            return results;
        }
    }
}
