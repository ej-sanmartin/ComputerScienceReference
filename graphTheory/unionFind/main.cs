// T - O(n), S - O(n)
public class UnionFindGraph {
    private class Edge {
        int source, destination;
        public Edge(){ source = destination = 0; }
    }

    private int vertices, edges;
    private Edge[] edgesArr;

    public UnionFindGraph(int vertices, int edges){
        this.vertices = vertices;
        this.edges = edges;
        edgesArr = new Edge[edges];
        for(int edge = 0; edge < edges; edge++){
            edgesArr[edge] = new Edge();
        }
    }

    public int Find(int[] parent, int i){
        if(parent[i] == -1){ return i; }
        return Find(parent, parent[i]);
    }

    public void Union(int[] parent, int x, int y){
        int xSet = Find(parent, x);
        int ySet = Find(parent, y);
        parent[xSet] = ySet;
    }

    public int isCycle(UnionFindGraph graph){
        
    }
}