using System;
using System.Linq;

public class Program
{
	public static void Main()
	{
		int n = int.Parse(Console.ReadLine());
		
		int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
		
		int sSum = 0, dSum = 0, turn = 0;
		int left = 0, right = n - 1;
		
		while (left <= right)
		{
			int answer;
			if (a[left] >= a[right])
			{
				answer = a[left];
				left++;
			}
			else
			{
				answer = a[right];
				right--;
			}
		
			if (turn % 2 == 0)
			{
				sSum += answer;
			}
			else
			{
				dSum += answer;
			}
				turn++;
			}
			
		Console.WriteLine(sSum + " " + dSum);
	}
}