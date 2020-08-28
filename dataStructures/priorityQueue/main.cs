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