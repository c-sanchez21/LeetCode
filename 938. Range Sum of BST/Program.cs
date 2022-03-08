using System;

namespace _938._Range_Sum_of_BST
{
    class Program
    {
        //https://leetcode.com/problems/range-sum-of-bst/
        static void Main(string[] args)
        {
            //Example 1
            TreeNode root = new TreeNode(10,
                new TreeNode(5, new TreeNode(3), new TreeNode(7)),
                new TreeNode(15, null, new TreeNode(18)));
            Console.WriteLine(RangeSumBST(root,7,15));
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
        static int result = 0;
        public static int RangeSumBST(TreeNode root, int L, int R)
        {
            result = 0;
            DFS(root, L, R);//Depth first search on tree
            return result;
        }

        public static void DFS(TreeNode n, int L, int R)
        {
            //Check for null;
            if (n == null) return;

            //If node withing range then add to result;
            if (L <= n.val && n.val <= R)
                result += n.val;
            //Check left if Left boundary less than node value
            if (L < n.val)
                DFS(n.left, L, R);
            //Check right if Right boundary greather than node value
            if (n.val < R)
                DFS(n.right, L, R);
        }
    }
}
