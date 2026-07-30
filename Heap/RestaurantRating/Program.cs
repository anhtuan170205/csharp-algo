using System;
using System.Text;
using System.Collections.Generic;

public class MaxHeap
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

			if (heap[parent] > heap[index]) break;

			int temp = heap[parent];
			heap[parent] = heap[index];
			heap[index] = temp;

			index = parent;
		}
	}

	public int Pop()
	{
		int maximum = heap[0];
		int lastIndex = heap.Count - 1;

		heap[0] = heap[lastIndex];
		heap.RemoveAt(lastIndex);

		int index = 0;

		while (index < heap.Count)
		{
			int left = index * 2 + 1;
			int right = index * 2 + 2;
			int largest = index;

			if (left < heap.Count && heap[left] > heap[largest]) largest = left;
			if (right < heap.Count && heap[right] > heap[largest]) largest = right;

			if (largest == index) break;

			int temp = heap[index];
			heap[index] = heap[largest];
			heap[largest] = temp;

			index = largest;
		}

		return maximum;
	}

	public int Peek()
	{
		return heap[0];
	}
}

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
}
public class Program
{
	public static void Main()
	{
		int n = int.Parse(Console.ReadLine());
		MaxHeap low = new MaxHeap();
		MinHeap high = new MinHeap();
		StringBuilder sb = new StringBuilder();

		int totalReviews = 0;

		for (int r = 0; r < n; r++)
		{
			string[] cmd = Console.ReadLine().Split();
			if (cmd.Length == 2)
			{
				totalReviews++;
				
				int val = int.Parse(cmd[1]);
				low.Push(val);
				high.Push(low.Pop());

				int requiredHighSize = totalReviews / 3;

				if (high.Count > requiredHighSize) low.Push(high.Pop());
			}
			else
			{
				if (high.Count == 0) sb.AppendLine("No reviews yet");
				else sb.AppendLine(high.Peek().ToString());
			}
		}

		Console.Write(sb.ToString());
	}
}