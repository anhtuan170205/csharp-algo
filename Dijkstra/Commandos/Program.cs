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
	public static int[] Dijkstra(List<Edge>[] graph, int source)
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

		return dist;
	}

	public static void Main()
	{
		int testCases = int.Parse(Console.ReadLine());
		for (int testCase = 0; testCase < testCases; testCase++)
		{
			int buildings = int.Parse(Console.ReadLine());
			int roads = int.Parse(Console.ReadLine());

			List<Edge>[] graph = new List<Edge>[buildings];
			
			for (int i = 0; i < buildings; i++)
			{
				graph[i] = new List<Edge>();
			}

			for (int i = 0; i < roads; i++)
			{
				int[] input = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
				int u = input[0], v = input[1];

				graph[u].Add(new Edge(v, 1));
				graph[v].Add(new Edge(u, 1));
			}

			int[] mission = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
			int s = mission[0], d = mission[1];

			int[] distS = Dijkstra(graph, s);
			int[] distD = Dijkstra(graph, d);

			int answer = int.MinValue;

			for (int i = 0; i < buildings; i++)
			{
				answer = Math.Max(answer, distS[i] + distD[i]);
			}

			Console.WriteLine($"Case {testCase + 1}: {answer}"); 
		}
	}
}