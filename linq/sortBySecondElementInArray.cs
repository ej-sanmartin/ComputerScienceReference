using System;
using System.Linq;

class LinqHelper {
  public static List<List<int>> sortBySecondElement(List<List<int>> arr){
    return arr.OrderBy(x => x[0]).OrderBy(y => y[1]).ToList();
  }
}
