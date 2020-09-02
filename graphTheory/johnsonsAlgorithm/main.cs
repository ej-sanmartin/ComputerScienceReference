// T - O(|V^2|log|V| + |V||E|), S - O(|V^2|)
public class JohnsonsGraph {
    private int SOURCE_NODE, nodeCount;
    private int[] potential;
    private int[][] augmentedMatrix, allShortestsPaths;
    private BellmanFordGraph bellmanFord;
    private DijkstrasGraph dijkstras;

    public JohnsonsGraph(int nodeCount){
        this.nodeCount = nodeCount;
        augmentedMatrix = new int[nodeCount + 2][nodeCount + 2];
        SOURCE_NODE = nodeCount + 1;
        potential = new int[nodeCount + 2];
        bellmanFord = new BellmanFordGraph(nodeCount + 1);
        dijkstras = new DijkstrasGraph(nodeCount);
        allShortestsPaths = new int[nodeCount + 1][nodeCount + 1];
    }

    private void ComputeAugmentedGraph(int[][] adjacencyMatrix){
        for(int source = 1; source <= nodeCount; source++){
            for(int destination = 1; destination <= nodeCount; destination++){
                augmentedMatrix[source][destination] = adjacencyMatrix[source][destination];
            }
        }

        for(int destination = 1; destination <= nodeCount; destination++){
            augmentedMatrix[SOURCE_NODE][destination] = 0;
        }
    }

    private int[][] ReweightGraph(int[][] adjacencyMatrix){
        int[][] result = new int[nodeCount + 1][nodeCount + 1];

        for(int source = 1; source <= nodeCount; source++){
            for(int destination = 1; destination <= nodeCount; destination++){
                result[source][destination] = adjacencyMatrix[source][destination] + potential[source] - potential[destination];
            }
        }

        return result;
    }

    public void JohnsonsAlgorithm(int[][] adjacencyMatrix){
        ComputeAugmentedGraph(adjacencyMatrix);
        bellmanFord.BellmanFordAlgorithm(adjacencyMatrix, SOURCE_NODE);
        potential = bellmanFord.GetDistances();
        int[][] reweightedGraph = reweightedGraph(adjacencyMatrix);

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