using System;
using System.Collections.Generic;

public class Program
{
	public static void Main()
	{
		int n = int.Parse(Console.ReadLine());
		Dictionary<string, int> freq = new Dictionary<string, int>();

		for (int i = 0; i < n; i++)
		{
			string s = Console.ReadLine();

			if (!freq.ContainsKey(s))
			{
				freq[s] = 1;
			}
			else
			{
				freq[s]++;
			}
		}

		string highestFreq = "";
		int highestCount = -1;

		foreach (KeyValuePair<string, int> entry in freq)
		{
			if (entry.Value > highestCount)
			{
				highestCount = entry.Value;
				highestFreq = entry.Key;
			}
		}

		Console.WriteLine(highestFreq);
	}
}