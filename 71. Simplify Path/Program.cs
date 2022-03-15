using System;
using System.Collections.Generic;
using System.Text;

namespace _71._Simplify_Path
{
    class Program
    {
        //https://leetcode.com/problems/simplify-path/
        static void Main(string[] args)
        {
            //Examples
            Console.WriteLine(SimplifyPath("/home/")+"!");
            Console.WriteLine(SimplifyPath("/../")+"!");
            Console.WriteLine(SimplifyPath("/home//food/")+"!");
            Console.WriteLine(SimplifyPath("/a/b/c/../../.../") + "!");
        }

        public static string SimplifyPath(string path)
        {
            //Check for null
            if (String.IsNullOrEmpty(path)) return path;

            //Split the path using the delimiter '/'
            string[] dirs = path.Split('/', StringSplitOptions.RemoveEmptyEntries);
            string d;


            StringBuilder sb = new StringBuilder();
            Stack<string> stack1 = new Stack<string>();
            Stack<string> stack2 = new Stack<string>();

            //Push directories into stack
            foreach(string dir in dirs)
            {
                d = dir.Trim();
                //If '..' then go up to parent direcotry
                if (d.CompareTo("..") == 0)
                {
                    if (stack1.Count > 0)
                        stack1.Pop();
                }
                //'.' is current directory so skip
                else if (d.CompareTo(".") == 0)
                    continue;
                else stack1.Push(d);
            }
            //Push directories into stack
            while(stack1.Count > 0)
            {
                d = stack1.Pop();
                stack2.Push(d);
            }
            //Pop directoriers and use StringBuilder to  build Path
            while(stack2.Count > 0)
            {
                d = stack2.Pop();
                sb.Append("/"+d);
            }
            if (sb.Length == 0) sb.Append("/");
            return sb.ToString();
        }
    }
}
