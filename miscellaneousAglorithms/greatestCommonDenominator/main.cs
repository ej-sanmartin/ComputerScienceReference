// Based on Euclid's Algorithm
class MathHelper {
  public int GreatestCommonDenominator(int a, int b){
    if(b == 0) return a;
    return GreatestCommonDenominator(b, a % b);
  }
}
