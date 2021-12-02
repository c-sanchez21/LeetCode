using System;

namespace _328._Odd_Even_Linked_List
{
    class Program
    {
        //https://leetcode.com/problems/odd-even-linked-list/
        static void Main(string[] args)
        {
            ListNode n = new ListNode(1);
            n.next = new ListNode(2);
            n.next.next = new ListNode(3);
            n.next.next.next = new ListNode(4);
            n = OddEvenList(n);
            PrintList(n);
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

        public static void PrintList(ListNode n)
        {
            Console.Write("[");
            while (n != null)
            {
                Console.Write("{0} ", n.val);
                n = n.next;
            }
            Console.Write("]");
        }

        public static ListNode OddEvenList(ListNode head)
        {
            //Base Case
            if (head == null || head.next == null) return head;

            //Initialize pointers
            ListNode n = head;//Odds
            ListNode n2 = head.next;//Even
            ListNode evenHead = n2;

            while (n2 != null && n2.next != null)
            {
                //Set the odds 
                n.next = n2.next;
                n = n.next;

                //Set the evens
                n2.next = n.next;
                n2 = n2.next;
            }
            //Point the odds tail to the evens head
            n.next = evenHead;

            return head;//Return solution.  
        }
    }
}
