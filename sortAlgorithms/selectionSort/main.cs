/// <summary>
/// Implements the selection sort algorithm.
/// </summary>
// T - O(n^2), S - O(1)
// In place and not stable
public class SelectionSort {
    /// <summary>
    /// Sorts an array using the selection sort algorithm.
    /// </summary>
    /// <param name="arr">The array to sort.</param>
    public static void Sort(int[] arr) {
        int n = arr.Length;
        for (int i = 0; i < n - 1; i++) {
            int minIndex = i;
            for (int j = i + 1; j < n; j++) {
                if (arr[j] < arr[minIndex]) {
                    minIndex = j;
                }
            }
            Swap(minIndex, i, arr);
        }
    }

    /// <summary>
    /// Swaps two elements in an array.
    /// </summary>
    /// <param name="a">The index of the first element.</param>
    /// <param name="b">The index of the second element.</param>
    /// <param name="arr">The array containing the elements.</param>
    private static void Swap(int a, int b, int[] arr) {
        int temporary = arr[a];
        arr[a] = arr[b];
        arr[b] = temporary;
    }
}