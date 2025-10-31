/// <summary>
/// Provides mathematical utility functions.
/// </summary>
// Based on Euclid's Algorithm
public class MathHelper {
    /// <summary>
    /// Calculates the greatest common divisor (GCD) of two integers using Euclid's algorithm.
    /// </summary>
    /// <param name="a">The first integer.</param>
    /// <param name="b">The second integer.</param>
    /// <returns>The greatest common divisor of a and b.</returns>
    public int GreatestCommonDenominator(int a, int b) {
        if (b == 0) return a;
        return GreatestCommonDenominator(b, a % b);
    }
}
