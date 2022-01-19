using System;

namespace _142._Linked_List_Cycle_II
{
    class Program
    {
        //https://leetcode.com/problems/linked-list-cycle-ii/
        static void Main(string[] args)
        {
            //Example 1:
            ListNode n1 = new ListNode(3);
            n1.next = new ListNode(2);
            n1.next.next = new ListNode(0);
            n1.next.next.next = new ListNode(-4);
            n1.next.next.next.next = n1.next;
            ListNode res1 = DetectCycle(n1);
            Console.WriteLine("{0}", res1);

            //Example 2:
            ListNode n2 = new ListNode(1);
            n2.next = new ListNode(2);
            n2.next.next = new ListNode(3);
            n2.next.next.next = n2;
            ListNode res2 = DetectCycle(n2);
            Console.WriteLine("{0}", res2);
        }
        

        //Definition for singly-linked list.
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x)
            {
                val = x;
                next = null;
            }

            public override string ToString()
            {
                return String.Format("[{0}]", val);
            }
        }


        public static ListNode DetectCycle(ListNode head)
        {
            //Floyd Tortoise and Hare
            ListNode slow, fast;
            slow = fast = head;

            //Find Intersection 
            while(fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
                if (slow == fast)
                    break;//Intersection Found  
            }

            //No Intersection - No Cycle - Return Null
            if (fast == null || fast.next == null)
                return null;

            //Increment both by 1 - They will meet at the entrance
            slow = head;
            while(slow != fast)
            {
                slow = slow.next;
                fast = fast.next;
            }

            return slow;
        }
    }
}
