//https://leetcode.com/problems/longest-zigzag-path-in-a-binary-tree/
Console.WriteLine("Hello, World!");

int maxSteps = 0;
int LongestZigZag(Treenode root)
{
    dfs(root, false, 0);
    dfs(root, true, 0);
    return maxSteps;
}

void dfs(Treenode n, bool goLeft, int steps)
{
    if(n == null) return;
    maxSteps = Math.Max(maxSteps, steps);

    if(goLeft)
    {
        dfs(n.left, false, steps + 1);
        dfs(n.right, true, 1);
    }
    else
    {
        dfs(n.left, false, 1);
        dfs(n.right, true, steps+ 1);
    }
}
    
// definition for a binary tree node.
public class Treenode
{
    public int val;
    public Treenode left;
    public Treenode right;
    public Treenode(int val = 0, Treenode left = null, Treenode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}
