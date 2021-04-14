using System;
using System.Collections.Generic;

namespace Partition_List
{
    class Program
    {
        //https://leetcode.com/problems/partition-list/
        static void Main(string[] args)
        {
            int[] arr1 = { 1, 4, 3, 2, 5, 2 };
            ListNode head = new ListNode(arr1[0]);
            ListNode n = head;
            for (int i = 1; i < arr1.Length; i++)
            {
                n.next = new ListNode(arr1[i]);
                n = n.next;
            }
                ListNode res = Partition(head, 3);
            n = res;
            Console.Write("[");
            while(n != null)
            {
                Console.Write(" {0} ", n.val);
                n = n.next;
            }
            Console.Write("]");
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
        public static ListNode Partition(ListNode head, int x)
        {
            if (head == null) return null;

            //Initialize new list
            List<ListNode> list = new List<ListNode>();

            //All less than x go first in the list
            ListNode n = head;
            while(n != null)
            {
                if (n.val < x)
                    list.Add(n);
                n = n.next;
            }

            //All equal to or greater than x go next in the list
            n = head;
            while(n != null)
            {
                if (n.val >= x)
                    list.Add(n);
                n = n.next;
            }

            //Re-construct NodeList
            n = list[0];
            for(int i = 1; i < list.Count;i++)
            {
                n.next = list[i];
                n = n.next;
            }
            //Last Node.Next should point to null
            list[list.Count - 1].next = null;

            //Return the new head of the list
            return list[0];
        }
    }
}
