// both approaches to binary search assumes array passed into the function is sorted
// to increase completeness of algorithm, would need to sort the array passed in before
// continuing with rest of the algorithm

// iterative T - O(logn)
public class BinarySearchIterative {
  public static bool BinarySearch(int[] arr, int targetValue){
    int low = 0;
    int high = arr.Length - 1;
    int guess = 0;
    int middle = 0;
    
    while(low <= high){
      middle = low + high;
      guess = arr[middle];
      
      if(guess == targetValue){
        return true;
      }
      
      if(guess > targetValue){
        high = middle - 1;
      } else {
        low = middle + 1;
      }
    }
    
    return false;
  }
}


// recursive T - O(logn)
// returns index of array where targetValue is located if found
// otherwise returns -1 if not found
public class BinarySearchRecursive {
  public static int BinarySearch(int[] arr, int targetValue, int low, int high){
    if(low > high) return -1;
    int middle = (low + high) / 2;
    if(targetValue == arr[middle]) return middle;
    
    if(targetValue > arr[middle]){
      return BinarySearch(arr, targetValue, middle + 1, high);
    } else {
      return BinarySearch(arr, targetValue, low, middle - 1);
    }
  }
}
