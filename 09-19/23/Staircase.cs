/*
There's a staircase with N steps, and you can climb 1 or 2 steps at a time. Given N, write a function that returns the number of unique ways you can climb the staircase. The order of the steps matters.
For example, if N is 6, then there are 13 unique ways:
1, 1, 1, 1, 1, 1
2, 1, 1, 1, 1
1, 2, 1, 1, 1
1, 1, 2, 1, 1
1, 1, 1, 2, 1
1, 1, 1, 1, 2
2, 2, 1, 1
1, 2, 2, 1 
1, 1, 2, 2
2, 1, 2, 1
1, 2, 1, 2
2, 1, 1, 2
2, 2, 2


What if, instead of being able to climb 1 or 2 steps at a time, you could climb any number from a set of positive integers X? For example, if X = {1, 3, 5}, you could climb 1, 3, or 5 steps at a time. Generalize your function to take in X. */
using System;
using System.Linq;
using System.Collections.Generic;
public class Staircase
{
    public static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Please enter the number of steps, and an optional list of stride size");
            return;

        }
        if (args.Length == 1)
        {
            Console.WriteLine(staircase(int.Parse(args[0])));
            return;
        }
        int[] arguments = new int[args.Length];
        for (int i = 0; i < arguments.Length; i++)
        {
            arguments[i] = int.Parse(args[i]);
        }
        int ways = staircase(arguments[0], arguments.Skip(1).ToArray());
        Console.WriteLine(ways);
        return;
    }

    public static int staircase(int steps)//yeah this is just fibonacci
    {
        int last = 1;
        int current = 1;
        int counter = 0;
        for (int i = 1; i < steps; i++)
        {
            counter = last + current;
            last = current;
            current = counter;
        }
        return current;
    }

    public static int staircase(int steps, int[] strides)//This works but is pretty slow (OX^N), could probably make more efficient.
    {
        if (steps < 0)
        {
            return 0;
        }
        if (steps == 0)
        {
            return 1;
        }
        int total = 0;
        for (int i = 0; i < strides.Length; i++)
        {
            total += staircase(steps - strides[i], strides);
        }
        return total;
    }
}

