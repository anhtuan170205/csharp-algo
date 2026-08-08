using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
	public static void Main()
	{
		int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
		int n = input[0], k = input[1];
		
		int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
		
		Dictionary<int, int> freq = new Dictionary<int, int>();
		
		int left = 0, distinct = 0;
		
		int bestl = -1, bestr = -1;
		int bestlen = int.MaxValue;
		
		for (int right = 0; right < n; right++)
		{
			if (!freq.ContainsKey(a[right]))
			{
				freq[a[right]] = 0;
			}
			
			if (freq[a[right]] == 0)
			{
				distinct++;
			}
			
			freq[a[right]]++;
			
			while (distinct > k)
			{
				freq[a[left]]--;
				if (freq[a[left]] == 0)
				{
					distinct--;
				}
				left++;
			}
			
			while (distinct == k && freq[a[left]] > 1)
			{
				freq[a[left]]--;
				left++;
			}
			
			if (distinct == k)
			{
				int currentlen = right - left + 1;
				if (currentlen < bestlen)
				{
					bestlen = currentlen;
					bestl = left + 1;
					bestr = right + 1;
				}
			}
		}
		
		Console.WriteLine(bestl + " " + bestr);
	}
}