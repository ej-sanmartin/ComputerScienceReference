using System;
using System.Collections.Generic;

// T - O(V), Graph represented as an AL
public class AdjacencyListGraph<T> {
    public List<T> vertexList;
    public Dictionary<T, List<T>> adjacencyList;

    public AdjacencyListGraph(T rootVertexKey){
        AddVertex(rootVertexKey);
    }

    private List<T> AddVertex(T key){
        List<T> vertex = new List<T>();
        vertexList.Add(vertex);
        adjacencyList.Add(key, vertex);

        return vertex;
    }

    public void AddEdge(T startKey,T endKey){
        List<T> startVertex = adjacencyList.ContainsKey(startKey) ? adjacencyList[startKey] : null;
        List<T> endVertex = adjacencyList.ContainsKey(endKey) ? adjacencyList[endKey]: null;

        if(startVertex == null){ throw new ArgumentNullException("First argument cannot be null"); }
        if(endVertex == null){ endVertex = AddVertex(endKey); }

        startVertex.Add(endKey);
        endVertex.Add(startKey);
    }
}

// Graph as an Adjacency Matrix
public class AdjacencyMatrixGraph {
    private bool[][] adjacencyMatrix;
    private int vertices;

    public AdjacencyMatrixGraph(int vertices){
        this.vertices = vertices;
        adjacencyMatrix = new bool[vertices][vertices];
    }

    public void AddEdge(int row, int column){
        adjacencyMatrix[row][column] = true;
        adjacencyMatrix[column][row] = true;
    }

    public void RemoveEdge(int row, int column){
        adjacencyMatrix[row][column] = false;
        adjacencyMatrix[column][row] = false;
    }
}