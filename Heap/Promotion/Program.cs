using System;
using System.Linq;
using System.Collections.Generic;

public class Heap<T>
{
    private readonly List<T> heap = new List<T>();
    private readonly Comparison<T> comparison;

    public int Count => heap.Count;

    public Heap(Comparison<T> comparison)
    {
        this.comparison = comparison;
    }

    public void Push(T value)
    {
        heap.Add(value);
        int index = heap.Count - 1;

        while (index > 0)
        {
            int parent = (index - 1) / 2;

            if (comparison(heap[index], heap[parent]) >= 0) break;

            Swap(index, parent);
            index = parent;
        }
    }

    public T Peek()
    {
        return heap[0];
    }

    public T Pop()
    {
        T root = heap[0];
        int lastIndex = heap.Count - 1;

        heap[0] = heap[lastIndex];
        heap.RemoveAt(lastIndex);

        int index = 0;

        while (true)
        {
            int left = index * 2 + 1;
            int right = index * 2 + 2;
            int best = index;

            if (left < heap.Count && comparison(heap[left], heap[best]) < 0) best = left;
            if (right < heap.Count && comparison(heap[right], heap[best]) < 0) best = right;

            if (best == index) break;

            Swap(index, best);
            index = best;
        }

        return root;
    }

    private void Swap(int i, int j)
    {
        T temp = heap[i];
        heap[i] = heap[j];
        heap[j] = temp;
    }
}

public class Receipt
{
	public int Amount;
	public int Id;

	public Receipt(int amount, int id)
	{
		Amount = amount;
		Id = id;
	}
}

public class Program
{
	public static void Main()
	{
		int n = int.Parse(Console.ReadLine());

		Heap<Receipt> minHeap = new Heap<Receipt>((a, b) => a.Amount.CompareTo(b.Amount));
		Heap<Receipt> maxHeap = new Heap<Receipt>((a, b) => b.Amount.CompareTo(a.Amount));
		bool[] removed = new bool[1000000];

		long totalPrize = 0;
		int nextId = 0;

		for (int day = 0; day < n; day++)
		{
			int[] values = Console.ReadLine().Split().Select(int.Parse).ToArray();
			int k = values[0];
			for (int i = 1; i <= k; i++)
			{
				Receipt receipt = new Receipt(values[i], nextId++);
				minHeap.Push(receipt);
				maxHeap.Push(receipt);
			}

			CleanHeap(maxHeap, removed);

			Receipt largest = maxHeap.Pop();
			removed[largest.Id] = true;

			CleanHeap(minHeap, removed);

			Receipt smallest = minHeap.Pop();
			removed[smallest.Id] = true;

			long prize = (long)largest.Amount - smallest.Amount;
			totalPrize += prize;
		}

		Console.Write(totalPrize.ToString());
	}

	public static void CleanHeap(Heap<Receipt> heap, bool[] removed)
	{
		while (heap.Count > 0 && removed[heap.Peek().Id] == true)
		{
			heap.Pop();
		} 
	}
}