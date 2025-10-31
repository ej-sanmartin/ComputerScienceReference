/// <summary>
/// Implements Kruskal's algorithm for finding the minimum spanning tree of a graph.
/// </summary>
// T - O(|E| log |V|), S - O(|E| + |V|)
public class KruskalsGraph {
    /// <summary>
    /// Represents an edge in the graph.
    /// </summary>
    public struct Edge {
        public int Source { get; set; }
        public int Destination { get; set; }
        public int Weight { get; set; }

        public Edge() {
            Source = Destination = Weight = 0;
        }
    }

    /// <summary>
    /// Represents a subset for union-find operations.
    /// </summary>
    public struct Subset {
        public int Parent { get; set; }
        public int Rank { get; set; }

        public Subset() {
            Parent = Rank = 0;
        }
    }

    private int vertices, edges;
    private Edge[] edgesArr;

    /// <summary>
    /// Initializes a new instance of the KruskalsGraph class.
    /// </summary>
    /// <param name="vertices">The number of vertices in the graph.</param>
    /// <param name="edges">The number of edges in the graph.</param>
    public KruskalsGraph(int vertices, int edges) {
        this.vertices = vertices;
        this.edges = edges;
        edgesArr = new Edge[edges];

        for (int edge = 0; edge < edges; edge++) {
            edgesArr[edge] = new Edge();
        }
    }

    /// <summary>
    /// Finds the root of the set containing the given element using path compression.
    /// </summary>
    /// <param name="subsets">The array of subsets.</param>
    /// <param name="i">The element to find.</param>
    /// <returns>The root of the set containing element i.</returns>
    private int Find(Subset[] subsets, int i) {
        if (subsets[i].Parent != i) {
            subsets[i].Parent = Find(subsets, subsets[i].Parent);
        }

        return subsets[i].Parent;
    }

    /// <summary>
    /// Performs union of two sets using union by rank.
    /// </summary>
    /// <param name="subsets">The array of subsets.</param>
    /// <param name="x">The first element.</param>
    /// <param name="y">The second element.</param>
    private void Union(Subset[] subsets, int x, int y) {
        int xRoot = Find(subsets, x);
        int yRoot = Find(subsets, y);

        if (subsets[xRoot].Rank < subsets[yRoot].Rank) {
            subsets[xRoot].Parent = yRoot;
        } else if (subsets[xRoot].Rank > subsets[yRoot].Rank) {
            subsets[yRoot].Parent = xRoot;
        } else {
            subsets[yRoot].Parent = xRoot;
            subsets[xRoot].Rank++;
        }
    }

    public void KruskalsAlgorithm(){
        Edge[] result = new Edge[vertices];
        int e = 0, i = 0;

        for (int vertex = 0; vertex < vertices; vertex++){
            result[vertex] = new Edge();
        }

        Array.Sort(edgesArr);

        Subset[] subsets = new Subset[vertices];

        for (int vertex = 0; vertex < vertices; vertex++){
            subsets[vertex] = new Subset();
        }

        for(int vertex = 0; vertex < vertices; vertex++){
            subsets[vertex].parent = vertex;
            subsets[vertex].rank = 0;
        }

        while(e < vertices - 1){
            Edge nextEdge = edgesArr[i++];

            int x = Find(subsets, nextEdge.source);
            int y = Find(subsets, nextEdge.destination);

            if(x != y){
                result[e++] = nextEdge;
                Union(subsets, x, y);
            }
        }

        // result array has minimum spanning tree of inputted graph
    }
}


