using System;

namespace _563._Binary_Tree_Tilt
{
    //https://leetcode.com/problems/binary-tree-tilt/
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(1, new TreeNode(2), new TreeNode(3));
            Console.WriteLine(FindTilt(root));
        }

        // Definition for a binary tree node.
        public class TreeNode {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null) {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        private static int TotalTilt = 0;
        public static int FindTilt(TreeNode root)
        {
            TotalTilt = 0;
            CalcuSum(root);
            return TotalTilt;
        }

        public static int CalcuSum(TreeNode n)
        {
            if (n == null) return 0;
            int lSum = CalcuSum(n.left);
            int rSum = CalcuSum(n.right);
            int tilt = Math.Abs(lSum - rSum);
            TotalTilt += tilt;
            return n.val + lSum + rSum;
        }
    }
}
