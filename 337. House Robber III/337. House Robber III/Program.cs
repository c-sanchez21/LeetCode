using System;
using System.Collections.Generic;

namespace _337._House_Robber_III
{
    //https://leetcode.com/problems/house-robber-iii/
    class Program
    {
        static void Main(string[] args)
        {
          
        }

        //Definition for a binary tree node.
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

        static Dictionary<TreeNode, int> cache = new Dictionary<TreeNode, int>();
        public static int Rob(TreeNode root)
        {
            //Note: Not necessary to create seperate sub function 
            //for this particular problem but Rob() can then later 
            //be modified to support additional problem paramaters. 
            return RobSub(root);
        }

        //Dyanmic Programming
        public static int RobSub(TreeNode n)
        {
            //Base Case return 0
            if (n == null) return 0;
            
            //If already calculated - return cached value
            if (cache.ContainsKey(n))
                return cache[n];

            //First case - Current Node + Max Value of Grandchildren
            int max1 = n.val;
            if(n.left != null)
            {
                max1 += RobSub(n.left.left);
                max1 += RobSub(n.left.right);
            }
            if(n.right != null)
            {
                max1 += RobSub(n.right.left);
                max1 += RobSub(n.right.right);
            }

            //Second case - Max Values of Children
            int max2 = RobSub(n.left) + RobSub(n.right);

            //Take greater value of two
            int max = Math.Max(max1, max2);

            //Cache to avoid repetitive calculations
            cache.Add(n, max);

            //Return max 
            return max;
        }
    }
}
