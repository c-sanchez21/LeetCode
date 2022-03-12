using System;
using System.Collections.Generic;

namespace _138._Copy_List_with_Random_Pointer
{
    class Program
    {
        //https://leetcode.com/problems/copy-list-with-random-pointer/
        static void Main(string[] args)
        {
            Node n1 = new Node(7);
            n1.next = new Node(13);
            Node n2 = n1.next;
            n2.next = new Node(11);
            Node n3 = n2.next;
            Node copy = CopyRandomList(n1);

        }

        // Definition for a Node.
        public class Node
        {
            public int val;
            public Node next;
            public Node random;

            public Node(int _val)
            {
                val = _val;
                next = null;
                random = null;
            }
        }
        public static Node CopyRandomList(Node head)
        {
            //Check for null
            if (head == null) return head;

            //Copy list and Map Nodes 
            Node n = head;
            Dictionary<Node, Node> map = new Dictionary<Node, Node>();
            Node n2 = new Node(-1);
            Node copyStart = n2;
            while (n != null)
            {
                n2.next = new Node(n.val);
                n2 = n2.next;
                map.Add(n, n2);
                n = n.next;
            }

            //Go thru list and assign the 'random' node
            //to their respective mappings
            n = head;
            n2 = copyStart.next;
            while (n != null)
            {
                if (n.random == null)
                    n2.random = null;
                else n2.random = map[n.random];
                n = n.next;
                n2 = n2.next;
            }
            return copyStart.next;
        }
    }
}
