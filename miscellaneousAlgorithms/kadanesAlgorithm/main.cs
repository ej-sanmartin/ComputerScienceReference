using System;

/// <summary>
/// Implements Kadane's algorithm for finding the maximum subarray sum.
/// </summary>
public class KadanesAlgorithm {
    /// <summary>
    /// Finds the maximum subarray sum using Kadane's algorithm.
    /// </summary>
    /// <param name="arr">The input array of integers.</param>
    /// <returns>The maximum subarray sum.</returns>
    public static int FindMaximumSubarraySum(int[] arr) {
        int max = Int32.MinValue;
        int currentSum = 0;

        for (int i = 0; i < arr.Length; i++) {
            currentSum += arr[i];
            max = Math.Max(max, currentSum);

            /*
              If we need to do something in addition to updating max,
              replace the line above with:
                if (currentSum > max) {
                  max = currentSum;
                  // do something here
                }
            */

            if (currentSum < 0) {
                currentSum = 0;
            }
        }

        return max;
    }
}
