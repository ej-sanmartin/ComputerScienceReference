// T - O(n^2), S - O(1)
// In place and stable
public class InsertionSort {
    public static void InsertionSort(int[] arr){
        for(int i = 1; i < arr.Length; ++i){
            int current = arr[i];
            int j = i - 1;
            while(j >= 0 && arr[j] > current){
                arr[j + 1] = arr[j];
                j--;
            }
            arr[j + 1] = current;
        }
    }
}