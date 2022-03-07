using System;
using System.Collections.Generic;

namespace _21._Merge_Two_Sorted_Lists
{
    class Program
    {
        //https://leetcode.com/problems/merge-two-sorted-lists/
        static void Main(string[] args)
        {
            //Example
            ListNode l1 = new ListNode(2,
                new ListNode(3, new ListNode(4)));
            ListNode l2 = new ListNode(5,
                new ListNode(6, new ListNode(7)));
            PrintLinkedList(MergeTwoLists(l1, l2));
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
            //Check for edge case
            if (l1 == null) return l2;
            if (l2 == null) return l1;

            //Variables 
            ListNode n1 = l1;
            ListNode n2 = l2;
            List<ListNode> list = new List<ListNode>();

            //Traverse both linked list
            while(n1 != null && n2 != null)
            {
                //Compare both list and take smaller value
                if (n1.val <= n2.val)
                {
                    list.Add(n1);
                    n1 = n1.next;
                }
                else
                {
                    list.Add(n2);
                    n2 = n2.next;
                }
            }

            //Get any remaining nodes from list1
            while(n1 != null)
            {
                list.Add(n1);
                n1 = n1.next;
            }
            //Get any remaining nodes from list2
            while(n2 != null)
            {
                list.Add(n2);
                n2 = n2.next;
            }

            //Staple the list together
            for (int i = 0; i < list.Count - 1; i++)
                list[i].next = list[i + 1];
            list[list.Count - 1].next = null;

            //Return the first node in the list
            return list[0];
        }
    }
}
