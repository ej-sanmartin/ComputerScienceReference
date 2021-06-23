class MathHelper {
  public bool isPrime(int n){
    int squaredN = n * n;
    for(int i = 2; i < n; i++){
      for(int j = 1; j < squaredN; j++){
        if(i * j == n) return false;
      }
    }
    return true;
  }
}
