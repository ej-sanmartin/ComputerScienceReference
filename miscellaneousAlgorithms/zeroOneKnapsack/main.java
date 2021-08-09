/*
  Without memo:
  T - O(2^n)
  S - O(n)
  
  With memo and with bottom up implementation:
  T - O(n^2)
  S - O(n * c)
*/
class Knapsack {
  // Top Down Solution with memoization
  public int solveKnapsack(int[] profits, int[] weights, int capacity){
    Integer[][] memo = new Integer[capacity + 1][profits.length]; // make memo
    return recursiveKnapsack(profits, weights, capacity, profits.length - 1, memo);
  }

  public int recursiveKnapsack(int[] profits, int[] weights, int capacity, int decision, Integer[][] memo){
    if(decision < 0 || capacity == 0){ // base case and checks if we are out of bounds
      return 0;
    }
    
    if(memo[capacity][decision] != null){ // if solution already found, return it.. no need to recompute everything
      return memo[capacity][decision];
    }

    int result;
    if(weights[decision] > capacity){ // if the weight is too large, call this method skipping this item
      result = recursiveKnapsack(profits, weights, capacity, decision - 1, memo); 
    } else { // else, find max of the below two cases
      int profitsOne = recursiveKnapsack(profits, weights, capacity, decision - 1, memo); // calculate profit if you were not to take current item
      int profitsTwo = profits[decision] + recursiveKnapsack(profits, weights, capacity - weights[decision], decision - 1, memo); // calculcate profit if you did take this item, remember to update weight
      result = Math.max(profitsOne, profitsTwo);
    }

    memo[capacity][decision] = result; // cache result
    return memo[capacity][decision];
  }
  
  public int solveKnapsack(int[] profits, int[] weights, int capacity){
    if(capacity == 0 || profits.length < 1 || profits == null || profits.length != weights.length){ // base cases
      return 0;
    }
    
    int[][] table = new int[profits.length][capacity + 1]; // create dp table to store sub solutions

    for(int i = 0; i < profits.length; i++){ // fill out table so all columns that have a 0 capacity have a value of 0
      table[i][0] = 0;
    }

    for(int i = 0; i <= capacity; i++){ // if only one item we can take is available, check all capacities and set value to that item's value if we can
      if(weights[0] <= i){
        table[0][i] = profits[0];
      }
    }

    for(int i = 1; i < profits.length; i++){
      for(int c = 1; c <= capacity; c++){
        int profitOne = 0; // calculates us taking the item, make sure to factor in the different weight to check right row/ column in dp table
        int profitTwo = 0; // calculates us not taking the item, thus taking value from cell above which has a sub solution

        if(weights[i] <= c){
          profitOne = profits[i] + table[i - 1][c - weights[i]];
        }

        profitTwo = table[i - 1][c];
        table[i][c] = Math.max(profitOne, profitTwo);
      }
    }

    return table[profits.length - 1][capacity];
  }

  public static void main(String[] args) {
    Knapsack ks = new Knapsack();
    int[] profits = {1, 6, 10, 16};
    int[] weights = {1, 2, 3, 5};
    int maxProfit = ks.solveKnapsack(profits, weights, 7);
    System.out.println("Total knapsack profit ---> " + maxProfit);
    maxProfit = ks.solveKnapsack(profits, weights, 6);
    System.out.println("Total knapsack profit ---> " + maxProfit);
  }
}
