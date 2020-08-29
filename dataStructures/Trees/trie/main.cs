using String;
using System.Collections.Generic;

// S - O(word * nodes)
public class Trie {
    private class Node {
        Dictionary<char, Node> children;
        bool endOfWord;
        public Node(){
            children = new Dictionary<char, Node>();
            endOfWord = false;
        }
    }

    private Node root;
    public Trie(){ root = new Node(); }

    // T - O(l), length of word
    public bool Find(String word){ return FindHelper(root, word, 0); }

    private bool FindHelper(Node current, String word, int index){
        if(index == word.Length){ return current.endOfWord; }

        char c = word[index];
        Node node = current.children[c];
        
        if(node == null){ return false; }

        return FindHelper(node, word, index++);
    }

    // T - O(l), length of word
    public void Insert(String word){ InsertHelper(root, word, 0); }

    private void InsertHelper(Node current, String word, int index){
        if(index == word.Length){
            current.endOfWord = true;
            return;
        }

        char c = word[index];
        Node node = current.children[c];

        if(node == null){
            node = new Node();
            current.children.Add(c, node);
        }

        InsertHelper(current, word, index++);
    }

    // T - O(l), length of word
    public void Delete(String word){ DeleteHelper(root, word, 0); }

    private bool DeleteHelper(Node current, String word, int index){
        if(index == word.Length){
            if(!current.endOfWord){ return false; }
            current.endOfWord = false;
            return current.children.Count == 0;
        }

        char c = word[index];
        Node node = current.children[c];

        if(node == null){ return false; }

        bool shouldDeleteCurrentNode = DeleteHelper(node, word, index++);

        if(shouldDeleteCurrentNode){
            current.children.Remove(c);
            return current.children.Count == 0;
        }

        return false;
    }
}