using System;
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
		string[] dim = Console.ReadLine().Split();
		int n = int.Parse(dim[0]), m = int.Parse(dim[1]), k = int.Parse(dim[2]);

		char[][] map = new char[n][];

		for (int i = 0; i < n; i++)
		{
			map[i] = Console.ReadLine().ToCharArray();
		}

		List<List<Coord>> lakes = FindAllLakes(map);
		lakes.Sort((a, b) => a.Count.CompareTo(b.Count));

		int lakesToRemove = lakes.Count - k;
		int changedCell = 0;

		for (int i = 0; i < lakesToRemove; i++)
		{
			changedCell += lakes[i].Count;
			FillLand(map, lakes[i]);
		}

		Console.WriteLine(changedCell);

		foreach (char[] row in map)
		{
			Console.WriteLine(new string(row));
		}
	}

	public static List<List<Coord>> FindAllLakes(char[][] map)
	{
		int rows = map.Length, cols = map[0].Length;
		List<List<Coord>> lakes = new List<List<Coord>>();
		List<Coord> visited = new List<Coord>();

		for (int i = 0; i < rows; i++)
		{
			for (int j = 0; j < cols; j++)
			{
				Coord coord = new Coord(i, j);

				if (map[i][j] == '*') continue;
				if (visited.Contains(coord)) continue;
				bool touchBorder = false;

				List<Coord> water = new List<Coord>();
				FindWater(map, coord, visited, water, ref touchBorder);
				if (!touchBorder) lakes.Add(water);
			}
		}

		return lakes;
	}

	public static void FindWater(char[][] map, Coord start, List<Coord> visited, List<Coord> water, ref bool touchBorder)
	{
		visited.Add(start);
		water.Add(start);
		if (IsBoundary(map, start)) touchBorder = true;

		for (int i = 0; i < 4; i++)
		{
			Coord next = new Coord(start.Row + dr[i], start.Col + dc[i]);

			if (!IsInsideMap(map, next)) continue;
			if (map[next.Row][next.Col] == '*') continue;
			if (visited.Contains(next)) continue;

			FindWater(map, next, visited, water, ref touchBorder);
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

	public static void FillLand(char[][] map, List<Coord> lake)
	{
		foreach (Coord coord in lake)
		{
			map[coord.Row][coord.Col] = '*';
		}
	} 
}