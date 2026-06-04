using System;
using System.Linq;
using System.Text;

public class Program
{
	public static void Main()
	{
		int t = int.Parse(Console.ReadLine());
		StringBuilder sb = new StringBuilder();

		for (int c = 0; c < t; c++)
		{
			int n = int.Parse(Console.ReadLine());
			int[] r = Console.ReadLine().Split().Select(int.Parse).ToArray();
			int[] g = new int[n];

			g[0] = r[0];
			for (int i = 1; i < n; i++)
			{
				g[i] = r[i] - r[i - 1];
			}
			
			int low = 1, high = g.Max() + 1, ans = high;
			
			while (low <= high)
			{
				int mid = low + (high - low) / 2;
				if (IsValid(g, mid))
				{
					ans = mid;
					high = mid - 1;
				}
				else
				{
					low = mid + 1;
				}
			}
			sb.AppendLine($"Case {c + 1}: " + ans);
		}
		Console.Write(sb.ToString());
	}
	
	public static bool IsValid(int[] g, int t)
	{
		int curr = t;
		for (int i = 0; i < g.Length; i++)
		{
			if (curr < g[i]) 
			{
				return false;
			}
			if (curr == g[i]) 
			{
				curr--;
			}
		}
		return true;
	}
}