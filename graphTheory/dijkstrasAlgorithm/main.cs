using System;
using System.Collections.Generic;

// Adjacency Matrix
// T - O(V^2), S - O(V * V)
public class DijkstrasMatrixGraph {
    public static void DijkstrasAlogrithm(int[,] graph, int source, int verticesCount){
        int[] distance = new int[verticesCount];
        bool[] shortestPathsTreeSet = new bool[verticesCount];

        for(int vertex = 0; vertex < verticesCount; vertex++){
            distance[vertex] = int.MaxValue;
            shortestPathsTreeSet[vertex] = false;
        }

        distance[source] = 0;

        for(int current = 0; current < verticesCount; current++){
            int current = MinimumDistance(distance, shortestPathsTreeSet, verticesCount);
            shortestPathsTreeSet[current] = true;

            for(int vertex = 0; vertex < verticesCount; vertex++){
                if(!shortestPathsTreeSet[vertex]
                    && Convert.ToBoolean(graph[current, vertex])
                    && distance[current] != int.MaxValue
                    && distance[current] + graph[current, vertex] < distance[vertex]){
                        distance[vertex] = distance[current] + graph[current, vertex];
                    }
            }
        }

        // At this point, distance array has shortest path distances from sources
    }

    private static int MinimumDistance(int[] distance, bool[] shortestPathsTreeSet, int verticesCount){
        int min = int.MaxValue;
        int minIndex = 0;

        for(int vertex = 0; vertex < verticesCount; vertex++){
            if(shortestPathsTreeSet[vertex] == false && distance[vertex] < min){
                min = distance[vertex];
                minIndex = vertex;
            }
        }

        return minIndex;
    }
}

// Adjacency List with a Priority Queue (implemented a Min Heap)
// For Min Heap used for this implementation, check MinHeap in the dataStructure/Trees/ folder
// T - O((|V| + |E|) log|V|) to O(|E|log|V|))
// S - O(V)
public class DijkstrasAdjacencyListGraph{
    private class Node {
        public int value, cost;
        public Node(int value, int cost){
            this.value = value;
            this.cost = cost;
        }
    }

    private int vertices;
    private int[] distance;
    private HashSet<int> seen;
    private MinHeap<Node> priorityQueue;
    private List<List<Node>> adjacencyList;

    public DijkstrasAdjacencyListGraph(int vertices){
        this.vertices = vertices;
        distance = new int[vertices];
        seen = new HashSet<int>();
        priorityQueue = new MinHeap<Node>(vertices, new Node());
    }

    private void processNeighbors(int current){
        int edgeDistance = -1;
        int newDistance = -1;

        for(int adjacent = 0; adjacent < adjacencyList[current].Count; adjacent++){
            Node current = adjacencyList[current][adjacent];
            if(!seen.Contains(current.value)){
                edgeDistance = current.cost;
                newDistance = distance[current] + edgeDistance;
                if(newDistance < distance[current.value]){
                    distance[current.value] = newEdge;
                }

                priorityQueue.Insert(new Node(current.value, distance[current.value]));
            }
        }
    }

    public void DijkstrasAlogrithm(List<List<Node>> adjacencyList, int source){
        this.adjacencyList = adjacencyList;
        for(int vertex = 0; vertex < vertices; vertex++){
            distance[vertex] = int.MaxValue;
        }

        priorityQueue.Insert(new Node(source, 0));

        distance[source] = 0;

        while(seen.Count != vertices){
            int current = priorityQueue.Pop().value;
            seen.Add(current);
            processNeighbors(current);
        }
    }
}