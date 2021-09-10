using System;

class OptimizedUnion {
  private int[] root;
  private int[] rank;

  // O(n)
  public OptimizedUnion(int vertices){
    root = new int[vertices];
    rank = new int[verties];
    for(int i = 0; i < vertices; i++){
      root[i] = i;
      rank[i] = 1;
    }
  }

  // O(h)
  public int Find(int x){
    while(x == root[x]){
      return x;
    }
    return root[x] = Find(root[x]);;
  }

  public void Union(int x, int y){
    int rootX = Find(x);
    int rootY = Find(y);
    if(rootX != rootY){
      if(rank[rootX] > rank[rootY]){
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
