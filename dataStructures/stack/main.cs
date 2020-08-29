public class Stack {
    private class Node {
        public int value;
        public Node next;
        public Node(int value){ this.value = value; }
    }

    private Node head;
    private int size;

    // T - O(1)
    public bool isEmpty(){ return head == null; }
    
    // T- O(1)
    public int Peak(){ return head.value; }

    // T - O(1)
    public int Size(){  return size; }

    // T - O(1)
    public void Push(int value){
        Node newNode = new Node(value);

        if(isEmpty()){
            head = newNode;
            size++;
            return;
        }

        newNode.next = head;
        head = newNode;
        size++;
    }

    // T - O(1)
    public int Pop(){
        int data = head.value;
        head = head.next;
        size--;
        return data;
    }
}