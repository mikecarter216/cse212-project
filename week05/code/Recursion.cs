using System;
using System.Collections.Generic;
using System.Linq;

public static class Recursion
{
    /// <summary>
    /// Problem 1: Sum of squares 1^2 + 2^2 + ... + n^2
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        if (n <= 0) return 0;
        return n * n + SumSquaresRecursive(n - 1);
    }

    /// <summary>
    /// Problem 2: Generate all permutations of given size
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size)
    {
        PermuteHelper(results, letters, size, "");
    }

    private static void PermuteHelper(List<string> results, string letters, int size, string prefix)
    {
        if (prefix.Length == size)
        {
            results.Add(prefix);
            return;
        }

        foreach (char c in letters)
        {
            if (!prefix.Contains(c))
            {
                PermuteHelper(results, letters, size, prefix + c);
            }
        }
    }

    /// <summary>
    /// Problem 3: Count number of ways to climb stairs with 1, 2, or 3 steps
    /// </summary>
    public static decimal CountWaysToClimb(int n)
    {
        Dictionary<int, decimal> memo = new();
        return CountWaysHelper(n, memo);
    }

    private static decimal CountWaysHelper(int n, Dictionary<int, decimal> memo)
    {
        if (n < 0) return 0;
        if (n == 0) return 1;
        if (memo.ContainsKey(n)) return memo[n];

        decimal ways = CountWaysHelper(n - 1, memo)
                     + CountWaysHelper(n - 2, memo)
                     + CountWaysHelper(n - 3, memo);

        memo[n] = ways;
        return ways;
    }

    /// <summary>
    /// Problem 4: Generate binary strings from wildcards (*)
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results)
    {
        WildcardHelper(pattern.ToCharArray(), 0, results);
    }

    private static void WildcardHelper(char[] arr, int index, List<string> results)
    {
        if (index == arr.Length)
        {
            results.Add(new string(arr));
            return;
        }

        if (arr[index] == '*')
        {
            arr[index] = '0';
            WildcardHelper(arr, index + 1, results);

            arr[index] = '1';
            WildcardHelper(arr, index + 1, results);

            arr[index] = '*'; // backtrack
        }
        else
        {
            WildcardHelper(arr, index + 1, results);
        }
    }

    /// <summary>
    /// Problem 5: Solve maze using backtracking
    /// </summary>
    public static void SolveMaze(List<string> results, Maze maze)
    {
        List<(int, int)> currPath = new();
        Explore(results, maze, 0, 0, currPath);
    }

    private static void Explore(List<string> results, Maze maze, int x, int y, List<(int, int)> currPath)
    {
        if (!maze.IsValidMove(currPath, x, y)) return;

        currPath.Add((x, y));

        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());
            currPath.RemoveAt(currPath.Count - 1); // backtrack
            return;
        }

        // explore all four directions
        Explore(results, maze, x + 1, y, currPath); // right
        Explore(results, maze, x - 1, y, currPath); // left
        Explore(results, maze, x, y + 1, currPath); // down
        Explore(results, maze, x, y - 1, currPath); // up

        currPath.RemoveAt(currPath.Count - 1); // backtrack
    }
}
