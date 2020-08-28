using System;

public class MaxHeap {
    private int capacity = 10;
    private int size;
    private int[] items = new int[capacity];

    private int leftChildIndex(int parentIndex){ return parentIndex * 2 + 1; }
    private int rightChildIndex(int parentIndex){ return parentIndex * 2 + 2; }
    private int parentIndex(int childIndex){ return (childIndex - 1)/2; }

    private bool hasLeftChild(int index){ return leftChildIndex(index) < size; }
    private bool hasRightChild(int index){ return rightChildIndex(index) < size; }
    private bool hasParent(int index){ return parentIndex(index) >= 0; }

    private int getLeftChild(int index){ return items[leftChildIndex(index)]; }
    private int getRightChild(int index){ return items[rightChildIndex(index)]; }
    private int getParent(int index){ return items[parentIndex(index)]; }

    private void Swap(int a, int b){
        int temporary = items[a];
        items[a] = items[b];
        items[b] = temporary;
    }

    private void HeapifyUp(){
        int index = size - 1;
        while(hasParent(index) && getParent(index) < items[index]){
            Swap(parentIndex(index), index);
            index = parentIndex(index);
        }
    }

    private void HeapifyDown(){
        int index = 0;

        while(hasLeftChild(index)){
            int smallerChildIndex = leftChildIndex(index);

            if(hasRightChild(index) && getRightChild(index) > getLeftChild(index)){
                smallerChildIndex = rightChildIndex(index);
            }

            if(items[index] > items[smallerChildIndex]){ break; }
            else {
                Swap(index, smallerChildIndex);
                index = smallerChildIndex;
            }
        }
    }

    private void EnsureCapacity(){
        if(size == capacity){
            int[] newItems = new int[capacity* 2];
            
            for(int i = 0; i < capacity; i++){
                newItems[i] = items[i];
            }

            items = newItems;
            capacity *= 2;
        }
    }

    // T - O(logn)
    public int ExtractMax(){
        if(size == 0){ throw new System.InvalidOperationException("Sorry, Max Heap is empty"); }

        int item = items[0];
        items[0] = items[size - 1];
        size--;
        HeapifyDown();
        return item;
    }

    // T - O(logn)
    public void Insert(int item){
        EnsureCapacity();
        items[size] = item;
        size++;
        HeapifyUp();
    }
}