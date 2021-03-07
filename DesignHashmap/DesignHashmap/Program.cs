using System;

namespace DesignHashmap
{
    class Program
    {
        //https://leetcode.com/explore/featured/card/march-leetcoding-challenge-2021/588/week-1-march-1st-march-7th/3663/
        //A simple array HashMap
        public class MyHashMap
        {
            int[] dic = new int[1000001];
            /** Initialize your data structure here. */
            public MyHashMap()
            {
                //Initialize all values to default -1;
                for (int i = 0; i < dic.Length; i++)
                    dic[i] = -1;
            }

            /** value will always be non-negative. */
            public void Put(int key, int value)
            {
                dic[key] = value;
            }

            /** Returns the value to which the specified key is mapped, or -1 if this map contains no mapping for the key */
            public int Get(int key)
            {
                return dic[key];
            }

            /** Removes the mapping of the specified value key if this map contains a mapping for the key */
            public void Remove(int key)
            {
                dic[key] = -1;
            }
        }
        static void Main(string[] args)
        {
            MyHashMap map = new MyHashMap();
        }
    }
}
