using System;

// S - O(n)
public class RedBlackTree {
    private static readonly bool RED = true;
    private static readonly bool BLACK = false;

    private class Node {
        public int key, value, size;
        public bool color;
        public Node left, right;

        public Node(int key, int value, int size, bool color){
            this.key = key;
            this.value = value;
            this.size = size;
            this.color = color;
        }
    }

    private Node root;

    public RedBlackTree(){ root = null; }

    private bool isEmpty(){ return root == null; }

    private bool isRed(Node node){
        if(node == null){ return false; }
        return node.color == RED;
    }

    public int Size(){ return SizeHelper(root); }

    private int SizeHelper(Node node){
        if(node == null){ return 0; }
        return node.size;
    }

    public int Height(){ return HeightHelper(root); }

    private int HeightHelper(Node node){
        if(node == null){ return -1; }
        return 1 + Math.Max(HeightHelper(node.left), HeightHelper(node.right));
    }

    private Node Min(Node node){
        if(node == null){ throw new ArgumentNullException("Argument is null, cannot proceed with Min Function"); }

        if(node.left == null){ return node; }
        else { return Min(node.left); }
    }

    private Node Max(Node node){
        if(node == null){ throw new ArgumentNullException("Argument is null, cannot proceed with Max function"); }

        if(node.right == null){ return node; }
        else { return Max(node.right); }
    }

    private Node RotateRight(Node node){
        if(node == null || isRed(node.left)){ throw new ArgumentException("Please enter a valid argument"); }

        Node leftChild = node.left;
        node.left = leftChild.right;
        leftChild.right = node;
        leftChild.color = leftChild.right.color;
        leftChild.right.color = RED;
        leftChild.size = node.size;
        node.size = SizeHelper(node.left) + SizeHelper(node.right) + 1;
        return leftChild;
    }

    private Node RotateLeft(Node node){
        if(node == null || isRed(node.right)){ throw new ArgumentException("Please enter a valid argument"); }

        Node rightChild = node.right;
        node.right = rightChild.left;
        rightChild.left = node;
        rightChild.color = rightChild.left.color;
        rightChild.left.color = RED;
        rightChild.size = node.size;
        node.size = SizeHelper(node.left) + SizeHelper(node.right) + 1;
        return rightChild;
    }

    private void FlipColors(Node node){
        if(node != null && node.left != null && node.right != null){
            node.color = !node.color;
            node.left.color = !node.left.color;
            node.right.color = !node.right.color;
        }
    }

    private Node MoveRedLeft(Node node){
        if(node != null && isRed(node) && !isRed(node.left) && !isRed(node.right)){
            FlipColors(node);
            if(isRed(node.right.left)){
                node.right = RotateRight(node.right);
                node = RotateLeft(node);
                FlipColors(node);
            }

            return node;
        } else {
            throw new ArgumentException("Argument passed not valid for a left rotation");
        }
    }

    private Node MoveRedRight(Node node){
        if(node != null && isRed(node) && !isRed(node.left) && !isRed(node.right)){
            FlipColors(node);
            if(isRed(node.left.left)){
                node = RotateRight(node);
                FlipColors(node);
            }

            return node;
        } else {
            throw new ArgumentException("Argument passed not valid for a right rotation");
        }
    }

    private Node Balance(Node node){
        if(node == null){ throw new ArgumentNullException("Argument passed in Balance function cannot be null. There is nothing to balance if there is nothing."); }

        if(isRed(node.left)){ node = RotateLeft(node); }
        if(isRed(node.left) && isRed(node.left.left)){ node = RotateRight(node); }
        if(isRed(node.left) && isRed(node.right)){ FlipColors(node); }

        node.size = SizeHelper(node.left) + SizeHelper(node.right) + 1;
        return node;
    }

    // T - O(logn)
    public int? Find(int key){
        return FindHelper(root, key);
    }

    private int? FindHelper(Node node, int key){
        while(node != null){
            if(key < node.key){ node = node.left; }
            else if(key > node.key){ node = node.right; }
            else { return node.value; }
        }
        return null;
    }

    public bool Contains(int key){ return Find(key) != null; }

    // T - O(logn)
    public void Insert(int key, int value){

        root = InsertHelper(root, key, value);
        root.color = BLACK;
    }

    private Node InsertHelper(Node node, int key, int value){
        if(node == null){ return new Node(key, value, 1, RED); }

        if(key < node.key){ node.left = InsertHelper(node.left, key, value); }
        else if(key > node.key){ node.right = InsertHelper(node.right, key, value); }
        else { node.value = value; }

        if(isRed(node.right) && !isRed(node.left)){ node = RotateLeft(node); }
        if(isRed(node.left) && isRed(node.left.left)){ node = RotateRight(node); }
        if(isRed(node.left) && isRed(node.right)){ FlipColors(node); }

        node.size = SizeHelper(node.left) + SizeHelper(node.right) + 1;

        return node;
    }

    public void DeleteMin(){
        if(isEmpty()){ throw new InvalidOperationException("Tree is empty. Nothing to delete"); }

        if(!isRed(root.left) && !isRed(root.right)){ root.color = RED; }

        root = DeleteMinHelper(root);

        if(!isEmpty()){ root.color = BLACK; }
    }

    private Node DeleteMinHelper(Node node){
        if(node.left == null){ return null; }

        if(!isRed(node.left) && !isRed(node.left.left)){ node = MoveRedLeft(node); }

        node.left = DeleteMinHelper(node.left);

        return Balance(node);
    }

    public void DeleteMax(){
        if(isEmpty()){ throw new InvalidOperationException("Tree is empty. Likely nothing to delete"); }

        if(!isRed(root.left) && !isRed(root.right)){ root.color = RED; }

        root = DeleteMaxHelper(root);

        if(!isEmpty()){ root.color = BLACK; }
    }

    private Node DeleteMaxHelper(Node node){
        if(isRed(node.left)){ node = RotateRight(node); }

        if(node.right == null){ return null; }

        if(!isRed(node.right) && !isRed(node.right.left)){ node = MoveRedRight(node); }

        node.right = DeleteMaxHelper(node.right);

        return Balance(node);
    }

    // T - O(logn)
    public void Delete(int key){
        if(!Contains(key)){ return; }

        if(!isRed(root.left) && !isRed(root.right)){ root.color = RED; }

        root = DeleteHelper(root, key);

        if(!isEmpty()){ root.color = BLACK; }
    }

    private Node DeleteHelper(Node node, int key){
        if(key < node.key){
            if(!isRed(node.left) && !isRed(node.left.left)){ node = MoveRedLeft(node); }
            node.left = DeleteHelper(node.left, key);
        } else {
            if(isRed(node.left)){ node = RotateRight(node); }
            if(key == node.key && node.right == null){ return null; }
            if(!isRed(node.right) && !isRed(node.right.left)){ node = MoveRedRight(node); }
            if(key == node.key){
                Node minNode = Min(node.right);
                node.key = minNode.key;
                node.value = minNode.value;
                node.right = DeleteMinHelper(node.right);
            } else {
                node.right = DeleteHelper(node.right, key);
            }
        }

        return Balance(node);
    }
}