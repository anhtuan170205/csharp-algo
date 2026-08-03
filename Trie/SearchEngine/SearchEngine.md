# Search Engine

**Memory Limit:** 512 MB

Let us see how search engines work. Consider the following simple auto complete feature. When you type some characters in the text bar, the engine automatically gives best matching options among it's database. Your job is simple. Given an incomplete search text, output the best search result.

Each entry in engine's database has a priority factor attached to it. We consider a result / search suggestion best if it has maximum weight and completes the given incomplete search query. For each query in the input, print the maximum weight of the string in the database, that completes the given incomplete search string. In case no such string exists, print `-1`.

## Input Format

First line contains two integers `n` and `q`, which represent number of database entries and number of search queries need to be completed. Next `n` lines contain a string `s` and an integer `weight`, which are the database entry and it's corresponding priority.

Next `q` lines follow, each line having a string `t`, which needs to be completed.

## Output Format

Output `q` lines, each line containing the maximum possible weight of the match for given query, else `-1`, in case no valid result is obtained.

## Constraints

- `1 ≤ n, weight, len(s), len(t) ≤ 10^6`
- `1 ≤ q ≤ 10^5`
- Total length of all strings in database entries `≤ 10^6`
- Total length of all query strings `≤ 10^6`

## Sample Test

### Input

```text
2 1
hackerearth 10
hackerrank 9
hacker
```

### Output

```text
10
```
