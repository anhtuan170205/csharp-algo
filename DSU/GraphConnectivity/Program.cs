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
		string line;

		for (int test = 0; test < testCases; test++)
		{
			do
			{
				line = Console.ReadLine();
			} while (line != null && string.IsNullOrWhiteSpace(line));

			char largestNode = line[0];
			int n = largestNode - 'A' + 1;
			DSU dsu = new DSU(n);

			while ((line = Console.ReadLine()) != null && !string.IsNullOrWhiteSpace(line))
			{
				int a = line[0] - 'A';
				int b = line[1] - 'A';
				dsu.Union(a, b); 
			}

			int components = 0;
			for (int i = 0; i < n; i++)
			{
				if (dsu.Find(i) == i) components++;
			}

			if (test > 0) Console.WriteLine();
			Console.WriteLine(components);
		}
	}
}