class NChooseK {
  // recursive, naive O(2^n)
  public static int NChooseKRecursive(int n, int k){
    if(k > n) return 0;
    if(k == 0 || k == n) return 1;
    return NChooseKRecursive(n - 1, k - 1) + NChooseKRecursive(n - 1, k);
  }

  // iterative, optimized O(nk)
  public static int NChooseK(int n, int k){
    int[,] table = new int[n + 1, k + 1];

    for(int i = 0; i <= n; i++){
      for(int j = 0; j <= Math.Min(i, k); j++){
        if(j == 0 || j == i) table[i, j] = 1;
        else table[i, j] = table[i - 1, j - 1] + table[i - 1, j];
      }
    }

    return table[n, k];
  }
}
