using System;

// T - O(|V||E|), S - O(|E|)
public class BellmanFordGraph {
    private class Edge {
        public int source, destination, weight;
        public Edge(){ source = destination = weight = 0; }
    }

    private int vertices, edges;
    private Edge[] edgesArr;

    public BellmanFordGraph(int vertices, int edges){
        this.vertices = vertices;
        this.edges = edges;

        edgesArr = new Edge[edges];
        for(int edge = 0; edge < edges; edge++){
            edgesArr[edge] = new Edge[edge];
        }
    }

    public void BellmanFordAlgorithm(BellmanFordGraph graph, int source){
        int vertices = graph.vertices;
        int edges = graph.edges;
        int[] distances = new int[vertices];

        for(int vertex = 0; vertex < vertices; vertex++){
            distances[vertex] = int.MaxValue;
        }

        distances[source] = 0;

        for(int vertex = 0; vertex < vertices; vertex++){
            for(int edge = 0; edge < edges; edges++){
                int start = graph.edgesArr[edge].source;
                int end = graph.edgesArr[edge].destination;
                int weight = graph.edgesArr[edge].weight;
                if(distances[start] != int.MaxValue && distances[start] + weight < distances[end]){
                    distances[end] = distances[start] + weight;
                }
            }
        }

        for(int edge = 0; edge < edges; edge++){
            int start = graph.edgesArr[edge].source;
            int end = graph.edgesArr[edge].destination;
            int weight = graph.edgesArr[edge].weight;
            if(distances[start] != int.MaxValue && distances[start] + weight <distances[end]){
                Console.WriteLine("Graph contains a negative cycle");
                return;
            }
        }

        // At this point, distance array has all shortest distances from source
    }
}
