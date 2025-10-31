/// <summary>
/// Represents a stack data structure implemented as a linked list.
/// </summary>
public class Stack {
    private class Node {
        public int Value { get; set; }
        public Node Next { get; set; }

        public Node(int value) {
            Value = value;
        }
    }

    private Node head;
    private int size;

    /// <summary>
    /// Checks if the stack is empty.
    /// </summary>
    /// <returns>True if the stack is empty, false otherwise.</returns>
    // T - O(1)
    public bool IsEmpty() {
        return head == null;
    }

    /// <summary>
    /// Returns the value at the top of the stack without removing it.
    /// </summary>
    /// <returns>The value at the top of the stack.</returns>
    // T - O(1)
    public int Peek() {
        return head.Value;
    }

    /// <summary>
    /// Gets the size of the stack.
    /// </summary>
    /// <returns>The number of elements in the stack.</returns>
    // T - O(1)
    public int Size() {
        return size;
    }

    /// <summary>
    /// Adds an element to the top of the stack.
    /// </summary>
    /// <param name="value">The value to add.</param>
    // T - O(1)
    public void Push(int value) {
        Node newNode = new Node(value);

        if (IsEmpty()) {
            head = newNode;
            size++;
            return;
        }

        newNode.Next = head;
        head = newNode;
        size++;
    }

    /// <summary>
    /// Removes and returns the element at the top of the stack.
    /// </summary>
    /// <returns>The value at the top of the stack.</returns>
    // T - O(1)
    public int Pop() {
        int data = head.Value;
        head = head.Next;
        size--;
        return data;
    }
}