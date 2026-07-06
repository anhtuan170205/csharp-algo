using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

public class Program
{
	public static void Main()
	{
		StringBuilder sb = new StringBuilder();
		int tcs = int.Parse(Console.ReadLine());

		for (int t = 0; t < tcs; t++)
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
				int u = e[0], v = e[1];
				
				g[u].Add(v);
			}

			int[] state = new int [n + 1];

			bool cycleFound = false;

			for (int i = 1; i <= n; i++)
			{
				if (state[i] == 0)
				{
					if (HasCyle(i, g, state))
					{
						cycleFound = true;
						break;
					}
				}
			}

			sb.AppendLine(cycleFound ? "YES" : "NO");
		}

		Console.Write(sb.ToString());
	}

	public static bool HasCyle(int node, List<int>[] g, int[] state)
	{
		state[node] = 1;

		foreach (var next in g[node])
		{
			if (state[next] == 1)
			{
				return true;
			}

			if (state[next] == 0)
			{
				if (HasCyle(next, g, state)) return true;
			}
		}

		state[node] = 2;
		return false;
	}
}