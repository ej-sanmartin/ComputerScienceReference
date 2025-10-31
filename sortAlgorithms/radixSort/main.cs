/// <summary>
/// Implements the radix sort algorithm.
/// </summary>
// T - O(d(n + k)), S - O(n + k)
public class RadixSort {
    /// <summary>
    /// Sorts an array using the radix sort algorithm.
    /// </summary>
    /// <param name="arr">The array to sort.</param>
    /// <param name="n">The size of the array.</param>
    public static void Sort(int[] arr, int n) {
        int max = GetMax(arr, n);
        for (int exponent = 1; (max / exponent) > 0; exponent *= 10) {
            CountSort(arr, n, exponent);
        }
    }

    /// <summary>
    /// Finds the maximum value in the array.
    /// </summary>
    /// <param name="arr">The array to search.</param>
    /// <param name="n">The size of the array.</param>
    /// <returns>The maximum value in the array.</returns>
    private static int GetMax(int[] arr, int n) {
        int max = arr[0];

        for (int i = 1; i < n; i++) {
            if (arr[i] > max) { max = arr[i]; }
        }

        return max;
    }

    /// <summary>
    /// Performs counting sort on the array based on the given exponent.
    /// </summary>
    /// <param name="arr">The array to sort.</param>
    /// <param name="n">The size of the array.</param>
    /// <param name="exponent">The current digit place (1, 10, 100, etc.).</param>
    private static void CountSort(int[] arr, int n, int exponent) {
        int i;
        int[] count = new int[10];
        int[] output = new int[n];

        for (i = 0; i < 10; i++) {
            count[i] = 0;
        }

        for (i = 0; i < n; i++) {
            count[(arr[i] / exponent) % 10]++;
        }

        for (i = 1; i < 10; i++) {
            count[i] += count[i - 1];
        }

        for (i = n - 1; i >= 0; i--) {
            output[count[(arr[i] / exponent) % 10] - 1] = arr[i];
            count[(arr[i] / exponent) % 10]--;
        }

        for (i = 0; i < n; i++) {
            arr[i] = output[i];
        }
    }
}