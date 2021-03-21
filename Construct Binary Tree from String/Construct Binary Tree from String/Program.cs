using System;
using System.Collections.Generic;

namespace Construct_Binary_Tree_from_String
{
    class Program
    {
        //https://leetcode.com/explore/challenge/card/march-leetcoding-challenge-2021/590/week-3-march-15th-march-21st/3672/
        static void Main(string[] args)
        {
            string[] inputs = { "1(2)(3)", "4(2(3)(1))(6(5))", "4(2(3)(1))(6(5)(7))", "-4(2(3)(1))(6(5)(7))", "1()(3)","4","-1"};
            TreeNode tree;
            foreach (string input in inputs)
            {
                tree = Str2tree(input);
                PrintTree(tree);
            }
        }


        //Definition for a binary tree node.1
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }
 
        public static TreeNode Str2tree(string s)
        {
            if(String.IsNullOrEmpty(s)) return null;
            int i = 0;
            return strToNode(s, ref i);
        }

        public static TreeNode strToNode(string s,ref int i)
        {
            bool isNeg = false;
            string digit = "";
            int num;
            TreeNode n = null;

            for(; i < s.Length; i++)
            {
                switch(s[i])
                {
                    case '-':
                        isNeg = true;
                        break;
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                        digit += s[i];
                        break;
                    case '(':
                        i++;
                        if (n == null)
                        {
                            num = int.Parse(digit);
                            num = isNeg ? num * -1 : num;
                            digit = "";
                            n = new TreeNode(num);
                            n.left = strToNode(s, ref i);
                        }
                        else n.right = strToNode(s, ref i);
                        break;
                    case ')':
                        if (n != null) return n;
                        if (string.IsNullOrEmpty(digit)) return null;
                        num = int.Parse(digit);
                        num = isNeg ? num * -1 : num;
                        return new TreeNode(num);
                }
            }
            if(!String.IsNullOrEmpty(digit))
            {
                num = int.Parse(digit);
                num = isNeg ? num * -1 : num;
                n = new TreeNode(num);
            }
            return n;
        }

        public static void PrintTree(TreeNode n)
        {
            Console.Write("[");
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(n);

            while(q.Count > 0)
            {
                n = q.Dequeue();
                Console.Write(n.val);
                if (n.left != null) q.Enqueue(n.left);
                if (n.right != null) q.Enqueue(n.right);
                if (q.Count > 0)
                    Console.Write(",");
            }
            Console.Write("]");
        }

    }
}
