/*
Given a list of numbers and a number k, return whether any two numbers from the list add up to k.

For example, given [10, 15, 3, 7] and k of 17, return true since 10 + 7 is 17.

Bonus: Can you do this in one pass?
 */
using System;
using System.Linq;
using System.Collections.Generic;
public class Addup
{
    public static void Main(string[] args)
    {
        int k;
        int[] list;
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: Addup <K> <List of Numbers>");
            return;
        }
        k = int.Parse(args[0]);
        list = new int[args.Length - 1];
        for (int i = 1; i < args.Length; i++)
        {
            list[i - 1] = int.Parse(args[i]);
        }
        if (CheckList(k, list))
        {
            Console.WriteLine("2 numbers from the list add up to " + k);
        }
        else
        {
            Console.WriteLine("No 2 numbers from the list add up to " + k);
        }
    }

    public static bool CheckList(int k, int[] list)
    {
        HashSet<int> hash = new HashSet<int>();
        for (int i = 0; i < list.Length; i++)
        {
            if (hash.Contains(k - list[i]))
            {
                return true;
            }
            hash.Add(list[i]);
        }
        return false;
    }
}