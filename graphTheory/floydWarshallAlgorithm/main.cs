/// <summary>
/// Implements the Floyd-Warshall algorithm for finding shortest paths between all pairs of vertices.
/// </summary>
// T - O(|V|^3), S - O(|V|^2)
public class FloydWarshallGraph {
    private const int INFINITY = int.MaxValue;

    /// <summary>
    /// Computes the shortest paths between all pairs of vertices using the Floyd-Warshall algorithm.
    /// </summary>
    /// <param name="graph">The adjacency matrix representation of the graph.</param>
    /// <param name="vertices">The number of vertices in the graph.</param>
    public static void FloydWarshallAlgorithm(int[,] graph, int vertices) {
        int[,] distances = new int[vertices, vertices];
        int i, j, k;

        for (i = 0; i < vertices; i++) {
            for (j = 0; j < vertices; j++) {
                distances[i, j] = graph[i, j];
            }
        }

        for (k = 0; k < vertices; k++) {
            for (i = 0; i < vertices; i++) {
                for (j = 0; j < vertices; j++) {
                    if (distances[i, k] != INFINITY &&
                        distances[k, j] != INFINITY &&
                        distances[i, k] + distances[k, j] < distances[i, j]) {
                        distances[i, j] = distances[i, k] + distances[k, j];
                    }
                }
            }
        }

        // Distance matrix contains shortest distances between every pair of vertices
    }
}
