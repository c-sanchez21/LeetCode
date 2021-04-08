using System;

namespace Inorder_Successor_in_BST
{
    class Program
    {
        static void Main(string[] args)
        {
            //Example 1 
            /*
            TreeNode tree = new TreeNode(2);
            tree.left = new TreeNode(1);
            tree.right = new TreeNode(3);
            TreeNode res = InorderSuccessor(tree, new TreeNode(1));
            string ans = res == null ? "null" : res.val.ToString();
            Console.WriteLine("InOrder Succesor of 1 is {0}", ans);
            */

            //Example 2
            TreeNode tree2 = new TreeNode(5);
            tree2.left = new TreeNode(3);
            tree2.right = new TreeNode(6);
            tree2.left.left = new TreeNode(1);
            tree2.left.right = new TreeNode(4);
            tree2.left.left.right = new TreeNode(2);
            tree2.right = new TreeNode(6);
            TreeNode res2 = InorderSuccessor(tree2, new TreeNode(4));
            string ans2 = res2 == null ? "null" : res2.val.ToString();
            Console.WriteLine("InOrder Succesor of 1 is {0}", ans2);

        }

        //Definition for a binary tree node.
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        public static TreeNode InorderSuccessor(TreeNode root, TreeNode p)
        {
            //Base case
            if (root == null) return null;
            return Successor(root, p, null);
        }

        public static TreeNode Successor(TreeNode n, TreeNode p, TreeNode prior)
        {
            if (n.val == p.val)
            {
                //If it has right node then successor is left most of right
                if (n.right != null)
                {
                    TreeNode leftmost = n.right;
                    while (leftmost.left != null)
                        leftmost = leftmost.left;
                    return leftmost;
                }
                else return prior; //Prior node is succesor
            }

            TreeNode ans = null;
            //Go Left with current node as succesor
            if (n.left != null)
                ans = Successor(n.left, p, n);
            if (ans != null) return ans;

            //Go right with prior as successor 
            if (n.right != null)
                ans = Successor(n.right, p, prior);
            return ans;
        }

    }
}
