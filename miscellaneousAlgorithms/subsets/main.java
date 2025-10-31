import java.util.*;

/**
 * Provides methods for generating subsets from arrays, handling duplicates.
 *
 * Time Complexity: O(n * 2^n)
 * Space Complexity: O(n * 2^n)
 */
public class SubsetWithDuplicates {

  /**
   * Finds all unique subsets of the given array, handling duplicates.
   *
   * @param nums the input array that may contain duplicates
   * @return a list of all unique subsets
   */
  public static List<List<Integer>> findSubsets(int[] nums) {
    Arrays.sort(nums);
    List<List<Integer>> subsets = new ArrayList<>();
    subsets.add(new ArrayList<>());
    int startIndex = 0;
    int endIndex = 0;
    for (int i = 0; i < nums.length; i++) {
      startIndex = 0;
      if (i > 0 && nums[i] == nums[i - 1]) {
        startIndex = endIndex + 1;
      }
      endIndex = subsets.size() - 1;
      for (int j = startIndex; j <= endIndex; j++) {
        List<Integer> subset = new ArrayList<>(subsets.get(j));
        subset.add(nums[i]);
        subsets.add(subset);
      }
    }

    return subsets;
  }

  public static void main(String[] args) {
    List<List<Integer>> result = SubsetWithDuplicates.findSubsets(new int[] { 1, 3, 3 });
    System.out.println("Here is the list of subsets: " + result);

    result = SubsetWithDuplicates.findSubsets(new int[] { 1, 5, 3, 3 });
    System.out.println("Here is the list of subsets: " + result);
  }
}
