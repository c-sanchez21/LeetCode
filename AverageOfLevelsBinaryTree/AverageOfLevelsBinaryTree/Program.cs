using System;
using System.Collections.Generic;

namespace AverageOfLevelsBinaryTree
{

    //Definition for a binary tree node.
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    class Program
    {
       
        //https://leetcode.com/explore/challenge/card/march-leetcoding-challenge-2021/588/week-1-march-1st-march-7th/3661/

        static void Main(string[] args)
        {
            TreeNode t = new TreeNode(3, new TreeNode(9), new TreeNode(20, new TreeNode(15), new TreeNode(7)));
            IList<double> results = AverageOfLevels(t);
            foreach (double d in results)
                Console.Write("{0} ", d);
            Console.WriteLine();
        }
        /// <summary>
        ///  A level order traversal of a binary tree returning the average of each level.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static IList<double> AverageOfLevels(TreeNode root)
        {
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            q.Enqueue(null);//Delimiter
            TreeNode n;
            double sum = 0;
            int nodeCount = 0;
            List<double> results = new List<double>();
            while (q.Count > 0)
            {
                n = q.Dequeue();
                if (n == null)
                {//Delimiter reached
                    results.Add(sum / nodeCount);//Add result
                    sum = nodeCount = 0; //Reset 

                    if (q.Count > 0)//If more levels
                        q.Enqueue(null); //Add another delimiter
                }
                else
                {
                    sum += n.val;
                    nodeCount++;
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
