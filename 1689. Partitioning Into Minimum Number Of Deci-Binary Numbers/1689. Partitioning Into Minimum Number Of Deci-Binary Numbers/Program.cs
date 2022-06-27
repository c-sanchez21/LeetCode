namespace _1689._Partitioning_Into_Minimum_Number_Of_Deci_Binary_Numbers;
class Program
{
    //https://leetcode.com/problems/partitioning-into-minimum-number-of-deci-binary-numbers/
    static void Main(string[] args)
    {
        Console.WriteLine(MinPartitions("32"));
        Console.WriteLine(MinPartitions("82734"));
        Console.WriteLine(MinPartitions("27346209830709182346"));
    }

    public static int MinPartitions(string n)
    {
        if (string.IsNullOrEmpty(n)) return 0;

        int max = 0;
        int val;
        foreach(char c in n)
        {
            val = (int) (c-'0');
            if(val > max) max = val; ;
        }
        return max;
    }
}
