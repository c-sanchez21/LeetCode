using System;
using System.Collections.Generic;
using System.Text;

namespace Symmetric_Tree
{
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
    public static class TreeTools
    {

        public static TreeNode ArrayToTree(int[] arr)
        {
            if (arr == null || arr.Length == 0) return null;
            int idx = 0;
            TreeNode n = new TreeNode(arr[idx++]);
            TreeNode root = n;
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(n);
            int x;
            while (idx < arr.Length)
            {
                n = q.Dequeue();
                x = arr[idx++];
                if (x > 0)
                {
                    n.left = new TreeNode(x);
                    q.Enqueue(n.left);
                }

                x = arr[idx++];
                if (x > 0)
                {
                    n.right = new TreeNode(x);
                    q.Enqueue(n.right);
                }
            }
            return root;
        }

        public static int Height(TreeNode n)
        {
            if (n == null) return 0;
            return 1 + Math.Max(Height(n.left), Height(n.right));
        }
    }
}
