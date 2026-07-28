# Add All

Yup!! The problem name reflects your task: just add a set of numbers. But you may feel condescended to write a C/C++ program just to add a set of numbers. Such a problem would simply question your erudition. So, let's add some flavor of ingenuity to it.

An addition operation has a cost, and the cost is the sum of the two numbers being added.

For example, adding `1` and `10` costs `11`.

If you want to add `1`, `2`, and `3`, there are several possible orders:

| Method 1 | Method 2 | Method 3 |
|---|---|---|
| `1 + 2 = 3`, cost = `3` | `1 + 3 = 4`, cost = `4` | `2 + 3 = 5`, cost = `5` |
| `3 + 3 = 6`, cost = `6` | `2 + 4 = 6`, cost = `6` | `1 + 5 = 6`, cost = `6` |
| **Total = 9** | **Total = 10** | **Total = 11** |

Your task is to add a set of integers so that the total cost is minimal.

## Input Format

Each test case starts with a positive integer `N`, where:

```text
2 ≤ N ≤ 5000
```

It is followed by `N` positive integers, each less than `100000`.

Input ends with a test case where `N = 0`. This test case should not be processed.

## Output Format

For each test case, print the minimum total cost of addition on a single line.

## Sample Test

### Input

```text
3
1 2 3
4
1 2 3 4
0
```

### Output

```text
9
19
```
