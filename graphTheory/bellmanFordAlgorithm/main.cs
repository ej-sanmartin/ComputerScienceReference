using System;

/// <summary>
/// Implements the Bellman-Ford algorithm for finding shortest paths in graphs with negative weights.
/// </summary>
// T - O(|V||E|), S - O(|E|)
public class BellmanFordGraph {
    private class Edge {
        public int Source { get; set; }
        public int Destination { get; set; }
        public int Weight { get; set; }

        public Edge() {
            Source = Destination = Weight = 0;
        }
    }

    private int vertices, edges;
    private Edge[] edgesArr;

    /// <summary>
    /// Initializes a new instance of the BellmanFordGraph class.
    /// </summary>
    /// <param name="vertices">The number of vertices in the graph.</param>
    /// <param name="edges">The number of edges in the graph.</param>
    public BellmanFordGraph(int vertices, int edges) {
        this.vertices = vertices;
        this.edges = edges;

        edgesArr = new Edge[edges];
        for (int edge = 0; edge < edges; edge++) {
            edgesArr[edge] = new Edge();
        }
    }

    /// <summary>
    /// Runs the Bellman-Ford algorithm to find shortest paths from a source vertex.
    /// </summary>
    /// <param name="graph">The graph to process.</param>
    /// <param name="source">The source vertex.</param>
    public void BellmanFordAlgorithm(BellmanFordGraph graph, int source) {
        int vertices = graph.vertices;
        int edges = graph.edges;
        int[] distances = new int[vertices];

        for (int vertex = 0; vertex < vertices; vertex++) {
            distances[vertex] = int.MaxValue;
        }

        distances[source] = 0;

        for (int vertex = 0; vertex < vertices - 1; vertex++) {
            for (int edge = 0; edge < edges; edge++) {
                int start = graph.edgesArr[edge].Source;
                int end = graph.edgesArr[edge].Destination;
                int weight = graph.edgesArr[edge].Weight;
                if (distances[start] != int.MaxValue && distances[start] + weight < distances[end]) {
                    distances[end] = distances[start] + weight;
                }
            }
        }

        // Check for negative cycles
        for (int edge = 0; edge < edges; edge++) {
            int start = graph.edgesArr[edge].Source;
            int end = graph.edgesArr[edge].Destination;
            int weight = graph.edgesArr[edge].Weight;
            if (distances[start] != int.MaxValue && distances[start] + weight < distances[end]) {
                Console.WriteLine("Graph contains a negative cycle");
                return;
            }
        }

        // At this point, distance array has all shortest distances from source
    }
}
