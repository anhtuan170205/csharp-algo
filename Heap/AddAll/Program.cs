using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

public class MinHeap
{
	private readonly List<long> heap = new List<long>();

	public int Count()
	{
		return heap.Count;
	}

	public void Push(long value)
	{
		heap.Add(value);
		int index = heap.Count - 1;

		while (index > 0)
		{
			int parent = (index - 1) / 2;

			if (heap[parent] <= heap[index]) break;

			long temp = heap[parent];
			heap[parent] = heap[index];
			heap[index] = temp;

			index = parent;
		}
	}

	public long Pop()
	{
		long minimum = heap[0];
		int lastIndex = heap.Count - 1;

		heap[0] = heap[lastIndex];
		heap.RemoveAt(lastIndex);

		int index = 0;

		while (index < heap.Count)
		{
			int left = index * 2 + 1;
			int right = index * 2 + 2;
			int smallest = index;

			if (left < heap.Count && heap[left] < heap[smallest]) smallest = left;
			if (right < heap.Count && heap[right] < heap[smallest]) smallest = right;

			if (smallest == index) break;

			long temp = heap[index];
			heap[index] = heap[smallest];
			heap[smallest] = temp;

			index = smallest;
		}

		return minimum;
	}
}

public class Program
{
	public static void Main()
	{
		StringBuilder sb = new StringBuilder();

		while (true)
		{
			int n = int.Parse(Console.ReadLine());

			if (n == 0) break;

			int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
			
			MinHeap heap = new MinHeap();
			for (int i = 0; i < nums.Length; i++)
			{
				heap.Push(nums[i]);
			}

			long totalCost = 0;

			while (heap.Count() > 1)
			{
				long firstSmallest = heap.Pop();
				long secondSmallest = heap.Pop();

				long sum = firstSmallest + secondSmallest;
				totalCost += sum;

				heap.Push(sum);
			}

			sb.AppendLine(totalCost.ToString());
		}

		Console.Write(sb.ToString());
	}
}