class SearchMethods {
  // checks if it exists
  public bool SequentialSearch(int target, int[] nums){
    int index = 0;
    while(index < nums.Length){
      if(nums[index] == target) return true;
      index++;
    }
    return false;
  }
  
  // returns index
  public int SequentialSearch(int target, int[] nums){
    int index = 0;
    while(index < nums.Length){
      if(nums[index] == target) return index;
      index++;
    }
    return -1;
  }
}
