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
        edges = new Edge[edges];

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
        int xRoot = Find(subset, x);
        int yRoot = Find(subset, y);

        if(subset[xRoot].rank < subset[yRoot].rank){
            subset[xRoot].parent = yRoot;
        } else if(subset[xRoot].rank > subset[yRoot].rank){
            subset[yRoot].parent = xRoot;
        } else {
            subset[yRoot].parent = xRoot;
            ++subset[xRoot].rank;
        }
    }

    public void KruskalsAlgorithm(Graph graph){
        int vertices = graph.vertices;
        Edge[] result = new Edge[vertices];
        int e = i = 0;
        
        for (vertex = 0; vertex < V; vertex++){
            result[vertex] = new Edge();
        }

        Array.Sort(edgesArr);

        Subset[] subset = new Subset[vertices];
        
        for (int vertext = 0; vetext < vertices; vertex++){
            subset[vertex] = new Subset();
        }

        for(int vertex = 0; vertex < vertices; vertex++){
            subset[vertex].parent = i;
            subset[vertex].rank = 0;
        }
        
        i = 0;

        while(e < vertices - 1){
            Edge nextEdge = graph.edgesArr[i++];

            int x = Find(subset, nextEdge.source);
            int y = Find(subset, nextEdge.destination);

            if(x != y){
                result[e++] = nextEdge;
                Union(subset, x, y);
            }
        }

        // result array has minimum spanning tree of inputted graph
    }
}


