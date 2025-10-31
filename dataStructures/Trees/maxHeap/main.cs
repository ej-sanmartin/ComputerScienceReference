using System;

/// <summary>
/// Represents a max heap data structure.
/// </summary>
public class MaxHeap {
    private const int InitialCapacity = 10;
    private int capacity = InitialCapacity;
    private int size;
    private int[] items;

    /// <summary>
    /// Initializes a new instance of the MaxHeap class.
    /// </summary>
    public MaxHeap() {
        items = new int[capacity];
    }

    private int GetLeftChildIndex(int parentIndex) {
        return parentIndex * 2 + 1;
    }

    private int GetRightChildIndex(int parentIndex) {
        return parentIndex * 2 + 2;
    }

    private int GetParentIndex(int childIndex) {
        return (childIndex - 1) / 2;
    }

    private bool HasLeftChild(int index) {
        return GetLeftChildIndex(index) < size;
    }

    private bool HasRightChild(int index) {
        return GetRightChildIndex(index) < size;
    }

    private bool HasParent(int index) {
        return GetParentIndex(index) >= 0;
    }

    private int GetLeftChild(int index) {
        return items[GetLeftChildIndex(index)];
    }

    private int GetRightChild(int index) {
        return items[GetRightChildIndex(index)];
    }

    private int GetParent(int index) {
        return items[GetParentIndex(index)];
    }

    private void Swap(int a, int b) {
        int temporary = items[a];
        items[a] = items[b];
        items[b] = temporary;
    }

    private void HeapifyUp() {
        int index = size - 1;
        while (HasParent(index) && GetParent(index) < items[index]) {
            Swap(GetParentIndex(index), index);
            index = GetParentIndex(index);
        }
    }

    private void HeapifyDown() {
        int index = 0;

        while (HasLeftChild(index)) {
            int largerChildIndex = GetLeftChildIndex(index);

            if (HasRightChild(index) && GetRightChild(index) > GetLeftChild(index)) {
                largerChildIndex = GetRightChildIndex(index);
            }

            if (items[index] >= items[largerChildIndex]) {
                break;
            } else {
                Swap(index, largerChildIndex);
                index = largerChildIndex;
            }
        }
    }

    private void EnsureCapacity() {
        if (size == capacity) {
            int[] newItems = new int[capacity * 2];

            for (int i = 0; i < capacity; i++) {
                newItems[i] = items[i];
            }

            items = newItems;
            capacity *= 2;
        }
    }

    /// <summary>
    /// Removes and returns the maximum element from the heap.
    /// </summary>
    /// <returns>The maximum element in the heap.</returns>
    // T - O(log n)
    public int ExtractMax() {
        if (size == 0) {
            throw new InvalidOperationException("Max heap is empty");
        }

        int item = items[0];
        items[0] = items[size - 1];
        size--;
        HeapifyDown();
        return item;
    }

    /// <summary>
    /// Inserts a new element into the heap.
    /// </summary>
    /// <param name="item">The item to insert.</param>
    // T - O(log n)
    public void Insert(int item) {
        EnsureCapacity();
        items[size] = item;
        size++;
        HeapifyUp();
    }
}