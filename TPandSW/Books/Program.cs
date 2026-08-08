using System;
using System.Linq;

public class Program
{
	public static void Main()
  {
  	int[] line1 = Console.ReadLine().Split().Select(int.Parse).ToArray();
    int n = line1[0];
    int t = line1[1];
    
    int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
    
    int left = 0, current_sum = 0;
    int max_length = Int32.MinValue;
    
    for (int right = 0; right < n; right++)
    {
    	current_sum += a[right];
      while (current_sum > t)
      {
        current_sum -= a[left];
        left++;
			}
      int current_length = right - left + 1;
      if (current_length > max_length)
      {
      	max_length = current_length;
      }
		}
    
    if (max_length == Int32.MinValue)
    {
    	Console.WriteLine(0);
    }
    else
    {
    	Console.WriteLine(max_length);
    }
  }
}