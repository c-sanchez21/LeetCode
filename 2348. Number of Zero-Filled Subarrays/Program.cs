// See https://aka.ms/new-console-template for more information
Console.WriteLine(ZeroFilledSubarray(new int[] { 0, 0, 0 }));
Console.WriteLine(ZeroFilledSubarray(new int[] {1, 3, 0, 0, 2, 0, 0, 4}));
Console.WriteLine(ZeroFilledSubarray(new int[] { 0, 0, 0, 2, 0, 0 }));

long ZeroFilledSubarray(int[] nums)
{
    long ans = 0;
    int idx = 0;
    int count = 0;
    for(; idx < nums.Length; idx++)
    {
        while (idx < nums.Length && nums[idx] == 0)
        {
            count++;
            idx++;
        }    
        if(count > 0)
        {
            ulong temp = (ulong)count;
            ulong gaussSum = (temp * (temp + 1)) / 2;
            ans += (long)gaussSum;
            count = 0;
        }
    }
    return ans;

}