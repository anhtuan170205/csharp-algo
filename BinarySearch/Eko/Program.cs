using System;
using System.Linq;

public class Program
{
	public static void Main()
	{
		long[] input = Console.ReadLine()!.Split().Select(long.Parse).ToArray();
		long n = input[0], m = input[1];
		long[] t = Console.ReadLine()!.Split().Select(long.Parse).ToArray();
		

		Array.Sort(t);
		long low = 0, high = t[n - 1], ans = 0;
		
		while (low <= high)
		{
			long mid = low + (high - low) / 2;
			long wood = GetWood(t, mid);

			if (wood >= m)
			{
				ans = mid;
				low = mid + 1;
			}
			else
			{
				high = mid - 1;
			}

		}
		Console.Write(ans);
	}

	public static long GetWood(long[] nums, long target)
	{
		long wood = 0;
		for (int i = 0; i < nums.Length; i++)
		{
			wood += Math.Max(nums[i] - target, 0);
		}
		return wood;
	}
}