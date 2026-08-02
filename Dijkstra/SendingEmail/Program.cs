using System;
using System.Linq;
using System.Collections.Generic;

public class Edge
{
	public int To;
	public int Cost;
	
	public Edge(int to, int cost)
	{
		To = to;
		Cost = cost;
	}
}

public class HeapNode
{
	public int City;
	public int Distance;

	public HeapNode(int city, int distance)
	{
		City = city;
		Distance = distance;
	}
}

public class MinHeap
{
	private readonly List<HeapNode> heap = new List<HeapNode>();

	public int Count
	{
		get { return heap.Count; }
	}

	public void Push(HeapNode node)
	{
		heap.Add(node);
		int index = heap.Count - 1;

		while (index > 0)
		{
			int parent = (index - 1) / 2;

			if (heap[parent].Distance <= heap[index].Distance) break;

			Swap(parent, index);
			index = parent;
		}
	}

	public HeapNode Pop()
	{
		HeapNode result = heap[0];
		int lastIndex = heap.Count - 1;

		heap[0] = heap[lastIndex];
		heap.RemoveAt(lastIndex);

		int index = 0;

		while (index < heap.Count)
		{
			int left = index * 2 + 1;
			int right = index * 2 + 2;
			int smallest = index;

			if (left < heap.Count && heap[left].Distance < heap[smallest].Distance) smallest = left;
			if (right < heap.Count && heap[right].Distance < heap[smallest].Distance) smallest = right;

			if (smallest == index) break;

			Swap(index, smallest);
			index = smallest;
		}

		return result;
	}

	private void Swap(int a, int b)
	{
		HeapNode temp = heap[a];
		heap[a] = heap[b];
		heap[b] = temp;
	}
}

public class Program
{
	public static int Dijkstra(List<Edge>[] graph, int source, int destination)
	{
		int[] dist = new int[graph.Length];

		for (int i = 0; i < graph.Length; i++) dist[i] = int.MaxValue;

		MinHeap heap = new MinHeap();
		dist[source] = 0;

		heap.Push(new HeapNode(source, 0));

		while (heap.Count > 0)
		{
			HeapNode node = heap.Pop();
			int current = node.City;
			int currentDistance = node.Distance;

			if (currentDistance != dist[current]) continue;
			if (current == destination) return currentDistance;

			for (int i = 0; i < graph[current].Count; i++)
			{
				Edge edge = graph[current][i];
				int newDistance = currentDistance + edge.Cost;

				if (newDistance < dist[edge.To])
				{
					dist[edge.To] = newDistance;
					heap.Push(new HeapNode(edge.To, newDistance));
				}
			}
		}	

		return dist[destination];
	}

	public static void Main()
	{
		int testCases = int.Parse(Console.ReadLine());
		for (int test = 1; test <= testCases; test++)
		{
			int[] line = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
			int n = line[0], m = line[1], s = line[2], t = line[3];

			List<Edge>[] graph = new List<Edge>[n];

			for (int i = 0; i < n; i++) graph[i] = new List<Edge>();

			for (int i = 0; i < m; i++)
			{
				int[] input = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
				int u = input[0], v = input[1], w = input[2];

				graph[u].Add(new Edge(v, w));
				graph[v].Add(new Edge(u, w));
			}

			int latency = Dijkstra(graph, s, t);

			if (latency != int.MaxValue) Console.WriteLine($"Case #{test}: {latency}");
			else Console.WriteLine($"Case #{test}: unreachable");
		}
	}
}