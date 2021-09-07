public class KosarajusAlgorithm {
  // returns count of number of Strongly Connected Components
  public static int KosarajusAlgorithm(Dictionary<int, List<int>> graph){
    int vertices = graph.Count;
    bool[] visited = new bool[vertices];
    Stack<int> stack = new Stack<int>();

    for(int vertex = 0; vertex < vertices; vertex++){
      if(!visited[vertex]){
        FindOrder(graph, vertex, stack, visited);
      }
    }

    Dictionary<int, List<int>> reversed = new Dictionary<int, List<int>>();
    TransposeGraph(vertices, graph, reversed);

    visited = new bool[vertices];

    int SCCCount = 0;
    while(stack.Count != 0){
      int vertex = stack.Pop();
      if(!visited[vertex]){
        DFS(reversed, vertex, visited);
        SCCCount++;
      }
    }

    return SCCCount;
  }

  // first DFS, adds to stack
  public static void FindOrder(Dictionary<int, List<int>> graph, int vertex, Stack<int> stack, bool[] visited){
    visited[vertex] = true;

    foreach(int adjacent in graph[vertex]){
      if(!visited[adjacent]){
        FindOrder(graph, adjacent, stack, visited);
      }
    }

    stack.Push(vertex);
  }

  // transposes graph, stores reversed edges to graph
  public static void TransposeGraph(int vertices, Dictionary<int, List<int>> orginal, Dictionary<int, List<int>> reversed){
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
