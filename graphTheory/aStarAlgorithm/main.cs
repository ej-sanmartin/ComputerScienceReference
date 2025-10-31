using System;
using System.Linq;
using System.Collections.Generic;

// T - O(|E|) to a worst case of O(b^d)
// S - O(|V|) to a worst case of O(b^d)
public class AStarGraph {
    private List<Node> open, close, path;
    private int xStart, yStart, xEnd, yEnd;
    private bool diagonal;
    private int[][] maze;
    private Node current;

    private class Node {
        public Node parent;
        public int x, y;
        public double cost, huestic;
        
        public Node(Node parent, int xPosition, int yPosition, double g, double h){
            this.parent = parent;
            this.x = xPosition;
            this.y = yPosition;
            this.cost = g;
            this.huestic = h;
        }
    }

    public AStarGraph(int[][] graph, int xStart, int yStart, int xEnd, int yEnd, bool diagonal){
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

    private bool FindNeighborsInList(List<Node> list, Node node){
        return list.SingleOrDefault(item => item.x == node.x || item.y == node.y) != null;
    }

    private double Distance(int x, int y){
        if(this.diagonal){
            return Math.Sqrt(Math.Pow(this.current.x + x - this.xEnd, 2) + Math.Pow(this.current.y + y - this.yEnd));
        } else {
            return Math.Abs(this.current.x + x - this.xEnd) + Math.Abs(this.current.y + y - this.yEnd);
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