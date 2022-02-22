using System;
using System.Collections.Generic;

namespace _234._Palindrome_Linked_List
{
    class Program
    {
        //https://leetcode.com/problems/palindrome-linked-list/
        static void Main(string[] args)
        {
            //Example 1
            ListNode n1 = new ListNode(1, new ListNode(2, new ListNode(2, new ListNode(1))));
            Console.WriteLine(IsPalindrome(n1));

            //Example 2
            ListNode n2 = new ListNode(1, new ListNode(2));
            Console.WriteLine(IsPalindrome(n2));
        }

        //Definition for singly-linked list.
        public class ListNode {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null) {
                this.val = val;
                this.next = next;
            }
        }


        public static bool IsPalindrome(ListNode head)
        {
            //Check for invalid input
            if (head == null) return false;

            //Utilize stack to determine if list is a palindrome
            Stack<ListNode> stack = new Stack<ListNode>();

            //Push all nodes into the stack
            ListNode n = head;
            while(n != null)
            {
                stack.Push(n);
                n = n.next;
            }

            //Traverse list and pop nodes to determine if list is a palindrome 
            n = head;
            while(n != null)
            {
                if (n.val != stack.Pop().val)
                    return false;
                n = n.next;
            }
            return true;
        }
    }
}
