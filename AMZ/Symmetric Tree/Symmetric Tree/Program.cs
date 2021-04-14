using System;

namespace Symmetric_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode t1 = TreeTools.ArrayToTree(new int[] { 1, 2, 2, 3, 4, 4, 3 });
            TreeNode t2 = TreeTools.ArrayToTree(new int[] { 1, 2, 2, 0, 3, 0, 3 });
            Console.WriteLine("T1 is symmetric? = {0}", IsSymmetric(t1));
            Console.WriteLine("T2 is symmetric? = {0}", IsSymmetric(t2));
        }


        public static bool IsSymmetric(TreeNode root)
        {
            if (root == null) return true;
            return CompareTree(root.left, root.right);

        }

        public static bool CompareTree(TreeNode n1, TreeNode n2)
        {
            if (n1 == null && n2 == null) return true;
            if (n1 != null && n2 == null) return false;
            if (n2 != null && n1 == null) return false;
            if (n1.val != n2.val) return false;
            return CompareTree(n1.left, n2.right) && CompareTree(n1.right, n2.left);
        }
    }
}
