using System.Collections.Generic;

/// <summary>
/// Provides utilities for binary number conversion.
/// </summary>
public class BinaryHelper {
    /// <summary>
    /// Converts a decimal number to its binary representation as a list of bits.
    /// </summary>
    /// <param name="n">The decimal number to convert.</param>
    /// <returns>A list of integers representing the binary digits (MSB first).</returns>
    public List<int> ToBinary(int n) {
        List<int> output = new List<int>();
        while (n > 0) {
            output.Add(n % 2);
            n /= 2;
        }
        output.Reverse();
        return output;
    }
}
