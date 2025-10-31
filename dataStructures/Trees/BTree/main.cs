using System;

// S - O(n)
public class BTree {
    private readonly int MAX_CHILDREN = 4;

    private class Node {
        public int childrenCount;
        public Entry[] children;
        public Node(int childrenCount, int maxChildren){
            this.childrenCount = childrenCount;
            this.children = new Entry[maxChildren];
        }
    }

    private class Entry {
        public int key, value;
        public Node next;
        public Entry(int key, int value, Node next){
            this.key = key;
            this.value = value;
            this.next = next;
        }
    }

    private Node root;
    private readonly int MAX_CHILDREN = 4;
    private int height, size;

    public BTree(){ root = new Node(0, MAX_CHILDREN); }

    public bool isEmpty(){ return size == 0; }

    public int Size(){ return size; }

    public int Height(){ return height; }

    private Node Split(Node node){
        Node newNode = new Node(MAX_CHILDREN / 2, MAX_CHILDREN);
        node.childrenCount = MAX_CHILDREN / 2;

        for(int i = 0; i < MAX_CHILDREN / 2; i++){
            newNode.children[i] = node.children[(MAX_CHILDREN/2) + i];
        }

        return newNode;
    }

    // T - O(logn)
    public int? Find(int key){
        return FindHelper(root, key, height);
    }

    private int? FindHelper(Node current, int key, int height){
        Entry[] children = current.children;

        if(height == 0){
            for(int i = 0; i < current.childrenCount; i++){
                if(key == children[i].key){ return children[i].value; }
            }
        } else {
            for(int i = 0; i < current.childrenCount; i++){
                if(i + 1 == current.childrenCount || key < children[i + 1].key){
                    return FindHelper(children[i].next, key, height - 1);
                }
            }
        }

        return null;
    }

    // T - O(logn)
    public void Insert(int key, int value){

        Node updatedNode = InsertHelper(root, key, value, height);

        size++;

        if(updatedNode == null){ return; }

        Node splitRoot = new Node(2, MAX_CHILDREN);

        splitRoot.children[0] = new Entry(root.children[0].key, 0, root);
        splitRoot.children[1] = new Entry(updatedNode.children[0].key, 0, updatedNode);
        splitRoot.childrenCount = 2;

        root = splitRoot;
        height++;
    }

    private Node InsertHelper(Node current, int key, int value, int height){
        int j;
        Entry newEntry = new Entry(key, value, null);

        if(height == 0){
            for(j = 0; j < current.childrenCount; j++){
                if(key < current.children[j].key){ break; }
            }
        } else {
            for(j = 0; j < current.childrenCount; j++){
                if(j + 1 == current.childrenCount || key < current.children[j + 1].key){
                    Node updatedNode = InsertHelper(current.children[j+ 1].next, key, value, height - 1);
                    if(updatedNode == null){ return null; }
                    newEntry.key = updatedNode.children[0].key;
                    newEntry.value = updatedNode.children[0].value;
                    newEntry.next = updatedNode;
                    break;
                }
            }
        }

        for(int i = current.childrenCount; i > j; i--){
            current.children[i] = current.children[i - 1];
        }

        current.children[j] = newEntry;
        current.childrenCount++;

        if(current.childrenCount < MAX_CHILDREN){ return null; }
        else{ return Split(current); }
    }
}