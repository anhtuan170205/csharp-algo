# Guilty Prince

Once there was a king named Akbar. He had a son named Shahjahan. For an unforgivable reason, the king wanted him to leave the kingdom. Since he loved his son, he decided that his son would be banished to a new place.

The prince became sad, but he followed his father's will. On the way, he found that the place was a combination of land and water. Since he did not know how to swim, he was only able to move on land. He did not know how many places might be reachable from his destination, so he asked for your help.

For simplicity, consider the place as a rectangular grid consisting of cells. A cell can be land or water. Each time, the prince can move to a new cell from his current position if the two cells share a side.

Your task is to find the number of land cells he can reach, including the cell where he starts.

## Input Format

The input starts with an integer `T` (`T ≤ 500`), denoting the number of test cases.

Each test case starts with a line containing two positive integers `W` and `H`:

- `W` is the number of cells in the horizontal (`x`) direction.
- `H` is the number of cells in the vertical (`y`) direction.
- `W, H ≤ 20`.

The next `H` lines each contain `W` characters describing the grid.

Each character represents the status of one cell:

1. `.` — land
2. `#` — water
3. `@` — the prince's initial position, which appears exactly once in each test case

## Output Format

For each test case, print the case number and the number of cells the prince can reach from the initial position, including the initial cell.

Use the following format:

```text
Case X: answer
```

## Sample Input

```text
4
6 9
....#.
.....#
......
......
......
......
......
#@...#
.#..#.
11 9
.#.........
.#.#######.
.#.#.....#.
.#.#.###.#.
.#.#..@#.#.
.#.#####.#.
.#.......#.
.#########.
...........
11 6
..#..#..#..
..#..#..#..
..#..#..###
..#..#..#@.
..#..#..#..
..#..#..#..
7 7
..#.#..
..#.#..
###.###
...@...
###.###
..#.#..
..#.#..
```

## Sample Output

```text
Case 1: 45
Case 2: 59
Case 3: 6
Case 4: 13
```
