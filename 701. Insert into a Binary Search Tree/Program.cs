using System;

namespace _701._Insert_into_a_Binary_Search_Tree
{
    //https://leetcode.com/problems/insert-into-a-binary-search-tree/
    class Program
    {
        static void Main(string[] args)
        {
            InsertIntoBST(null, 1);
        }

 // Definition for a binary tree node.
  public class TreeNode {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
          this.val = val;
          this.left = left;
          this.right = right;
     }
  }
 
        public static TreeNode InsertIntoBST(TreeNode root, int val)
        {
            //Note: All values are guaranteed Unique
            //When a null node found then insert node
            if (root == null) return new TreeNode(val);

            //Go Right
            if (root.val < val) root.right = InsertIntoBST(root.right, val);

            //Go Left 
            else root.left = InsertIntoBST(root.left, val);

            //Recursively return root Inception style
            return root;
        }
    }
}
