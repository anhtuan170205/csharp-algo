# Commandos

A group of commandos were assigned a critical task. They must destroy an enemy headquarters consisting of several buildings connected by roads.

The commandos start at a particular building, then spread out to visit every building and place a bomb at its base. After completing the task, all commandos must gather at a common destination building.

Each commando takes exactly one unit of time to move from one building to another through a road. The time needed to place a bomb is negligible. There is an unlimited number of commandos, and each commando can carry an unlimited number of bombs.

Your task is to determine the minimum time required to complete the mission.

## Input Format

The input starts with an integer `T` (`T ≤ 50`), the number of test cases.

For each test case:

- The first line contains an integer `N` (`1 ≤ N ≤ 100`), the number of buildings.
- The next line contains an integer `R`, the number of roads.
- Each of the next `R` lines contains two distinct integers:

```text
u v
```

meaning there is a road connecting building `u` and building `v`.

The buildings are numbered from `0` to `N - 1`.

- The last line of each test case contains two integers:

```text
s d
```

where:

- `s` is the building where the mission starts.
- `d` is the building where all commandos must gather after completing the mission.

You may assume that:

- There is at most one direct road between any two buildings.
- Every building is reachable from every other building.

## Output Format

For each test case, print:

```text
Case X: answer
```

where `X` is the case number and `answer` is the minimum time required to complete the mission.

## Sample Test

### Input

```text
2
4
3
0 1
2 1
1 3
0 3
2
1
0 1
1 0
```

### Output

```text
Case 1: 4
Case 2: 1
```
