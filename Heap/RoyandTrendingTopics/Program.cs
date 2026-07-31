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

public class Topic
{
	public long Id;
	public long NewScore;
	public long Change;

	public Topic(long id, long newScore, long change)
	{
		Id = id;
		NewScore = newScore;
		Change = change;
	}
}

public class Program
{
	public static void Main()
	{
		int n = int.Parse(Console.ReadLine());
		Heap<Topic> minHeap = new Heap<Topic>(CompareTopics);

		for (int t = 0; t < n; t++)
		{
			long[] input = Console.ReadLine().Split().Select(long.Parse).ToArray();
			long id = input[0], oldScore = input[1], p = input[2], l = input[3], c = input[4], s = input[5];

			long newScore = 50 * p + 5 * l + 10 * c + 20 * s;
			long change = newScore - oldScore;

			Topic topic = new Topic(id, newScore, change);
			minHeap.Push(topic);

			if (minHeap.Count > 5) minHeap.Pop();

		}

		List<Topic> result = new List<Topic>();

		while (minHeap.Count > 0)
		{
			result.Add(minHeap.Pop());
		}

		result.Reverse();

		for (int i = 0; i < result.Count; i++)
		{
			Console.WriteLine(result[i].Id.ToString() + " " + result[i].NewScore.ToString());
		}
	}

	public static int CompareTopics(Topic a, Topic b)
	{
		if (a.Change != b.Change) return a.Change.CompareTo(b.Change);
		return a.Id.CompareTo(b.Id);
	}
}