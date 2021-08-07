class ArrayPermutations {

  public static List<List<Integer>> findPermutations(int[] nums) {
    List<List<Integer>> result = new ArrayList<>();
    permutations(nums, 0, new ArrayList<Integer>(), result);
    return result;
  }

  private static void permutations(int[] nums, int index, List<Integer> currentPermutation,
      List<List<Integer>> result) {
    if (index == nums.length) {
      result.add(currentPermutation);
    } else {
      for (int i = 0; i <= currentPermutation.size(); i++) {
        List<Integer> newPermutation = new ArrayList<Integer>(currentPermutation);
        newPermutation.add(i, nums[index]);
        permutations(nums, index + 1, newPermutation, result);
      }
    }
  }

  public static void main(String[] args) {
    List<List<Integer>> result = Permutations.findPermutations(new int[] { 1, 2 });
    System.out.print("Here are all the permutations: " + result);
  }
}
