using System;
using System.Collections.Generic;

// Iterative BFT of a Binary Search Tree
public class BreadthFirstTreeTraversal {
    private class Node {
        private int value;
        private Node left, right;
        public Node(int value){ this.value = value; }
    }

    private Node root;
    public BreadthFirstTreeTraversal(int value){ root = new Node(value); }
    
    // T - O(n)
    public void PrintLevelOrder(){
        if(root == null){ return; }

        Queue<Node> queue = new Queue<Node>();
        queue.Enqueue(root);

        while(queue.Count != 0){
            Node current = queue.Dequeue();
            Console.WriteLine(current.value);

            if(current.left != null){ queue.Enqueue(current.left); }
            if(current.right != null){ queue.Enqueue(current.right); }
        }
    }

}