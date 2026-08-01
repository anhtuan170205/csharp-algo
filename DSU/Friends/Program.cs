using System;

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

public class Progam
{
	public static void Main()
	{
		int testCases = int.Parse(Console.ReadLine());

		while (testCases-- > 0)
		{
			string[] l = Console.ReadLine().Split();
			int n = int.Parse(l[0]);
			int m = int.Parse(l[1]);

			DSU dsu = new DSU(n);

			for (int i = 0; i < m; i++)
			{
				string[] pair = Console.ReadLine().Split();
				int a = int.Parse(pair[0]) - 1;
				int b = int.Parse(pair[1]) - 1;

				dsu.Union(a, b);
			}

			int largestGroup = 1;

			for (int i = 0; i < n; i++)
			{
				largestGroup = Math.Max(largestGroup, dsu.GetSize(i));
			}

			Console.WriteLine(largestGroup);
		}
	}
}