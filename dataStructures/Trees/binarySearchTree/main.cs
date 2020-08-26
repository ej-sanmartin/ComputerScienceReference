using System;

// This binary search tree allows no duplicate keys

public class BinarySearchTree {
    private class Node {
        private int key;
        private String value;
        private Node left, right;
        public Node(int key, String value){
            this.key = key;
            this.value = value;
        }

        public Node min(){
            if(left == null){ return this; }
            else { return left.min(); }
        }
    }

    private Node root;

    public BinarySearchTree(){ root = null; }

    // T - O(n)
    public Node FindMin(Node node){ return node.min(); }

    // T - O(logn)
    public void Insert(int key, String value){
        root = InsertHelper(root, key, value);
    }

    private Node InsertHelper(Node node, int key, String value){
        Node newNode = new Node(key, value);

        if(node == null){
            node = newNode;
            return node;
        }

        if(key < node.key){
            node.left = InsertHelper(node.left, key, value);
        } else {
            node.right = InsertHelper(node.right, key, value);
        }

        return node;
    }

    // T - O(logn)
    public String Find(int key){
        Node node  = FindHelper(root, key);
        return node == null ? null : node.value;
    }

    private Node FindHelper(Node node, int key){
        if(node == null || node.key == key){return node; }
        else if(key < node.key){ return FindHelper(node.left, key); }
        else if(key > node.key){ return FindHelper(node.right, key); }
        return null;
    }

    // T - O(h)
    public void Delete(int key){ root = DeleteHelper(root, key); }

    private Node DeleteHelper(Node node, int key){
        if(node == null){ return null; }
        else if(key < node.key){ node.left = DeleteHelper(node.left, key); }
        else if(key > node.key){ node.right = DeleteHelper(node.right, key); }
        else {
            if(node.left == null && node.right == null){ node = null; }

            else if(node.left == null){ node = node.right; }
            else if(node.right == null) { node = node.left; }

            else {
                Node minRight = FindMin(node.right);
                node.key = minRight.key;
                node.value = minRight.value;
                node.right = DeleteHelper(node.right, key);
            }
        }

        return node;
    }

    // T - O(n)
    public void PrintInOrder(){ InOrderTraversal(root); }

    private void InOrderTraversal(Node node){
        if(node != null){
            InOrderTraversal(node.left);
            Console.WriteLine(node.key);
            InOrderTraversal(node.right);
        }
    }

    // T - O(n)
    public void PrintPreOrder(){ PreOrderTraversal(root); }

    private void PreOrderTraversal(Node node){
        if(node != null){
            Console.WriteLine(node.key);
            PreOrderTraversal(node.left);
            PreOrderTraversal(node.right);
        }
    }

    // T - O(n)
    public void PrintPostOrder(){ PostOrderTraversal(root); }

    private void PostOrderTraversal(Node node){
        if(node != null){
            PostOrderTraversal(node.left);
            PostOrderTraversal(node.right);
            Console.WriteLine(node.key);
        }
    }
}