using System;
using System.Collections.Generic;

namespace Deepest_Leaves_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = new int[] { 1, 2, 3, 4, 5, 0, 6, 7, 0, 0, 0, 0, 8 };
            TreeNode t1 = ArrayToTree(arr1);
            Console.WriteLine(Height(t1));
            Console.WriteLine(DeepestLeavesSum(t1));
        }

        //Definition for a binary tree node.
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

        public static int DeepestLeavesSum(TreeNode root)
        {
            if (root == null) return 0;
            int maxHeight = Height(root);
            List<int> numsToAdd = new List<int>();
            GetNums(root, 1, maxHeight, numsToAdd);
            int sum = 0;
            foreach (int i in numsToAdd)
                sum += i;
            return sum;
        }

        public static void GetNums(TreeNode n, int curHeight, int Target, List<int> nums)
        {
            if (n == null) return;
            if (curHeight == Target)
            {
                nums.Add(n.val);
                return;
            }
            GetNums(n.left, curHeight + 1, Target, nums);
            GetNums(n.right, curHeight + 1, Target, nums);
        }

        public static int Height(TreeNode n)
        {
            if (n == null) return 0;
            return 1 + Math.Max(Height(n.left), Height(n.right));
        }

        /// <summary>
        /// Convert an int Array to Tree
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
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
    }
}
