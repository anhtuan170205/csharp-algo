using System;
using System.Linq;
using System.Collections.Generic;

public class DSU
{
	private readonly int[] parent;
	private readonly int[] size;

	public DSU(int n)
	{
		parent = new int[n];
		size = new int[n];

		for (int i = 0; i < n; i++)
		{
			parent[i] = i;
			size[i] = 1;
		}
	}

	public int Find(int x)
	{
		if (parent[x] != x) parent[x] = Find(parent[x]);
		return parent[x];
	}

	public bool Union(int a, int b)
	{
		int rootA = Find(a);
		int rootB = Find(b);

		if (rootA == rootB) return false;

		if (size[rootA] < size[rootB])
		{
			int temp = rootA;
			rootA = rootB;
			rootB = temp;
		}

		parent[rootB] = rootA;
		size[rootA] += size[rootB];

		return true;
	}

	public int GetSize(int x)
	{
		return size[Find(x)];
	}
}

public class Point
{
	public double X;
	public double Y;

	public Point(double x, double y)
	{
		X = x;
		Y = y;
	}
}

public class Edge
{
	public int From;
	public int To;
	public double Weight;

	public Edge(int from, int to, double weight)
	{
		From = from;
		To = to;
		Weight = weight;	
	}
}

public class Program
{
	public static void Main()
	{
		int testCases = int.Parse(ReadNonEmptyLine());

		for (int test = 0; test < testCases; test++)
		{
			int n = int.Parse(ReadNonEmptyLine());
			Point[] points = new Point[n];

			for (int i = 0; i < n; i++)
			{
				string[] line = ReadNonEmptyLine().Split();
				double x = double.Parse(line[0]), y = double.Parse(line[1]);

				points[i] = new Point(x, y);
			}

			List<Edge> edges = new List<Edge>();

			for (int i = 0; i < n; i++)
			{
				for (int j = i + 1; j < n; j++)
				{
					double dx = points[i].X - points[j].X;
					double dy = points[i].Y - points[j].Y;
					double distance = Math.Sqrt(dx * dx + dy * dy);

					edges.Add(new Edge(i, j, distance));
				}
			}

			edges.Sort((a, b) => a.Weight.CompareTo(b.Weight));

			DSU dsu = new DSU(n);
			double total = 0;
			int usedEdges = 0;

			foreach (Edge edge in edges)
			{
				if (dsu.Union(edge.From, edge.To))
				{
					total += edge.Weight;
					usedEdges++;

					if (usedEdges == n - 1) break;
				}
			}

			if (test > 0) Console.WriteLine();
			Console.WriteLine(total.ToString("F2"));
		}
	}

	public static string ReadNonEmptyLine()
	{
		string line;

		do
		{
			line = Console.ReadLine();
		}
		while (line != null && string.IsNullOrWhiteSpace(line));

		return line;
	}
}