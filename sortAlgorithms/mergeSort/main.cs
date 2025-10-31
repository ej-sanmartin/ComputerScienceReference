using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Implements the merge sort algorithm.
/// </summary>
// T - O(nlogn), S - O(n)
// Stable but not in place
public class MergeSort {
    /// <summary>
    /// Sorts a list using the merge sort algorithm.
    /// </summary>
    /// <param name="list">The list to sort.</param>
    /// <returns>A new sorted list.</returns>
    public static List<int> Sort(List<int> list) {
        if (list.Count <= 1) { return list; }

        List<int> left = new List<int>();
        List<int> right = new List<int>();

        int middle = list.Count / 2;

        for (int i = 0; i < middle; i++) {
            left.Add(list[i]);
        }

        for (int i = middle; i < list.Count; i++) {
            right.Add(list[i]);
        }

        left = Sort(left);
        right = Sort(right);

        return Merge(left, right);
    }

    /// <summary>
    /// Merges two sorted lists into a single sorted list.
    /// </summary>
    /// <param name="left">The first sorted list.</param>
    /// <param name="right">The second sorted list.</param>
    /// <returns>A merged sorted list.</returns>
    private static List<int> Merge(List<int> left, List<int> right) {
        List<int> result = new List<int>();

        while (left.Count > 0 || right.Count > 0) {
            if (left.Count > 0 && right.Count > 0) {
                if (left.First() <= right.First()) {
                    result.Add(left.First());
                    left.Remove(left.First());
                } else {
                    result.Add(right.First());
                    right.Remove(right.First());
                }
            } else if (left.Count > 0) {
                result.Add(left.First());
                left.Remove(left.First());
            } else if (right.Count > 0) {
                result.Add(right.First());
                right.Remove(right.First());
            }
        }

        return result;
    }
}