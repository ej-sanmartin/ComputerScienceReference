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


/*
  Another implementation
*/
public class QS {
    public void QS(int[] arr){
        QSHelper(arr, 0, arr.Length - 1);
        return arr;
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
        leftSubArrayIsSmaller = rightIndex - 1 - low < high - (rightIndex + 1);
        if(leftSubArrayIsSmaller){
            QSHelper(arr, low, rightIndex - 1);
            QSHelper(arr, rightIndex + 1, high);
        } else {
            QSHelper(arr, rightIndex + 1, high);
            QSHelper(arr, low, rightIndex - 1);
        }
    }
}
