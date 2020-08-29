using System;

public class AVLTree {
    private class Node {
        private int value, height, balanceFactor;
        private Node left, right;
        public Node(int value){
            this.value = value;
        }
    }

    private Node root;
    private int nodeCount = 0;

    public int Size(){ return nodeCount; }

    public Node FindMinimumNode(Node node){
        Node temporary = node;

        while(temporary.left != null){
            temporary = temporary.left;
        }

        return temporary;
    }

    public int Height(){
        if(root == null){ return 0; }
        return root.height;
    }

    private void Update(Node node){
        int leftNodeHeight = (node.left == null ? -1 : node.left.height);
        int rightNodeHeight = (node.right == null ? -1 : node.right.height);

        node.height = Math.Max(leftNodeHeight, rightNodeHeight) + 1;
        node.balanceFactor = rightNodeHeight - leftNodeHeight;
    }

    private Node Balance(Node node){
        if(node.balanceFactor == -2){
            if(node.left.balanceFactor <= 0){
                return LeftLeftCase(node);
            } else {
                return LeftRightCase(node);
            } 
        } else if(node.balanceFactor == 2){
            if(node.right.balanceFactor >= 0){
                return RightRightCase(node);
            } else {
                return RightLeftCase(node);
            }
        }

        return node;
    }

    private Node LeftLeftCase(Node node){ return RightRotation(node); }

    private Node LeftRightCase(Node node){
        node.left = LeftRotation(node.left);
        return LeftLeftCase(node);
    }

    private Node RightRightCase(Node node){ return LeftRotation(); }

    private Node RightLeftCase(Node node){
        node.right = RightRotation(node.right);
        return RightRightCase(node);
    }

    private Node LeftRotation(Node node){
        Node newParent = node.right;
        node.right = newParent.left;
        newParent.left = node;
        Update(node);
        Update(newParent);
        return newParent;
    }

    private Node RightRotation(Node node){
        Node newParent = node.left;
        node.left = newParent.right;
        newParent.right = node;
        Update(node);
        Update(newParent);
        return newParent;
    }

    public bool Contains(int value){ return ContainsHelper(root, value); }

    private bool ContainsHelper(Node node, int value){
        if(node == null){ return false; }

        if(value < node.value){ return ContainsHelper(node.left, value); }
        else { return ContainsHelper(node.right, value); }
        
        return true;
    }

    public bool Insert(int value){
        if(value == null){ return false; }

        if(!ContainsHelper(root, value)){
            root = InsertHelper(root, value);
            nodeCount++;
            return true;
        }

        return false;
    }

    private Node InsertHelper(Node node, int value){
        if(node == null){ return new Node(value); }

        if(value < node.value){ node.left = InsertHelper(node.left, value); }
        else { node.right = InsertHelper(node.right, value); }

        Update(node);
        return Balance(node);
    }

    public bool Remove(int value){
        if(value == null){ return false; }

        if(Contains(root, value)){
            root = RemoveHelper(root, value);
            nodeCount--;
            return true;
        }

        return false;
    }

    private Node RemoveHelper(Node node, int value){
        if(node == null){ return null; }

        if(value < node.value){ node.left = RemoveHelper(node.left, value); }
        else if(value > node.value){ node.right = RemoveHelper(node.right, value); }
        else {
            if(node.left == null){ return node.right; }
            else if(node.right == null){ return node.left; }
            else {
                Node temporary = FindMinimumNode(node.left);
                node.value = temporary.value;
                node.right = RemoveHelper(node.right, temporary.value);
            }
        }

        Update(node);
        return Balance(node);
    }
}