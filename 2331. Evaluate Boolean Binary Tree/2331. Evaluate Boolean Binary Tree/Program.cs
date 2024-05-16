
//2331.Evaluate Boolean Binary Tree
using System.Data;

https://leetcode.com/problems/evaluate-boolean-binary-tree/description


//Example 1:
TreeNode e1 = new TreeNode()
{
    val = 2,
    left = new TreeNode() { val = 1 },
    right = new TreeNode() { val = 3, left = new TreeNode() { val = 0 }, right = new TreeNode() { val = 1 } }
};
Console.WriteLine($"Example 1: {EvaluateTree(e1)}");

//Example 2:
TreeNode e2 = new TreeNode() { val = 0 };
Console.WriteLine($"Example 2: {EvaluateTree(e2)}");

static bool EvaluateTree(TreeNode root)
{
    if(root == null || root.val == 0) return false;

    if(root.val == 1) return true; 

    if(root.val == 2)
        return (EvaluateTree(root.left) || EvaluateTree(root.right));
    
    if(root.val == 3)
        return (EvaluateTree(root.left) && EvaluateTree(root.right));

    return false;    
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
