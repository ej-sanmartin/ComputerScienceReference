using System;
using System.Collections.Generic;

class GraphConversion {
  public static int[,] UnweightedUndirectedAdjacencyListToAdjacencyMatrix(Dictionary<int, List<int>> graph){
    int vertices = graph.Count;
    int[,] matrix = new int[vertices, vertices];

    for(int vertex = 0; vertex < vertices; vertex++){
      for(int edge = 0; edge < graph[vertex].Count; edge++){
        matrix[vertex, graph[vertex][edge]] = 1;
        matrix[graph[vertex][edge], vertex] = 1;
      }
    }

    return matrix;
  }

  public static int[,] UnweightedDirectedAdjacencyListToAdjacencyMatrix(Dictionary<int, List<int>> graph){
    int vertices = graph.Count;
    int[,] matrix = new int[vertices, vertices];

    for(int vertex = 0; vertex < vertices; vertex++){
      for(int edge = 0; edge < graph[vertex].Count; edge++){
        matrix[vertex, graph[vertex][edge]] = 1;
      }
    }

    return matrix;
  }

  public static int[,] WeightedUndirectedAdjacencyListToAdjacencyMatrix(Dictionary<int, List<int[]>> graph){
    int vertices = graph.Count;
    int[,] matrix = new int[vertices, vertices];

    for(int vertex = 0; vertex < vertices; vertex++){
      for(int edge = 0; edge < graph[vertex].Count; edge++){
        matrix[vertex, graph[vertex][edge][0]] = graph[vertex][edge][1];
        matrix[graph[vertex][edge][0], vertex] = graph[vertex][edge][1];
      }
    }

    return matrix;
  }

  public static int[,] WeightedDirectedAdjacencyListToAdjacencyMatrix(Dictionary<int, List<int[]>> graph){
    int vertices = graph.Count;
    int[,] matrix = new int[vertices, vertices];

    for(int vertex = 0; vertex < vertices; vertex++){
      for(int edge = 0; edge < graph[vertex].Count; edge++){
        matrix[vertex, graph[vertex][edge][0]] = graph[vertex][edge][1];
      }
    }

    return matrix;
  }

  public static int[,] EdgeListToWeightedUndirectedAdjacencyMatrix(int[,] edges, int vertices){
    int[,] graph = new int[vertices, vertices];

    for(int i = 0; i < edges.GetLength(0); i++){
      graph[edges[i, 0], edges[i, 1]] = edges[i, 2];
      graph[edges[i, 1], edges[i, 0]] = edges[i, 2];
    }

    return graph;
  }

  public static int[,] EdgeListToUnweightedUndirectedAdjacencyMatrix(int[,] edges, int vertices){
    int[,] graph = new int[vertices, vertices];

    for(int i = 0; i < edges.GetLength(0); i++){
      graph[edges[i, 0], edges[i, 1]] = 1;
      graph[edges[i, 1], edges[i, 0]] = 1;
    }

    return graph;
  }

  public static int[,] EdgeListToWeightedDirectedAdjacencyMatrix(int[,] edges, int vertices){
    int[,] graph = new int[vertices, vertices];

    for(int i = 0; i < edges.GetLength(0); i++){
      graph[edges[i, 0], edges[i, 1]] = edges[i, 2];
    }

    return graph;
  }

  public static int[,] EdgeListToUnweightedDirectedAdjacencyMatrix(int[,] edges, int vertices){
    int[,] graph = new int[vertices, vertices];

    for(int i = 0; i < edges.GetLength(0); i++){
      graph[edges[i, 0], edges[i, 1]] = 1;
    }

    return graph;
  }

  public static Dictionary<int, List<int>> EdgeListToUnweightedUndirectedAdjacencyList(int[,] edges, int vertices){
    Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();

    for(int i = 0; i < vertices; i++){
      graph.Add(i, new List<int>());
    }

    for(int i = 0; i < edges.GetLength(0); i++){
      graph[edges[i, 0]].Add(edges[i, 1]);
      graph[edges[i, 1]].Add(edges[i, 0]);
    }

    return graph;
  }

  public static Dictionary<int, List<int[]>> EdgeListToWeightedUndirectedAdjacencyList(int[,] edges, int vertices){
    Dictionary<int, List<int[]>> graph = new Dictionary<int, List<int[]>>();

    for(int vertex = 0; vertex < vertices; vertex++){
      graph.Add(vertex, new List<int[]>());
    }

    for(int vertex = 0; vertex < edges.GetLength(0); vertex++){
      graph[edges[vertex, 0]].Add(new int[]{ edges[vertex, 1], edges[vertex, 2] });
      graph[edges[vertex, 1]].Add(new int[]{ edges[vertex, 0], edges[vertex, 2] });
    }

    return graph;
  }

