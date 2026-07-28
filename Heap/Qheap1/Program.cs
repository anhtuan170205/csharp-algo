using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

public class Program
{
	static List<int> heap = new List<int>();
	static Dictionary<int, int> indexOf = new Dictionary<int, int>();
	
	public static void Main()
	{
		int q = int.Parse(Console.ReadLine());
		StringBuilder sb = new StringBuilder();

		while (q-- > 0)
		{
			string[] cmd = Console.ReadLine().Split();
			int op = int.Parse(cmd[0]);

			if (op == 1) Insert(int.Parse(cmd[1]));
			else if (op == 2) Delete(int.Parse(cmd[1]));
			else sb.AppendLine(heap[0].ToString());
		}

		Console.Write(sb.ToString());
	}

	public static void Insert(int value)
	{
		heap.Add(value);
		int index = heap.Count - 1;
		indexOf[value] = index;
		SiftUp(index);
	}

	public static void Delete(int value)
	{
		int index = indexOf[value];
		int lastIndex = heap.Count - 1;

		indexOf.Remove(value);

		if (index == lastIndex)
		{
			heap.RemoveAt(lastIndex);
			return;
		}

		heap[index] = heap[lastIndex];
		indexOf[heap[index]] = index;
		heap.RemoveAt(lastIndex);

		if (index > 0 && heap[index] < heap[(index - 1) / 2]) SiftUp(index);
		else MinHeapify(index);
	}

	public static void SiftUp(int index)
	{
		while (index > 0)
		{
			int parent = (index - 1) / 2;

			if (heap[parent] <= heap[index]) break;

			Swap(parent, index);
			index = parent;
		}
	}

	public static void MinHeapify(int index)
	{
		while (true)
		{
			int left = index * 2 + 1;
			int right = index * 2 + 2;
			int smallest = index;

			if (left < heap.Count && heap[left] < heap[smallest]) smallest = left;
			if (right < heap.Count && heap[right] < heap[smallest]) smallest = right;

			if (smallest == index) break;

			Swap(index, smallest);
			index = smallest;
		}
	}

	public static void Swap(int a, int b)
	{
		int temp = heap[a];
		heap[a] = heap[b];
		heap[b] = temp;

		indexOf[heap[a]] = a;
		indexOf[heap[b]] = b;
	}
}