using System;

public class LinkedList {
    private class Node {
        public int value;
        public Node next;
        public Node(int value){ this.value = value; }
    }

    private int size = 0;
    private Node head;

    // T - O(1)
    public bool isEmpty(){ return head == null; }

    // T - O(1)
    public int peak(){ return head.value; }

    // T - O(1)
    public void Clear(){ head = null; }

    // T - O(1)
    public int GetSize(){ return size; }

    // T - O(1)
    public void AddFront(int value){
        Node newNode = new Node(value);
        if(heaad == null){
            head = newNode;
            size++;
            return;
        }

        newNode.next = head;
        head = newNode;
        size++;
    }

    // T - O(n)
    public void AddLast(int value){
        Node nextNode = new Node(value);
        if(isEmpty()){
            head = newNode;
            size++;
            return;
        }

        Node current = head;

        while(current.next != null){
            current = current.next;
        }

        current.next = newNode;
        size++;
    }

    // T - O(1)
    public int Pop(){
        if(isEmpty()){
            throw new System.InvalidOperationException("Linked List is empty. Cannot pop anything.");
        }

        int data = head.value;
        head = head.next;
        size--;
        return data;
    }

    // T - O(n)
    public void RemoveValue(int value){
        if(isEmpty()){
            throw new System.InvalidOperationException("Sorry, Linked List is empty. Value not likely to be found.");
        }

        if(head.value == value){
            Pop();
            size--;
            return;
        }

        Node current = head;

        while(current.next != null){
            if(current.next.value == value){
                current.next = current.next.next;
                size--;
                return;
            }
            current = current.next;
        }

        Console.Write("Value not found");
    }

    // T - O(n)
    public void RemoveLast(){
        if(isEmpty()){
            throw new System.InvalidOperationException("Linked List is empty. Nothing to remove.");
        }

        if(head.next == null){ Pop(); }

        Node current = head;

        while(true){
            if(current.next.next == null){
                current.next = null;
                size--;
                return;
            }

            current = current.next;
        }
    }

    // T - O(n)
    public bool Contains(int value){
        if(isEmpty()){
            return false;
        }

        if(head.value == value){ return true; }

        Node current = head;

        while(current != null){
            if(current.value == value) return true;
            current = current.next;
        }
        
        return false;
    }

    // T - O(n)
    public bool ContainsCycle(){
        Node slow = head;
        Node fast = head;
        
        while(slow != null && fast != null && fast.next != null){
            slow = slow.next;
            fast = fast.next.next;
            if(slow == fast) return true;
        }

        return false;
    }
    
    public int FindMid(){
        if (IsEmpty()) return 0;
        
        Node current = head;

        if (current.next == null) return current.value;

        Node mid = current;
        current= current.next.next;

        while (current != null){
            mid = mid.next;

            current = current.next;
            if (current != null) current = current.next;     // pointing to current's next
        }
                                  
        if (mid != null) return mid.value;
        return 0;
    }
    
    // T - O(n)
    // S - O(1)/ O(n) in recursive solution
    public void ReverseIterative(){
        Node previous = null;
        Node current = head;
        Node next = null;
        
        while(current != null){
            next = current.next;
            current.next = previous;
            previous = current;
            current = next;
        }
        head = previous;
    }
    
    public Node ReverseRecursive(Node head){
        if(head == null || head.next == null) return head;
        Node reversedListHead = ReverseRecursive(head.next);
        head.next.next = head;
        head.next = null;
        return reversedListHead;
    }
}
