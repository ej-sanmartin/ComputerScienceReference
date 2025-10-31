using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Provides LINQ-based utility methods for array manipulation.
/// </summary>
public class LinqHelper {
    /// <summary>
    /// Sorts a list of lists by the second element of each inner list.
    /// </summary>
    /// <param name="arr">The list of lists to sort.</param>
    /// <returns>A new sorted list where elements are ordered by their second element.</returns>
    public static List<List<int>> SortBySecondElement(List<List<int>> arr) {
        return arr.OrderBy(list => list[1]).ToList();
    }
}
