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

    // will print out word if found in Boggle 2D array
    public void SearchWord(TrieNode root, char[,] boggle, int row, int column, bool[,] visited, String str){
        if(root.isLeaf == true){ Console.WriteLine(str); }

        if(isSafe(row, column, visited)){
            visited[row, column] = true;

            for(int child = 0; child < SIZE; child++){
                if(root.children[child] != null){
                    char c = (char)(child + 'A');

                    if(isSafe(row + 1, column + 1, visited) && boggle[row + 1, column + 1] == c){
                        SearchWord(root.children[child], boggle, row + 1, column + 1, visited, str + c);
                    }

                    if(isSafe(row, column + 1, visited) && boggle[row, column + 1] == c){
                        SearchWord(root.children[child], boggle, row, column + 1, visited, str + c);
                    }

                    if(isSafe(row - 1, column + 1, visited) && boggle[row - 1, column + 1] == c){
                        SearchWord(root.children[child], boggle, row - 1, column + 1, visited, str + c);
                    }

                    if(isSafe(row + 1, column, visited) && boggle[row + 1, column] == c){
                        SearchWord(root.children[child], boggle, row + 1, column, visited, str + c);
                    }

                    if(isSafe(row + 1, column - 1, visited) && boggle[row + 1, column - 1] == c){
                        SearchWord(root.children[child], boggle, row + 1, column - 1, visited, str + c);
                    }

                    if(isSafe(row, column - 1, visited) && boggle[row, column - 1] == c){
                        SearchWord(root.children[child], boggle, row, column - 1, visited, str + c);
                    }

                    if(isSafe(row - 1, column - 1, visited) && boggle[row - 1, column - 1] == c){
                        SearchWord(root.children[child], boggle, row - 1, column - 1, visited, str + c);
                    }
                    
                    if(isSafe(row - 1, column, visited) && boggle[row - 1, column] == c){
                        SearchWord(root.children[child], boggle, row - 1, column, visited, str + c);
                    }
                }
            }
            
            visited[row, column] = false;
        }
    }

    public void FindWord(char[,] boggle, TrieNode root){
        bool[,] visited = new bool[ROW, COLUMN];
        TrieNode current = root;
        String str = "";

        for(int row = 0; row < ROW; row++){
            for(int column = 0; column < COLUMN; column++){
                if(current.children[(boggle[row, column] - 'A')] != null){
                    str = str + boggle[row, column];
                    SearchWord(current.children[(boggle[row, column] - 'A')], boggle, row, column, visited, str);
                    str = "";
                }
            }
        }
    }
}