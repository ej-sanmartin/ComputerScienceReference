// T - O(|E| log |V|), S - O(|E| + |V|)
public class KruskalsGraph {
    public struct Edge {
        public int source, destination, weight;
        public Edge(){ source = destination = weight = 0; }
    }

    public struct Subset {
        public int parent, rank;
        public Subset(){ parent = rank = 0; }
    }

    private int vertices, edges;
    Edge[] edgesArr;

    public KruskalsGraph(int vertices, int edges){
        this.vertices = vertices;
        this.edges = edges;
        edgesArr = new Edge[edges];

        for(int edge = 0; edge < edges; edge++){
            edgesArr[edge] = new Edge();
        }
    }

    private int Find(Subset[] subset, int i){
        if(subset[i].parent != i){
            subset[i].parent = Find(subset, subset[i].parent);
        }

        return subset[i].parent;
    }

    private void Union(Subset[] subsets, int x, int y){
        int xRoot = Find(subsets, x);
        int yRoot = Find(subsets, y);

        if(subsets[xRoot].rank < subsets[yRoot].rank){
            subsets[xRoot].parent = yRoot;
        } else if(subsets[xRoot].rank > subsets[yRoot].rank){
            subsets[yRoot].parent = xRoot;
        } else {
            subsets[yRoot].parent = xRoot;
            ++subsets[xRoot].rank;
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


