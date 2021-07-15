/*
  T - O(n * n!), for any given length of array n there are n! possible permutations
  S - O(n!), recursive call stack for all n! permutations at worst case
*/
class ArrayPermutations {
  public static List<int[]> ArrayPermutations(int[] arr){
    List<int[]> results = new List<int[]>();
    ArrayPermutationsHelper(arr, 0, results);
    return results;
  }

  private static void ArrayPermutationsHelper(int[] arr, int start, List<int[]> results){
    if(start >= arr.Length){
      int[] newArr = arr.Clone() as int[];
      results.Add(newArr);
    } else {
      for(int i = start; i < arr.Length; i++){
        Swap(arr, start, i);
        ArrayPermutationsHelper(arr, start + 1, results);
        Swap(arr, start, i);
      }
    }
  }

  private static void Swap(int[] array, int a, int b){
    int temp = array[a];
    array[a] = array[b];
    array[b] = temp;
  }
}

class StringPermutations {
  public static List<string> StringPermutations(string s){
    List<string> results = new List<string>();
    StringPermutationsHelper("", s, results);
    return results;
  }
  
  // keep in mind, make prefix one larger per loop and suffix one smaller from the start per loop
  public static void StringPermutationsHelper(string prefix, string suffix, List<string> results){
    if(suffix.Length == 0){
      results.Add(prefix);
    } else {
      for(int i = 0; i < suffix.Length; i++){
        StringPermutationsHelper(prefix + suffix[i], suffix.Substring(0, i) + suffix.Substring(i + 1, suffix.Length - (i + 1)), results);
      }
    }
  }
}
