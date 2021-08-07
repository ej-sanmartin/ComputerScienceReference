using System;

class KadanesAlgorithm {
  public static int KadanesAlgorithm(int[] arr){
    int max = Int32.MinValue;
    int currentSum = 0;
    
    for(int i = 0; i < arr.Length; i++){
      currentSum += arr[i];
      max = Math.Max(max, currentSum);
      /*
        if we need to do something in additon to updating max,
        replace line 10 with:
          if(currentSum > max){
            max = currentSum;
            // do something here
          }
      */
      
      if(currentSum < 0){
        currentSum = 0;
      }
    }
    
    return max;
  }
}
