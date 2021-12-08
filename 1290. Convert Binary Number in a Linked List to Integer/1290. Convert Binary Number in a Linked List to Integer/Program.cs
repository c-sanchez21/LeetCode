using System;

namespace _1290._Convert_Binary_Number_in_a_Linked_List_to_Integer
{
    //https://leetcode.com/problems/convert-binary-number-in-a-linked-list-to-integer/
    class Program
    {
        static void Main(string[] args)
        {
            ListNode n1 = new ListNode(1, new ListNode(0, new ListNode(1)));
            ListNode n2 = new ListNode(0);
            ListNode n3 = new ListNode(1);
            Console.WriteLine(GetDecimalValue(n1));
            Console.WriteLine(GetDecimalValue(n2));
            Console.WriteLine(GetDecimalValue(n3));
        }


        //* Definition for singly-linked list.
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
 
        public static int GetDecimalValue(ListNode head)
        {
            if (head == null) return 0;
            ListNode n = head;
            int val = 0;

            while(n != null)
            {
                val <<= 1;
                val = val | n.val;
                n = n.next;
            }
            return val;
        }
    }
}
