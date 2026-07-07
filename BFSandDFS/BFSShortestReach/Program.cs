using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

public class Program
{
	public static void Main()
	{
		StringBuilder sb = new StringBuilder();
		int qs = int.Parse(Console.ReadLine());

		for (int q = 0; q < qs; q++)
		{
			int[] l = Console.ReadLine().Split().Select(int.Parse).ToArray();
			int n = l[0], m = l[1];

			List<int>[] g = new List<int>[n + 1];

			for (int i = 1; i <= n; i++)
			{
				g[i] = new List<int>();
			}

			for (int i = 0; i < m; i++)
			{
				int[] e = Console.ReadLine().Split().Select(int.Parse).ToArray();
				int u = e[0];
				int v = e[1];

				g[u].Add(v);
				g[v].Add(u);
			}

			int start = int.Parse(Console.ReadLine());

			int[] distances = BFS(g, start);
			List<int> output = new List<int>();


            for (int node = 1; node <= n; node++)
            {
                if (node == start) continue;
                output.Add(distances[node]);
            }
			
			sb.AppendLine(string.Join(" ", output));

		}

		Console.Write(sb.ToString());
	}


	public static int[] BFS(List<int>[] g, int start)
	{
		int[] distances = new int[g.Length];
		Array.Fill(distances, -1);

		Queue<int> queue = new Queue<int>();

		distances[start] = 0;
		queue.Enqueue(start);

		while (queue.Count > 0)
		{
			int current = queue.Dequeue();

			foreach (var next in g[current])
			{
				if (distances[next] != -1) continue;
				distances[next] = distances[current] + 6;
				queue.Enqueue(next);
			}
		}

		return distances;
	}
}