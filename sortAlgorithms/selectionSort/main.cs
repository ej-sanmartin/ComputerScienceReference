// T - O(n^2), S - O(1)
// In place and not stable
public class SelectionSort {
    public static void SelectionSort(int[] arr){
        int n = arr.Length;
        for(int i = 0; i < n - 1; i++){
            int minIndex;
            for(int j = i + 1; j < n; j++){
                if(arr[j] < arr[minIndex]){
                    minIndex = j;
                }
            }
            swap(minIndex, i, arr);
        }
    }

    private void Swap(int min, int start, int[] arr){
        int temporary = arr[min];
        arr[min] = arr[start];
        arr[start] = temporary;
    }
}