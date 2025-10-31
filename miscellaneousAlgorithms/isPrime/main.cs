/// <summary>
/// Provides mathematical utility functions.
/// </summary>
public class MathHelper {
    /// <summary>
    /// Determines if a number is prime.
    /// </summary>
    /// <param name="n">The number to check for primality.</param>
    /// <returns>True if the number is prime, false otherwise.</returns>
    public bool IsPrime(int n) {
        if (n <= 1) return false;
        if (n <= 3) return true;
        if (n % 2 == 0 || n % 3 == 0) return false;

        for (int i = 5; i * i <= n; i += 6) {
            if (n % i == 0 || n % (i + 2) == 0) return false;
        }
        return true;
    }
}
