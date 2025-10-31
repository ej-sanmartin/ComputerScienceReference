using System;

/// <summary>
/// Provides mathematical utility functions.
/// </summary>
public class MathHelper {
    /// <summary>
    /// Determines if a number is a perfect power of the given base.
    /// </summary>
    /// <param name="num">The number to check.</param>
    /// <param name="pow">The base to check against.</param>
    /// <returns>True if num is a perfect power of pow, false otherwise.</returns>
    public static bool IsPowerOf(int num, int pow) {
        if (num <= 0 || pow <= 1) return false;
        if (num == 1) return true;

        double logResult = Math.Log(num, pow);
        return logResult % 1 == 0;
    }
}
