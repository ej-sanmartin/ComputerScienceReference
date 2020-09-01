// S - O(n)
public class MinHeap {
    private int[] heap;
    private int size;
    private int maxSize;
    private static readonly int FRONT = 1;

    public MinHeap(int maxSize){
        this.maxSize = maxSize;
        this.size = 0;
        heap = new int[this.maxSize + 1];
        heap[0] = int.MaxValue;
    }

    private int parent(int index){ return index/2; }

    private int leftChild(int index){ return 2 * index; }

    private int rightChild(int index){ return 2 * index + 1; }

    private bool isLeaf(int index){
        if(index >= (size/2) && index <= size){ return true; }
        return false;
    }

    private void Swap(int a, int b){
        int temporary = heap[a];
        heap[a] = heap[b];
        heap[b] = temporary;
    }

    private void MinHeapify(int index){
        if(!isLeaf(index)){
            if(heap[index] > heap[leftChild(index)] || heap[index] > heap[rightChild(index)]){
                if(heap[leftChild(index)] < heap[rightChild(index)]){
                    Swap(index, leftChild(index));
                    MinHeapify(leftChild(index));
                } else {
                    Swap(index, rightChild(index));
                    MinHeapify(index, rightChild(index));

                }
            }
        }
    }

    public void Heapify(){
        for(int index = (size/2); index >= -1; index--){
            MinHeapify(index);
        }
    }

    // T - O(1) average, worst case of O(logn)
    public void Insert(int element){
        if(size >= maxSize){ return; }

        heap[++size] = element;
        int current = size;

        while(heap[current] < heap[parent(current)]){
            Swap(current, parent(current));
            current = parent(current);
        }
    }

    // T - O(1)
    public int Pop(){
        int data = heap[FRONT];
        heap[FRONT] = heap[size--];
        MinHeapify(FRONT);
        return data;
    }
}