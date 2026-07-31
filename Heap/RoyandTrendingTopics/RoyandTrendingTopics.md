# Roy and Trending Topics

Roy is developing a widget that displays trending topics on the home page of HackerEarth Academy.

He has collected a list of `N` topics. Each topic has:

- a unique topic ID;
- an old popularity score, called the **z-score**;
- counts of posts, likes, comments, and shares.

The new z-score is calculated using these rules:

- Each post contributes `50`.
- Each like contributes `5`.
- Each comment contributes `10`.
- Each share contributes `20`.

For a topic with posts `P`, likes `L`, comments `C`, and shares `S`:

```text
newZ = 50P + 5L + 10C + 20S
```

The trending rank is based on the change in z-score:

```text
change = newZ - oldZ
```

Topics with a larger change rank higher.

If two topics have the same change, the topic with the larger ID gets higher priority.

Your task is to print the top 5 trending topics.

## Input Format

The first line contains an integer `N`.

The next `N` lines each contain 6 space-separated integers:

```text
ID Z P L C S
```

where:

- `ID` is the topic ID;
- `Z` is the old z-score;
- `P` is the number of posts;
- `L` is the number of likes;
- `C` is the number of comments;
- `S` is the number of shares.

## Constraints

```text
1 ≤ N ≤ 10^6
1 ≤ ID ≤ 10^9
0 ≤ Z, P, L, C, S ≤ 10^9
```

Topic IDs are unique.

## Output Format

Print the top 5 topics, one per line.

Each line should contain:

```text
TopicID newZScore
```

Order the topics by:

1. descending change in z-score;
2. descending topic ID when the change is tied.

## Sample Test

### Input

```text
8
1003 100 4 0 0 0
1002 200 6 0 0 0
1001 300 8 0 0 0
1004 100 3 0 0 0
1005 200 3 0 0 0
1006 300 5 0 0 0
1007 100 3 0 0 0
999 100 4 0 0 0
```

### Output

```text
1003 200
1002 300
1001 400
999 200
1007 150
```

## Explanation for the Sample Test

The new z-score and its change from the old z-score are:

| Topic ID | Old z-score | New z-score | Change |
|---:|---:|---:|---:|
| 1003 | 100 | 200 | 100 |
| 1002 | 200 | 300 | 100 |
| 1001 | 300 | 400 | 100 |
| 1004 | 100 | 150 | 50 |
| 1005 | 200 | 150 | -50 |
| 1006 | 300 | 250 | -50 |
| 1007 | 100 | 150 | 50 |
| 999 | 100 | 200 | 100 |

The topics with change `100` are ranked by descending ID:

```text
1003, 1002, 1001, 999
```

The topics with change `50` are also ranked by descending ID, so `1007` comes before `1004`.

Therefore, the top 5 topics are:

```text
1003, 1002, 1001, 999, 1007
```
