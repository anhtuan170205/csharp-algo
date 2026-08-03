using System;
using System.Linq;
using System.Collections.Generic;

public class TrieNode
{
	public TrieNode[] Children = new TrieNode[26];
	public int MaxWeight = -1;
}

public class Trie
{
	private readonly TrieNode root = new TrieNode();

	public void Insert(string word, int weight)
	{
		TrieNode current = root;

		foreach (char c in word)
		{
			int index = c - 'a';
			if (current.Children[index] == null) current.Children[index] = new TrieNode();
			current = current.Children[index];
			current.MaxWeight = Math.Max(current.MaxWeight, weight);
		}
	}

	public int SearchPrefix(string prefix)
	{
		TrieNode current = root;

		foreach (char c in prefix)
		{
			int index = c - 'a';
			if (current.Children[index] == null) return -1;
			current = current.Children[index];
		}
		
		return current.MaxWeight;
	}
}

public class Program
{
	public static void Main()
	{
		int[] line = Console.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
		int n = line[0], q = line[1];

		Trie trie = new Trie();

		for (int i = 0; i < n; i++)
		{
			string[] input = Console.ReadLine().Split();
			string word = input[0];
			int weight = int.Parse(input[1]);

			trie.Insert(word, weight);
		}

		for (int i = 0; i < q; i++)
		{
			string query = Console.ReadLine();
			Console.WriteLine(trie.SearchPrefix(query));
		}
	}
}
