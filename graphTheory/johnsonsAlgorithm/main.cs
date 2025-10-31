/// <summary>
/// Implements Johnson's algorithm for finding shortest paths between all pairs of vertices.
/// </summary>
// T - O(|V^2|log|V| + |V||E|), S - O(|V^2|)
public class JohnsonsGraph {
    private const int SOURCE_NODE = 0;
    private int nodeCount;
    private int[] potential;
    private int[,] augmentedMatrix, allShortestsPaths;

    /// <summary>
    /// Initializes a new instance of the JohnsonsGraph class.
    /// </summary>
    /// <param name="nodeCount">The number of nodes in the graph.</param>
    public JohnsonsGraph(int nodeCount) {
        this.nodeCount = nodeCount;
        augmentedMatrix = new int[nodeCount + 1, nodeCount + 1];
        potential = new int[nodeCount + 1];
        allShortestsPaths = new int[nodeCount, nodeCount];
    }

    /// <summary>
    /// Computes the augmented graph by adding a source node with zero-weight edges.
    /// </summary>
    /// <param name="adjacencyMatrix">The original adjacency matrix.</param>
    private void ComputeAugmentedGraph(int[,] adjacencyMatrix) {
        for (int source = 0; source < nodeCount; source++) {
            for (int destination = 0; destination < nodeCount; destination++) {
                augmentedMatrix[source, destination] = adjacencyMatrix[source, destination];
            }
        }

        for (int destination = 0; destination < nodeCount; destination++) {
            augmentedMatrix[SOURCE_NODE, destination] = 0;
        }
    }

    /// <summary>
    /// Reweights the graph edges using the potential function.
    /// </summary>
    /// <param name="adjacencyMatrix">The original adjacency matrix.</param>
    /// <returns>The reweighted adjacency matrix.</returns>
    private int[,] ReweightGraph(int[,] adjacencyMatrix) {
        int[,] result = new int[nodeCount, nodeCount];

        for (int source = 0; source < nodeCount; source++) {
            for (int destination = 0; destination < nodeCount; destination++) {
                result[source, destination] = adjacencyMatrix[source, destination] + potential[source] - potential[destination];
            }
        }

        return result;
    }

    public void JohnsonsAlgorithm(int[][] adjacencyMatrix){
        ComputeAugmentedGraph(adjacencyMatrix);
        bellmanFord.BellmanFordAlgorithm(adjacencyMatrix, SOURCE_NODE);
        potential = bellmanFord.GetDistances();
        int[][] reweightedGraph = ReweightGraph(adjacencyMatrix);

        for(int source = 1; source <= nodeCount; source++){
            dijkstras.DijkstrasAlgorithm(reweightedGraph, source);
            int[] result = dijkstras.GetDistances();

            for(int destination = 1; destination <= nodeCount; destination++){
                allShortestsPaths[source][destination] = result[destination] + potential[destination] - potential[source];
            }
        }

        // at this point allShortestsPaths 2D array has shortests paths of all pairs
    }
}