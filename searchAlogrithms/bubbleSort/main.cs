// T - O(n^2), S - O(1)
public class BubbleSort {
    public static void BubbleSort(int[] arr){
        int n = arr.Length;

        for(int i = 0; i < n; i++){
            for(int j = 0; j < n - i - 1; j++){
                if(arr[j] > arr[j + 1]){
                    Swap(arr[j], arr[j + 1], arr);
                }
            }
        }
    }

    private static void Swap(int a, int b, int[] arr){
        int temporary = arr[a];
        arr[a] = arr[b];
        arr[b] = temporary;
    }
}