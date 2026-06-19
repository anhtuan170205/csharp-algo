using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
	public static void Main()
	{
		int n = int.Parse(Console.ReadLine());
		List<int>[] adj = new List<int>[n + 1];

		for (int i = 1; i <= n; i++)
		{
			adj[i] = new List<int>();
		}

		for (int i = 0; i < n - 1; i++)
		{
			int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
			int u = input[0];
			int v = input[1];

			adj[u].Add(v);
			adj[v].Add(u);
		}

		int[] distance = new int[n + 1];
		Array.Fill(distance, -1);

		Queue<int> queue = new Queue<int>();
		queue.Enqueue(1);
		distance[1] = 0;

		while (queue.Count > 0)
		{
			int u = queue.Dequeue();

			foreach (int v in adj[u])
			{
				if (distance[v] == -1)
				{
					distance[v] = distance[u] + 1;
					queue.Enqueue(v);
				}
			}
		}
		int q = int.Parse(Console.ReadLine());

		int bestCountry = -1;
		int bestDistance = int.MaxValue;

		for (int i = 0; i < q; i++)
		{
			int x = int.Parse(Console.ReadLine());

			if (distance[x] < bestDistance)
			{
				bestDistance = distance[x];
				bestCountry = x;
			}
			else if (distance[x] == bestDistance && x < bestCountry)
			{
				bestCountry = x;
			}
		}

		Console.WriteLine(bestCountry);
	}
}