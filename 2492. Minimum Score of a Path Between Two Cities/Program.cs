// See https://aka.ms/new-console-template for more information
Console.WriteLine(MinScore(4, new int[][] { new int[] { 1, 2, 2 }, new int[] { 1, 3, 4 }, new int[] { 3, 4, 7 } }));

int MinScore(int n, int[][] roads)
{
    //Create Adjency List
    Dictionary<int, List<KeyValuePair<int, int>>> map = new Dictionary<int, List<KeyValuePair<int, int>>>();
    foreach (int[] road in roads)
    {//Add Bi-directional paths
        //Path 0 -> 1
        if (!map.ContainsKey(road[0]))
            map.Add(road[0], new List<KeyValuePair<int, int>>());
        map[road[0]].Add(new KeyValuePair<int, int>(road[1], road[2]));

        //Path 1 -> 0 
        if (!map.ContainsKey(road[1]))
            map.Add(road[1], new List<KeyValuePair<int, int>>());
        map[road[1]].Add(new KeyValuePair<int, int>(road[0], road[2]));
    }
    return BFS(n, map);
}

int BFS(int n, Dictionary<int,List<KeyValuePair<int,int>>> map)
{
    bool[] visited = new bool[n + 1];
    Queue<int> q = new Queue<int>();
    int ans = int.MaxValue;

    q.Enqueue(1);
    visited[1] = true;
    int node;
    while(q.Count > 0)
    {
        node = q.Dequeue();
        if (!map.ContainsKey(node)) continue;
        foreach(KeyValuePair<int,int> kvp in map[node])
        {
            ans = Math.Min(ans, kvp.Value);
            if (!visited[kvp.Key])
            {
                visited[kvp.Key] = true;
                q.Enqueue(kvp.Key);
            }
        }
    }
    return ans;
}