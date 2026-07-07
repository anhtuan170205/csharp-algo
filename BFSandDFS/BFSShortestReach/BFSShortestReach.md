# Breadth First Search: Shortest Reach

Consider an undirected graph consisting of `n` nodes labeled from `1` to `n`.

Every edge has a fixed length of `6`.

Given a starting node `s`, perform a breadth-first search and determine the shortest distance from `s` to every other node in the graph.

If a node cannot be reached from `s`, its distance is `-1`.

## Input Format

The first line contains an integer `q`, the number of queries.

For each query:

- The first line contains two integers `n` and `m`:
  - `n` is the number of nodes.
  - `m` is the number of edges.
- The next `m` lines each contain two integers `u` and `v`, representing an undirected edge between nodes `u` and `v`.
- The last line contains one integer `s`, the starting node.

## Constraints

- `1 ≤ q ≤ 10`
- `2 ≤ n ≤ 1000`
- `1 ≤ m ≤ n(n - 1) / 2`
- `1 ≤ u, v, s ≤ n`

## Output Format

For each query, print one line containing `n - 1` space-separated integers.

The values should be the shortest distances from `s` to every other node, listed in increasing node order.

Do not print the distance from `s` to itself.

If a node is unreachable from `s`, print `-1`.

## Sample Input

```text
2
4 2
1 2
1 3
1
3 1
2 3
2
```

## Sample Output

```text
6 6 -1
-1 6
```

## Why the first output is `6 6 -1`

For the first query:

```text
4 2
1 2
1 3
1
```

The graph contains these edges:

```text
1 -- 2
1 -- 3
```

Node `4` is disconnected.

The starting node is `1`.

- Node `2` is one edge away, so its distance is `6`.
- Node `3` is one edge away, so its distance is `6`.
- Node `4` is unreachable, so its distance is `-1`.

The starting node itself is not included in the output.

Therefore, the output is:

```text
6 6 -1
```

In general:

```text
distance = number of edges in the shortest path × 6
```
