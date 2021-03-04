using System;

namespace LinkedListIntersection
{
    class Program
    {
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }
    
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            ListNode intersection = null;
            ListNode n = headA;
            while(n != null)
            {
                n.val *= -1; //Mark node as visited
                n = n.next;
            }
            n = headB;
            while(n != null)
            {
                if (n.val < 0)
                {
                    intersection = n;
                    break;
                }
                n = n.next;
            }
            //Restore list
            n = headA;
            while (n != null)
            {
                n.val *= -1;
                n = n.next;
            }

            return intersection;
        }
    }
}
