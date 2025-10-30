// T - O(d(n + k)), S - O(n + k)
public class RadixSort {
    public static void RadixSort(int[] arr, int n){
        int max = GetMax(arr, n);
        for(int exponent = 1; (max/exponent) > 0; exponent *= 10){
            CountSort(arr, n, exponent);
        }
    }

    private static int GetMax(int[] arr, int n){
        int max = arr[0];

        for(int i = 1; i < n; i++){
            if(arr[i] > max){ max = arr[i]; }
        }

        return max;
    }

    private static void CountSort(int[] arr, int n, int exponent){
        int i;
        int[] count = new int[10];
        int[] output = new int[n];

        for(i = 0; i < 10; i++){
            count[i] = 0;
        }

        for(i = 0; i < n; i++){
            count[(arr[i]/exponent) % 10]++;
        }

        for(i = 1; i < 10; i++){
            count[i] += count[i - 1];
        }

        for(i = n - 1; i >= 0; i--){
            output[count[(arr[i]/exponent) % 10] - 1] = arr[i];
            count[(arr[i]/exponent) % 10]--;
        }

        for(i = 0; i < n; i++){
            arr[i] = output[i];
        }
    }
}