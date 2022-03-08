using System;

namespace _141._Linked_List_Cycle
{
    class Program
    {
        //https://leetcode.com/problems/linked-list-cycle/
        static void Main(string[] args)
        {
            //Example
            ListNode n = new ListNode(3);
            n.next = new ListNode(2);
            n.next.next = new ListNode(0);
            n.next.next.next = new ListNode(-4);
            n.next.next.next.next = n;
            Console.WriteLine("Has Cycle? = "+HasCycle(n));
        }

        //Definition for singly-linked list.
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        public static bool HasCycle(ListNode head)
        {
            //Check for null
            if (head == null) return false;

            //Variables
            ListNode n1 = head; //Slow Node
            ListNode n2 = head; //Fast Node 

            while(n1 != null && n2 != null && n2.next != null)
            {
                n1 = n1.next; //Move x1 Speed
                n2 = n2.next.next;//Move x2 Speed
                if (n1 == n2) return true; //If they are equal then cycle exists
            }
            return false; //No cycle detected
        }
    }
}
