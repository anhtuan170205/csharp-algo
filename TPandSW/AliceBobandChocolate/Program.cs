using System;
using System.Linq;

public class Program
{
	public static void Main()
	{
		int n = int.Parse(Console.ReadLine());
		int[] t = Console.ReadLine().Split().Select(int.Parse).ToArray();
		
		int leftsum = 0, left = 0;
		int rightsum = 0, right = n - 1;
		int lres = 0, rres = 0;
		
		while (left <= right)
		{
			if (leftsum <= rightsum)
			{
				leftsum += t[left++];
				lres++;
			}
			else
			{
				rightsum += t[right--];
				rres++;
			}
		}
		
		Console.WriteLine(lres + " " + rres);
	}
}