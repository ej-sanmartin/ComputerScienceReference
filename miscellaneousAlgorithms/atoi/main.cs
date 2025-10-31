/// <summary>
/// Implements the atoi function (ASCII to integer conversion).
/// </summary>
/*
  Converts a string to its integer equivalent if the string represents a valid integer.

  Time Complexity: O(n), where n is the length of the input string
  Space Complexity: O(1), uses only constant extra space
*/
public class Atoi {
    /// <summary>
    /// Converts a string to an integer, following C's atoi behavior.
    /// </summary>
    /// <param name="s">The string to convert.</param>
    /// <returns>The integer value, or -1 if the string is invalid.</returns>
    public static int ATOI(string s) {
        if (s == null || s.Length == 0) {
            return -1;
        }

        int sign = 1;
        int result = 0;
        int i = 0;

        // Skip leading whitespace
        while (i < s.Length && s[i] == ' ') {
            i++;
        }

        // Check bounds after skipping whitespace
        if (i >= s.Length) {
            return -1;
        }

        // Handle sign
        if (s[i] == '+' || s[i] == '-') {
            sign = (s[i++] == '-') ? -1 : 1;
        }

        // Check bounds after processing sign
        if (i >= s.Length) {
            return -1;
        }

        // Check if first non-whitespace character is not a digit
        if (!char.IsDigit(s[i])) {
            return -1;
        }

        // Convert digits
        while (i < s.Length && s[i] >= '0' && s[i] <= '9') {
            int digit = s[i] - '0';

            if (IsNearOverflow(result, digit)) {
                return (sign == 1) ? int.MaxValue : int.MinValue;
            }

            result = result * 10 + digit;
            i++;
        }

        // If there are remaining non-digit characters, invalid input
        if (i < s.Length) {
            return -1;
        }

        return result * sign;
    }

  public static bool IsNearInfinity(int total, int num){
    if(total > Int32.MaxValue / 10 || (total == Int32.MaxValue / 10 && num > 7)){
      return true;
    }
    return false;
  }
}
