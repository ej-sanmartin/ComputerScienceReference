/// <summary>
/// Provides mathematical utility functions.
/// </summary>
public class MathHelper {
    /// <summary>
    /// Calculates the factorial of a non-negative integer using iteration.
    /// </summary>
    /// <param name="n">The non-negative integer to calculate factorial for.</param>
    /// <returns>The factorial of n, or 1 if n is less than 2.</returns>
    public int Factorial(int n) {
        if (n < 2) return 1;
        int factorialNumber = 1;
        for (int i = 2; i <= n; i++) {
            factorialNumber *= i;
        }
        return factorialNumber;
    }
}
