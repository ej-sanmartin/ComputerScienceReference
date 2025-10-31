/// <summary>
/// Implements the Union-Find (Disjoint Set) data structure.
/// </summary>
// T - O(n), S - O(n)
public class UnionFindGraph {
    private class Edge {
        public int Source { get; set; }
        public int Destination { get; set; }

        public Edge() {
            Source = Destination = 0;
        }
    }

    private int vertices, edges;
    private Edge[] edgesArr;

    /// <summary>
    /// Initializes a new instance of the UnionFindGraph class.
    /// </summary>
    /// <param name="vertices">The number of vertices.</param>
    /// <param name="edges">The number of edges.</param>
    public UnionFindGraph(int vertices, int edges) {
        this.vertices = vertices;
        this.edges = edges;
        edgesArr = new Edge[edges];
        for (int edge = 0; edge < edges; edge++) {
            edgesArr[edge] = new Edge();
        }
    }

    /// <summary>
    /// Finds the root of the set containing element i (recursive implementation).
    /// </summary>
    /// <param name="parent">The parent array.</param>
    /// <param name="i">The element to find.</param>
    /// <returns>The root of the set.</returns>
    public int Find(int[] parent, int i) {
        if (parent[i] == -1) {
            return i;
        }
        return Find(parent, parent[i]);
    }

    /// <summary>
    /// Finds the root of the set containing element i with path compression (iterative implementation).
    /// </summary>
    /// <param name="parent">The parent array.</param>
    /// <param name="i">The element to find.</param>
    /// <returns>The root of the set.</returns>
    public int IterativeFind(int[] parent, int i) {
        int root = i;
        while (root != parent[root]) {
            root = parent[root];
        }

        while (i != root) {
            int next = parent[i];
            parent[i] = root;
            i = next;
        }

        return root;
    }

    /// <summary>
    /// Unions two sets containing elements x and y.
    /// </summary>
    /// <param name="parent">The parent array.</param>
    /// <param name="x">The first element.</param>
    /// <param name="y">The second element.</param>
    public void Union(int[] parent, int x, int y) {
        int xSet = Find(parent, x);
        int ySet = Find(parent, y);
        parent[xSet] = ySet;
    }

    /// <summary>
    /// Checks if the graph contains a cycle using Union-Find algorithm.
    /// </summary>
    /// <param name="graph">The graph to check for cycles.</param>
    /// <returns>True if a cycle is detected, false otherwise.</returns>
    public bool IsCycle(UnionFindGraph graph) {
        int[] parent = new int[graph.vertices];

        for (int vertex = 0; vertex < graph.vertices; vertex++) {
            parent[vertex] = -1;
        }

        for (int edge = 0; edge < graph.edges; edge++) {
            int x = Find(parent, graph.edgesArr[edge].Source);
            int y = Find(parent, graph.edgesArr[edge].Destination);

            if (x == y) {
                return true;
            }
            Union(parent, x, y);
        }

        return false;
    }
}
