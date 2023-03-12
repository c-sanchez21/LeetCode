using System;
using System.Collections.Generic;

namespace _23._Merge_k_Sorted_Lists
{
    class Program
    {
        //Rating: Hard
        //https://leetcode.com/problems/merge-k-sorted-lists/
        static void Main(string[] args)
        {
            //Example:
            //Input: lists = [[1, 4, 5],[1,3,4],[2,6]]
            //Output:[1,1,2,3,4,4,5,6]
            ListNode[] lists = new ListNode[]
            {
                new ListNode(1,new ListNode(4,new ListNode(5))),
                new ListNode(1,new ListNode(3,new ListNode(4))),
                new ListNode(2,new ListNode(6))
            };
            //Print Resulsts
            ListNode root = MergeKLists(lists);
            while(root != null)
            {
                Console.Write("{0} -> ", root.val);
                root = root.next;
            }

            //Example 2: 
            //Input: lists2 = [] //Empty Set
            //Output: null 
            ListNode[] lists2 = new ListNode[0];
            root = MergeKLists(lists2);
            if (root == null) Console.WriteLine("Null");
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

        //Merge Lists Together
        public static ListNode MergeKLists(ListNode[] lists)
        {
            //Base Case Test:
            if (lists == null) return null;

            //Sort the nodes into a dictionary sorted by their values
            SortedDictionary<int, List<ListNode>> sortedLists = new SortedDictionary<int, List<ListNode>>();
            ListNode n = null;
            foreach (ListNode node in lists)
            {
                n = node;
                while (n != null)
                {//Each uqnique value is put into a linked list
                    if (!sortedLists.ContainsKey(n.val))
                        sortedLists.Add(n.val, new List<ListNode>());
                    sortedLists[n.val].Add(n);
                    n = n.next;
                }
            }

            //Iterate thru each Key Value Pair in the Sorted Dictionary
            //And join the linnked lists together. 
            ListNode root = null;
            foreach (KeyValuePair<int, List<ListNode>> kvp in sortedLists)
            {
                foreach(ListNode node in kvp.Value)
                {
                    //Special case for the first node
                    if (root == null)
                    {
                        root = node; 
                        n = node;
                    }
                    else
                    {
                        n.next = node;
                        n = n.next;
                    }
                }
            }
            //For the last node
            if(n != null)
                n.next = null;

            //Return root
            return root;
        }
    }
}
