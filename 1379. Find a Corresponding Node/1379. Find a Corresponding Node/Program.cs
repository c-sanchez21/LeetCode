using System;

namespace _1379._Find_a_Corresponding_Node
{
    internal class Program
    {
        //https://leetcode.com/problems/find-a-corresponding-node-of-a-binary-tree-in-a-clone-of-that-tree/
        static void Main(string[] args)
        {
        }

        // Definition for a binary tree node.
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }
        public static TreeNode GetTargetCopy(TreeNode original, TreeNode cloned, TreeNode target)
        {
            if (original == null || target == null) return null;
            return TraverseTree(original, cloned, target);
        }

        static TreeNode TraverseTree(TreeNode og, TreeNode clone, TreeNode target)
        {
            if (og == target) return clone;
            TreeNode cloneTarg = null;
            if (og.left != null)
            {
                cloneTarg = TraverseTree(og.left, clone.left, target);
                if (cloneTarg != null) return cloneTarg;
            }
            if (og.right != null)
            {
                cloneTarg = TraverseTree(og.right, clone.right, target);
                if (cloneTarg != null) return cloneTarg;
            }
            return null;
        }
    }
}
