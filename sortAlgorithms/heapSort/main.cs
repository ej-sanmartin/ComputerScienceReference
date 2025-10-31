/// <summary>
/// Implements the heap sort algorithm.
/// </summary>
// T - O(nlogn), S - O(1)
// Not stable and in place
public class HeapSort {
    /// <summary>
    /// Sorts an array using the heap sort algorithm.
    /// </summary>
    /// <param name="arr">The array to sort.</param>
    public static void Sort(int[] arr) {
        int n = arr.Length;

        for (int i = (n / 2) - 1; i >= 0; i--) {
            Heapify(arr, n, i);
        }

        for (int i = n - 1; i > 0; i--) {
            Swap(0, i, arr);
            Heapify(arr, i, 0);
        }
    }

    /// <summary>
    /// Maintains the heap property for a subtree rooted at index i.
    /// </summary>
    /// <param name="arr">The array representing the heap.</param>
    /// <param name="n">The size of the heap.</param>
    /// <param name="i">The root index of the subtree to heapify.</param>
    private static void Heapify(int[] arr, int n, int i) {
        int largest = i;
        int left = 2 * i + 1;
        int right = 2 * i + 2;

        if (left < n && arr[left] > arr[largest]) { largest = left; }
        if (right < n && arr[right] > arr[largest]) { largest = right; }

        if (largest != i) {
            Swap(i, largest, arr);
            Heapify(arr, n, largest);
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