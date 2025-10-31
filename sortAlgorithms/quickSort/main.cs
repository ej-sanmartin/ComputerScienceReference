/// <summary>
/// Implements the quicksort algorithm.
/// </summary>
// T - O(nlogn), S - O(logn) to O(n)
// Not stable but in place
public class QuickSort {
    /// <summary>
    /// Sorts an array using the quicksort algorithm.
    /// </summary>
    /// <param name="arr">The array to sort.</param>
    /// <param name="low">The starting index.</param>
    /// <param name="high">The ending index.</param>
    public static void Sort(int[] arr, int low, int high) {
        if (low < high) {
            int partitionIndex = Partition(arr, low, high);
            Sort(arr, low, partitionIndex - 1);
            Sort(arr, partitionIndex + 1, high);
        }
    }

    /// <summary>
    /// Partitions the array around a pivot element.
    /// </summary>
    /// <param name="arr">The array to partition.</param>
    /// <param name="low">The starting index.</param>
    /// <param name="high">The ending index.</param>
    /// <returns>The partition index.</returns>
    private static int Partition(int[] arr, int low, int high) {
        int pivot = arr[high];
        int i = (low - 1);

        for (int j = low; j < high; j++) {
            if (arr[j] < pivot) {
                i++;
                Swap(i, j, arr);
            }
        }

        Swap(i + 1, high, arr);
        return i + 1;
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


/*
  Another implementation
*/
public class QS {
    public void QS(int[] arr){
        QSHelper(arr, 0, arr.Length - 1);
    }
    
    private void Swap(int[] arr, int a, int b){
        int temp = arr[a];
        arr[a] = arr[b];
        arr[b] = temp;
    }
    
    private void QSHelper(int[] arr, int low, int high){
        if(low >= high) return;
        int pivot = low;
        int leftIndex = low + 1;
        int rightIndex = high;
        while(rightIndex >= leftIndex){
            if(arr[leftIndex] > arr[pivot] && arr[rightIndex] < arr[pivot]){
                Swap(arr, leftIndex, rightIndex);
            }
            if(arr[leftIndex] <= arr[pivot]) leftIndex++;
            if(arr[rightIndex] >= arr[pivot]) rightIndex--;
        }
        Swap(arr, pivot, rightIndex);
        bool leftSubArrayIsSmaller = rightIndex - 1 - low < high - (rightIndex + 1);
        if(leftSubArrayIsSmaller){
            QSHelper(arr, low, rightIndex - 1);
            QSHelper(arr, rightIndex + 1, high);
        } else {
            QSHelper(arr, rightIndex + 1, high);
            QSHelper(arr, low, rightIndex - 1);
        }
    }
}
