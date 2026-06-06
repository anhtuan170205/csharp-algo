using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

public class Program
{
	public static void Main()
	{
		StringBuilder sb = new StringBuilder();
		int c = int.Parse(Console.ReadLine());
		for (int i = 0; i < c; i++)
		{
			int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
			int n = input[0], t = input[1], m = input[2];
			Queue<(int, int)> left = new Queue<(int, int)>();
			Queue<(int, int)> right = new Queue<(int, int)>();

			for (int j = 0; j < m; j++)
			{
				string[] l = Console.ReadLine().Split();
				int v = int.Parse(l[0]);
				string s = l[1];
				if (s == "left")
				{
					left.Enqueue((v, j));
				}
				else
				{
					right.Enqueue((v, j));
				}
			}

			Queue<(int, int)> currSide = new Queue<(int, int)>(n);
			Queue<(int, int)> otherSide = new Queue<(int, int)>(n);
			int[] ans = new int[m];
			int time = 0;
			bool isLeft = true;

			while (left.Count > 0 || right.Count > 0)
			{
				currSide = isLeft ? left : right;
				otherSide = isLeft ? right : left;

				int loaded = 0;

				while (loaded < n && currSide.Count > 0 && currSide.Peek().Item1 <= time)
				{
					var car = currSide.Dequeue();
					ans[car.Item2] = time + t;
					loaded++;
				}

				if (loaded > 0)
				{
					isLeft = !isLeft;
					time += t;
				}
				else
				{
					if (otherSide.Count > 0 && otherSide.Peek().Item1 <= time)
					{
						isLeft = !isLeft;
						time += t;
					}
					else
					{
						int nextTime = int.MaxValue;
						
						if (left.Count > 0)
						{
							nextTime = Math.Min(nextTime, left.Peek().Item1);
						}

						if (right.Count > 0)
						{
							nextTime = Math.Min(nextTime, right.Peek().Item1);
						}

						time = Math.Max(time, nextTime);
					}
				}
			}

			for (int j = 0; j < m; j++)
			{
				sb.AppendLine(ans[j].ToString());
			}
			if (i != c - 1)
			{
				sb.AppendLine();
			}
		}
		Console.Write(sb.ToString());
	}
}