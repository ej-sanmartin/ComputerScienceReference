class MathHelper {
  public static bool NumberIsPowerOf(int num, int pow){
    return Math.Log(num, pow) % 1 == 0;
  }
}
