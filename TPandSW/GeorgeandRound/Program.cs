using System;
using System.Linq;

public class Program
{
	public static void Main()
  {
  	int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
    int n = input[0], m = input[1];
    
    int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
    int[] b = Console.ReadLine().Split().Select(int.Parse).ToArray();
    
    int aidx = 0, bidx = 0;
    
    while (aidx < n && bidx < m)
    {
    	if (a[aidx] <= b[bidx])
      {
      	aidx++;
      }
			bidx++;
		}
        
    int count = n - aidx;
    
    Console.WriteLine(count);
	}
}