using System;

/// <summary>
/// Represents a doubly linked list data structure.
/// </summary>
public class DoublyLinkedList {
    private class Node {
        public int Value { get; set; }
        public Node Next { get; set; }
        public Node Previous { get; set; }

        public Node(int value) {
            Value = value;
        }
    }

    private Node head;
    private int size;

    /// <summary>
    /// Initializes a new instance of the DoublyLinkedList class with a single node.
    /// </summary>
    /// <param name="value">The initial value for the list.</param>
    public DoublyLinkedList(int value) {
        head = new Node(value);
        size = 1;
    }

    /// <summary>
    /// Checks if the doubly linked list is empty.
    /// </summary>
    /// <returns>True if the list is empty, false otherwise.</returns>
    // T - O(1)
    public bool IsEmpty() {
        return head == null;
    }

    /// <summary>
    /// Clears all elements from the doubly linked list.
    /// </summary>
    // T - O(1)
    public void Clear() {
        head = null;
        size = 0;
    }

    /// <summary>
    /// Gets the size of the doubly linked list.
    /// </summary>
    /// <returns>The number of elements in the list.</returns>
    // T - O(1)
    public int Size() {
        return size;
    }

    /// <summary>
    /// Returns the value at the front of the doubly linked list without removing it.
    /// </summary>
    /// <returns>The value at the front of the list.</returns>
    // T - O(1)
    public int Peak() {
        return head.Value;
    }

    // T - O(1)
    public void Pop(){
        if(isEmpty()){ throw new System.InvalidOperationException("Doubly Linked List empty. Likely nothing to pop"); }

        Node oldHead = head; // reference to old Head node
        head.next.previous = null; // detatch link between next node and old head through next node's previous reference
        head = head.next; // move head to be pointing to our new head
        oldHead.next = null; // remove oldHead entirely by having its next reference point to null

        size--;
    }

    // T - O(1)
    // utility function to be used if adding to an empty DLL
    private void NewHead(int value){
        head = new Node(value);
        size++;
    }

    // T - O(1)
    public void AddFront(int value){
        if(isEmpty()){
            NewHead(value);
            return;
        }

        Node newNode = new Node(value);
        newNode.next = head;
        head.previous = newNode;
        head = newNode;
        size++;
    }

    // T - O(n)
    public void AddBack(int value){
        if(isEmpty()){
            NewHead(value);
            return;
        }

        Node newNode = new Node(value);
        Node current = head;
        
        if(head.next == null){
            head.next = newNode;
            newNode.previous = head;
            size++;
            return;
        }

        while(current.next != null){
            current = current.next;
        }

        current.next = newNode;
        newNode.previous = current;
        size++;
    }

    // T - O(n)
    public void RemoveAtEnd(){
        if(isEmpty()){ throw new System.InvalidOperationException("Doubly Linked List Empty, nothing to remove"); }

        if(size == 1){ Pop(); }

        Node current = head;

        while(current.next.next != null){
            current = current.next;
        }

        current.next.previous = null;
        current.next = null;
        size--;
    }

    // T - O(n)
    // Removes first instance of a value
    public void RemoveValue(int value){
        if(isEmpty()){ throw new System.InvalidOperationException("Doubly linked list is empty. Nothing to remove"); }

        if(head.value == value){ Pop(); }

        Node current = head;

        while(current.next.value != value){
            current = current.next;
        }

        Node deletedNode = current.next;
        current.next.next.previous = current;
        current.next = current.next.next;
        deletedNode.next = null;
        deletedNode.previous = null;
        size--;
    }
}