using System;
using System.Collections.Generic;
using System.Linq;

namespace _314._Binary_Tree_Vertical_Order_Traversal
{
    class Program
    {
        //https://leetcode.com/problems/binary-tree-vertical-order-traversal/
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
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

        static Dictionary<int, List<int>> columns = new Dictionary<int, List<int>>();
        public static IList<IList<int>> VerticalOrder(TreeNode root)
        {
            columns = new Dictionary<int, List<int>>();
            List<IList<int>> results = new List<IList<int>>();
            if (root == null) return results;
            Traverse(root);
            List<int> keys = columns.Keys.ToList();
            keys.Sort();
            foreach (int key in keys)
                results.Add(columns[key]);
            return results;

        }

        public static void Traverse(TreeNode n)
        {
            
            if (n == null) return;

            KeyValuePair<int, TreeNode> kvp = new KeyValuePair<int, TreeNode>();
            int col = 0;
            Queue<KeyValuePair<int, TreeNode>> q = new Queue<KeyValuePair<int, TreeNode>>();
            q.Enqueue(new KeyValuePair<int, TreeNode>(col, n));

            while(q.Count > 0)
            {
                kvp = q.Dequeue();
                col = kvp.Key;
                if (!columns.ContainsKey(col))
                    columns.Add(col, new List<int>());
                columns[col].Add(kvp.Value.val);

                if (kvp.Value.left != null)
                    q.Enqueue(new KeyValuePair<int, TreeNode>(kvp.Key - 1, kvp.Value.left));
                if (kvp.Value.right != null)
                    q.Enqueue(new KeyValuePair<int, TreeNode>(kvp.Key + 1, kvp.Value.right));
            }
        }
    }
}
