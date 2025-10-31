using System;
using System.Collections.Generic;

/// <summary>
/// Implements the allConstructs algorithm for finding all ways to construct a target string.
/// </summary>
/*
  Given a target string and an array of string, return a list of all possible ways
  that the target string can be constructed by concatenating elements from the array
  of strings.

  Each element in the output list should represent a combination of elements from
  the string array that constructs the target.


  T - O(n^m), have to construct all possible lists that is equal to target, testing every combination
  S - O(n^m), space created from constructing the valid list of string elements that make up target
*/
public class AllConstructsSolution {
    /// <summary>
    /// Finds all possible ways to construct the target string from the word bank.
    /// </summary>
    /// <param name="target">The target string to construct.</param>
    /// <param name="wordBank">Array of strings that can be used to construct the target.</param>
    /// <returns>A list of all possible combinations of strings that form the target.</returns>
    public static List<List<string>> AllConstructs(string target, string[] wordBank) {
        List<List<string>>[] table = new List<List<string>>[target.Length + 1];
        for (int i = 0; i < table.Length; i++) {
            table[i] = new List<List<string>>();
        }

        // Initialize the first position with an empty combination
        table[0].Add(new List<string>());

        for (int i = 0; i <= target.Length; i++) {
            if (table[i].Count == 0) continue;

            foreach (string word in wordBank) {
                if (i + word.Length <= target.Length &&
                    target.Substring(i, word.Length) == word) {

                    // Copy all combinations from current position
                    foreach (List<string> combination in table[i]) {
                        List<string> newCombination = new List<string>(combination);
                        newCombination.Add(word);
                        table[i + word.Length].Add(newCombination);
                    }
                }
            }
        }

        return table[target.Length];
    }

  public static void Main (string[] args) {
    Console.WriteLine("");

    // Testing out Code speed
    var watch = new System.Diagnostics.Stopwatch();
    string[] wordBank = new string[]{ "ab", "abc", "cd", "def", "abcd", "ef", "c" };
    
    watch.Start();
    List<List<string>> example = AllConstructs("abcdef", wordBank);
    watch.Stop();

    foreach(List<string> list in example){
      string output = "[ ";
      foreach(string word in list){
        output += $"{word}, ";
      }
      output += "]";
      Console.WriteLine(output.Remove(output.Length - 3, 1));
    }

    Console.WriteLine($"\nExecution Time: {watch.ElapsedMilliseconds} ms");
  }
}
