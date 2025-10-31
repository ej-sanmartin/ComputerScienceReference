using System;

public class HashTable {
    private int initialCapacity = 16;
    private HashEntry[] data;

    private class HashEntry {
        public String key, value;
        public HashEntry next;
        public HashEntry(String key, String value){
            this.key = key;
            this.value = value;
            this.next = null;
        }
    }

    public HashTable(){ data = new HashEntry[initialCapacity]; }

    // T - O(1)
    private int GetIndex(String key){
        int hashCode = key.GetHashCode();
        int index = (hashCode & 0x7fffffff) % initialCapacity;
        return index;
    }

    // T - O(1), with collision can increase to O(n)
    public void Put(String key, String value){
        int index = GetIndex(key);
        HashEntry entry = new HashEntry(key, value);

        if(data[index] == null){ data[index] = entry; }
        else {
            HashEntry entries = data[index];
            while(entries.next != null){
                entries = entries.next;
            }
            entries.next = entry;
        }
    }

    // T - O(1) unless there's a collision, that would increase time to O(n)
    public String Get(String key){
        int index = GetIndex(key);
        HashEntry entries = data[index];

        if(entries != null){
            while(!(entries.key == key) && entries.next != null){
                entries = entries.next;
            }
            return entries.value;
        } else {
            Console.WriteLine("Item not found in HashTable");
            return null;
        }
    }
}