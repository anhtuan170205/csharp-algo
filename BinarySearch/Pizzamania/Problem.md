# Pizzamania

**Difficulty:** Secret  
**Source:** SPOJ  
**Time Limit:** 3000 ms  
**Memory Limit:** 1024 MB

## Statement

Singham and his friends are fond of pizza. But this time they are short of money. So they decided to help each other. They all decided to bring pizza in pairs. Our task is to find the total number of pairs possible which can buy pizza, given the cost of pizza.

As pizza boy does not have any cash for change, if the pair adds up to more money than required, then also they are unable to buy the pizza. Each friend is guaranteed to have distinct amount of money. As it is Singham's world, money can also be negative 🙂.

## Input Format

The first line consists of `t`, where `1 <= t <= 100`, the number of test cases.

For each test case:

- The first line contains two integers `n` and `m`, where `1 <= n <= 100000`.
  - `n` is the number of Singham's friends.
  - `m` is the price of pizza.
- The next line contains `n` integers, separated by spaces, representing the money each friend has.

The value of `m` and each money value is within the limits of `int` in C/C++.

## Output Format

For each test case, output a single integer representing the number of pairs which can eat pizza.

## Sample Input

```text
2
4 12
9 -3 4 3
5 -9
-7 3 -2 8 7
```

## Sample Output

```text
1
1
```