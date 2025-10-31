using System;
using System.Collections.Generic;

/// <summary>
/// Implements a grid-based pathfinding game with obstacles and teleporters.
/// </summary>
/*
  A player can only move right. When reaching the rightmost border, they move to
  the start of the next row. Obstacles block the path, and teleporters transport
  the player to different locations.

  - Obstacles are represented as [row, col] coordinates
  - Teleporters are [fromRow, fromCol, toRow, toCol] arrays

  Given grid dimensions m x n, obstacles, and teleporters, determine if the player
  can reach the end (bottom-right corner) starting from (0, 0).
*/
public class GridGameSolution {
    /// <summary>
    /// Determines if a path exists from (0,0) to (m-1,n-1) following movement rules.
    /// </summary>
    /// <param name="m">Number of rows in the grid.</param>
    /// <param name="n">Number of columns in the grid.</param>
    /// <param name="obstacles">List of obstacle coordinates.</param>
    /// <param name="teleports">List of teleporter definitions.</param>
    /// <returns>True if a path exists to the end, false otherwise.</returns>
    /*
        Time Complexity: O(m*n), as we may need to visit each cell
        Space Complexity: O(m*n), for the grid and visited tracking
    */
    public static bool CanReachEnd(int m, int n, List<int[]> obstacles, List<int[]> teleports) {
        if (m <= 0 || n <= 0) return true;

        int[,] grid = CreateGrid(m, n, obstacles, teleports);
        bool[,] visited = new bool[m, n];

        return CanReachEndRecursive(grid, visited, 0, 0, m, n);
    }

    private static bool CanReachEndRecursive(int[,] grid, bool[,] visited, int row, int col, int m, int n) {
        // Check bounds
        if (row < 0 || row >= m || col < 0 || col >= n) return false;

        // Check if already visited or is obstacle
        if (visited[row, col] || grid[row, col] == -1) return false;

        // Reached the end
        if (row == m - 1 && col == n - 1) return true;

        visited[row, col] = true;

        // Check for teleporter
        if (grid[row, col] > 0) {
            // This should be handled by the teleporter list indexing
            // For now, assume teleporters are marked but destinations need to be tracked separately
            return false; // Simplified - would need proper teleporter destination tracking
        }

        // Try moving right, or to next row if at end of current row
        if (col + 1 < n) {
            if (CanReachEndRecursive(grid, visited, row, col + 1, m, n)) return true;
        } else if (row + 1 < m) {
            if (CanReachEndRecursive(grid, visited, row + 1, 0, m, n)) return true;
        }

        return false;
    }
                 
    public static int[,] CreateGrid(int m, int n, List<int[]> obstacles, List<int[]> teleports){
        int[,] grid = new int[m, n];
        
        foreach(int[] obstacle in obstacles){
            grid[obstacle[0], obstacle[1]] = -1;
        }
        
        int i = 1;
        foreach(int[] teleport in teleports){
            grid[teleport[0], teleport[1]] = i++;
        }
        
        return grid;
    }
    
    public static bool IsOutOfBounds(int[,] grid, int row, int column){
      if(row < 0 || column < 0 || row >= grid.GetLength(0) || column >= grid.GetLength(1)) return true;
      return false
    }
    
    static void Main(string[] args) {
        int m = 5;
        int n = 5;
        List<int[]> obstaclesOne = new List<int[]>();
        obstaclesOne.Add(new int[2]{ 2, 4 });
        obstaclesOne.Add(new int[2]{ 3, 3 });
        obstaclesOne.Add(new int[2]{ 1, 2 });
        
        // All of these teleports are before obstacles and take player to the other side of it
        // Remove any one and it'll return false, otherwise, will returns true
        List<int[]> teleportsOne = new List<int[]>();
        teleportsOne.Add(new int[4]{ 2, 3, 3, 1 });
        teleportsOne.Add(new int[4]{ 3, 2, 3, 4 });
        teleportsOne.Add(new int[4]{ 1, 1, 1, 3 });
        
        Console.WriteLine(GridGame(m, n, obstaclesOne, teleportsOne));
    }
}
