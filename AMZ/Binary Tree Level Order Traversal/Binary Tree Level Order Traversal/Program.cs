using System;
using System.Collections.Generic;
using Symmetric_Tree;

namespace Binary_Tree_Level_Order_Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode t1 = TreeTools.ArrayToTree(new int[] { 3, 9, 20, 0, 0, 15, 7 });
            IList<IList<int>> res = LevelOrder(t1);
            PrintLists(res);
        }

        public static void PrintLists(IList<IList<int>> lists)
        {
            Console.Write("[ ");
            foreach(List<int> l in lists)
            {
                Console.Write("[");
                foreach (int i in l)
                    Console.Write(" {0} ", i);
                Console.Write("]");
            }
            Console.WriteLine("]");
        }

        public static IList<IList<int>> LevelOrder(TreeNode root)
        {

            List<IList<int>> results = new List<IList<int>>();
            if (root == null) return results;//Base case return empty list

            //Initialize Queue
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            q.Enqueue(null);//Delimiter to denote another level

            TreeNode n;
            List<int> levelList = new List<int>(); //List to hold current level of integers
            while(q.Count > 0)
            {
                n = q.Dequeue();
                if (n == null) //Another level reached
                {
                    results.Add(levelList);
                    levelList = new List<int>();
                    if (q.Count > 0) //Add another delimiter
                        q.Enqueue(null);
                }
                else //Add value for the current level. 
                {
                    levelList.Add(n.val);
                    if (n.left != null)
                        q.Enqueue(n.left);
                    if (n.right != null)
                        q.Enqueue(n.right);
                }
            }
            return results;
        }
    }
}
