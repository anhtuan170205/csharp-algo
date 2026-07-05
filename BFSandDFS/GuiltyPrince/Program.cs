using System;
using System.Text;
using System.Collections.Generic;

public class Coord
{
	public int Row;
	public int Col; 

	public Coord(int row, int col)
	{
		Row = row;
		Col = col;
	}

	public override bool Equals(object obj)
	{
		Coord other = obj as Coord;

		if (other == null) return false;

		return Row == other.Row && Col == other.Col;
	}

	public override int GetHashCode()
	{
		return Row * 397 ^ Col;
	}
}

public class Program
{
	static readonly int[] dr = { -1, 1, 0, 0 };
	static readonly int[] dc = { 0, 0, -1, 1 };
	public static void Main()
	{
		StringBuilder sb = new StringBuilder();
		int testCases = int.Parse(Console.ReadLine());

		for (int test = 0; test < testCases; test++)
		{
			string[] dims = Console.ReadLine().Split();
			int cols = int.Parse(dims[0]), rows = int.Parse(dims[1]);

			char[][] map = new char[rows][];

			for (int i = 0; i < rows; i++)
			{
				map[i] = Console.ReadLine().ToCharArray();
			}

			List<Coord> visited = new List<Coord>();
			List<Coord> lands = new List<Coord>();
			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < cols; j++)
				{
					if (map[i][j] == '@')
					{
						Coord start = new Coord(i, j);
						FindLand(map, start, visited, lands);
					}
				}
			}
			
			sb.AppendLine($"Case {test + 1}: {lands.Count}");
		}

		Console.Write(sb.ToString());
	}

	public static void FindLand(char[][] map, Coord start, List<Coord> visited, List<Coord> lands)
	{
		visited.Add(start);
		lands.Add(start);
		
		for (int i = 0; i < 4; i++)
		{
			Coord next = new Coord(start.Row + dr[i], start.Col + dc[i]);

			if (!IsInsideMap(map, next)) continue;
			if (map[next.Row][next.Col] == '#') continue;
			if (visited.Contains(next)) continue;

			FindLand(map, next, visited, lands);
		}
	}

	public static bool IsBoundary(char[][] map, Coord coord)
	{
		return coord.Row == 0 || coord.Row == map.Length - 1 || coord.Col == 0 || coord.Col == map[0].Length - 1; 
	}

	public static bool IsInsideMap(char[][] map, Coord coord)
	{
		return coord.Row < map.Length && coord.Row >= 0 && coord.Col >= 0 && coord.Col < map[0].Length;
	}
}