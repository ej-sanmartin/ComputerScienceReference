/// <summary>
/// Implements Prim's algorithm for finding the minimum spanning tree of a graph.
/// </summary>
// Adjacency Matrix
// T - O(V^2), S - O(V)
public class PrimsGraph {
    /// <summary>
    /// Finds the vertex with the minimum key value that hasn't been included in the MST yet.
    /// </summary>
    /// <param name="key">The key values array.</param>
    /// <param name="minimumSpanningTreeSet">The set of vertices included in the MST.</param>
    /// <returns>The index of the vertex with minimum key.</returns>
    public static int MinKey(int[] key, bool[] minimumSpanningTreeSet) {
        int min = int.MaxValue;
        int minIndex = -1;

        for (int vertex = 0; vertex < key.Length; vertex++) {
            if (!minimumSpanningTreeSet[vertex] && key[vertex] < min) {
                min = key[vertex];
                minIndex = vertex;
            }
        }

        return minIndex;
    }

    /// <summary>
    /// Constructs the minimum spanning tree using Prim's algorithm.
    /// </summary>
    /// <param name="graph">The adjacency matrix representation of the graph.</param>
    public static void PrimsAlgorithm(int[,] graph) {
        int vertices = graph.GetLength(0);
        int[] parent = new int[vertices];
        int[] key = new int[vertices];
        bool[] minimumSpanningTreeSet = new bool[vertices];

        for (int vertex = 0; vertex < vertices; vertex++) {
            key[vertex] = int.MaxValue;
            minimumSpanningTreeSet[vertex] = false;
        }

        key[0] = 0;
        parent[0] = -1;

        for (int count = 0; count < vertices - 1; count++) {
            int minVertex = MinKey(key, minimumSpanningTreeSet);
            minimumSpanningTreeSet[minVertex] = true;

            for (int vertex = 0; vertex < vertices; vertex++) {
                if (graph[minVertex, vertex] != 0
                    && !minimumSpanningTreeSet[vertex]
                    && graph[minVertex, vertex] < key[vertex]) {
                    parent[vertex] = minVertex;
                    key[vertex] = graph[minVertex, vertex];
                }
            }
        }
    }
}