# Kefa and Park

Kefa decided to celebrate his first big salary by going to a restaurant.

He lives near an unusual park. The park is a rooted tree consisting of `n` vertices, with the root at vertex `1`. Vertex `1` also contains Kefa's house.

Some vertices contain cats. The leaf vertices of the tree contain restaurants.

Kefa wants to choose a restaurant to visit, but he is afraid of cats. He will not go to a restaurant if the path from his house to that restaurant contains more than `m` consecutive vertices with cats.

Your task is to count the number of restaurants Kefa can visit.

## Input Format

The first line contains two integers:

```text
n m
```

where:

- `n` is the number of vertices in the tree.
- `m` is the maximum number of consecutive vertices with cats that Kefa can tolerate.

Constraints:

- `2 ≤ n ≤ 100000`
- `1 ≤ m ≤ n`

The second line contains `n` integers:

```text
a1 a2 ... an
```

Each `ai` is either:

- `0` — vertex `i` does not contain a cat.
- `1` — vertex `i` contains a cat.

The next `n - 1` lines contain the edges of the tree. Each line has the form:

```text
xi yi
```

where vertices `xi` and `yi` are connected by an edge.

## Output Format

Print one integer: the number of leaf vertices whose path from Kefa's house contains at most `m` consecutive vertices with cats.

## Sample 1

### Input

```text
4 1
1 1 0 0
1 2
1 3
1 4
```

### Output

```text
2
```

## Sample 2

### Input

```text
7 1
1 0 1 1 0 0 0
1 2
1 3
2 4
2 5
3 6
3 7
```

### Output

```text
2
```

## Explanation

A tree is a connected graph with `n` vertices and `n - 1` edges.

A rooted tree has one special vertex called the root. For every edge in a rooted tree, the vertex closer to the root is the parent and the other vertex is the child.

A vertex is a leaf if it has no children.
