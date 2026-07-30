# Restaurant Rating

Chef has opened a new restaurant. Like every other restaurant, critics review it. The Chef wants to gather as much positive publicity as possible, and he knows that people generally do not read all reviews.

So, he selects the positive reviews and displays them on the restaurant website.

A review is represented by an integer rating. A review is considered positive if it belongs to the top one-third of all reviews when sorted by rating.

For example, suppose the ratings from 8 critics are:

```text
2 8 3 1 6 4 5 7
```

Since integer division is used:

```text
8 / 3 = 2
```

the top two reviews are:

```text
8 and 7
```

The minimum rating displayed on the website is therefore:

```text
7
```

The Chef receives new reviews continuously, so the displayed top one-third reviews must be updated over time.

At any point, the Chef may ask for the minimum rating currently displayed on the website.

A review may enter the displayed set and later be removed when better reviews arrive, or vice versa.

> **Note:** If there are currently `n` reviews, the number of displayed reviews is:
>
> ```text
> floor(n / 3)
> ```

## Input Format

The first line contains a single integer `N`, the number of operations.

The next `N` lines each contain one operation.

There are two types of operation:

- `1 x` — Add a review with rating `x`.
- `2` — Report the current minimum rating displayed on the website.

## Output Format

For every operation of type `2`:

- Print the minimum rating among the currently displayed top one-third reviews.
- If no review currently qualifies, print:

```text
No reviews yet
```

## Sample Test

### Input

```text
10
1 1
1 7
2
1 9
1 21
1 8
1 5
2
1 9
2
```

### Output

```text
No reviews yet
9
9
```

## Explanation for Sample Test

Before the first type-2 query, the only ratings are:

```text
1, 7
```

The number of positive reviews is:

```text
2 / 3 = 0
```

So no review qualifies, and the output is:

```text
No reviews yet
```

Before the second type-2 query, the ratings are:

```text
1, 5, 7, 8, 9, 21
```

There are 6 reviews, so the number of displayed reviews is:

```text
6 / 3 = 2
```

The top two ratings are:

```text
21 and 9
```

Therefore, the minimum displayed rating is:

```text
9
```

Before the last query, another rating `9` has been added. There are now two reviews with rating `9`, but only one of them needs to be included among the displayed top reviews.

The minimum displayed rating remains:

```text
9
```
