using System;
using System.Linq;
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
		int t = int.Parse(Console.ReadLine());

		for (int test = 0; test < t; test++)
		{
			int[] dim = Console.ReadLine().Split().Select(int.Parse).ToArray();
			int m = dim[0], n = dim[1];

			char[][] maze = new char[m][];

			for (int i = 0; i < m; i++)
			{
				maze[i] = Console.ReadLine().ToCharArray();
			}

			List<Coord> openings = new List<Coord>();

			openings = GetAllOpenings(maze);

			if (openings.Count != 2) 
			{
				sb.AppendLine("invalid");
				continue;
			}

			List<Coord> visited = new List<Coord>();
			bool hasPath = HasPath(maze, openings[0], openings[1], visited);

			sb.AppendLine(hasPath ? "valid" : "invalid");
		}

		Console.Write(sb.ToString());
	}

	public static List<Coord> GetAllOpenings(char[][] maze)
	{
		int rows = maze.Length;
		int cols = maze[0].Length;

		List<Coord> openings = new List<Coord>();
		for (int i = 0; i < rows; i++)
		{
			for (int j = 0; j < cols; j++)
			{
				Coord coord = new Coord(i, j);
				if (IsBoundary(maze, coord) && maze[i][j] == '.')
				{
					openings.Add(coord);
				}
			}
		}
		return openings;
	}

	public static bool IsBoundary(char[][] maze, Coord coord)
	{
		return coord.Row == 0 || coord.Row == maze.Length - 1 
			|| coord.Col == 0 || coord.Col == maze[0].Length - 1;
	}

	public static bool IsInsideMaze(char[][] maze, Coord coord)
	{
		return coord.Row < maze.Length && coord.Row >= 0
			&& coord.Col >= 0 && coord.Col < maze[0].Length;
	}

	public static bool HasPath(char[][] maze, Coord start, Coord end, List<Coord> visited)
	{
		if (start.Equals(end)) return true;

		visited.Add(start);

		for (int i = 0; i < 4; i++)
		{
			Coord next = new Coord(start.Row + dr[i], start.Col + dc[i]);
			
			if (!IsInsideMaze(maze, next)) continue;
			if (maze[next.Row][next.Col] == '#') continue;
			if (visited.Contains(next)) continue;

			if (HasPath(maze, next, end, visited)) return true;
		}		

		return false;
	}
}

