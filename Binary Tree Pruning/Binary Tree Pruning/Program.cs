using System;
using System.Collections.Generic;

namespace Binary_Tree_Pruning
{
    //https://leetcode.com/problems/binary-tree-pruning/
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode n = new TreeNode(1);
            n.right = new TreeNode(0);
            n.right.left = new TreeNode(0);
            n.right.right = new TreeNode(1);

            PruneTree(n);
            Console.WriteLine(n);
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

        public static TreeNode PruneTree(TreeNode root)
        {
            if (root == null) return null;
            if (CalcTree(root.left) == 0)
                root.left = null;
            else PruneTree(root.left);
            if (CalcTree(root.right) == 0)
                root.right = null;
            else PruneTree(root.right);

            //Special Case - Entire tree is zero
            if (root.left == null && root.right == null && root.val == 0)
                return null;

            return root;
        }

        public static int CalcTree(TreeNode n)
        {
            if (n == null) return 0;
            return CalcTree(n.left) + n.val + CalcTree(n.right);
        }
    }
}
