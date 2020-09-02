using System;
using System.Collections.Generic;

// T - O(|V| + |E|), S - O(|V|)
public class TarjansGraph{
    private int vertices;
    private List<int> adjacencyList;

    private int time;

    public TarjansGraph(int vertices){
        this.vertices = vertices;
        adjacencyList = new List<int>[vertices];
    }

    public void AddEdge(int vertex, int weight){
        adjacencyList[vertex].Add(weight);
    }

    private void TarjansAlgorithmHelper(int current, int[] discoveryTimes, int[] earliestVisitedVertex, Stack<int> stack){
        discoveryTimes[current] = earliestVisitedVertex[curret] = ++time;
        stack.Push(current);

        foreach(int adjacent in adjacencyList){
            int vertex = adjacent;

            if(discoveryTimes[vertex] == -1){
                TarjansAlgorithmHelper(vertex, discoveryTimes, earliestVisitedVertex, stack);
                earliestVisitedVertex[current] = Math.Min(earliestVisitedVertex[current], earliestVisitedVertex[vertex]);
            } else if(stack.Contains(vertex)){
                earliestVisitedVertex[current] = Math.Min(earliestVisitedVertex[current, earliestVisitedVertex[vertex]]);
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

