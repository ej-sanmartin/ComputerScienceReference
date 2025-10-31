using System;

/// <summary>
/// Represents an AVL self-balancing binary search tree.
/// </summary>
public class AVLTree {
    private class Node {
        public int Value { get; set; }
        public int Height { get; set; }
        public int BalanceFactor { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node(int value) {
            Value = value;
            Height = 0;
            BalanceFactor = 0;
        }
    }

    private Node root;
    private int nodeCount = 0;

    /// <summary>
    /// Gets the number of nodes in the AVL tree.
    /// </summary>
    /// <returns>The size of the tree.</returns>
    public int Size() {
        return nodeCount;
    }

    /// <summary>
    /// Finds the node with the minimum value in the given subtree.
    /// </summary>
    /// <param name="node">The root of the subtree to search.</param>
    /// <returns>The node with the minimum value.</returns>
    public Node FindMinimumNode(Node node) {
        Node temporary = node;

        while (temporary.Left != null) {
            temporary = temporary.Left;
        }

        return temporary;
    }

    /// <summary>
    /// Gets the height of the AVL tree.
    /// </summary>
    /// <returns>The height of the tree.</returns>
    public int Height() {
        if (root == null) {
            return 0;
        }
        return root.Height;
    }

    private void Update(Node node) {
        int leftNodeHeight = (node.Left == null ? -1 : node.Left.Height);
        int rightNodeHeight = (node.Right == null ? -1 : node.Right.Height);

        node.Height = Math.Max(leftNodeHeight, rightNodeHeight) + 1;
        node.BalanceFactor = rightNodeHeight - leftNodeHeight;
    }

    private Node Balance(Node node) {
        if (node.BalanceFactor == -2) {
            if (node.Left.BalanceFactor <= 0) {
                return LeftLeftCase(node);
            } else {
                return LeftRightCase(node);
            }
        } else if (node.BalanceFactor == 2) {
            if (node.Right.BalanceFactor >= 0) {
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

    private Node RightRightCase(Node node){ return LeftRotation(node); }

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
        if(ContainsHelper(root, value)){
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