using System;
using System.Collections.Generic;

public class Trie {
  private Node root;

  class Node {
    public Dictionary<char, Node> children;
    public bool IsEndWord;
    public Node(){
      children = new Dictionary<char, Node>();
      IsEndWord = false;
    }
  }

  public Trie(){
    root = new Node();
  }

  public void confirm(){
    Console.WriteLine("Trie Initialize");
  }

  public void Insert(string word){
    InsertHelper(root, word, 0);
  }

  private void InsertHelper(Node root, string word, int index){
    if(index == word.Length){
      root.IsEndWord = true;
      return;
    }

    char c = word[index];
    if(!root.children.ContainsKey(c)){
      Node node = new Node();
      root.children.Add(c, node);
    }

    InsertHelper(root.children[c], word, index + 1);
  }

  public bool Find(string word){
    return FindHelper(root, word, 0);
  }

  private bool FindHelper(Node root, string word, int index){
    if(index == word.Length) return root.IsEndWord;

    char c = word[index];
    if(!root.children.ContainsKey(c)){
      return false;
    }

    return FindHelper(root.children[c], word, index + 1);
  }

  public void Delete(string word){
    DeleteHelper(root, word, 0);
  }

  private bool DeleteHelper(Node root, string word, int index){
    if(index == word.Length){
      if(root.IsEndWord == false) return false;
      root.IsEndWord = false;
      return root.children.Count == 0;
    }

    char c = word[index];
    if(!root.children.ContainsKey(c)){
      return false;
    }

    bool shouldDeleteCurrentWord = DeleteHelper(root.children[c], word, index + 1);

    if(shouldDeleteCurrentWord){
      root.children.Remove(c);
      return root.children.Count == 0;
    }

    return false;
  }
}
