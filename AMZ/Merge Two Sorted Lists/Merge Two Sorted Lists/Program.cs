using System;

namespace Merge_Two_Sorted_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            ListNode l1 = new ListNode(2,
                new ListNode(3,
                new ListNode(4)));
            ListNode l2 = new ListNode(5,
                new ListNode(6,
                new ListNode(7)));
            PrintLinkedList(MergeTwoLists(l1, l2));
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
        public static ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            if (l1 == null) return l2;
            if (l2 == null) return l1;
            ListNode n1 = l1;
            ListNode n2 = l2;
            ListNode res = new ListNode();
            ListNode n3 = res;
            int val; 
            while(n1 != null && n2 != null)
            {
                if(n1.val <= n2.val)
                {
                    n3.next = new ListNode(n1.val);
                    n1 = n1.next;
                    n3 = n3.next;
                }
                else
                {
                    n3.next = new ListNode(n2.val);
                    n2 = n2.next;
                    n3 = n3.next;
                }
            }
            while(n1 != null)
            {
                n3.next = new ListNode(n1.val);
                n1 = n1.next;
                n3 = n3.next;
            }

            while(n2 != null)
            {
                n3.next = new ListNode(n2.val);
                n2 = n2.next;
                n3 = n3.next;
            }
            return res.next;
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
            Console.Write("]");
        }
    }
}
