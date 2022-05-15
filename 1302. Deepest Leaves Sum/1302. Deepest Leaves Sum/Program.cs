using System;

namespace _1302._Deepest_Leaves_Sum
{
    internal class Program
    {
        //https://leetcode.com/problems/deepest-leaves-sum/
        static void Main(string[] args)
        {

        }

        public static int totSum = 0;
        public static int maxHeight = 0;
        public static int DeepestLeavesSum(TreeNode root)
        {
            if (root == null) return 0;
            maxHeight = GetHeight(root);
            SumLeaves(root, 1);
            return totSum;
        }

        public static void SumLeaves(TreeNode n, int level)
        {
            if (n == null) return;
            if(n.left == null && n.right == null && level == maxHeight)
            {
                totSum += n.val;
                return;
            }
            SumLeaves(n.left, level + 1);
            SumLeaves(n.right, level + 1);
        }

        public static int GetHeight(TreeNode r)
        {
            if(r == null) return 0;
            return 1 + Math.Max(GetHeight(r.left), GetHeight(r.right));
        }

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
    }
}
