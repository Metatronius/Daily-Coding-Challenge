/*
Given an array of integers, return a new array such that each element at index i of the new array is the product of all the numbers in the original array except the one at i.

For example, if our input was [1, 2, 3, 4, 5], the expected output would be [120, 60, 40, 30, 24]. If our input was [3, 2, 1], the expected output would be [2, 3, 6].

Follow-up: what if you can't use division?
 */
using System;
using System.Linq;
using System.Collections.Generic;
public class ArrayProduct
{
	public static void Main(string[] args)
	{
		int[] list;
		int[] newList;

		if (args.Length < 2)
		{
			Console.WriteLine("Usage: ArrayProduct <List of Numbers>");
			return;
		}
		list = new int[args.Length];
		for (int i = 0; i < args.Length; i++)
		{
			list[i] = int.Parse(args[i]);
		}

		newList = ExclusiveProduct(list);

		Console.WriteLine("Your New Array is:[{0}]", string.Join(", ", newList));
	}

	public static int[] ExclusiveProduct (int[] arr) 
	{
		int[] output = new int[arr.Length];

		for (int i = 0; i < arr.Length; i++)
		{
			output[i] = ExclusiveProductOf(arr, i);
		}

		return output;
	}

	public static int ExclusiveProductOf(int[] arr, int exclude)
	{
		int product = 1;

		for(int i = 0; i < arr.Length; i++)
		{
			if (i != exclude)
			{
				product *= arr[i];
			}
		}

		return product;
	}
}