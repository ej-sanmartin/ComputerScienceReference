using System.Collections.Generic;

// T - O(n^2), S - (n + k)
// Not in place, good with floats
public class BucketSort {
    public static List<float> BucketSort(float[] arr, int n){
        if(n <= 0){ return null; }

        List<float> sortedArray = new List<float>();
        List<float>[] buckets = new List<float>[n];

        for(int i = 0; i < n; i++){
            buckets[i] = new List<float>();
        }

        for(int i = 0; i < arr.Length; i++){
            int bucketIndex = (int)(arr[i] * n);
            if(bucketIndex >= n) bucketIndex = n - 1;
            if(bucketIndex < 0) bucketIndex = 0;
            buckets[bucketIndex].Add(arr[i]);
        }

        for(int i = 0; i < n; i++){
            buckets[i].Sort();
            sortedArray.AddRange(buckets[i]);
        }

        return sortedArray;
    }
}