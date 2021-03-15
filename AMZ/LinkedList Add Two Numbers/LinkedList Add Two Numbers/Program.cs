using System;

namespace LinkedList_Add_Two_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            ListNode l1 = new ListNode(2,
                new ListNode(4,
                new ListNode(3)));
            ListNode l2 = new ListNode(5,
                new ListNode(6,
                new ListNode(4)));
            PrintLinkedList(AddTwoNumbers(l1, l2));
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
        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            int digit, carry;
            carry = 0;
            ListNode n1 = l1;
            ListNode n2 = l2;
            ListNode res = new ListNode();
            ListNode n3 = new ListNode();
            res = n3;
            int a, b; 
            while(n1 != null || n2 != null)
            {
                a = (n1 == null) ? 0 : n1.val;
                b = (n2 == null) ? 0 : n2.val;
                digit = a + b + carry;
                carry = (digit >= 10) ? 1 : 0;
                n3.next = new ListNode(digit % 10);
                n3 = n3.next;
                if (n1 != null) n1 = n1.next;
                if (n2 != null) n2 = n2.next;
            }
            if (carry > 0)
                n3.next = new ListNode(carry);
            return res.next;
        }

        public static void PrintLinkedList(ListNode n)
        {
            Console.Write("[");
            while(n != null)
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
