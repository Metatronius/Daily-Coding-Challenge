/*
Given the root to a binary tree, implement serialize(root), which serializes the tree into a string, and deserialize(s), which deserializes the string back into the tree.

For example, given the following Node class

class Node:
    def __init__(self, val, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right
The following test should pass:

node = Node('root', Node('left', Node('left.left')), Node('right'))
assert deserialize(serialize(node)).left.left.val == 'left.left'
*/

using System;
using System.Linq;
using System.Collections.Generic;


public class SerializeBinaryTree
{
	public static void Main()
	{
		Node left = new Node("left", new Node("left.left"), new Node("left.right"));
		Node right = new Node("right", new Node("right.left"), new Node("right.right"));
		Node root = new Node("root", left, right);
		Tree t = new Tree(root);
		string serialized = t.serialize();
		Console.WriteLine(serialized + serialized.Length);
		t.deserialize(serialized);
		serialized = t.serialize();
		Console.WriteLine(serialized + serialized.Length);
		Tree o = new Tree(root);
		if(o.root.left.left.val == t.root.left.left.val)
		{
			Console.WriteLine("Test Passed");
		}
		else
		{
			Console.WriteLine("Test Failed");
		}
	}
	public class Node
	{
		public string val;
		public Node left;
		public Node right;
		public Node(string value)
		{
			this.val = value;
			this.left = null;
			this.right = null;
		}
		public Node(string value, Node l, Node r)
		{
			this.val = value;
			this.left = l;
			this.right = r;
		}
		public Node(string value, Node l)
		{
			this.val = value;
			this.left = l;
			this.right = null;
		}
	
	}
	public class Tree
	{
		public Node root;
		public Tree(Node n)
		{
			this.root = n;
		}
		public string serialize()
		{
			string s = "";
			return serialize(this.root, s);
		}
		private string serialize(Node n, string s)
		{
			if (n != null)
			{
				return (s+ n.val + "," + serialize(n.left, s) + serialize(n.right, s));
			}
			else
			{
				return s+",";
			}
		}
		public Node deserialize(string s)
		{
			Queue<string> strings = new Queue<string>();
			string[] arr = s.Split(',');
			for(int i = 0; i < arr.Length; i++)
			{
				strings.Enqueue(arr[i]);
			}
			this.root = deserialize(strings);
			return this.root;
		}
		private Node deserialize(Queue<string> q)
		{
			if(q.Count < 1)
			{
				return null;
			}
			string val = q.Dequeue();
			if (String.IsNullOrEmpty(val))
			{
				return null;
			}
			Node n = new Node(val);
			n.left = deserialize(q);
			n.right = deserialize(q);
			return n;
		}
		
	}
}
