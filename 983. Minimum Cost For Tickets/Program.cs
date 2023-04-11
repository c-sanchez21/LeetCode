// See https://aka.ms/new-console-template for more information
using System.Net.Http.Headers;

Console.WriteLine(MincostTickets(new int[] { 1, 4, 6, 7, 8, 20 }, new int[] { 2, 7, 15 }));
Console.WriteLine(MincostTickets(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 30, 31 }, new int[] { 2, 7, 15 }));
Console.WriteLine(MincostTickets(new int[] { 1, 4, 6, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 20, 21, 22, 23, 27, 28 }, new int[] { 2, 7, 15 }));

Dictionary<int, int> cache;
int MincostTickets(int[] days, int[] costs)
{
    cache = new Dictionary<int, int>();
    int temp = Math.Min(Min(days, costs, days[0]+1, costs[0]), Min(days, costs, days[0] + 7, costs[1]));
    return Math.Min(temp, Min(days, costs, days[0] + 30, costs[2]));
}

int Min(int[] days, int[] costs, int day, int cost)
{
    if (cache.ContainsKey(day)) return cache[day];
    int idx = 0;
    while (idx < days.Length && day > days[idx])
        idx++;
    if (idx >= days.Length) return cost;
    int temp = Math.Min(Min(days, costs, days[idx]+1, cost + costs[0]), Min(days, costs, days[idx] + 7, cost + costs[1]));
    temp = Math.Min(temp, Min(days, costs, days[idx] + 30, cost + costs[2]));
    cache.Add(day, temp);
    return cache[day];
}