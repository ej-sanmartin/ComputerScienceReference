/// <summary>
/// Implements the insertion sort algorithm.
/// </summary>
// T - O(n^2), S - O(1)
// In place and stable
public class InsertionSort {
    /// <summary>
    /// Sorts an array using the insertion sort algorithm.
    /// </summary>
    /// <param name="arr">The array to sort.</param>
    public static void Sort(int[] arr) {
        for (int i = 1; i < arr.Length; ++i) {
            int current = arr[i];
            int j = i - 1;
            while (j >= 0 && arr[j] > current) {
                arr[j + 1] = arr[j];
                j--;
            }
            arr[j + 1] = current;
        }
    }
}