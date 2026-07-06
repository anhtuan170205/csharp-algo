# Dudu Service Maker

Dudu needs a document to finalize a task at work. After searching, he found that this document depends on other documents, which may also depend on additional documents, and so on.

Dudu created a final list of all required documents. However, he suspects that the dependency list may contain loops.

For example, if document `A` depends on document `B`, and document `B` also depends on document `A`, then it would be impossible to obtain all documents. A loop may contain two documents, three documents, or more.

Given the list of dependencies, determine whether there is at least one cycle in the dependency graph.

## Input Format

The first line contains an integer `T` (`T ≤ 100`), the number of test cases.

For each test case:

- The first line contains two integers `N` and `M`.
  - `N` is the number of documents.
  - `M` is the number of dependencies.

Constraints:

- `1 ≤ N ≤ 10^4`
- `1 ≤ M ≤ 3 × 10^4`

The next `M` lines each contain two integers:

```text
A B
```

This means that document `A` depends on document `B`.

Notes:

- `1 ≤ A, B ≤ N`
- `A ≠ B`
- Repeated dependencies may appear.

## Output Format

For each test case, print:

- `YES` if there is at least one cycle.
- `NO` otherwise.

## Sample Input

```text
3
2 1
1 2
2 2
1 2
2 1
4 4
2 3
3 4
4 2
1 3
```

## Sample Output

```text
NO
YES
YES
```
