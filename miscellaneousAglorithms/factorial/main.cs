class MathHelper {
  public int Factorial(int n){
    if(n < 2) return 1;
    int factorialNumber = 1;
    for(int i = 2; i <= n; i++){
      factorialNumber *= i;
    }
    return factorialNumber;
  }
}
