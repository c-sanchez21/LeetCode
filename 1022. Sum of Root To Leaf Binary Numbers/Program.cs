using System;

namespace _1022._Sum_of_Root_To_Leaf_Binary_Numbers
{
    class Program
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
        static void Main(string[] args)
        {
            //Build the tree
            TreeNode n = new TreeNode(1);

            TreeNode nLeft = new TreeNode(0,
                new TreeNode(0), new TreeNode(1));

            TreeNode nRight = new TreeNode(1,
                new TreeNode(0), new TreeNode(1));

            n.left = nLeft;
            n.right = nRight;

            Console.WriteLine(SumRootToLeaf(n));
        }

        static int RootToLeafValue = 0;
        public static void PreOrder(TreeNode n, int cur)
        {
            //Base Case
            if (n == null) return;

            //XOR cur value with new node
            cur = cur << 1;
            cur = cur | n.val;

            //If it's a leaf update the sum
            if (n.left == null && n.right == null)
            {
                RootToLeafValue += cur;
                Console.WriteLine(cur);
            }

            //Continue Pre-Order traversal on children. 
            PreOrder(n.left, cur);
            PreOrder(n.right, cur);
        }
        public static int SumRootToLeaf(TreeNode root)
        {
            PreOrder(root, 0);
            return RootToLeafValue;
        }
    }
}
