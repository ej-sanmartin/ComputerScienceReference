// T - O(|V|^3), S - O(|V|^2)
public class FloydWarshallGraph {
    private readonly INFINIT = int.MaxValue;
    
    public static void FloydWarshallAlgorithm(int[,] graph, int vertices){
        int[,] distances = new int[vertices, vertices];
        int i, j, k;

        for(i = 0; i < vertices; i++){
            for(j = 0; j < vertices; j++){
                distances[i, j] = graph[i, j];
            }
        }

        for(k = 0; k < vertices; k++){
            for(i = 0; i < vertices; i++){
                for(j = 0; j < vertices; j++){
                    if(distances[i, k] != INFINITY &&
                       distances[k , j] != INFININTY &&
                       distances[i, k] + distances[k, j] < distances[i, j]){
                        distances[i, j] = distances[i, k] + distances[k, j];
                    }
                }
            }
        }

        // distance matrix contains shortest distances between every pair of vertices
    }
}
