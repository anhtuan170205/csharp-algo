# Validate The Maze

There are many algorithms to generate a maze. After generating the maze, we need to validate whether it is a valid maze.

A valid maze must satisfy both conditions:

1. It has exactly one entry point and exactly one exit point, meaning there are exactly two open cells on the boundary.
2. There is at least one path from the entry point to the exit point.

Given a maze, determine whether it is `valid` or `invalid`.

## Input Constraints

- `1 ≤ t ≤ 10000`
- `1 ≤ m ≤ 20`
- `1 ≤ n ≤ 20`

## Input Format

The first line contains an integer `t`, the number of test cases.

For each test case:

- The first line contains two integers `m` and `n`, representing the number of rows and columns in the maze.
- The next `m` lines contain the maze of size `m × n`.

Each cell is represented by:

- `#` — a wall
- `.` — an open space

## Output Format

For each test case, print:

- `valid` if the maze has exactly two boundary openings and there is a path between them.
- `invalid` otherwise.

## Sample Input

```text
6
4 4
####
#...
#.##
#.##
5 5
#.###
#..##
##..#
#.#.#
###.#
1 1
.
5 1
#
#
.
.
#
2 2
#.
.#
3 4
#..#
#.##
#.##
```

## Sample Output

```text
valid
valid
invalid
valid
invalid
invalid
```
