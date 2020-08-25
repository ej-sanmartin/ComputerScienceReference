using System;

public class DynamicArray {
    private Object[] data;
    private int size;
    private int initialCapacity;

    public DynamicArray(int initialCapacity){
        this.initialCapacity = initialCapacity;
        data = new Object[initialCapacity];
    }

    // T - O(1)
    public String Get(int index){ return (String)data[index]; }

    // T - O(1)
    public void Set(int index, String value){ data[index] = value; }

    // T - O(1)
    public int Size(){ return size; }

    // T - O(1)
    public bool isEmpty(){ return size == 0; }

    // T - O(n)
    private void Resize(){
        Object[] newData = new Object[initialCapacity * 2];
        for(int i = 0; i < initialCapacity; i++){
            newData[i] = data[i];
        }

        data = newData;
        initialCapacity *= 2;
    }

    // T - O(n)
    public void Insert(int index, String value){
        if(index >= initialCapacity){
            throw new ArgumentException("Index out of bound");
        }

        if(size == initialCapacity){ Resize(); }

        for(int i = size; i > index; i--){
            data[i] = data[i - 1];
        }

        data[index] = value;
        size++;
    }

    // T - o(n)
    public void Delete(int index){
        if(index >= initialCapacity || isEmpty() || index > size - 1){
            throw new ArgumentException("Index is out of range");
        }

        for(int i = index; i < size - 1; i++){
            data[i] = data[i + 1];
        }

        size--;
    }

    // T - O(n)
    public bool Contains(String value){
        if(isEmpty()){ return false; }

        for(int i = 0; i < size; i++){
            if(data[i] == value){ return true; }
        }

        return false;
    }
}