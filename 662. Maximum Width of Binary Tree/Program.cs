//https://leetcode.com/problems/maximum-width-of-binary-tree/
Console.WriteLine("Hello, World!");


int WidthOfBinaryTree(TreeNode root)
{
    return BFS(root);
}

int BFS(TreeNode n)
{
    Queue<KeyValuePair<TreeNode, int>> q = new Queue<KeyValuePair<TreeNode, int>>();
    q.Enqueue(new KeyValuePair<TreeNode, int>(n, 0));

    int maxWidth = 0;
    int lvlLength, lvlStart, idx;
    TreeNode node;
    KeyValuePair<TreeNode, int> kvp;
    while (q.Count > 0)
    {
        lvlLength = q.Count;
        lvlStart = q.Peek().Value;
        idx = 0;

        for (int i = 0; i < lvlLength; i++)
        {
            kvp = q.Dequeue();
            node = kvp.Key;
            idx = kvp.Value;

            if (node.left != null) q.Enqueue(new KeyValuePair<TreeNode, int>(node.left, 2 * idx));

            if (node.right != null) q.Enqueue(new KeyValuePair<TreeNode, int>(node.right, 2 * idx + 1));
        }
        maxWidth = Math.Max(maxWidth, idx - lvlStart + 1);
    }
    return maxWidth;
}

//  Definition for a binary tree node.
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