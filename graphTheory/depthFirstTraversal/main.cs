using System;
using System.Collections.Generic;

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