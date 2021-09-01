  /*
    Implement C's ATOI, which takes a string and outputs its integer
    equivalent if the string is a valid integer
  
    T - O(n), n where n is length of input string we must traverse through
    S - O(1), no extra space created besides constant space ints
  */
class Atoi {
  public static int ATOI(string s){
    if(s == null || s.Length == 0){
      return -1;
    }

    int sign = 1;
    int result = 0;
    int i = 0;

    while(s[i] == ' '){
      i++;
    }

    if(s[i] == '+' || s[i] == '-'){
      sign = 1 - 2 * (s[i++] == '-' ? 1 : 0);
    }

    // check if first non whitespace is not even a + or -
    if(char.IsDigit(s[i]) == false){
      return -1;
    }

    while(i < s.Length && s[i] >= '0' && s[i] <= '9'){
      if(IsNearInfinity(result, s[i] - '0')){
        if(sign == 1){
          return Int32.MaxValue;
        } else {
          return Int32.MinValue;
        }
      }

      result = result * 10 + (s[i++] - '0');
    }

    // if loop breaks early, non digit in string
    if(i < s.Length){
        return -1;
    }

    return result * sign;
  }

  public static bool IsNearInfinity(int total, int num){
    if(total > Int32.MaxValue / 10 || (total == Int32.MaxValue / 10 && num > 7)){
      return true;
    }
    return false;
  }
}
