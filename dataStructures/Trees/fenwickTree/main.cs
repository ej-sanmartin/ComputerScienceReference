using System;

// This implementation of the tree is implemented with a fixed array
public class FenwickTree {
    int[] arr;
    public FenwickTree(int size){ arr = new int[size + 1]; }

    // DRY-ing code since this showed up more than once, just manually handles if developer trying to access non existent index
    private void OutOfRangeHandler(int index){
        if(index < 0 || index >= arr.Length){ throw new ArgumentOutOfRangeException("Index out of bounds."); }
    }

    // T - O(logn)
    public int RangeSumQuery(int index){
        OutOfRangeHandler(index);

        int sum = 0;

        while(index > 0){
            sum += arr[index];
            index -= index & (-index);
        }

        return sum;
    }

    // T - O(logn)
    public int RangeSumQueryBetweenPoints(int a, int b){
        if(!(b >= a && a > 0 && b > 0)){ throw new InvalidOperationException("Invalid arguments. Make sure indexes are not negative and that the second argument is larger than the first."); }

        return RangeSumQuery(b) - RangeSumQuery(a - 1);
    }

    // T - O(logn)
    public void Update(int index, int value){
        OutOfRangeHandler(index);

        while(index < arr.Length){
            arr[index] += value;
            index += index & (-index);
        }
    }
}