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
}
public class Program
{
	public static void Main()
	{
		StringBuilder sb = new StringBuilder();
		string line;
		while ((line = Console.ReadLine()) != null)
		{
			int n = int.Parse(line);

			Stack<int> stack = new Stack<int>();
			Queue<int> queue = new Queue<int>();
			MaxHeap maxHeap = new MaxHeap();

			bool canBeStack = true, canBeQueue = true, canBeHeap = true;

			for (int i = 0; i < n; i++)
			{
				string[] cmd = Console.ReadLine().Split();
				int op = int.Parse(cmd[0]), val = int.Parse(cmd[1]);

				if (op == 1)
				{
					stack.Push(val);
					queue.Enqueue(val);
					maxHeap.Push(val);
				}
				else
				{
					int s = stack.Pop();
					if (s != val) canBeStack = false;

					int q = queue.Dequeue();
					if (q != val) canBeQueue = false;

					int h = maxHeap.Pop();
					if (h != val) canBeHeap = false;
				}
			}

			sb.AppendLine(GetResult(canBeStack, canBeQueue, canBeHeap));
		}

		Console.Write(sb.ToString());
	}

	public static string GetResult(bool canBeStack, bool canBeQueue, bool canBeHeap)
	{
		int count = 0;
		string result = "";

		if (canBeStack)
		{
			count++;
			result = "stack";
		}

		if (canBeQueue)
		{
			count++;
			result = "queue";
		}

		if (canBeHeap)
		{
			count++;
			result = "priority queue";
		}

		if (count == 0) return "impossible";
		if (count > 1) return "not sure";

		return result;
	}
}