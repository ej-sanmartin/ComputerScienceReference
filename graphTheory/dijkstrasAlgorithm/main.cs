using System;
using System.Collections.Generic;

/// <summary>
/// Implements Dijkstra's algorithm using an adjacency matrix representation.
/// </summary>
// T - O(V^2), S - O(V^2)
public class DijkstrasMatrixGraph {
    /// <summary>
    /// Finds the shortest paths from a source vertex to all other vertices using Dijkstra's algorithm.
    /// </summary>
    /// <param name="graph">The adjacency matrix representation of the graph.</param>
    /// <param name="source">The source vertex.</param>
    /// <param name="verticesCount">The total number of vertices in the graph.</param>
    public static void DijkstrasAlgorithm(int[,] graph, int source, int verticesCount) {
        int[] distance = new int[verticesCount];
        bool[] shortestPathsTreeSet = new bool[verticesCount];

        for (int vertex = 0; vertex < verticesCount; vertex++) {
            distance[vertex] = int.MaxValue;
            shortestPathsTreeSet[vertex] = false;
        }

        distance[source] = 0;

        for (int current = 0; current < verticesCount; current++) {
            int u = MinimumDistance(distance, shortestPathsTreeSet, verticesCount);
            shortestPathsTreeSet[u] = true;

            for (int vertex = 0; vertex < verticesCount; vertex++) {
                if (!shortestPathsTreeSet[vertex]
                    && Convert.ToBoolean(graph[u, vertex])
                    && distance[u] != int.MaxValue
                    && distance[u] + graph[u, vertex] < distance[vertex]) {
                    distance[vertex] = distance[u] + graph[u, vertex];
                }
            }
        }

        // At this point, distance array has shortest path distances from source
    }

    /// <summary>
    /// Finds the vertex with the minimum distance value that hasn't been processed yet.
    /// </summary>
    /// <param name="distance">The distance array.</param>
    /// <param name="shortestPathsTreeSet">The set of vertices included in the shortest path tree.</param>
    /// <param name="verticesCount">The total number of vertices.</param>
    /// <returns>The index of the vertex with minimum distance.</returns>
    private static int MinimumDistance(int[] distance, bool[] shortestPathsTreeSet, int verticesCount) {
        int min = int.MaxValue;
        int minIndex = 0;

        for (int vertex = 0; vertex < verticesCount; vertex++) {
            if (!shortestPathsTreeSet[vertex] && distance[vertex] < min) {
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
            Node vertex = adjacencyList[current][adjacent];
            if(!seen.Contains(vertex.value)){
                edgeDistance = vertex.cost;
                newDistance = distance[vertex.value] + edgeDistance;
                if(newDistance < distance[vertex.value]){
                    distance[vertex.value] = newDistance;
                }

                priorityQueue.Insert(new Node(vertex.value, distance[vertex.value]));
            }
        }
    }

    public void DijkstrasAlgorithm(List<List<Node>> adjacencyList, int source){
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
