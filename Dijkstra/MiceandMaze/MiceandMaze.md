# Mice and Maze

A set of laboratory mice is being trained to escape a maze. The maze is made up of cells, and each cell is connected to some other cells.

There may be obstacles in the passages between cells, so moving through a passage takes a certain amount of time. Some passages are one-way, meaning mice can travel from one cell to another but not necessarily in the reverse direction.

All mice are trained to choose a path that reaches the exit cell in the minimum possible time.

A mouse is placed in every cell of the maze and a count-down timer is started. When the timer stops, your task is to determine how many mice have managed to reach the exit.

## Problem

Given the maze, an exit cell, and a time limit, determine how many mice can reach the exit within the allowed time.

You may assume there are no bottlenecks in the maze: every cell can contain any number of mice.

## Input Format

The maze cells are numbered from `1` to `N`, where:

```text
N ≤ 100
```

The first four input lines contain:

1. `N` — the number of cells.
2. `E` — the exit cell.
3. `T` — the time limit.
4. `M` — the number of directed connections in the maze.

The next `M` lines each contain three integers:

```text
a b time
```

meaning there is a one-way passage from cell `a` to cell `b` that takes `time` units.

Each connection is directed. A mouse cannot travel from `b` to `a` unless another connection explicitly allows that direction.

The travelling time in each direction may also be different.

## Output Format

Print a single integer: the number of mice that can reach exit cell `E` in at most `T` time units.

## Sample Test

### Input

```text
4
2
1
8
1 2 1
1 3 1
2 1 1
2 4 1
3 1 1
3 4 1
4 2 1
4 3 1
```

### Output

```text
3
```
