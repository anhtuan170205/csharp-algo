using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

public class Program
{
	public static void Main()
	{
		StringBuilder sb = new StringBuilder();
		int t = int.Parse(Console.ReadLine());
		for (int i = 0; i < t; i++)
		{
			int[] l1 = Console.ReadLine().Split().Select(int.Parse).ToArray();
			int n = l1[0], x = l1[1];

			int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();

			HashSet<int> hs = new HashSet<int>(a);

			if (hs.Count == x)
			{
				sb.AppendLine("Good");
			}
			else if (hs.Count < x)
			{
				sb.AppendLine("Bad");
			}
			else
			{
				sb.AppendLine("Average");
			}
		}

		Console.Write(sb.ToString());
	}
}