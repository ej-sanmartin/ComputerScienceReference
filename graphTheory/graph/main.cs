using System;
using System.Collections.Generic;

/// <summary>
/// Represents a graph using an adjacency list representation.
/// </summary>
/// <typeparam name="T">The type of the vertices.</typeparam>
// T - O(V), Graph represented as an AL
public class AdjacencyListGraph<T> {
    /// <summary>
    /// Gets or sets the list of vertices in the graph.
    /// </summary>
    public List<T> VertexList { get; set; }

    /// <summary>
    /// Gets or sets the adjacency list representing the graph edges.
    /// </summary>
    public Dictionary<T, List<T>> AdjacencyList { get; set; }

    /// <summary>
    /// Initializes a new instance of the AdjacencyListGraph class with a root vertex.
    /// </summary>
    /// <param name="rootVertexKey">The key of the root vertex.</param>
    public AdjacencyListGraph(T rootVertexKey) {
        VertexList = new List<T>();
        AdjacencyList = new Dictionary<T, List<T>>();
        AddVertex(rootVertexKey);
    }

    private List<T> AddVertex(T key) {
        List<T> vertex = new List<T>();
        VertexList.Add(key);
        AdjacencyList[key] = vertex;

        return vertex;
    }

    /// <summary>
    /// Adds an edge between two vertices in the graph.
    /// </summary>
    /// <param name="startKey">The starting vertex of the edge.</param>
    /// <param name="endKey">The ending vertex of the edge.</param>
    public void AddEdge(T startKey, T endKey) {
        List<T> startVertex = AdjacencyList.ContainsKey(startKey) ? AdjacencyList[startKey] : null;
        List<T> endVertex = AdjacencyList.ContainsKey(endKey) ? AdjacencyList[endKey] : null;

        if (startVertex == null) {
            throw new ArgumentNullException("Start vertex cannot be null");
        }
        if (endVertex == null) {
            endVertex = AddVertex(endKey);
        }

        startVertex.Add(endKey);
        endVertex.Add(startKey);
    }
}

/// <summary>
/// Represents a graph using an adjacency matrix representation.
/// </summary>
public class AdjacencyMatrixGraph {
    private bool[,] adjacencyMatrix;
    private int vertices;

    /// <summary>
    /// Initializes a new instance of the AdjacencyMatrixGraph class.
    /// </summary>
    /// <param name="vertices">The number of vertices in the graph.</param>
    public AdjacencyMatrixGraph(int vertices) {
        this.vertices = vertices;
        adjacencyMatrix = new bool[vertices, vertices];
    }

    /// <summary>
    /// Adds an edge between two vertices in the graph.
    /// </summary>
    /// <param name="row">The row index of the first vertex.</param>
    /// <param name="column">The column index of the second vertex.</param>
    public void AddEdge(int row, int column) {
        adjacencyMatrix[row, column] = true;
        adjacencyMatrix[column, row] = true;
    }

    /// <summary>
    /// Removes an edge between two vertices in the graph.
    /// </summary>
    /// <param name="row">The row index of the first vertex.</param>
    /// <param name="column">The column index of the second vertex.</param>
    public void RemoveEdge(int row, int column) {
        adjacencyMatrix[row, column] = false;
        adjacencyMatrix[column, row] = false;
    }
}