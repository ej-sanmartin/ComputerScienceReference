using System;
using System.Collections.Generics;

/*
  Given a target string and an array of string, return a list of all possible ways
  that the target string can be constructed by concatenating elements from the array
  of strings.
  
  Each element in the output list should represent a combination of elements from
  the string array that constructs the target.


  T - O(n^m), have to construct all possible lists that is equal to target, testing every combination
  S - O(n^m), space created from constructing the valid list of string elements that make up target
*/

class Solution {
  public static List<List<string>> AllConstructs(string target, string[] wordBank){
    List<List<string>>[] table = new List<List<string>>[target.Length + 1];
    for(int i = 0; i < table.Length; i++){
      table[i] = new List<List<string>>();
    }

    for(int i = 0; i < target.Length; i++){
      foreach(string word in wordBank){
        if(word.Length + i > target.Length) continue;
        if(target.Substring(i, word.Length) == word){
          if(table[i].Count == 0) table[i].Add(new List<string>(){ word });
          List<List<string>> newCombinations = new List<List<string>>();
          List<List<string>> currentCombinations = table[i];
          foreach(List<string> combination in currentCombinations){
            List<string> newCombination = combination.GetRange(0, combination.Count);
            newCombination.Add(word);
            newCombinations.Add(newCombination);
          }

          foreach(List<string> list in newCombinations){
            if(i == 0) list.RemoveAt(0); // TODO: this fixes bug where first string in each combination list is duplicated
            table[i + word.Length].Add(list);
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
