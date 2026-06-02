using System;
using System.Linq;
using System.Text;

public class Program
{
	public static void Main()
	{
		int t = int.Parse(Console.ReadLine()!);
		StringBuilder output = new StringBuilder();

		for (int i = 0; i < t; i++)
		{
			int[] l1 = Console.ReadLine()!.Split().Select(int.Parse).ToArray();
			int n = l1[0], m = l1[1];
			
			int[] a = Console.ReadLine()!.Split().Select(int.Parse).ToArray();
			int count = 0;
			
			Array.Sort(a);
			
			int left = 0, right = n - 1;
			
			while (left < right)
			{
				int currSum = a[left] + a[right];
				if (currSum == m)
				{
					count++;
					left++;
					right--;
				}
				else if (currSum < m)
				{
					left++;
				}
				else
				{
					right--;
				}
			}
			output.AppendLine(count.ToString());
		}
		Console.Write(output.ToString());
	}
}