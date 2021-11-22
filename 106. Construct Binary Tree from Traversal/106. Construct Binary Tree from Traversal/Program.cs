using System;
using System.Collections.Generic;

namespace _106._Construct_Binary_Tree_from_Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            //inorder = [9, 3, 15, 20, 7], postorder = [9, 15, 7, 20, 3]
            TreeNode n = BuildTree(new int[] { 9, 3, 15, 20, 7 }, new int[] { 9, 15, 7, 20, 3 });
            PrintTree(n);//Root, Left, Right...,
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

        static int idxPost;
        static int[] InOrder;
        static int[] PostOrder;
        static Dictionary<int, int> IdxMap = new Dictionary<int, int>();
        public static TreeNode BuildTree(int[] inorder, int[] postorder)
        {
            InOrder = inorder;
            PostOrder = postorder;
            idxPost = postorder.Length - 1;//Start with Last Element

            //Build map of the InOrder traversal
            for (int i = 0; i < inorder.Length; i++)
                if (!IdxMap.ContainsKey(inorder[i]))
                    IdxMap.Add(inorder[i], i);
                else IdxMap[inorder[i]] = i; 

            return BuildTreeSub(0, inorder.Length - 1);

        }

        public static TreeNode BuildTreeSub(int l, int r)
        {
            //If Inorder L > R
            if (l > r) return null;

            int rootVal = PostOrder[idxPost];
            TreeNode root = new TreeNode(rootVal);

            //Root value determines left & right subTrees
            int idx = IdxMap[rootVal];
            idxPost--;

            //Build Right SubTree
            root.right = BuildTreeSub(idx + 1, r);
            //Build Left SubTree
            root.left = BuildTreeSub(l, idx - 1);
            return root;
        }


        public static void PrintTree(TreeNode n)
        {
            Console.Write("[");
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(n);

            while (q.Count > 0)
            {
                n = q.Dequeue();
                Console.Write(n.val);
                if (n.left != null) q.Enqueue(n.left);
                if (n.right != null) q.Enqueue(n.right);
                if (q.Count > 0)
                    Console.Write(",");
            }
            Console.Write("]");
        }
    }
}
