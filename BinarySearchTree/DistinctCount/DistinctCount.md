# Distinct Count

Given an array `A` of `N` integers, classify it as being **Good**, **Bad**, or **Average**.

- It is called **Good** if it contains exactly `X` distinct integers.
- It is called **Bad** if it contains fewer than `X` distinct integers.
- It is called **Average** if it contains more than `X` distinct integers.

## Input Format

The first line consists of a single integer `T` denoting the number of test cases.

The first line of each test case consists of two space-separated integers denoting `N` and `X`.

The second line of each test case consists of `N` space-separated integers denoting the array elements.

## Constraints

- `1 ≤ T ≤ 50`
- `1 ≤ X, N ≤ 13000`
- `1 ≤ A[i] ≤ 10^9`

## Output Format

Print the required answer for each test case on a new line.

## Sample Test

### Input

```text
4
4 1
1 4 2 5
4 2
4 2 1 5
4 3
5 2 4 1
4 4
1 2 4 5
```

### Output

```text
Average
Average
Average
Good
```
