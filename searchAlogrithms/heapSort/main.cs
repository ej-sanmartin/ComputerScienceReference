// T - O(nlogn), S - O(1)
// Not stable and in place
public class HeapSort {
    public static void HeapSort(int[] arr){
        int n = arr.Length;

        for(int i = (n/2) - 1; i >= 0; i--){
            Heapify(arr, n, i);
        }

        for(int i = n - 1; i > 0; i--){
            Swap(0, i, arr);
            Heapify(arr, n, 0);
        }
    }

    private static void Heaify(int[] arr, int n, int i){
        int largest = i;
        int left = 2 * i + 1;
        int right = 2 * i + 2;

        if(left < n && arr[left] > arr[largest]){ largest = left; }
        if(right < n && arr[right] > arr[largest]){ largest = right; }

        if(largest != i){
            Swap(i, largest, arr);
            Heaify(arr, n, largest);
        }
    }

    private static void Swap(int a, int b, int[] arr){
        int temporary = arr[a];
        arr[a] = arr[b];
        arr[b] = temporary;
    }
}