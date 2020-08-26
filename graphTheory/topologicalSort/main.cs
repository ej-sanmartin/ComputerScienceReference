using System;
using System.Collections.Generic;

/* 
    T - O(V + E), S - O(V)
    This implementation will result in the stack containing the topologically
    sorted items. You can do what you wish with it, in this file I ended up
    printing each item out.
*/
public class TopologicalSortGraph {
    private int vertices;
    private List<List<int>> adjacencyList;

    public TopologicalSortGraph(int vertices){
        this.vertices = vertices;
        adjacencyList = new List<List<int>>(vertices);

        for(int i = 0; i < vertices; i++){
            adjacencyList.Add(new List<int>());
        }
    }

    public void AddEdge(int vertex, int edge){
        adjacencyList[vertex].Add(edge);
    }

    private void TopologicalSortHelper(int vertex, bool[] visited, Stack<int> stack){
        visited[vertex] = true;

        foreach(var adjacent in adjacencyList[vertex]){
            if(!visited[adjacent]){
                TopologicalSortHelper(adjacent, visited, stack);
            }
        }

        stack.Push(vertex);
    }

    public void TopologicalSort(){
        Stack<int> stack = new Stack<int>();
        bool[] visited = new bool[vertices];

        for(int vertex = 0; vertex < vertices; vertex++){
            if(visited[vertex] == false){ TopologicalSortHelper(vertex, visited, stack); }
        }

        // At this point, stack contains sorted vertices. If you are not printing items out,
        // you may replace following code
        foreach(int vertex in stack){
            Console.WriteLine("{0}\n", vertex);
        }
    }
}