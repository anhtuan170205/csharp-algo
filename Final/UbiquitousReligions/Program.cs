using System;
using System.Linq;

public class DSU
{
	private readonly int[] parent;
	private readonly int[] size;

	public DSU(int n)
	{
		parent = new int[n + 1];
		size = new int[n + 1];

		for (int i = 1; i <= n; i++)
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


public class Program
{
	public static void Main()
	{
		int test = 1;
		while (true)
		{
			string[] line = Console.ReadLine().Split();
			int n = int.Parse(line[0]), m = int.Parse(line[1]);

			if (n == 0 && m == 0) break;

			DSU dsu = new DSU(n);

			for (int i = 0; i < m; i++)
			{
				string[] student = Console.ReadLine().Split();
				int a = int.Parse(student[0]), b = int.Parse(student[1]);

				dsu.Union(a, b);
			}

			int religious = 0;

			for (int i = 1; i <= n; i++)
			{
				if (dsu.Find(i) == i) religious++;
			}

			Console.WriteLine("Case " + test + ": " + religious);
			test++;
		}
	}
}