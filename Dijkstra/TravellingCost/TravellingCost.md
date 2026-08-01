# Travelling Cost

The government of **SpojLand** has selected a number of locations in the city for road construction and numbered them from `0` to `500`.

They want to construct roads between pairs of locations, say `A` and `B`, and assign a travelling cost `W` for going between those two locations in either direction.

Rohit wants to find the minimum travelling cost from a source location `U` to `Q` destination locations.

## Input Format

- The first line contains `N`, the number of roads.
- The next `N` lines each contain three integers:

```text
A B W
```

where:

- `A` and `B` are the two locations connected by the road.
- `W` is the travelling cost from `A` to `B` or from `B` to `A`.

- The next line contains an integer `U`, the source location.
- The next line contains `Q`, the number of queries.
- The next `Q` lines each contain an integer `V`, a destination location for which the minimum cost from `U` must be found.

## Constraints

- `1 ≤ N ≤ 500`
- `0 ≤ A, B ≤ 500`
- `1 ≤ W ≤ 100`
- `0 ≤ U, V ≤ 500`
- `1 ≤ Q ≤ 500`

## Output Format

For each query:

- Print the minimum travelling cost from `U` to `V`.
- If no path exists from `U` to `V`, print:

```text
NO PATH
```

## Sample Test

### Input

```text
7
0 1 4
0 3 8
1 4 1
1 2 2
4 2 3
2 5 3
3 4 2
0
4
1
4
5
7
```

### Output

```text
4
5
9
NO PATH
```

## Explanation

### Query 1

```text
0 -> 1
```

Cost:

```text
4
```

### Query 2

```text
0 -> 4 = 0 -> 1 -> 4
```

Cost:

```text
4 + 1 = 5
```

### Query 3

```text
0 -> 5 = 0 -> 1 -> 2 -> 5
```

Cost:

```text
4 + 2 + 3 = 9
```

### Query 4

```text
0 -> 7
```

No path exists between locations `0` and `7`.
