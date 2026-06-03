using System;
using System.Linq;

public class Program
{
	public static void Main()
	{
		int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
		int n = input[0], k = input[1];
		int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();

		Array.Sort(a);

		double low = 0, high = a[n - 1];
		double ans = 0;

		for (int i = 0; i < 100; i++)
		{
			double mid = low + (high - low) / 2;
			
			if (TotalDonate(a, mid, k) >= TotalReceive(a, mid))
			{
				ans = mid;
				low = mid;
			}
			else
			{
				high = mid;
			}
		}

		Console.Write(ans.ToString("F9"));
	}

	public static double TotalDonate(int[] nums, double target, int percent)
	{
		double donors = 0;

		for (int i = 0; i < nums.Length; i++)
		{
			if (nums[i] > target)
			{
				donors += (nums[i] - target) * (100.0 - percent) / 100.0;
			}
		}

		return donors;
	}

	public static double TotalReceive(int[] nums, double target)
	{
		double receivers = 0;

		for (int i = 0; i < nums.Length; i++)
		{
			if (nums[i] < target)
			{
				receivers += target - nums[i];
			}
		}

		return receivers;
	}
}