/// <summary>
/// Provides sequential search implementations for finding elements in arrays.
/// </summary>
public class SearchMethods {
    /// <summary>
    /// Performs sequential search to check if a target value exists in the array.
    /// </summary>
    /// <param name="target">The value to search for.</param>
    /// <param name="nums">The array to search in.</param>
    /// <returns>True if the target value is found, false otherwise.</returns>
    public bool Contains(int target, int[] nums) {
        int index = 0;
        while (index < nums.Length) {
            if (nums[index] == target) return true;
            index++;
        }
        return false;
    }

    /// <summary>
    /// Performs sequential search to find the index of a target value in the array.
    /// </summary>
    /// <param name="target">The value to search for.</param>
    /// <param name="nums">The array to search in.</param>
    /// <returns>The index of the target value if found, -1 otherwise.</returns>
    public int FindIndex(int target, int[] nums) {
        int index = 0;
        while (index < nums.Length) {
            if (nums[index] == target) return index;
            index++;
        }
        return -1;
    }
}
