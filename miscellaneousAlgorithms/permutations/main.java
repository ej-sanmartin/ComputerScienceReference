import java.util.ArrayList;
import java.util.List;

/**
 * Provides methods for generating permutations of arrays.
 */
public class ArrayPermutations {

  /**
   * Finds all permutations of the given array.
   *
   * @param nums the input array of integers
   * @return a list of all possible permutations, where each permutation is a list of integers
   */
  public static List<List<Integer>> findPermutations(int[] nums) {
    List<List<Integer>> result = new ArrayList<>();
    permutations(nums, 0, new ArrayList<Integer>(), result);
    return result;
  }

  private static void permutations(int[] nums, int index, List<Integer> currentPermutation,
      List<List<Integer>> result) {
    if (index == nums.length) {
      result.add(new ArrayList<>(currentPermutation));
    } else {
      for (int i = 0; i <= currentPermutation.size(); i++) {
        List<Integer> newPermutation = new ArrayList<Integer>(currentPermutation);
        newPermutation.add(i, nums[index]);
        permutations(nums, index + 1, newPermutation, result);
      }
    }
  }

  public static void main(String[] args) {
    List<List<Integer>> result = ArrayPermutations.findPermutations(new int[] { 1, 2 });
    System.out.println("Here are all the permutations: " + result);
  }
}
