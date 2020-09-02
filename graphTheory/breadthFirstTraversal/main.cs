using System;
using System.Collections.Generic;

// T - O(V + E)

// Iterative BFT of a Binary Search Tree
public class BreadthFirstTreeTraversal {
    private class Node {
        public int value;
        public Node left, right;
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


// Iterative Breadth First Search of a graph
public class BreadFirstTraversalGraph {
    private int vertices;
    private List<int>[] adjacencyList;

    public BreadFirstTraversalGraph(int vertices){
        this.vertices = vertices;
        adjacencyList = new List<int>[vertices];
        for(int i = 0; i < vertices; i++){
            adjacencyList[i] = new List<int>();
        }
    }

    public void AddEdge(int vertex, int edge){
        adjacencyList[vertex].Add(edge);
    }

    public void BreadthFirstSearch(int source){
        bool[] visited = new bool[vertices];
        Queue<int> queue = new Queue<int>();

        for(int vertex = 0; vertex < vertices; vertex++){
            visited[vertex] = false;
        }

        visited[source] = true;
        queue.Enqueue(source);

        while(queue.Count != 0){
            int current = queue.Dequeue();
            Console.WriteLine(current);

            List<int> adjacentList = adjacencyList[current];

            foreach(int adjacent in adjacentList){
                if(!visited[adjacencyList]){
                    visited[adjacent] = true;
                    queue.Enqueue(adjacent);
                }
            }
        }
    }
}