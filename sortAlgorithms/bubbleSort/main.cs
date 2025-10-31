/// <summary>
/// Implements the bubble sort algorithm.
/// </summary>
// T - O(n^2), S - O(1)
// In place and stable
public class BubbleSort {
    /// <summary>
    /// Sorts an array using the bubble sort algorithm.
    /// </summary>
    /// <param name="arr">The array to sort.</param>
    public static void Sort(int[] arr) {
        int n = arr.Length;

        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n - i - 1; j++) {
                if (arr[j] > arr[j + 1]) {
                    Swap(j, j + 1, arr);
                }
            }
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