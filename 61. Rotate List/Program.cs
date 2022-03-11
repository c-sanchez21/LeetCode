using System;

namespace _61._Rotate_List
{
    class Program
    {
        //https://leetcode.com/problems/rotate-list/
        static void Main(string[] args)
        {
            //Example 
            for (int i = 1; i <= 5; i++)
                PrintLinkedList(RotateRight(CreateList(5), i));
        }

        public static ListNode RotateRight(ListNode head, int k)
        {
            //Check for null or single node
            if (head == null || head.next == null) return head;

            int size = 0;
            ListNode n = head;
            ListNode last = n;

            //Count the size of the list
            while (n != null)
            {
                size++;
                last = n;
                n = n.next;
            }

            //Mod k by size to determine actual rotations needed
            k = k % size;
            if (k == 0) return head; //No rotation needed

            //Find the new last node
            int rot = size - k;
            ListNode newLast = head;
            for (int i = 1; i < rot; i++)
                newLast = newLast.next;

            //Restructure list and return new beginning of list
            last.next = head;
            ListNode newFirst = newLast.next;
            newLast.next = null;
            return newFirst;
        }

        private static ListNode CreateList(int n)
        { 
            ListNode first, node;
            node = new ListNode();
            first = node;
            for(int i = 1; i <= n; i++)
            {
                node.next = new ListNode(i);
                node = node.next;
            }
            return first.next;
        }

        //Definition for singly-linked list.
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        public static void PrintLinkedList(ListNode n)
        {
            Console.Write("[");
            while (n != null)
            {
                Console.Write(n.val);
                if (n.next != null)
                    Console.Write(',');
                n = n.next;
            }
            Console.WriteLine("]");
        }

    }
}
