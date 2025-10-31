using System;

/// <summary>
/// Represents a dynamic array that automatically resizes as elements are added.
/// </summary>
public class DynamicArray {
    private object[] data;
    private int size;
    private int initialCapacity;

    /// <summary>
    /// Initializes a new instance of the DynamicArray class with the specified capacity.
    /// </summary>
    /// <param name="initialCapacity">The initial capacity of the array.</param>
    public DynamicArray(int initialCapacity) {
        this.initialCapacity = initialCapacity;
        data = new object[initialCapacity];
    }

    /// <summary>
    /// Gets the element at the specified index.
    /// </summary>
    /// <param name="index">The index of the element to get.</param>
    /// <returns>The element at the specified index.</returns>
    // T - O(1)
    public object Get(int index) {
        return data[index];
    }

    /// <summary>
    /// Sets the element at the specified index.
    /// </summary>
    /// <param name="index">The index to set.</param>
    /// <param name="value">The value to set.</param>
    // T - O(1)
    public void Set(int index, object value) {
        data[index] = value;
    }

    /// <summary>
    /// Gets the current size of the dynamic array.
    /// </summary>
    /// <returns>The number of elements in the array.</returns>
    // T - O(1)
    public int Size() {
        return size;
    }

    /// <summary>
    /// Checks if the dynamic array is empty.
    /// </summary>
    /// <returns>True if the array is empty, false otherwise.</returns>
    // T - O(1)
    public bool IsEmpty() {
        return size == 0;
    }

    /// <summary>
    /// Resizes the internal array when capacity is exceeded.
    /// </summary>
    // T - O(n)
    private void Resize() {
        object[] newData = new object[initialCapacity * 2];
        for (int i = 0; i < initialCapacity; i++) {
            newData[i] = data[i];
        }

        data = newData;
        initialCapacity *= 2;
    }

    /// <summary>
    /// Inserts a value at the specified index.
    /// </summary>
    /// <param name="index">The index to insert at.</param>
    /// <param name="value">The value to insert.</param>
    // T - O(n)
    public void Insert(int index, object value) {
        if (index >= initialCapacity) {
            throw new ArgumentException("Index out of bound");
        }

        if (size == initialCapacity) {
            Resize();
        }

        for (int i = size; i > index; i--) {
            data[i] = data[i - 1];
        }

        data[index] = value;
        size++;
    }

    /// <summary>
    /// Deletes the element at the specified index.
    /// </summary>
    /// <param name="index">The index to delete from.</param>
    // T - O(n)
    public void Delete(int index) {
        if (index >= initialCapacity || IsEmpty() || index > size - 1) {
            throw new ArgumentException("Index is out of range");
        }

        for (int i = index; i < size - 1; i++) {
            data[i] = data[i + 1];
        }

        size--;
    }

    /// <summary>
    /// Checks if the array contains the specified value.
    /// </summary>
    /// <param name="value">The value to search for.</param>
    /// <returns>True if the value is found, false otherwise.</returns>
    // T - O(n)
    public bool Contains(object value) {
        if (IsEmpty()) {
            return false;
        }

        for (int i = 0; i < size; i++) {
            if (data[i] == value) {
                return true;
            }
        }

        return false;
    }
}