using System;
using System.Collections.Generic;

// T - O(b^d/2), S - O(b^d/2)
public class BidirectionalGraph {
    private int vertices;
    private List<int>[] adjacencyList;

    public BidirectionalGraph(int vertices){
        this.vertices = vertices;
        adjacencyList = new List<int>[vertices];
        for(int i = 0; i < vertices; i++){
            adjacencyList[i] = new List<int>();
        }
    }

    private void BreadthFirstSearch(Queue queue, bool[] visited, int[] parent){
        int current = queue.Dequeue();

        foreach(int vertex in adjacencyList[current]){
            parent[vertex] = current;
            visited[vertex] = true;
            queue.Enqueue(vertex);
        }
    }

    private int isIntersecting(bool[] startVisited, bool[] endVisited){
        for(int vertex = 0; vertex < vertices; vertex++){
            if(startVisited[vertex] && endVisited[vertex]){ return vertex; }
        }
        return -1;
    }

    public void BidirectionalSearch(int start, int end){
        bool[] startVisited = new bool[vertices];
        bool[] endVisited = new bool[vertices];
        int[] startParent = new int[vertices];
        int[] endParent = new int[vertices];

        Queue<int> startQueue = new Queue<int>();
        Queue<int> endQueue = new Queue<int>();

        int intersectNode = -1;

        for(int i = 0; i < vertices; i++){
            startVisited[i] = false;
            endVisited[i] = false;
        }

        startQueue.Enqueue(start);
        startVisited[start] = true;
        startParent[start] = -1;

        endQueue.Enqueue(end);
        endVisited[end] = true;
        endParent[end] = -1;

        while(startQueue.Count != 0 && endQueue.Count != 0){
            BreadthFirstSearch(startQueue, startVisited, startParent);
            BreadthFirstSearch(endQueue, endVisited, endParent);

            intersectNode = isIntersecting(startVisited, endVisited);

            // if this block of code is ran, path exists between start and end vertices
            // startParent and endParent contains vertices between two points
            if(intersectNode != -1){
                Console.WriteLine("Path exists between start and end");
            }
        }
    }
}