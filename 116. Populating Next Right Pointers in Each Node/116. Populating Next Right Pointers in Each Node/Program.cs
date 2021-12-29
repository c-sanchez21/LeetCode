using System;
using System.Collections.Generic;

namespace _116._Populating_Next_Right_Pointers_in_Each_Node
{
    class Program
    {
        //https://leetcode.com/problems/populating-next-right-pointers-in-each-node/
        static void Main(string[] args)
        {
            Node n = new Node(1, new Node(2), new Node(3), null);
            Node connected = Connect(n);
        }

        //Definition for a Node.
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

        public static Node Connect(Node root)
        {
            //Base Case
            if (root == null) return null;

            //Use a Queue to do a Level order traversal
            Node n = root;
            Node prev = null;
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(n);
            q.Enqueue(null);  //Use null as delimiter
            while(q.Count > 0)
            {
                n = q.Dequeue();
                if (n == null) //Delimiter reached;
                {
                    if (q.Count > 0)//If Q not empty..
                        q.Enqueue(null);//Push another delimiter
                }
                else
                {
                    //Push Children
                    if (n.left != null)
                        q.Enqueue(n.left);
                    if (n.right != null)
                        q.Enqueue(n.right);
                }
                if (prev != null)
                    prev.next = n;
                prev = n;
            }
            return root;
        }
    }
}
