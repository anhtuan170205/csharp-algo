using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
	public static void Main()
	{
		while (true)
		{
			int n = int.Parse(Console.ReadLine());
			
			if (n == 0) break;
			
			int[] t = Console.ReadLine().Split().Select(int.Parse).ToArray();

			Stack<int> st = new Stack<int>();
			int need = 1;

			for (int i = 0; i < n; i++)
			{
				if (t[i] == need)
				{
					need++;
				}
				else
				{
					st.Push(t[i]);
				}

				while (st.Count > 0 && st.Peek() == need)
				{
					st.Pop();
					need++;
				}
			}

			if (need == n + 1)
			{
				Console.WriteLine("yes");
			}
			else
			{
				Console.WriteLine("no");
			}
		}
	}
}