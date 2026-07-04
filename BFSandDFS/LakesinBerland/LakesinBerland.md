# Lakes in Berland

The map of Berland is a rectangle of size `n × m`, consisting of cells of size `1 × 1`.

Each cell is either land or water. The map is surrounded by the ocean.

A **lake** is a maximal region of water cells connected by sides that is not connected to the ocean.

Formally, a lake is a set of water cells such that:

- It is possible to move from any cell in the set to any other cell without leaving the set.
- Movement is allowed only between cells sharing a side.
- None of the cells is located on the border of the rectangle.
- It is impossible to add another water cell to the set while keeping it connected.

Your task is to fill the minimum number of water cells with earth so that exactly `k` lakes remain in Berland.

The initial number of lakes is guaranteed to be at least `k`.

## Input Format

The first line contains three integers:

```text
n m k
```

where:

- `n` is the number of rows.
- `m` is the number of columns.
- `k` is the number of lakes that should remain.

Constraints:

- `1 ≤ n, m ≤ 50`
- `0 ≤ k ≤ 50`

The next `n` lines contain `m` characters each describing the map.

Each character is either:

- `.` — water
- `*` — land

It is guaranteed that the map contains at least `k` lakes.

## Output Format

Print the minimum number of water cells that should be changed into land.

Then print the resulting map in the next `n` lines.

If there are several valid answers, print any of them.

It is guaranteed that an answer exists.

## Sample 1

### Input

```text
5 4 1
****
*..*
****
**.*
..**
```

### Output

```text
1
****
*..*
****
****
..**
```

## Sample 2

### Input

```text
3 3 0
***
*.*
***
```

### Output

```text
1
***
***
***
```
