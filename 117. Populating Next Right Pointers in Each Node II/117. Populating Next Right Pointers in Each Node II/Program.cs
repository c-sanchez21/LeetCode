using System;
using System.Collections.Generic;

namespace _117._Populating_Next_Right_Pointers_in_Each_Node_II
{
    internal class Program
    {
        //https://leetcode.com/problems/populating-next-right-pointers-in-each-node-ii/submissions/
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
        }

        public Node Connect(Node root)
        {
            if (root == null) return null;

            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root);
            q.Enqueue(null);//Insert Delimiter
            Node prev = null;
            Node cur = null;
            while(q.Count > 0)
            {
                cur = q.Dequeue();
                if (cur != null)
                {
                    if (prev != null) prev.next = cur;
                    if (cur.left != null) q.Enqueue(cur.left);
                    if (cur.right != null) q.Enqueue(cur.right);
                }
                else if (q.Count > 0)
                    q.Enqueue(null); //Insert Delimiter
                prev = cur;
            }
            return root;
        }

        public class Node
        {
            public int val;
            public Node left;
            public Node right;
            public Node next;

            public Node() { }

            public Node(int _val)
            {
                val = _val;
            }

            public Node(int _val, Node _left, Node _right, Node _next)
            {
                val = _val;
                left = _left;
                right = _right;
                next = _next;
            }
        }


    }
}
