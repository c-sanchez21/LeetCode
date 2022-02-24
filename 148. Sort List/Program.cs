using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace _148._Sort_List
{
    class Program
    {
        //https://leetcode.com/problems/sort-list/
        static void Main(string[] args)
        {
            //Example 1
            ListNode n1 = new ListNode(4, new ListNode(2, new ListNode(1, new ListNode(3))));
            n1 = SortList(n1);
            while (n1 != null)
            {
                Console.Write("{0}->", n1.val);
                n1 = n1.next;
            }
            Console.WriteLine("Null");

            //Example 2 - with duplicate values
            ListNode n2 = new ListNode(2, new ListNode(2, new ListNode(1, new ListNode(3))));
            n2 = SortList(n2);
            while (n2 != null)
            {
                Console.Write("{0}->", n2.val);
                n2 = n2.next;
            }
            Console.WriteLine("Null");
        }


        // Definition for singly-linked list.
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
        public class CustomComparer<TKey> : IComparer<TKey> where TKey : IComparable
        {
            public int Compare(TKey x, TKey y)
            {
                int val = x.CompareTo(y);
                //Allows for duplicate keys but breaks certains
                //functions such as Remove(key), IndexOfKey(key)
                return (val == 0) ? 1 : val;
            }
        }

        public static ListNode SortList(ListNode head)
        {
            //Check for invalid input 
            if (head == null) return head;

            //Utilized a SortedList with CustomComparer to sort nodes
            SortedList<int, ListNode> sorted = new SortedList<int, ListNode>(new CustomComparer<int>());
            
            //Add all nodes to SortedList
            ListNode n = head;
            while (n != null)
            {
                sorted.Add(n.val, n);
                n = n.next;
            }

            //Get all nodes from SortedList and re-order them
            ListNode root = null;
            foreach(ListNode node in sorted.Values)
            {
                if (root == null)
                {//Case for 1st node
                    root = node;
                    n = node;
                }
                else
                {
                    n.next = node;
                    n = n.next;
                }
            }

            //Set last node.next to null
            if (n != null)
                n.next = null;

            return root;
        }
    }
}
