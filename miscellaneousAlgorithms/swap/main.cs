// Common helper method, if class has its own private array to keep track of items, may not need third parameter
class GeneralHelperMethods {
  public void Swap(int a, int b, int[] arr){
    int temp = arr[a];
    arr[a] = arr[b];
    arr[b] = temp;
  }
}
