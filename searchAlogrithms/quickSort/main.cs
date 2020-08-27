// T - O(nlogn), S - O(logn) to O(n)
// Not stable but in place
public class QuickSort {
    public static void QuickSort(int[] arr, int low, int high){
        if(low < high){
            int partitionIndex = Partition(arr, low, high);
            QuickSort(arr, low, partitionIndex - 1);
            QuickSort(arr, partitionIndex + 1, high);
        }
    }

    private static int Partition(int[] arr, int low, int high){
        int pivot = arr[high];
        int i = (low - 1);

        for(int j = low; j < high; j++){
            if(arr[j] > pivot){
                i++;
                Swap(i, j, arr);
            }
        }

        Swap(i + 1, high, arr);
        return i + 1;
    }

    private static void Swap(int a, int b, int[] arr){
        int temporary = arr[a];
        arr[a] = arr[b];
        arr[b] = temporary;
    }
}