using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Security.Cryptography;

namespace _904._Fruit_Into_Baskets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    private static int TotalFruits(int[] fruits)
    {
        Dictionary<int, int> basket = new Dictionary<int, int>();
        int l = 0, r = 0;

        int fType; //Fruit Type
        for(r = 0; r < fruits.Length; r++)
        {
            fType = fruits[r];
            if (!basket.ContainsKey(fType))
                basket.Add(fType, 0);
            basket[fType]++;

            if(basket.Keys.Count > 2)
            {
                basket.Add()
            }
        }
    }
}