  public static Dictionary<int, List<int>> EdgeListToUnweightedDirectedAdjacencyList(int[,] edges, int vertices){
    Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();

    for(int vertex = 0; vertex < vertices; vertex++){
      graph.Add(vertex, new List<int>());
    }

    for(int vertex = 0; vertex < edges.GetLength(0); vertex++){
      graph[edges[vertex, 0]].Add(edges[vertex, 1]);
    }

    return graph;
  }

  public static Dictionary<int, List<int[]>> EdgeListToWeightedDirectedAdjacencyList(int[,] edges, int vertices){
    Dictionary<int, List<int[]>> graph = new Dictionary<int, List<int[]>>();

    for(int vertex = 0; vertex < vertices; vertex++){
      graph.Add(vertex, new List<int[]>());
    }

    for(int vertex = 0; vertex < edges.GetLength(0); vertex++){
      graph[edges[vertex, 0]].Add(new int[]{ edges[vertex, 1], edges[vertex, 2] });
    }

    return graph;
  }

  public static List<int[]> WeightedDirectedAdjacencyListToEdgeList(Dictionary<int, List<int[]>> graph){
    List<int[]> edgeList = new List<int[]>();

    for(int vertex = 0; vertex < graph.Count; vertex++){
      foreach(int[] edge in graph[vertex]){
        edgeList.Add(new int[]{ vertex, edge[0], edge[1] });
      }
    }

    return edgeList;
  }

  public static List<int[]> WeightedUndirectedAdjacencyListToEdgeList(Dictionary<int, List<int[]>> graph){
    List<int[]> edgeList = new List<int[]>();

    for(int vertex = 0; vertex < graph.Count; vertex++){
      foreach(int[] edge in graph[vertex]){
        edgeList.Add(new int[]{ vertex, edge[0], edge[1] });
        edgeList.Add(new int[]{ edge[0], vertex, edge[1] });
      }
    }

    return edgeList;
  }

  public static List<int[]> UnweightedDirectedAdjacencyListToEdgeList(Dictionary<int, List<int>> graph){
    List<int[]> edgeList = new List<int[]>();

    for(int vertex = 0; vertex < graph.Count; vertex++){
      foreach(int edge in graph[vertex]){
        edgeList.Add(new int[]{ vertex, edge});
      }
    }

    return edgeList;
  }

  public static List<int[]> UnweightedUndirectedAdjacencyListToEdgeList(Dictionary<int, List<int>> graph){
    List<int[]> edgeList = new List<int[]>();

    for(int vertex = 0; vertex < graph.Count; vertex++){
      foreach(int edge in graph[vertex]){
        edgeList.Add(new int[]{ vertex, edge});
        edgeList.Add(new int[]{ edge, vertex});
      }
    }

    return edgeList;
  }

  public static List<int[]> WeightedDirectedAdjacencyMatrixToEdgeList(int[,] graph){
    List<int[]> edgeList = new List<int[]>();

    for(int vertex = 0; vertex < graph.Count; vertex++){
      for(int edge = 0; edge < graph.GetLength(1); edge++){
        if(graph[vertex, edge] != 0){
          edgeList.Add(new int[]{ vertex, edge, graph[vertex, edge] });
        }
      }
    }

    return edgeList;
  }

  public static List<int[]> WeightedUndirectedAdjacencyMatrixToEdgeList(int[,] graph){
    List<int[]> edgeList = new List<int[]>();

    for(int vertex = 0; vertex < graph.Count; vertex++){
      for(int edge = 0; edge < graph.GetLength(1); edge++){
        if(graph[vertex, edge] != 0){
          edgeList.Add(new int[]{ vertex, edge, graph[vertex, edge] });
          edgeList.Add(new int[]{ edge, vertex, graph[vertex, edge] });
        }
      }
    }

    return edgeList;
  }

  public static List<int[]> UnweightedDirectedAdjacencyMatrixToEdgeList(int[,] graph){
    List<int[]> edgeList = new List<int[]>();

    for(int vertex = 0; vertex < graph.Count; vertex++){
      for(int edge = 0; edge < graph.GetLength(1); edge++){
        if(graph[vertex, edge] != 0){
          edgeList.Add(new int[]{ vertex, edge });
        }
      }
    }

    return edgeList;
  }

  public static List<int[]> UnweightedDirectedAdjacencyMatrixToEdgeList(int[,] graph){
    List<int[]> edgeList = new List<int[]>();

    for(int vertex = 0; vertex < graph.Count; vertex++){
      for(int edge = 0; edge < graph.GetLength(1); edge++){
        if(graph[vertex, edge] != 0){
          edgeList.Add(new int[]{ vertex, edge });
          edgeList.Add(new int[]{ edge, vertex });
        }
      }
    }

    return edgeList;
  }
}
