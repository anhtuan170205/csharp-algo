using System;
using System.Linq;

public class Program
{
	public static void Main()
	{
		int caseNumber = 1;
		while (true)
		{
			int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
			int n = input[0], q = input[1];
			
			if (n == 0 && q == 0) break;
			
			Console.WriteLine($"CASE# {caseNumber}:");
			caseNumber++;
		
			int[] arr = new int[n];
			
			for (int i = 0; i < n; i++)
			{
				arr[i] = int.Parse(Console.ReadLine());
			}
			
			Array.Sort(arr);
		
			for (int i = 0; i < q; i++)
			{
				int t = int.Parse(Console.ReadLine());
				int ans = -1;
				
				ans = BinarySearchFirst(arr, t);
				if (ans != -1) 
				{
					Console.WriteLine($"{t} found at {ans + 1}");
				}
				else 
				{
					Console.WriteLine($"{t} not found");
				}
			}
		}
	}
	
	public static int BinarySearchFirst(int[] arr, int target)
	{
		int left = 0, right = arr.Length - 1, res = -1;
		
		while (left <= right)
		{
			int mid = left + (right - left) / 2;
			if (arr[mid] == target)
			{
				res = mid;
				right = mid - 1;
			}
			else if (arr[mid] < target)
			{
				left = mid + 1;
			}
			else
			{
				right = mid - 1;
			}
		}
		
		return res;
	}
}