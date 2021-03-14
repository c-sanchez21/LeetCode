using System;

namespace Swapping_Nodes_in_a_Linked_List
{
    //https://leetcode.com/explore/challenge/card/march-leetcoding-challenge-2021/589/week-2-march-8th-march-14th/3671/
    class Program
    {
        static void Main(string[] args)
        {
            //First Example:
            ListNode n1 = new ListNode(1,
                new ListNode(2,
                new ListNode(3,
                new ListNode(4,
                new ListNode(5)))));
            PrintLinkedList(n1);
            n1 = SwapNodes(n1, 2);
            PrintLinkedList(n1);

            //Second Example:
            ListNode n2 = new ListNode(1);
            PrintLinkedList(n2);
            n2 = SwapNodes(n2, 1);
            PrintLinkedList(n2);
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
        public static ListNode SwapNodes(ListNode head, int k)
        {
            if (head == null) return head;
            ListNode n = head;
            ListNode k1 = null; //Node to swap
            int nodeCount = 0;
            int i, j;
            i = 0;
            //Find first Node to swap and find LinkedList count
            while(n != null)
            {
                i++;
                nodeCount++;
                if (i == k)
                    k1 = n;
                n = n.next;
            }
            j = nodeCount - (k - 1);
            if (j < 0) return head;
            n = head;
            i = 0;

            //Find second Node to swap & swap
            while(n != null)
            {
                i++;
                if(i == j)
                {
                    //Swap Values (w/out Temp)
                    /* //Wont Work if k1 = n;
                    k1.val = k1.val + n.val;
                    n.val = k1.val - n.val;
                    k1.val = k1.val - n.val;
                    */
                    int temp = k1.val;
                    k1.val = n.val;
                    n.val = temp;
                    break;
                }
                n = n.next;
            }

            return head;
        }

        public static void PrintLinkedList(ListNode head)
        {
            Console.Write("[");
            ListNode n = head;
            while(n != null)
            {
                Console.Write(n.val);
                if (n.next != null)
                    Console.Write(',');
                n = n.next;
            }
            Console.WriteLine("]");
        }
    }
}
