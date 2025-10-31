using System;
using System.Collections.Generic;

/// <summary>
/// Provides utilities for array manipulation.
/// </summary>
public class RemoveDuplicates {
    /// <summary>
    /// Removes duplicate elements from a string array while preserving order.
    /// </summary>
    /// <param name="arr">The input array that may contain duplicates.</param>
    /// <returns>A new array containing only unique elements.</returns>
    public static string[] RemoveDuplicatesFromArray(string[] arr) {
        HashSet<string> hs = new HashSet<string>();
        foreach (string word in arr) {
            hs.Add(word);
        }

        string[] unique = new string[hs.Count];
        int i = 0;

        foreach (string word in hs) {
            unique[i++] = word;
        }

        return unique;
    }
}
