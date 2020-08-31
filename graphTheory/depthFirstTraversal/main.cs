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

// T - O(|V| + |E|), S - O(|V|)
public class IterativeDepthFirstTraversal {
    public static void IterativeDepthFirstPrint(int start, Graph adjacencyList){
        Stack<int> stack = new Stack<int>();
        HashSet<int> seen = new HashSet<int>();

        stack.Push(start);

        while(stack.Count != 0){
            int current = stack.Pop();

            if(!seen.Contains(current)){
                seen.Add(current);
                Console.WriteLine(current.value);
            }

            foreach(int adjacent in adjacencyList.vertexList){
                if(!seen.Contains(adjacent)){
                    stack.Push(adjacent);
                }
            }
        }
    }
}

public class RecursiveDepthFirstSearch {
    public static void RecursiveDepthFirstSearch(int start, Graph adjacencyList){
        bool[] visited = new bool[adjacencyList.Count];
        RecursiveDepthFirstSearch(start, visited, adjacencyList);
    }

    private void RecursiveDepthFirstSearchHelper(int current, bool[] visited, Graph adjacencyList){
        visited[current] = true;
        // can do what you want with current at this point
        Console.WriteLine(current);

        foreach(int adjacent in adjacencyList.vertexList){
            if(!visited[adjacent]){ RecursiveDepthFirstSearchHelper(adjacent, visited); }
        }
    }
}