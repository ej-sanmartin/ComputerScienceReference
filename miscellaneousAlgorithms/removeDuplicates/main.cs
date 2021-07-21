using System;
using System.Collections.Generic;

class RemoveDuplicates {
   public static string[] RemoveDuplicates(string[] arr){
        HashSet<string> hs = new HashSet<string>();
        foreach(string word in arr){
            hs.Add(word);
        }
        
        string[] unique = new string[hs.Count];
        int i = 0;
        
        foreach(string word in hs){
            unique[i++] = word;
        }
        
        return unique;
    }
}
