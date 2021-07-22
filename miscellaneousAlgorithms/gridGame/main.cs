using System;
using System.Collections;
using System.Collections.Generic;

/*
  A player is only able to move right. Once they reach the rightmost border, they go to
  the start of the next row and keep going. If you hit an obstacle, you cannot make it
  to the end. There are also one way teleporters that take you from one spot to another.
  
  - The list of obstacles represent indicices on a grid.
  - The list of teleporters are structured such that teleporters[i] = [a, b, c, d] where
      index [a, b] teleports to index [c, d].

  Given int m and int n that are the width and height of a grid, a list of obstacles, and
  a list of teleporters, can you reach the end of the grid starting from 0, 0?
*/

class Solution {
    /*
        T - O(nm), as we must traverse through all elements in th grid of size m X n
        S - O(nm), as we are creating the grid based on m and n
    */
    public static bool GridGame(int m, int n, List<int[]> obstacles, List<int[]> teleports){
        if(m <= 0 || n <= 0) return true;
        
        int[,] grid = CreateGrid(m, n, obstacles, teleports);
        int currentTile;
        
        for(int row = 0; row < m; row++){
            for(int column = 0; column < n; column++){
                currentTile = grid[row, column];
                if(currentTile > 0){
                    row = teleports[currentTile - 1][2];
                    column = teleports[currentTile - 1][3];
                    if(IsOutOfBounds(grid, row, column);
                    currentTile = grid[row, column];
                }
                if(currentTile == -1) return false;
            }
        }
        
        return true;
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
