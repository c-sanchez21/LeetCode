using System;

namespace _1026._Maximum_Difference_Between_Node_and_Ancestor
{
    class Program
    {
        //https://leetcode.com/problems/maximum-difference-between-node-and-ancestor/
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(1, new TreeNode(2), new TreeNode(3));
            Console.WriteLine(MaxAncestorDiff(root));
        }

        // Definition for a binary tree node.
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
        public static int MaxAncestorDiff(TreeNode root)
        {
            if (root == null) return 0;
            return FindMinMax(root, root.val, root.val);
        }

        public static int FindMinMax(TreeNode n, int min, int max)
        {
            //If leaf return max - min
            if (n == null) return (max - min);

            //Get the current min and max
            max = Math.Max(max, n.val);
            min = Math.Min(min, n.val);

            //Find the Max diff in left & right node. 
            int left = FindMinMax(n.left, min, max);
            int right = FindMinMax(n.right, min, max);

            //Return max diff 
            return Math.Max(left, right);
        }
    }
}
