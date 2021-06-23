using System.Collections.Generic;

class BinaryHelper {
  public List<int> ToBinary(int n){
    List<int> output = new List<int>();
    while(n > 0){
      output.Add(n % 2);
      n /= 2;
    }
    return output.Reverse();
  }
}
