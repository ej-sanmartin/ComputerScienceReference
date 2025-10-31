using System;
using System.Collections.Generic;

/// <summary>
/// Provides breadth-first traversal algorithms for trees and graphs.
/// </summary>
// T - O(V + E)

/// <summary>
/// Performs breadth-first traversal on a binary search tree.
/// </summary>
public class BreadthFirstTreeTraversal {
    private class Node {
        public int Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node(int value) {
            Value = value;
        }
    }

    private Node root;

    /// <summary>
    /// Initializes a new instance of the BreadthFirstTreeTraversal class.
    /// </summary>
    /// <param name="value">The root value of the tree.</param>
    public BreadthFirstTreeTraversal(int value) {
        root = new Node(value);
    }

    /// <summary>
    /// Prints the level order traversal of the tree.
    /// </summary>
    // T - O(n)
    public void PrintLevelOrder() {
        if (root == null) {
            return;
        }

        Queue<Node> queue = new Queue<Node>();
        queue.Enqueue(root);

        while (queue.Count != 0) {
            Node current = queue.Dequeue();
            Console.WriteLine(current.Value);

            if (current.Left != null) {
                queue.Enqueue(current.Left);
            }
            if (current.Right != null) {
                queue.Enqueue(current.Right);
            }
        }
    }
}


/// <summary>
/// Performs breadth-first search traversal on a graph.
/// </summary>
public class BreadFirstTraversalGraph {
    private int vertices;
    private List<int>[] adjacencyList;

    /// <summary>
    /// Initializes a new instance of the BreadFirstTraversalGraph class.
    /// </summary>
    /// <param name="vertices">The number of vertices in the graph.</param>
    public BreadFirstTraversalGraph(int vertices) {
        this.vertices = vertices;
        adjacencyList = new List<int>[vertices];
        for (int i = 0; i < vertices; i++) {
            adjacencyList[i] = new List<int>();
        }
    }

    /// <summary>
    /// Adds an edge between two vertices in the graph.
    /// </summary>
    /// <param name="vertex">The source vertex.</param>
    /// <param name="edge">The destination vertex.</param>
    public void AddEdge(int vertex, int edge) {
        adjacencyList[vertex].Add(edge);
    }

    /// <summary>
    /// Performs breadth-first search starting from the specified source vertex.
    /// </summary>
    /// <param name="source">The source vertex to start the search from.</param>
    public void BreadthFirstSearch(int source) {
        bool[] visited = new bool[vertices];
        Queue<int> queue = new Queue<int>();

        for (int vertex = 0; vertex < vertices; vertex++) {
            visited[vertex] = false;
        }

        visited[source] = true;
        queue.Enqueue(source);

        while (queue.Count != 0) {
            int current = queue.Dequeue();
            Console.WriteLine(current);

            List<int> adjacentList = adjacencyList[current];

            foreach (int adjacent in adjacentList) {
                if (!visited[adjacent]) {
                    visited[adjacent] = true;
                    queue.Enqueue(adjacent);
                }
            }
        }
    }
}

// BFS with an adjacency list that is an array of linked lists
public class BreadthFirstTraversalLinkedListGraph{
    class LinkedList {
        class Node {
            int value;
            Node next;
            public Node(int value){
                this.value = value;
                this.next = null;
            }
        }
        
        private Node head;
        private int size;
        
        public LinkedList(){
            head = null;
        }
        
        public Node GetHead(){
            Node retrievedNode = head;
            head = head.next;
            return retrievedNode;
        }
        
        public void AddAtHead(int value){
            Node newNode = new Node(value);
            newNode.next = head;
            head = newNode;
            size++;
        }
        
        public int GetSize(){
            return size;
        }
   }
    
   class Graph {
        private int vertices;
        private LinkedList[] adjacencyList;
       
        public Graph(int vertices){
            this.vertices = vertices;
            adjacencyList = new LinkedList[vertices];
            
            for(int i = 0; i < vertices; i++){
                adjacencyList[i] = new LinkedList();
            }
        }
       
        // this is to add edges to a directed graph. Undirected, just need to take out comments for commented out line in method
        public void AddEdge(int source, int destination){
            if(source < vertices && destination < vertices){
                adjacencyList[source].AddAtHead(destination);
                // adjacencyList[destination].AddAtHead(source);
            }
        }
       
        public int GetVertices(){
            return vertices;
        }
       
        public LinkedList[] GetAdjacencyList(){
            return adjacencyList;
        }
   }
    
   public static string DFSGeneratedStringFromGraph(Graph adjacencyList, int source){
        if(source > adjacencyList.GetVertices()){
            Console.WriteLine("Source entered does not exist in graph of this size. Terminating function call");
            return;
        }
       
        Queue<int> queue = new Queue<int>();
        int vertices = adjacencyList.GetVertices();
        bool[] visited = new bool[vertices];
        StringBuilder result = new StringBuilder();
       
        for(int i = 0; i < vertices; i++){
            visited[i] = false;
        }
       
        visited[source] = true;
        queue.Enqueue(source);
       
        while(queue.Count != 0){
            int vertex = queue.Dequeue();
            result.Append(vertex);
            LinkedList.Node current = g.GetAdjacencyList()[current].GetHead();
            while(current != null){
                if(!visited[current.value]){
                    visited[current.value] = true;
                    queue.Enqueue(current.value);
                }
                current = current.next;
            }
        }
       
        return result.ToString();
   }
}
