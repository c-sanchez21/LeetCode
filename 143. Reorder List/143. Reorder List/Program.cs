using System;
using System.Collections.Generic;

namespace _143._Reorder_List
{
    //https://leetcode.com/problems/reorder-list/
    class Program
    {
        static void Main(string[] args)
        {
            ListNode n = new ListNode(1,
                new ListNode(2,
                new ListNode(3,
                new ListNode(4,
                new ListNode(5)))));
            PrintListNode(n);
            ReorderList(n);
            PrintListNode(n);

            ListNode n2 = new ListNode(1,
             new ListNode(2,
             new ListNode(3,
             new ListNode(4))));
            PrintListNode(n2);
            ReorderList(n2);
            PrintListNode(n2);
        }

        public static void PrintListNode(ListNode n)
        {
            Console.Write("[");
            while(n != null)
            {
                Console.Write("{0} ", n.val);
                n = n.next;
            }
            Console.WriteLine("]"); 
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

        public static void ReorderList(ListNode head)
        {
            if (head == null) return;

            //Put nodes into a list - **A Deque would be preferable but not readily available in C#
            List<ListNode> list = new List<ListNode>();
            ListNode n = head;
            while (n != null)
            {
                list.Add(n);
                n = n.next;
            }

            //Start taking nodes alternatively from the start and end of the List
            n = list[0];
            list.RemoveAt(0);
            bool takeEnd = true; //Flag indicating which side to take from
            while(list.Count > 0)
            {
                if(takeEnd) //Take from the end
                {
                    n.next = list[list.Count - 1];
                    list.RemoveAt(list.Count - 1);
                    takeEnd = false;
                }
                else //Take from the start
                {
                    n.next = list[0];
                    list.RemoveAt(0);
                    takeEnd = true;
                }
                n = n.next;
            }
            n.next = null; 
        }
    }
}
