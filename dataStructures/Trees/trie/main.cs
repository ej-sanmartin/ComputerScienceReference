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

  // O(l), where L is the length of the word you are inserting
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

  // O(l), where L is the size of the word you are searching for
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

  // O(l) where L is the length of the word you are trying to delete
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
