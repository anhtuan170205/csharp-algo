using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

public class Program
{
	public static void Main()
	{
		int caseNumber = 1;
		StringBuilder sb = new StringBuilder();
		while (true)
		{
			int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
			int p = input[0], c = input[1];

			if (p == 0 && c == 0) break;

			sb.AppendLine($"Case {caseNumber}:");
			caseNumber++;

			List<int> queue = new List<int>();

			int limit = Math.Min(p, c);

			for (int i = 1; i <= limit; i++)
			{
				queue.Add(i);
			}

			for (int i = 0; i < c; i++)
			{
				string[] line = Console.ReadLine().Split();
				if (line.Length == 1)
				{
					int person = queue[0];
					queue.RemoveAt(0);

					sb.AppendLine(person.ToString());
					queue.Add(person);
				}
				else
				{
					int x = int.Parse(line[1]);
					queue.Remove(x);
					queue.Insert(0, x);
					sb.AppendLine(x.ToString());
				}
			}
		}
		Console.Write(sb.ToString());
	}
}