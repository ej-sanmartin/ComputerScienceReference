using System;
using System.Collections.Generic;

/// <summary>
/// Implements Tarjan's algorithm for finding strongly connected components.
/// </summary>
// T - O(|V| + |E|), S - O(|V|)
public class TarjansGraph {
    private int vertices;
    private List<int>[] adjacencyList;
    private int time;

    /// <summary>
    /// Initializes a new instance of the TarjansGraph class.
    /// </summary>
    /// <param name="vertices">The number of vertices in the graph.</param>
    public TarjansGraph(int vertices) {
        this.vertices = vertices;
        adjacencyList = new List<int>[vertices];
        for (int i = 0; i < vertices; i++) {
            adjacencyList[i] = new List<int>();
        }
    }

    /// <summary>
    /// Adds a directed edge from one vertex to another.
    /// </summary>
    /// <param name="vertex">The source vertex.</param>
    /// <param name="adjacent">The destination vertex.</param>
    public void AddEdge(int vertex, int adjacent) {
        adjacencyList[vertex].Add(adjacent);
    }

    private void TarjansAlgorithmHelper(int current, int[] discoveryTimes, int[] earliestVisitedVertex, Stack<int> stack) {
        discoveryTimes[current] = earliestVisitedVertex[current] = ++time;
        stack.Push(current);

        foreach (int adjacent in adjacencyList[current]) {
            int vertex = adjacent;

            if (discoveryTimes[vertex] == -1) {
                TarjansAlgorithmHelper(vertex, discoveryTimes, earliestVisitedVertex, stack);
                earliestVisitedVertex[current] = Math.Min(earliestVisitedVertex[current], earliestVisitedVertex[vertex]);
            } else if (stack.Contains(vertex)) {
                earliestVisitedVertex[current] = Math.Min(earliestVisitedVertex[current], discoveryTimes[vertex]);
            }
        }

        int topStack = 0;
        if(earliestVisitedVertex[current] == discoveryTimes[current]){
            while(stack.Peek() != current){
                topStack = (int) stack.Pop();
                Console.WriteLine(topStack);
            }
            topStack = (int) stack.Pop();
            Console.WriteLine(topStack);            
        }
    }

    public void TarjansAlgorithm(){
        int[] discoveryTimes = new int[vertices];
        int[] earliestVisitedVertex = new int[vertices];
        Stack<int> stack = new Stack<int>();

        for(int i = 0; i < vertices; i++){
            discoveryTimes[i] = null;
            earliestVisitedVertex[i] = null;
        }

        for(int vertex = 0; vertex < vertices; vertex++){
            if(discoveryTimes[vertex] == null){
                TarjansAlgorithmHelper(vertex, discoveryTimes, earliestVisitedVertex, stack);
            }
        }
    }
}

