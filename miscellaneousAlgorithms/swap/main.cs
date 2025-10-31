/// <summary>
/// Provides general utility methods for array manipulation.
/// </summary>
// Common helper method, if class has its own private array to keep track of items, may not need third parameter
public class GeneralHelperMethods {
    /// <summary>
    /// Swaps two elements in an integer array.
    /// </summary>
    /// <param name="a">The index of the first element to swap.</param>
    /// <param name="b">The index of the second element to swap.</param>
    /// <param name="arr">The array containing the elements to swap.</param>
    public void Swap(int a, int b, int[] arr) {
        int temp = arr[a];
        arr[a] = arr[b];
        arr[b] = temp;
    }
}
