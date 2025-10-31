/// <summary>
/// Provides implementations for calculating binomial coefficients (n choose k).
/// </summary>
public class NChooseK {
    /// <summary>
    /// Calculates binomial coefficient C(n, k) using recursion.
    /// </summary>
    /// <param name="n">The total number of items.</param>
    /// <param name="k">The number of items to choose.</param>
    /// <returns>The binomial coefficient C(n, k), or 0 if k > n.</returns>
    // Recursive, naive O(2^n)
    public static int NChooseKRecursive(int n, int k) {
        if (k > n) return 0;
        if (k == 0 || k == n) return 1;
        return NChooseKRecursive(n - 1, k - 1) + NChooseKRecursive(n - 1, k);
    }

    /// <summary>
    /// Calculates binomial coefficient C(n, k) using dynamic programming.
    /// </summary>
    /// <param name="n">The total number of items.</param>
    /// <param name="k">The number of items to choose.</param>
    /// <returns>The binomial coefficient C(n, k).</returns>
    // Iterative, optimized O(nk)
    public static int Calculate(int n, int k) {
        int[,] table = new int[n + 1, k + 1];

        for (int i = 0; i <= n; i++) {
            for (int j = 0; j <= Math.Min(i, k); j++) {
                if (j == 0 || j == i) table[i, j] = 1;
                else table[i, j] = table[i - 1, j - 1] + table[i - 1, j];
            }
        }

        return table[n, k];
    }
}
