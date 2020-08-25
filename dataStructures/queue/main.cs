using System;

public class Queue {
    private class Node {
        private int value;
        private Node next;
        public Node(int value){ this.value = value; }
    }

    private Node head, tail;
    private int size;

    // T - O(1)
    public bool isEmpty(){ return head == null; }

    // T - O(1)
    public int Size(){ return size; }

    // T - O(1)
    public int Peak(){ return head.value; }

    // T - O(1)
    public void Enqueue(int value){
        Node newNode = new Node(value);

        if(tail != null){ tail.next = newNode; }

        tail = newNode;
        if(isEmpty()){ head = tail; }
        size++;
    }

    // T O(1)
    public int Dequeue(){
        if(head == null){
            throw new System.InvalidOperationException("Sorry, Queue is empty. Likely nothing to remove.");
         }

        int data = head.value;
        head = head.next;

        if(isEmpty()){ tail = null; }

        size--;
        return data;
    }
}