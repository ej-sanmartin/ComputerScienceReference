using System;
using System.Collections.Generic;

// T - O(V), Graph represented as an AL
public class Graph<T> {
    public List<T> vertexList;
    public Dictionary<T, List<T>> adjacencyList;

    public Graph(T rootVertexKey){
        AddVertex(rootVertexKey);
    }

    private List<T> AddVertex(T key){
        List<T> vertex = new List<t>();
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

// TODO: Graph as an Adjacency Matrix