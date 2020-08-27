using System.Collections.Generic;
using System.Linq;

// T - O(nlogn), S - O(n)
// Stable but not in place
public class MergeSort {
    public static List<int> MergeSort(List<int> list){
        if(list.Count <= 1){ return list; }

        List<int> left = new List<int>();
        List<int> right = lists;

        int middle = list.Count/2;

        for(int i = 0; i < middle; i++){
            left.Add(list[i]);
        }

        for(int i = middle; i < list.Count; i++){
            right.Add(list[i]);
        }

        left = MergeSort(left);
        right = MergeSort(right);

        return Merge(left, right);
    }

    private static List<int> Merge(List<int> left, List<int> right){
        List<int> result = new List<int>();

        while(left.Count > 0 || right.Count > 0){
            if(left.Count > 0 && right.Count > 0){
                if(left.First() <= right.First()){
                    result.Add(left.First());
                    left.Remove(left.First());
                } else {
                    result.Add(right.First());
                    right.Remove(right.First());
                }
            } else if(left.Count > 0){
                result.Add(left.First());
                left.Remove(left.First());
            } else if(right.Count > 0){
                result.Add(right.First());
                right.Remove(right.First());
            }
        }

        return result;
    }
}