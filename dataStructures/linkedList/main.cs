using System;

/// <summary>
/// Represents a singly linked list data structure.
/// </summary>
public class LinkedList {
    private class Node {
        public int Value { get; set; }
        public Node Next { get; set; }

        public Node(int value) {
            Value = value;
        }
    }

    private int size = 0;
    private Node head;

    /// <summary>
    /// Checks if the linked list is empty.
    /// </summary>
    /// <returns>True if the list is empty, false otherwise.</returns>
    // T - O(1)
    public bool IsEmpty() {
        return head == null;
    }

    /// <summary>
    /// Returns the value at the front of the linked list without removing it.
    /// </summary>
    /// <returns>The value at the front of the list.</returns>
    // T - O(1)
    public int Peak() {
        return head.Value;
    }

    /// <summary>
    /// Clears all elements from the linked list.
    /// </summary>
    // T - O(1)
    public void Clear() {
        head = null;
        size = 0;
    }

    /// <summary>
    /// Gets the size of the linked list.
    /// </summary>
    /// <returns>The number of elements in the list.</returns>
    // T - O(1)
    public int GetSize() {
        return size;
    }

    /// <summary>
    /// Adds a new element to the front of the linked list.
    /// </summary>
    /// <param name="value">The value to add.</param>
    // T - O(1)
    public void AddFront(int value) {
        Node newNode = new Node(value);
        if (head == null) {
            head = newNode;
            size++;
            return;
        }

        newNode.Next = head;
        head = newNode;
        size++;
    }

    /// <summary>
    /// Adds a new element to the end of the linked list.
    /// </summary>
    /// <param name="value">The value to add.</param>
    // T - O(n)
    public void AddLast(int value) {
        Node newNode = new Node(value);
        if (IsEmpty()) {
            head = newNode;
            size++;
            return;
        }

        Node current = head;

        while (current.Next != null) {
            current = current.Next;
        }

        current.Next = newNode;
        size++;
    }

    /// <summary>
    /// Removes and returns the element at the front of the linked list.
    /// </summary>
    /// <returns>The value at the front of the list.</returns>
    // T - O(1)
    public int Pop() {
        if (IsEmpty()) {
            throw new System.InvalidOperationException("Linked List is empty. Cannot pop anything.");
        }

        int data = head.Value;
        head = head.Next;
        size--;
        return data;
    }

    /// <summary>
    /// Removes the first occurrence of the specified value from the linked list.
    /// </summary>
    /// <param name="value">The value to remove.</param>
    // T - O(n)
    public void RemoveValue(int value) {
        if (IsEmpty()) {
            throw new System.InvalidOperationException("Linked List is empty. Value not found.");
        }

        if (head.Value == value) {
            Pop();
            return;
        }

        Node current = head;

        while (current.Next != null) {
            if (current.Next.Value == value) {
                current.Next = current.Next.Next;
                size--;
                return;
            }
            current = current.Next;
        }

        Console.Write("Value not found");
    }

    /// <summary>
    /// Removes the last element from the linked list.
    /// </summary>
    // T - O(n)
    public void RemoveLast() {
        if (IsEmpty()) {
            throw new System.InvalidOperationException("Linked List is empty. Nothing to remove.");
        }

        if (head.Next == null) {
            Pop();
            return;
        }

        Node current = head;

        while (current.Next.Next != null) {
            current = current.Next;
        }

        current.Next = null;
        size--;
    }

    /// <summary>
    /// Checks if the linked list contains the specified value.
    /// </summary>
    /// <param name="value">The value to search for.</param>
    /// <returns>True if the value is found, false otherwise.</returns>
    // T - O(n)
    public bool Contains(int value) {
        if (IsEmpty()) {
            return false;
        }

        if (head.Value == value) {
            return true;
        }

        Node current = head;

        while (current != null) {
            if (current.Value == value) {
                return true;
            }
            current = current.Next;
        }

        return false;
    }

    /// <summary>
    /// Checks if the linked list contains a cycle.
    /// </summary>
    /// <returns>True if a cycle is detected, false otherwise.</returns>
    // T - O(n)
    public bool ContainsCycle() {
        Node slow = head;
        Node fast = head;

        while (slow != null && fast != null && fast.Next != null) {
            slow = slow.Next;
            fast = fast.Next.Next;
            if (slow == fast) {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Finds the middle element of the linked list.
    /// </summary>
    /// <returns>The value of the middle element.</returns>
    public int FindMid() {
        if (IsEmpty()) {
            return 0;
        }

        Node current = head;

        if (current.Next == null) {
            return current.Value;
        }

        Node mid = current;
        current = current.Next.Next;

        while (current != null) {
            mid = mid.Next;

            current = current.Next;
            if (current != null) {
                current = current.Next;
            }
        }

        if (mid != null) {
            return mid.Value;
        }
        return 0;
    }

    /// <summary>
    /// Reverses the linked list iteratively.
    /// </summary>
    // T - O(n), S - O(1)
    public void ReverseIterative() {
        Node previous = null;
        Node current = head;
        Node next = null;

        while (current != null) {
            next = current.Next;
            current.Next = previous;
            previous = current;
            current = next;
        }
        head = previous;
    }

    /// <summary>
    /// Reverses the linked list recursively.
    /// </summary>
    /// <param name="head">The head of the list to reverse.</param>
    /// <returns>The new head of the reversed list.</returns>
    public Node ReverseRecursive(Node head) {
        if (head == null || head.Next == null) {
            return head;
        }
        Node reversedListHead = ReverseRecursive(head.Next);
        head.Next.Next = head;
        head.Next = null;
        return reversedListHead;
    }
}
