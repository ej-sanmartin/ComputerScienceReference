using System;
using System.Collections.Generic;

// Implemented as a max heap
public class PriorityQueue {
    private List<int> heap;
    private int size;

    public PriorityQueue(){
        heap = new List<int>();
        size = 0;
    }

    private void Swap(int a, int b){
        int temporary = heap[a];
        heap[a] = heap[b];
        heap[b] = temporary;
    }

    // T - O(logn)
    public void Insert(int value){
        int position = size;
        heap[position] = value;

        // HeapifyUp
        while(position > 0){
            int parent = (position + 1)/2 - 1;
            if(heap[parent] >= heap[position]){ break; }
            Swap(parent, position);
            position = parent;
        }

        size++;
    }

    // T - O(logn)
    public int Pop(){
        if(size == 0){ throw new System.InvalidOperationException("Priority Queue is empty, nothing to pop"); }

        int data = heap[0];
        heap[0] = heap[size - 1];
        int position = 0;
        size--;

        // HeapifyDown
        while(position < (size/2)){
            int leftChild = position * 2 + 1;
            int rightChild = leftChild + 1;

            if(rightChild < size && heap[leftChild] < heap[rightChild]){
                if(heap[position] >= heap[rightChild]){ break; }

                Swap(position, rightChild);
                position = rightChild;
            } else {
                if(heap[position] >= heap[leftChild]){ break; }

                Swap(position, leftChild);
                position = leftChild;
            }
        }

        return data;
    }
}


// implemented as a MinHeap
public class PQ {
    private int[] minHeap;
    private int capacity;
    private int size;
    
    public PQ(int capacity){
        this.capacity = capacity;
        this.minHeap = new int[capcaity];
        this.size = 0;
    }
    
    private void Swap(int a, int b){
        int temp = minHeap[a];
        minHeap[a] = minHeap[b];
        minHeap[b] = temp;
    }
    
    private int Parent(int key){
        return Math.Floor((key - 1)/2);
    }
    
    private int leftChild(int key){
        return 2 * key + 1;
    }
    
    private int rightChild(int key){
        return 2 * key + 2;
    }
    
    private void MinHeapify(int key){
        int left = leftChild(key);
        int right = rightChild(key);
        int smallest = key;
        
        if(left < size && minHeap[left] < minHeap[smallest]) smallest = left;
        if(right < size && minHeap[right] < minHeap[smallest]) smallest = right;
        if(smallest != key){
            Swap(key, smallest);
            MinHeapify(smallest);
        }
    }
    
    public int getMin() return minHeap[0];
     
    public int extractMin(){
        if(size == 0) return int.MaxValue;
        if(size == 1){
            size--;
            return minHeap[0];
        }
        
        int data = minHeap[0];
        size--;
        MinHeapify(0);
        return data;
    }
              
    public bool insertKey(int key){
        if(size == capacity) return false;
        
        int current = size;
        minHeap[current] = key;
        size++;
        
        while(current != 0 && minHeap[current] < minHeap[parent(current)]){
            Swap(current, Parent(current));
            current = Parent(current);
        }
    }
    
    public void deleteKey(int key){
        descreaseKey(key, int.MaxValue);
        extractMin();
    }
    
    public void increaseKey(int key, int newKey){
        minHeap[key] = newKey;
        MinHeapify(key);
    }
    
    public void descreaseKey(int key, int newKey){
        minHeap[key] = newKey;
        while(key != 0 && minHeap[key] < minHeap[Parent(key)]{
            Swap(key, Parent(key));
            key = Parent(key);
        }
    }
              
    public void ChangeValueOfKey(int key, int newKey){
        if(minHeap[key] == newKey) return;
        
        if(minHeap[key] < newKey){
            increaseKey(key, newKey);
        } else {
            decreaseKey(key, newKey);
        }
    }
}
