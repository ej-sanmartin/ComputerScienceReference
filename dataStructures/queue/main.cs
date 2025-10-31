using System;

/// <summary>
/// Represents a queue data structure implemented as a linked list.
/// </summary>
public class Queue {
    private class Node {
        public int Value { get; set; }
        public Node Next { get; set; }

        public Node(int value) {
            Value = value;
        }
    }

    private Node head, tail;
    private int size;

    /// <summary>
    /// Checks if the queue is empty.
    /// </summary>
    /// <returns>True if the queue is empty, false otherwise.</returns>
    // T - O(1)
    public bool IsEmpty() {
        return head == null;
    }

    /// <summary>
    /// Gets the size of the queue.
    /// </summary>
    /// <returns>The number of elements in the queue.</returns>
    // T - O(1)
    public int Size() {
        return size;
    }

    /// <summary>
    /// Returns the value at the front of the queue without removing it.
    /// </summary>
    /// <returns>The value at the front of the queue.</returns>
    // T - O(1)
    public int Peek() {
        return head.Value;
    }

    /// <summary>
    /// Adds an element to the end of the queue.
    /// </summary>
    /// <param name="value">The value to add.</param>
    // T - O(1)
    public void Enqueue(int value) {
        Node newNode = new Node(value);

        if (tail != null) {
            tail.Next = newNode;
        }

        tail = newNode;
        if (IsEmpty()) {
            head = tail;
        }
        size++;
    }

    /// <summary>
    /// Removes and returns the element at the front of the queue.
    /// </summary>
    /// <returns>The value at the front of the queue.</returns>
    // T - O(1)
    public int Dequeue() {
        if (head == null) {
            throw new System.InvalidOperationException("Queue is empty. Cannot dequeue.");
        }

        int data = head.Value;
        head = head.Next;

        if (IsEmpty()) {
            tail = null;
        }

        size--;
        return data;
    }
}