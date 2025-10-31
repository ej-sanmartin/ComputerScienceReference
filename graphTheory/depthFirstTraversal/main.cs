using System;
using System.Collections.Generic;

/// <summary>
/// Provides depth-first traversal algorithms for graphs.
/// </summary>
// T - O(|V| + |E|), S - O(|V|)
public class IterativeDepthFirstTraversal {
    /// <summary>
    /// Performs iterative depth-first traversal starting from the specified vertex.
    /// </summary>
    /// <param name="start">The starting vertex for traversal.</param>
    /// <param name="adjacencyList">The adjacency list representation of the graph.</param>
    public static void IterativeDepthFirstPrint(int start, AdjacencyListGraph<int> adjacencyList) {
        Stack<int> stack = new Stack<int>();
        HashSet<int> seen = new HashSet<int>();

        stack.Push(start);

        while (stack.Count != 0) {
            int current = stack.Pop();

            if (!seen.Contains(current)) {
                seen.Add(current);
                Console.WriteLine(current);
            }

            // Get neighbors of current vertex
            if (adjacencyList.AdjacencyList.ContainsKey(current)) {
                foreach (int adjacent in adjacencyList.AdjacencyList[current]) {
                    if (!seen.Contains(adjacent)) {
                        stack.Push(adjacent);
                    }
                }
            }
        }
    }
}

/// <summary>
/// Provides recursive depth-first search algorithms.
/// </summary>
public class RecursiveDepthFirstSearch {
    /// <summary>
    /// Performs recursive depth-first search starting from the specified vertex.
    /// </summary>
    /// <param name="start">The starting vertex for search.</param>
    /// <param name="adjacencyList">The adjacency list representation of the graph.</param>
    public static void DepthFirstSearch(int start, AdjacencyListGraph<int> adjacencyList) {
        bool[] visited = new bool[adjacencyList.VertexList.Count];
        DepthFirstSearchHelper(start, visited, adjacencyList);
    }

    private static void DepthFirstSearchHelper(int current, bool[] visited, AdjacencyListGraph<int> adjacencyList) {
        visited[adjacencyList.VertexList.IndexOf(current)] = true;
        // Process current vertex
        Console.WriteLine(current);

        // Visit all neighbors
        if (adjacencyList.AdjacencyList.ContainsKey(current)) {
            foreach (int adjacent in adjacencyList.AdjacencyList[current]) {
                if (!visited[adjacencyList.VertexList.IndexOf(adjacent)]) {
                    DepthFirstSearchHelper(adjacent, visited, adjacencyList);
                }
            }
        }
    }
}