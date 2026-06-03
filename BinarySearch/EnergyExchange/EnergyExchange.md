# Energy Exchange

It is well known that the planet suffers from the energy crisis. Little Petya doesn't like that and wants to save the world. For this purpose he needs every accumulator to contain the same amount of energy. Initially every accumulator has some amount of energy: the *i*th accumulator has *a_i* units of energy. Energy can be transferred from one accumulator to the other. Every time *x* units of energy are transferred (*x* is not necessarily an integer), *k* percent of it is lost. That is, if *x* units were transferred from one accumulator to the other, amount of energy in the first one decreased by *x* units and in other increased by *x - xk / 100* units.

Your task is to help Petya find what maximum equal amount of energy can be stored in each accumulator after the transfers.

## Input Format

First line of the input contains two integers *n* and *k* (1 <= *n* <= 10000, 0 <= *k* <= 99) - number of accumulators and the percent of energy that is lost during transfers.

Next line contains *n* integers *a_1, a_2, ..., a_n* - amounts of energy in the first, second, ..., *n*th accumulator respectively (0 <= *a_i* <= 1000, 1 <= *i* <= *n*).

## Output Format

Output maximum possible amount of energy that can remain in each of accumulators after the transfers of energy.

The absolute or relative error in the answer should not exceed 10^-6.

## Sample test

### Sample 1

**Input**

```text
3 50
4 2 1
```

**Output**

```text
2.000000000
```

### Sample 2

**Input**

```text
2 90
1 11
```

**Output**

```text
1.909090909
```

## Explanation for sample test

Looking at it, you can see that the first accumulator transfer 2 unit of energy to the third accumulator.

- The first accumulator has 2 units left.
- The amount of transfer is reduced by 50%, so the third accumulator receives 1 unit, so the third accumulator contain 2 units.

All accumulator have 2 units.
