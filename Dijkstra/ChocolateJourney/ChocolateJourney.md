# Chocolate Journey

You live in city `B`. Your friend lives in city `A`. You need a special chocolate `xyz`.

The chocolate is not available in your city and is available only at `k` cities. There are `N` cities in the country and `M` bidirectional roads between the cities, and the length of each road is given.

The chocolate is preserved in cold containers and can stay for an infinite time while it remains in those containers. Once it is taken out of the cold container, it expires in `x` units of time and cannot be put back into the cold container to make it available for infinite time again.

It takes `1` unit of time to cover `1` unit of distance.

Your task is to find the minimum amount of time your friend needs to reach you with the chocolate.

If it is not possible to reach you with the chocolate, print:

```text
-1
```

There are no self-loops and no multiple edges.

## Input Format

The first line contains four integers:

```text
N M k x
```

where:

- `N` — number of cities
- `M` — number of bidirectional roads
- `k` — number of cities where chocolate is available
- `x` — expiry time of the chocolate

The next line contains `k` space-separated integers denoting the cities where chocolate is available.

Cities are indexed from `1` to `N`.

The next `M` lines each contain three integers:

```text
u v d
```

meaning there is a bidirectional road between cities `u` and `v` with length `d`.

The last line contains two integers:

```text
A B
```

where:

- `A` — your friend's city
- `B` — your city

## Constraints

- `1 ≤ N ≤ 10^5`
- `1 ≤ M ≤ min(10^6, N * (N - 1) / 2)`
- `1 ≤ k ≤ N - 1`
- `1 ≤ x ≤ N`
- `1 ≤ d ≤ 500`
- `1 ≤ u, v, A, B ≤ N`

## Output Format

Print the minimum amount of time taken to reach city `B` from city `A` with the chocolate.

If it is not possible, print:

```text
-1
```

## Sample Test

### Input

```text
7 3 1 6
1
4 7 1
3 5 7
6 1 3
6 2
```

### Output

```text
-1
```

## Explanation for Sample Test

Here `A = 6` and `B = 2`.

Chocolate is available in city `1`.

The roads are:

```text
4 <-> 7, cost 1
3 <-> 5, cost 7
6 <-> 1, cost 3
```

There is no path from city `6` to city `2`, so the answer is:

```text
-1
```
