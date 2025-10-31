/// <summary>
/// Provides binary search implementations for finding elements in sorted arrays.
/// </summary>
// Both approaches assume the array passed is sorted.
// To increase completeness, sort the array before using these methods.

// Iterative T - O(logn)
public class BinarySearchIterative {
    /// <summary>
    /// Performs iterative binary search on a sorted array.
    /// </summary>
    /// <param name="arr">The sorted array to search in.</param>
    /// <param name="targetValue">The value to search for.</param>
    /// <returns>True if the target value is found, false otherwise.</returns>
    public static bool BinarySearch(int[] arr, int targetValue) {
        int low = 0;
        int high = arr.Length - 1;

        while (low <= high) {
            int middle = (low + high) / 2;
            int guess = arr[middle];

            if (guess == targetValue) {
                return true;
            }

            if (guess > targetValue) {
                high = middle - 1;
            } else {
                low = middle + 1;
            }
        }

        return false;
    }
}

/// <summary>
/// Provides recursive binary search implementation.
/// </summary>
// Recursive T - O(logn)
// Returns index of array where targetValue is located if found,
// otherwise returns -1 if not found
public class BinarySearchRecursive {
    /// <summary>
    /// Performs recursive binary search on a sorted array.
    /// </summary>
    /// <param name="arr">The sorted array to search in.</param>
    /// <param name="targetValue">The value to search for.</param>
    /// <param name="low">The lower bound index.</param>
    /// <param name="high">The upper bound index.</param>
    /// <returns>The index where the target value is found, or -1 if not found.</returns>
    public static int BinarySearch(int[] arr, int targetValue, int low, int high) {
        if (low > high) return -1;
        int middle = (low + high) / 2;
        if (targetValue == arr[middle]) return middle;

        if (targetValue > arr[middle]) {
            return BinarySearch(arr, targetValue, middle + 1, high);
        } else {
            return BinarySearch(arr, targetValue, low, middle - 1);
        }
    }
}
