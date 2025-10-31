/// <summary>
/// Implements the counting sort algorithm.
/// </summary>
// T - O(n + k), S - O(n + k)
public class CountingSort {
    /// <summary>
    /// Sorts an array of characters using the counting sort algorithm.
    /// </summary>
    /// <param name="arr">The character array to sort.</param>
    public static void Sort(char[] arr) {
        int n = arr.Length;
        char[] output = new char[n];
        int[] count = new int[256];

        for (int i = 0; i < 256; i++) {
            count[i] = 0;
        }

        for (int i = 0; i < n; ++i) {
            ++count[arr[i]];
        }

        for (int i = 1; i < 256; i++) {
            count[i] += count[i - 1];
        }

        for (int i = n - 1; i >= 0; i--) {
            output[count[arr[i]] - 1] = arr[i];
            --count[arr[i]];
        }

        for (int i = 0; i < n; ++i) {
            arr[i] = output[i];
        }
    }
}
