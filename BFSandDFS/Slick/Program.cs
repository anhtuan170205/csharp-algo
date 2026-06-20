using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

public class Program
{
	static int n, m;
	static int[,] grid;
	static readonly int[] dr = { -1, 1, 0, 0 };
	static readonly int[] dc = { 0, 0, -1, 1 };

	static int DFS(int r, int c)
	{
		if (r < 0 || r >= n || c < 0 || c >= m) return 0;
		if (grid[r, c] == 0) return 0;

		grid[r, c] = 0;
		int size = 1;

		for (int i = 0; i < 4; i++)
		{
			size += DFS(r + dr[i], c + dc[i]);
		}

		return size;
	}
	public static void Main()
	{
		StringBuilder sb = new StringBuilder();

		while (true)
		{
			int[] dimensions = Console.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
			n = dimensions[0]; m = dimensions[1];

			if (n == 0 && m == 0) break;

			grid = new int[n, m];

			for (int i = 0; i < n; i++)
			{
				int[] values = Console.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

				for (int j = 0; j < m; j++)
				{
					grid[i, j] = values[j]; 
				}
			}

			int totalSlicks = 0;
			SortedDictionary<int, int> frequency = new SortedDictionary<int, int>();

			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < m; j++)
				{
					if (grid[i, j] == 1)
					{
						int size = DFS(i, j);
						totalSlicks++;

						if (!frequency.ContainsKey(size))
						{
							frequency[size] = 0;
						}

						frequency[size]++;
					}
				}
			}

			sb.AppendLine(totalSlicks.ToString());

			foreach (KeyValuePair<int, int> entry in frequency)
			{
				sb.AppendLine($"{entry.Key} {entry.Value}");
			}
		}

		Console.Write(sb.ToString());
	}
}

