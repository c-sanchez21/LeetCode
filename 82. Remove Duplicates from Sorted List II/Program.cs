using System;
using System.Collections.Generic;

namespace _82._Remove_Duplicates_from_Sorted_List_II
{
    class Program
    {
        //https://leetcode.com/problems/remove-duplicates-from-sorted-list-ii/
        static void Main(string[] args)
        {
            //Example 1
            int[] arr1 = new int[] { 1, 2, 3, 3, 4, 4, 5 };
            ListNode n1 = CreateList(arr1);
            n1 = DeleteDuplicates(n1);
            PrintList(n1);
        }

        private static void PrintList(ListNode n)
        {
            Console.Write("[");
            while (n != null)
            {
                Console.Write(" {0} ", n.val);
                n = n.next;
            }
            Console.Write("]");
        }

        private static ListNode CreateList(IEnumerable<int> a)
        {
            ListNode n = new ListNode();
            ListNode root = n;
            ListNode prev = null;
            foreach(int i in a)
            {
                n.val = i;
                n.next = new ListNode();
                prev = n;
                n = n.next;
            }
            if (prev != null)
                prev.next = null;
            return root;
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


        public static ListNode DeleteDuplicates(ListNode head)
        {
            //Check for Null
            if (head == null) return head;

            //Count the frequency of the values
            Dictionary<int, int> frq = new Dictionary<int, int>();
            ListNode n = head;
            while(n != null)
            {
                if (!frq.ContainsKey(n.val))
                    frq.Add(n.val, 1);
                else frq[n.val]++;
                n = n.next;
            }

            //Find first node without duplicates
            ListNode first = null;
            n = head;
            while (n != null && frq[n.val] > 1)
                n = n.next;
            first = n;

            //Traverse the list and only augment nodes without duplicates
            ListNode next;
            while(n != null)
            {
                next = n.next;
                while(next != null && frq[next.val] > 1)
                    next = next.next;
                n.next = next;
                n = n.next;
            }
            return first; //Return the first node
        }
    }
}
