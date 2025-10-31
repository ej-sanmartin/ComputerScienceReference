using System;

/// <summary>
/// Implements an optimized Union-Find data structure with path compression and union by rank.
/// </summary>
public class OptimizedUnion {
    private int[] root;
    private int[] rank;

    /// <summary>
    /// Initializes a new instance of the OptimizedUnion class.
    /// </summary>
    /// <param name="vertices">The number of vertices.</param>
    // O(n)
    public OptimizedUnion(int vertices) {
        root = new int[vertices];
        rank = new int[vertices];
        for (int i = 0; i < vertices; i++) {
            root[i] = i;
            rank[i] = 1;
        }
    }

    /// <summary>
    /// Finds the root of the set containing the given element with path compression.
    /// </summary>
    /// <param name="x">The element to find.</param>
    /// <returns>The root of the set containing x.</returns>
    // O(h)
    public int Find(int x) {
        if (x != root[x]) {
            root[x] = Find(root[x]);
        }
        return root[x];
    }

    /// <summary>
    /// Performs union of two sets using union by rank.
    /// </summary>
    /// <param name="x">The first element.</param>
    /// <param name="y">The second element.</param>
    public void Union(int x, int y) {
        int rootX = Find(x);
        int rootY = Find(y);
        if (rootX != rootY) {
            if (rank[rootX] > rank[rootY]) {
                root[rootY] = rootX;
      } else if(rank[rootX] < rank[rootY]){
        root[rootX] = rootY;
      } else {
        root[rootY] = rootX;
        rank[rootX]++;
      }
    }
  }

  public bool IsConnected(int x, int y){
    return Find(x) == Find(y);
  }
}
