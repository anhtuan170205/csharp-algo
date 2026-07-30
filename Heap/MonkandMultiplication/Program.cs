using System;
using System.Text;
using System.Collections.Generic;

public class MinHeap
{
	private readonly List<int> heap = new List<int>();
	public int Count => heap.Count;

	public void Push(int value)
	{
		heap.Add(value);
		int index = heap.Count - 1;

		while (index > 0)
		{
			int parent = (index - 1) / 2;

			if (heap[parent] <= heap[index]) break;

			int temp = heap[parent];
			heap[parent] = heap[index];
			heap[index] = temp;

			index = parent;
		}
	}

	public int Pop()
	{
		int minimum = heap[0];
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

			int temp = heap[index];
			heap[index] = heap[smallest];
			heap[smallest] = temp;

			index = smallest;
		}

		return minimum;
	}

	public int Peek()
	{
		return heap[0];
	}

	public long Product()
	{
		long product = 1;

		for (int i = 0; i < heap.Count; i++)
		{
			product *= (long)heap[i];
		}

		return product;
	}
}


public class Program
{
	public static void Main()
	{
		int n = int.Parse(Console.ReadLine());
		string[] a = Console.ReadLine().Split();
		StringBuilder sb = new StringBuilder();

		MinHeap heap = new MinHeap();

		for (int i = 0; i < n; i++)
		{
			int val = int.Parse(a[i]);
			heap.Push(val);

			if (heap.Count < 3)
			{
				sb.AppendLine("-1");
				continue;
			}
			else if (heap.Count == 3)
			{
				sb.AppendLine(heap.Product().ToString());
			}
			else
			{
				heap.Pop();
				sb.AppendLine(heap.Product().ToString());
			}
		}

		Console.WriteLine(sb.ToString());
	}
}