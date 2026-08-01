using System;
using System.Text;
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

public class CandidateRoad
{
	public int U;
	public int V;
	public int Cost;

	public CandidateRoad(int u, int v, int cost)
	{
		U = u;
		V = v;
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
		int datasets = int.Parse(Console.ReadLine());

		for (int dataset = 0; dataset < datasets; dataset++)
		{
			int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
			int n = input[0], m = input[1], k = input[2], s = input[3] - 1, t = input[4] - 1;

			List<Edge>[] graph = new List<Edge>[n];
			List<Edge>[] reverseGraph = new List<Edge>[n];

			for (int i = 0; i < n; i++)
			{
				graph[i] = new List<Edge>();
				reverseGraph[i] = new List<Edge>();
			}

			for (int i = 0; i < m; i++)
			{
				int[] line = Console.ReadLine().Split().Select(int.Parse).ToArray();
				int d = line[0] - 1, c = line[1] - 1, l = line[2];

				graph[d].Add(new Edge(c, l));
				reverseGraph[c].Add(new Edge(d, l));
			}

			List<CandidateRoad> candidates = new List<CandidateRoad>();

			for (int i = 0; i < k; i++)
			{
				int[] line = Console.ReadLine().Split().Select(int.Parse).ToArray();
				int u = line[0] - 1, v = line[1] - 1, cost = line[2];

				candidates.Add(new CandidateRoad(u, v, cost));
			}

			int[] distFromS = Dijkstra(graph, s);
			int[] distToT = Dijkstra(reverseGraph, t);

			int answer = distFromS[t];

			for (int i = 0; i < candidates.Count; i++)
			{
				CandidateRoad road = candidates[i];

				if (distFromS[road.U] != int.MaxValue && distToT[road.V] != int.MaxValue)
				{
					int distance = distFromS[road.U] + road.Cost + distToT[road.V];
					answer = Math.Min(answer, distance);
				}

				if (distFromS[road.V] != int.MaxValue && distToT[road.U] != int.MaxValue)
				{
					int distance = distFromS[road.V] + road.Cost + distToT[road.U];
					answer = Math.Min(answer, distance);
				}
			}

			if (answer == int.MaxValue) Console.WriteLine(-1);
			else Console.WriteLine(answer);
		}
	}
}