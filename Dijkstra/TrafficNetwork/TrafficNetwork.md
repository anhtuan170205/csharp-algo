# Traffic Network

The city traffic network consists of `n` nodes numbered from `1` to `n` and `m` one-way roads connecting pairs of nodes.

To reduce the length of the shortest path between two different critical nodes `s` and `t`, a list of `k` two-way roads is proposed as candidates to be constructed.

Your task is to choose one two-way road from the proposed list so that the resulting shortest path between `s` and `t` is minimized.

## Input Format

The input contains several data sets.

The first line contains the number of data sets, which is a positive integer not greater than `20`.

For each data set:

- The first line contains five positive integers:

```text
n m k s t
```

where:

- `n` — number of nodes, `n ≤ 10000`
- `m` — number of existing one-way roads, `m ≤ 100000`
- `k` — number of proposed two-way roads, `k < 300`
- `s` — source node, `1 ≤ s ≤ n`
- `t` — destination node, `1 ≤ t ≤ n`

- The following `m` lines each contain three integers:

```text
d_i c_i l_i
```

representing a one-way road from node `d_i` to node `c_i` with length `l_i`, where `0 < l_i ≤ 1000`.

- The next `k` lines each contain three positive integers:

```text
u_j v_j q_j
```

representing a proposed two-way road between nodes `u_j` and `v_j` with length `q_j`, where `q_j ≤ 1000`.

## Output Format

For each data set, print one line containing the smallest possible length of the shortest path from `s` to `t` after building one proposed two-way road.

If no path from `s` to `t` exists, print:

```text
-1
```

## Sample Test

### Input

```text
1
4 5 3 1 4
1 2 13
2 3 19
3 1 25
3 4 17
4 1 18
1 3 23
2 3 5
2 4 25
```

### Output

```text
35
```
