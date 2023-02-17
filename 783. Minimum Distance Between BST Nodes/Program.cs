using System;
using System.Collections.Generic;

namespace _783._Minimum_Distance_Between_BST_Nodes
{
    internal class Program
    {
        //783. Minimum Distance Between BST Nodes
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
        }

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

        private static int minDiff = 1000000;
        public static int MinDiffInBST(TreeNode root)
        {
            List<int> list = new List<int>();
            list.Add(root.val);
            MinDiffInBST(root, list);
            list.Sort();
            for (int i = 0; i < list.Count - 1; i++)
                minDiff = Math.Min(minDiff, Math.Abs(list[i] - list[i + 1]));
            return minDiff;
        }

        public static void MinDiffInBST(TreeNode root, List<int> list)
        {
            if (root.left != null)
            {
                list.Add(root.left.val);
                MinDiffInBST(root.left,list);
            }
            if (root.right != null)
            {
                list.Add(root.right.val);
                MinDiffInBST(root.right, list);
            }
        }
    }
}
