using System;

namespace Reverse_Nodes_in_k_Group
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

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
       
        public static ListNode ReverseKGroup(ListNode head, int k)
        {
            ListNode n = head;
            ListNode tail = null;//tail from previous group
            ListNode newHead = null;//Overall final head

            int count;
            while(n != null)
            {
                count = 0;
                n = head;
                while(count < k && n != null)
                {
                    n = n.next;
                    count++;
                }    

                if(count == k)
                {
                    ListNode revHead = ReverseLinkedList(head, k);
                    if (newHead == null) newHead = revHead;//Initialzie New Head
                    if (tail != null) tail.next = revHead;
                    tail = head;
                    head = n;
                }
            }
            if (tail != null) tail.next = head;
            return newHead != null ? newHead : head;

        }

        public static ListNode ReverseLinkedList(ListNode head, int k)
        {
            ListNode newHead = null;
            ListNode n = head;
            ListNode next;
            while(k > 0 && n != null)
            {
                next = n.next;
                n.next = newHead;
                newHead = n;
                n = next;
                k--;
            }
            return newHead;
        }
    }
}
