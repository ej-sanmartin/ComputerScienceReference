using System;

// T - O(4^(n^2)), S - O(n^2)
public class Boggle {
    private readonly int SIZE = 26; // number of characters in alphabet
    private readonly int ROW = 3;
    private readonly int COLUMN = 3;

    private class TrieNode {
        public TrieNode[] children = new TrieNode[SIZE];
        public bool isLeaf;
        public TrieNode(){
            this.isLeaf = false;
            for(int i = 0; i < SIZE; i++){
                children[i] = null;
            }
        }
    }

    public void Insert(TrieNode root, String key){
        int n = key.Length;
        TreeNode = current = root;

        for(int i = 0; i < n; i++){
            int index = key[i] - 'A';

            if(current.children[index] == null){
                current.children[index] = new TrieNode();
            }

            current = current.children[index];
        }

        current.leaf = false;
    }

    public bool isSafe(int row, int column, bool[,] visited){
        return (row >= 0 && row < ROW && column >= 0 && column < COLUMN && !visited[row, column]);
    }

    public void SearchWord(TrieNode root, char[,] boggle, int row, int column, bool[,] visited, String str){
        
    }

    public void FindWord(char[,] boggle, TrieNode root){

    }
}