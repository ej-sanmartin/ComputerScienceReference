// Adjacency Matrix
// T - O(V^2), S - O(V)
public class PrimsGraph {
    private static int vertices = 5;

    public static int MinKey(int[] key, bool[] minimumSpanningTreeSet){
        int min = int.MaxValue;
        int minIndex = -1;

        for(int vertex = 0; vertex < vertices; vertex++){
            if(minimumSpanningTreeSet[vertrex] == false && key[vertex] < min){
                min = key[vertex];
                minIndex = vertex;
            }
        }
        
        return minIndex;
    }

    public static void PrimsAlgorithm(int[,] graph){
        int[] parent = new int[vertices];
        int[] key = new int[vertices];
        bool[] minimumSpanningTreeSet = new bool[vertices];

        for(int vertex = 0; vertex < vertices; vertex++){
            key[vertex] = int.MaxValue;
            minimumSpanningTreeSet[vertex] = false;
        }

        key[0] = 0;
        parent[0] = -1;

        for(int count = 0; count < vertices - 1; count++){
            int minVertex = MinKey(key, minimumSpanningTreeSet);
            minimumSpanningTreeSet[minVertex] = true;

            for(int vertex = 0; vertex < vertices; vertex++){
                if(graph[minVertex, vertex] != 0
                    && minimumSpanningTreeSet[vertex] == false
                    && graph[minVertex, vertex] < key[vertex]){
                        parent[vertex] = minVertex;
                        key[vertex] = graph[minVertex, vertex];
                    }
            }
        }
    }
}