using System;

/// <summary>
/// Represents a Fenwick Tree (Binary Indexed Tree) for efficient range sum queries and updates.
/// </summary>
public class FenwickTree {
    private int[] tree;

    /// <summary>
    /// Initializes a new instance of the FenwickTree class with the specified size.
    /// </summary>
    /// <param name="size">The size of the Fenwick tree.</param>
    public FenwickTree(int size) {
        tree = new int[size + 1];
    }

    /// <summary>
    /// Validates that the index is within valid range.
    /// </summary>
    /// <param name="index">The index to validate.</param>
    private void ValidateIndex(int index) {
        if (index < 0 || index >= tree.Length) {
            throw new ArgumentOutOfRangeException("Index out of bounds.");
        }
    }

    /// <summary>
    /// Computes the sum of elements from index 1 to the specified index.
    /// </summary>
    /// <param name="index">The upper bound of the range sum query.</param>
    /// <returns>The sum of elements from 1 to index.</returns>
    // T - O(log n)
    public int RangeSumQuery(int index) {
        ValidateIndex(index);

        int sum = 0;

        while (index > 0) {
            sum += tree[index];
            index -= index & (-index);
        }

        return sum;
    }

    /// <summary>
    /// Computes the sum of elements between two indices (inclusive).
    /// </summary>
    /// <param name="start">The start index of the range.</param>
    /// <param name="end">The end index of the range.</param>
    /// <returns>The sum of elements from start to end.</returns>
    // T - O(log n)
    public int RangeSumQueryBetweenPoints(int start, int end) {
        if (!(end >= start && start > 0 && end > 0)) {
            throw new InvalidOperationException("Invalid arguments. Make sure indices are positive and end >= start.");
        }

        return RangeSumQuery(end) - RangeSumQuery(start - 1);
    }

    /// <summary>
    /// Updates the value at the specified index by adding the given value.
    /// </summary>
    /// <param name="index">The index to update.</param>
    /// <param name="value">The value to add.</param>
    // T - O(log n)
    public void Update(int index, int value) {
        ValidateIndex(index);

        while (index < tree.Length) {
            tree[index] += value;
            index += index & (-index);
        }
    }
}