using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

public class Program
{
	public static void Main()
	{
		StringBuilder sb = new StringBuilder();
		while (true)
		{
			int n = int.Parse(Console.ReadLine());
			if (n == 0) break;

			Queue<int> queue = new Queue<int>();
			int[] discard = new int[n - 1];
			int index = 0;

			for (int i = 1; i <= n; i++)
			{
				queue.Enqueue(i);
			}

			while (index < n - 1)
			{
				int a = queue.Dequeue();
				discard[index++] = a;

				int b = queue.Dequeue();
				queue.Enqueue(b);
			}

			sb.Append("Discarded cards:");
			for (int i = 0; i < discard.Length; i++)
			{
				if (i == 0)
				{
					sb.Append(" ");
				}
				else
				{
					sb.Append(", ");
				}
				sb.Append(discard[i]);
			}
			sb.AppendLine();

			sb.Append("Remaining card: ");
			sb.AppendLine(queue.Peek().ToString());
			
		}
		Console.Write(sb.ToString());
	}
}