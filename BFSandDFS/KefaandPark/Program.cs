using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
	static List<int>[] graph;
    static int[] cats;
    static int maxCats;
    static int answer;
	public static void Main()
	{
		int[] l = Console.ReadLine().Split().Select(int.Parse).ToArray();
		int n = l[0];
		maxCats = l[1];

		int[] cl = Console.ReadLine().Split().Select(int.Parse).ToArray();
		cats = new int[n + 1];

		for (int i = 1; i <= n; i++)
		{
			cats[i] = cl[i - 1];
		} 

		graph = new List<int>[n + 1];

		for (int i = 1; i <= n; i++)
		{
			graph[i] = new List<int>();
		}

		for (int i = 0; i < n - 1; i++)
		{
			int[] edge = Console.ReadLine().Split().Select(int.Parse).ToArray();
			int u = edge[0];
			int v = edge[1];

			graph[u].Add(v);
			graph[v].Add(u);
		}

		CountCats(1, 0, 0);

		Console.WriteLine(answer);
	}

	public static void CountCats(int node, int parent, int consecutiveCats)
	{
		if (cats[node] == 1) consecutiveCats++;
		else consecutiveCats = 0;

		if (consecutiveCats > maxCats) return;
		
		bool isLeaf = true;

		foreach (int next in graph[node])
		{
			if (next == parent) continue;
			isLeaf = false;
			CountCats(next, node, consecutiveCats);
		}

		if (isLeaf) answer++;
	}
}