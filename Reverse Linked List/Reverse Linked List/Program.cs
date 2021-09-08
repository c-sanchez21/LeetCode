using System;

namespace Reverse_Linked_List
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO: Add test case - when working less hours. 
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
 

        public static ListNode ReverseList(ListNode head)
        {
            if (head == null) return head;
            ListNode n = head;
            ListNode next = null;
            ListNode prev = null;
            while(n != null)
            {
                next = n.next;
                n.next = prev;
                prev = n;
                n = next; 
            }
            return prev;
        }
    }
}
