# Promotion

A large Bytelandian supermarket chain has asked you to write a program to simulate the costs of a promotion.

The promotion follows these rules:

- A customer who wants to participate writes their personal details on the receipt and places it into a special ballot box.
- At the end of every day:
  - the receipt with the largest amount is selected;
  - the receipt with the smallest amount is selected.
- The customer with the largest receipt receives a prize equal to:

```text
largest receipt amount - smallest receipt amount
```

- The two selected receipts are removed permanently from the ballot box.
- All remaining receipts stay in the ballot box and continue participating on later days.

It is guaranteed that before selecting the largest and smallest receipts at the end of each day, there are at least two receipts in the ballot box.

Your task is to compute the total amount of prize money paid during the entire promotion.

## Input Format

The first line contains one positive integer `n`:

```text
1 ≤ n ≤ 5000
```

This is the number of days in the promotion.

Each of the next `n` lines describes the receipts added on one day.

The first integer on each line is `k`:

```text
0 ≤ k ≤ 10^5
```

where `k` is the number of receipts added that day.

The next `k` integers are the amounts written on those receipts.

Each receipt amount is a positive integer not larger than:

```text
10^6
```

The total number of receipts added during the entire promotion does not exceed:

```text
10^6
```

## Output Format

Print exactly one integer: the total cost of all prizes paid during the entire promotion.

## Sample Test

### Input

```text
5
3 1 2 3
2 1 1
4 10 5 5 1
0
1 2
```

### Output

```text
19
```
