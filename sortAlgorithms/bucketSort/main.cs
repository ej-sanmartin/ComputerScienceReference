using System.Collections.Generic;

/// <summary>
/// Implements the bucket sort algorithm.
/// </summary>
// T - O(n^2), S - (n + k)
// Not in place, good with floats
public class BucketSort {
    /// <summary>
    /// Sorts an array of floats using the bucket sort algorithm.
    /// </summary>
    /// <param name="arr">The array of floats to sort.</param>
    /// <param name="n">The number of buckets to use.</param>
    /// <returns>A sorted list of floats, or null if n is not positive.</returns>
    public static List<float> Sort(float[] arr, int n) {
        if (n <= 0) { return null; }

        List<float> sortedArray = new List<float>();
        List<float>[] buckets = new List<float>[n];

        for (int i = 0; i < n; i++) {
            buckets[i] = new List<float>();
        }

        for (int i = 0; i < arr.Length; i++) {
            int bucketIndex = Math.Min((int)(arr[i] * n), n - 1);
            bucketIndex = Math.Max(bucketIndex, 0);
            buckets[bucketIndex].Add(arr[i]);
        }

        for (int i = 0; i < n; i++) {
            buckets[i].Sort();
            sortedArray.AddRange(buckets[i]);
        }

        return sortedArray;
    }
}