using System;
using System.Linq;

public class Program
{
	public static void Main()
	{
		int n = int.Parse(Console.ReadLine()!);
		int[] l = Console.ReadLine()!.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
		int q = int.Parse(Console.ReadLine()!);
		int[] h = Console.ReadLine()!.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

		for (int i = 0; i < q; i++)
		{
			int t = h[i];
			int left = 0, right = n - 1, x = -1, y = -1;

			while (left <= right)
			{
				int mid = left + (right - left) / 2;
				if (l[mid] < t)
				{
					x = l[mid];
					left = mid + 1;
				}
				else
				{
					right = mid - 1;
				}
			}

			left = 0; right = n - 1;

			while (left <= right)
			{
				int mid = left + (right - left) / 2;
				if (l[mid] > t)
				{
					y = l[mid];
					right = mid - 1;
				}
				else
				{
					left = mid + 1;
				}
			}

			if (x != -1 && y != -1)
			{
				Console.WriteLine(x + " " + y);
			}
			else if (x == -1 && y == -1)
			{
				Console.WriteLine("X X");
			}
			else if (x == -1)
			{
				Console.WriteLine("X " + y);
			}
			else
			{
				Console.WriteLine(x + " X");
			}
			
		}
	}
}