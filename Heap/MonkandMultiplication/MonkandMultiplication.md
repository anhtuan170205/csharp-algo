# Monk and Multiplication

The Monk recently learned about priority queues and asked his teacher for an interesting problem.

He is given an integer array `A`.

For each index `i`, determine the product of the:

- largest element,
- second-largest element,
- third-largest element

in the prefix:

```text
A[1..i]
```

> **Note:** Two numbers may have the same value, but they must come from different indices.

## Input Format

The first line contains an integer `N`, the number of elements in array `A`.

The second line contains `N` space-separated integers representing the array.

## Constraints

```text
1 ≤ N ≤ 100000
0 ≤ A[i] ≤ 1000000
```

## Output Format

For every index `i`, print the answer on a separate line.

If fewer than three elements exist in the prefix ending at index `i`, print:

```text
-1
```

## Sample Test

### Input

```text
5
1 2 3 4 5
```

### Output

```text
-1
-1
6
24
60
```

## Explanation for Sample Test

The array contains:

```text
1, 2, 3, 4, 5
```

For the first two indices, fewer than three elements are available, so the output is:

```text
-1
```

For the third index, the three largest values are:

```text
3, 2, 1
```

Their product is:

```text
3 × 2 × 1 = 6
```

For the fourth index, the three largest values are:

```text
4, 3, 2
```

Their product is:

```text
4 × 3 × 2 = 24
```

For the fifth index, the three largest values are:

```text
5, 4, 3
```

Their product is:

```text
5 × 4 × 3 = 60
```
