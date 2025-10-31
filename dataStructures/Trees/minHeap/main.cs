/// <summary>
/// Represents a min heap data structure.
/// </summary>
public class MinHeap {
    private int[] heap;
    private int size;
    private int maxSize;
    private const int Front = 1;

    /// <summary>
    /// Initializes a new instance of the MinHeap class with the specified maximum size.
    /// </summary>
    /// <param name="maxSize">The maximum size of the heap.</param>
    public MinHeap(int maxSize) {
        this.maxSize = maxSize;
        this.size = 0;
        heap = new int[this.maxSize + 1];
        heap[0] = int.MaxValue;
    }

    private int GetParent(int index) {
        return index / 2;
    }

    private int GetLeftChild(int index) {
        return 2 * index;
    }

    private int GetRightChild(int index) {
        return 2 * index + 1;
    }

    private bool IsLeaf(int index) {
        if (index >= (size / 2) && index <= size) {
            return true;
        }
        return false;
    }

    private void Swap(int a, int b) {
        int temporary = heap[a];
        heap[a] = heap[b];
        heap[b] = temporary;
    }

    private void MinHeapify(int index) {
        if (!IsLeaf(index)) {
            if (heap[index] > heap[GetLeftChild(index)] || heap[index] > heap[GetRightChild(index)]) {
                if (heap[GetLeftChild(index)] < heap[GetRightChild(index)]) {
                    Swap(index, GetLeftChild(index));
                    MinHeapify(GetLeftChild(index));
                } else {
                    Swap(index, GetRightChild(index));
                    MinHeapify(GetRightChild(index));
                }
            }
        }
    }

    /// <summary>
    /// Builds a heap from the current array.
    /// </summary>
    public void Heapify() {
        for (int index = (size / 2); index >= 1; index--) {
            MinHeapify(index);
        }
    }

    /// <summary>
    /// Inserts a new element into the heap.
    /// </summary>
    /// <param name="element">The element to insert.</param>
    // T - O(log n)
    public void Insert(int element) {
        if (size >= maxSize) {
            return;
        }

        heap[++size] = element;
        int current = size;

        while (heap[current] < heap[GetParent(current)]) {
            Swap(current, GetParent(current));
            current = GetParent(current);
        }
    }

    /// <summary>
    /// Removes and returns the minimum element from the heap.
    /// </summary>
    /// <returns>The minimum element in the heap.</returns>
    // T - O(log n)
    public int Pop() {
        int data = heap[Front];
        heap[Front] = heap[size--];
        MinHeapify(Front);
        return data;
    }
}