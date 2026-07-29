# I Can Guess the Data Structure!

There is a bag-like data structure supporting two operations:

| Command | Description |
|---|---|
| `1 x` | Insert element `x` into the bag. |
| `2 x` | Remove an element from the bag and observe that the removed value is `x`. |

Given a sequence of operations and returned values, determine which data structure could have produced them:

- **Stack** — Last-In, First-Out.
- **Queue** — First-In, First-Out.
- **Priority queue** — Always removes the largest element first.
- Or none of the above.

## Input Format

There are several test cases.

Each test case begins with a single integer `n`:

```text
1 ≤ n ≤ 1000
```

Each of the next `n` lines contains one operation:

- `1 x` — insert `x`;
- `2 x` — remove an element, and the returned value is expected to be `x`.

It is guaranteed that every type-2 operation returns a value without error.

The value of `x` is always a positive integer not larger than `100`.

Input is terminated by end-of-file (`EOF`).

## Output Format

For each test case, print exactly one of the following:

| Output | Meaning |
|---|---|
| `stack` | It is definitely a stack. |
| `queue` | It is definitely a queue. |
| `priority queue` | It is definitely a priority queue. |
| `impossible` | It cannot be a stack, queue, or priority queue. |
| `not sure` | More than one of the three data structures is possible. |

## Sample Test

### Input

```text
6
1 1
1 2
1 3
2 1
2 2
2 3
6
1 1
1 2
1 3
2 3
2 2
2 1
2
1 1
2 2
4
1 2
1 1
2 1
2 2
7
1 2
1 5
1 1
1 3
2 5
1 4
2 4
```

### Output

```text
queue
not sure
impossible
stack
priority queue
```
