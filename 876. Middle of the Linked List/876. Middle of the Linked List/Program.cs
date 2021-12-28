using System;

namespace _876._Middle_of_the_Linked_List
{
    class Program
    {
        //https://leetcode.com/problems/middle-of-the-linked-list/
        static void Main(string[] args)
        {
            //Example 1: 
            ListNode n1 = new ListNode(1,
                new ListNode(2,
                new ListNode(3)));
            Console.WriteLine("Example 1:= {0}",MiddleNode(n1).val);

            //Example 2: - Method 2 
            Console.WriteLine("Example 2:= {0}",MiddleNode2(n1).val);
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

        //Counting Method
        public static ListNode MiddleNode(ListNode head)
        {
            if (head == null || head.next == null) return head;

            //Count number of nodes
            int count = 0;
            ListNode n = head;
            while(n != null)
            {
                count++;
                n = n.next;
            }

            int mid = (count / 2);
            //Per Instruction: If there are two middle nodes, return the second middle node.
            mid = mid + 1;

            //Find mid node;
            n = head;
            count = 1;
            while (count != mid)
            {
                n = n.next;
                count++;
            }
            return n;
        }

        //Fast and Slow Pointer
        public static ListNode MiddleNode2(ListNode head)
        {
            ListNode fast, slow;
            fast = slow = head;
            while(fast != null && fast.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
            }
            return slow;
        }
    }
}
