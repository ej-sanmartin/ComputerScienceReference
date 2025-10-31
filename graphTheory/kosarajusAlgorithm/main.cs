/// <summary>
/// Implements Kosaraju's algorithm for finding strongly connected components in a directed graph.
/// </summary>
public class KosarajusAlgorithm {
    /// <summary>
    /// Finds the number of strongly connected components in the graph using Kosaraju's algorithm.
    /// </summary>
    /// <param name="graph">The adjacency list representation of the graph.</param>
    /// <returns>The count of strongly connected components.</returns>
    public static int KosarajusAlgorithm(Dictionary<int, List<int>> graph) {
        int vertices = graph.Count;
        bool[] visited = new bool[vertices];
        Stack<int> stack = new Stack<int>();

        for (int vertex = 0; vertex < vertices; vertex++) {
            if (!visited[vertex]) {
                FindOrder(graph, vertex, stack, visited);
            }
        }

        Dictionary<int, List<int>> reversed = new Dictionary<int, List<int>>();
        TransposeGraph(vertices, graph, reversed);

        visited = new bool[vertices];

        int sccCount = 0;
        while (stack.Count != 0) {
            int vertex = stack.Pop();
            if (!visited[vertex]) {
                DFS(reversed, vertex, visited);
                sccCount++;
            }
        }

        return sccCount;
    }

    /// <summary>
    /// Performs the first DFS traversal and adds vertices to the stack in finishing order.
    /// </summary>
    /// <param name="graph">The adjacency list representation of the graph.</param>
    /// <param name="vertex">The current vertex being visited.</param>
    /// <param name="stack">The stack to store vertices in finishing order.</param>
    /// <param name="visited">The array tracking visited vertices.</param>
    public static void FindOrder(Dictionary<int, List<int>> graph, int vertex, Stack<int> stack, bool[] visited) {
        visited[vertex] = true;

        foreach (int adjacent in graph[vertex]) {
            if (!visited[adjacent]) {
                FindOrder(graph, adjacent, stack, visited);
            }
        }

        stack.Push(vertex);
    }

    /// <summary>
    /// Transposes the graph by reversing all edges.
    /// </summary>
    /// <param name="vertices">The number of vertices in the graph.</param>
    /// <param name="original">The original graph adjacency list.</param>
    /// <param name="reversed">The transposed graph adjacency list.</param>
    public static void TransposeGraph(int vertices, Dictionary<int, List<int>> original, Dictionary<int, List<int>> reversed) {
    for(int i = 0; i < vertices; i++){
      reversed[i] = new List<int>();
    }

    for(int i = 0; i < vertices; i++){
      foreach(int adjacent in orginal[i]){
        reversed[adjacent].Add(i);
      }
    }
  }

  // second DFS to find the strongly connected components
  public static void DFS(Dictionary<int, List<int>> graph, int vertex, bool[] visited){
    visited[vertex] = true;

    foreach(int adjacent in graph[vertex]){
      if(!visited[adjacent]){
        DFS(graph, adjacent, visited);
      }
    }
  }
}
