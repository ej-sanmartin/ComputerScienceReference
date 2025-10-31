using System;
using System.Linq;
using System.Collections.Generic;

/// <summary>
/// Implements the A* pathfinding algorithm for grid-based graphs.
/// </summary>
// T - O(|E|) to a worst case of O(b^d)
// S - O(|V|) to a worst case of O(b^d)
public class AStarGraph {
    private List<Node> open, close, path;
    private int xStart, yStart, xEnd, yEnd;
    private bool diagonal;
    private int[][] maze;
    private Node current;

    /// <summary>
    /// Represents a node in the A* search graph.
    /// </summary>
    private class Node {
        public Node Parent { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public double Cost { get; set; }
        public double Heuristic { get; set; }

        public Node(Node parent, int xPosition, int yPosition, double g, double h) {
            Parent = parent;
            X = xPosition;
            Y = yPosition;
            Cost = g;
            Heuristic = h;
        }
    }

    /// <summary>
    /// Initializes a new instance of the AStarGraph class.
    /// </summary>
    /// <param name="graph">The grid representation of the maze.</param>
    /// <param name="xStart">The starting X coordinate.</param>
    /// <param name="yStart">The starting Y coordinate.</param>
    /// <param name="xEnd">The ending X coordinate.</param>
    /// <param name="yEnd">The ending Y coordinate.</param>
    /// <param name="diagonal">Whether diagonal movement is allowed.</param>
    public AStarGraph(int[][] graph, int xStart, int yStart, int xEnd, int yEnd, bool diagonal) {
        this.open = new List<Node>();
        this.close = new List<Node>();
        this.path = new List<Node>();
        this.maze = graph;
        this.current = new Node(null, xStart, yStart, 0, 0);
        this.xStart = xStart;
        this.yStart = yStart;
        this.xEnd = xEnd;
        this.yEnd = yEnd;
        this.diagonal = diagonal;
    }

    /// <summary>
    /// Checks if a node with the same coordinates exists in the given list.
    /// </summary>
    /// <param name="list">The list to search in.</param>
    /// <param name="node">The node to search for.</param>
    /// <returns>True if a node with the same coordinates exists, false otherwise.</returns>
    private bool FindNeighborsInList(List<Node> list, Node node) {
        return list.SingleOrDefault(item => item.X == node.X && item.Y == node.Y) != null;
    }

    /// <summary>
    /// Calculates the heuristic distance from the current position to the end position.
    /// </summary>
    /// <param name="x">The X offset from current position.</param>
    /// <param name="y">The Y offset from current position.</param>
    /// <returns>The heuristic distance.</returns>
    private double Distance(int x, int y) {
        int targetX = current.X + x;
        int targetY = current.Y + y;

        if (diagonal) {
            return Math.Sqrt(Math.Pow(targetX - xEnd, 2) + Math.Pow(targetY - yEnd, 2));
        } else {
            return Math.Abs(targetX - xEnd) + Math.Abs(targetY - yEnd);
        }
    }

    private void AddNeighborsToOpenList(){
        Node node;

        for(int x = -1; x <= 1; x++){
            for(int y = -1; y <= 1; y++){
                if(!this.diagonal && x != 0 && y != 0){ continue; }
                node = new Node(this.current, this.current.x + x, this.current.cost + y, this.current.cost, Distance(x, y));

                if((x != 0 || y != 0) && this.current.x >= 0
                    && this.current.x + x < this.maze[0].Length
                    && this.current.y + y >= 0 && this.current.y + y < this.maze.Length
                    && !FindNeighborsInList(this.open, node)
                    && !FindNeighborsInList(this.close, node)){
                        node.cost = node.parent.cost + 1;
                        node.cost += maze[this.current.y + y][this.current.x + x];
                        this.open.Add(node);
                    }
            }
        }

        this.open.Sort();
    }

    public List<Node> AStarSearchAlgorithm(int xEnd, int yEnd){
        this.xEnd = xEnd;
        this.yEnd = yEnd;
        this.close.Add(this.current);

        AddNeighborsToOpenList();

        while(this.current.x != this.xEnd || this.current.y != this.yEnd){
            if(this.open.Count == 0){ return null; }
            this.current = this.open.First();
            this.open.RemoveAt(0);
            this.close.Add(this.current);
            AddNeighborsToOpenList();
        }

        this.path.Insert(0, this.current);

        while(this.current.x != this.xStart || this.current.y != this.yStart){
            this.current = this.current.parent;
            this.path.Insert(0, this.current);
        }

        this.path;
    }
}