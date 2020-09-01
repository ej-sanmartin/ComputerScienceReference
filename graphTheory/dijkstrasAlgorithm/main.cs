using System;

// Adjacency Matrix
// T - O(V^2), S - O(V * V)
public class DijkstrasMatrixGraph {
    public static void DijkstrasAlogrithm(int[,] graph, int source, int verticesCount){
        int[] distance = new int[verticesCount];
        bool[] shortestPathsTreeSet = new bool[verticesCount];

        for(int vertex = 0; vertex < verticesCount; vertex++){
            distance[vertex] = int.MaxValue;
            shortestPathsTreeSet[vertex] = false;
        }

        distance[source] = 0;

        for(int current = 0; current < verticesCount; current++){
            int current = MinimumDistance(distance, shortestPathsTreeSet, verticesCount);
            shortestPathsTreeSet[current] = true;

            for(int vertex = 0; vertex < verticesCount; vertex++){
                if(!shortestPathsTreeSet[vertex]
                    && Convert.ToBoolean(graph[current, vertex])
                    && distance[current] != int.MaxValue
                    && distance[current] + graph[current, vertex] < distance[vertex]){
                        distance[vertex] = distance[current] + graph[current, vertex];
                    }
            }
        }

        // At this point, distance array has shortest path distances from sources
    }

    private static int MinimumDistance(int[] distance, bool[] shortestPathsTreeSet, int verticesCount){
        int min = int.MaxValue;
        int minIndex = 0;

        for(int vertex = 0; vertex < verticesCount; vertex++){
            if(shortestPathsTreeSet[vertex] == false && distance[vertex] < min){
                min = distance[vertex];
                minIndex = vertex;
            }
        }

        return minIndex;
    }
}

// Adjacency List with a Priority Queue (implemented a Min Heap)
// T - O((|V| + |E|) log|V|) to O(|E|log|V|))
// S - O(V)
public class DijkstrasAdjacencyListGraph{
    
}