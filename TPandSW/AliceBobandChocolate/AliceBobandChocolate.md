# Alice Bob and Chocolate

Alice and Bob like games. And now they are ready to start a new game. They have placed \(n\) chocolate bars in a line. Alice starts to eat chocolate bars one by one from **left to right**, and Bob — from **right to left**.

For each chocolate bar, the time needed for the player to consume it is known. Alice and Bob eat them with equal speed. When a player consumes a chocolate bar, they immediately start another one. It is not allowed to eat two chocolate bars at the same time, to leave a bar unfinished, or to make pauses.

If both players start to eat the same bar simultaneously, Bob leaves it to Alice as a true gentleman.

How many bars will each player consume?

## Input Format

- The first line contains one integer \(n\) \((1 \le n \le 10^5)\) — the number of chocolate bars on the table.
- The second line contains a sequence \(t_1, t_2, \ldots, t_n\) \((1 \le t_i \le 1000)\), where \(t_i\) is the time in seconds needed to consume the \(i\)-th bar, ordered from left to right.

## Output Format

Print two integers \(a\) and \(b\), where:

- \(a\) is the number of bars consumed by Alice.
- \(b\) is the number of bars consumed by Bob.

## Sample Test

### Input

```text
5
2 9 8 2 7
```

### Output

```text
2 3
```
