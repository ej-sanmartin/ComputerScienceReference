using System;

/// <summary>
/// Represents a hash table data structure using separate chaining for collision resolution.
/// </summary>
public class HashTable {
    private const int InitialCapacity = 16;
    private HashEntry[] data;

    private class HashEntry {
        public string Key { get; set; }
        public string Value { get; set; }
        public HashEntry Next { get; set; }

        public HashEntry(string key, string value) {
            Key = key;
            Value = value;
            Next = null;
        }
    }

    /// <summary>
    /// Initializes a new instance of the HashTable class.
    /// </summary>
    public HashTable() {
        data = new HashEntry[InitialCapacity];
    }

    /// <summary>
    /// Computes the hash index for a given key.
    /// </summary>
    /// <param name="key">The key to hash.</param>
    /// <returns>The computed hash index.</returns>
    // T - O(1)
    private int GetIndex(string key) {
        int hashCode = key.GetHashCode();
        int index = (hashCode & 0x7fffffff) % InitialCapacity;
        return index;
    }

    /// <summary>
    /// Inserts a key-value pair into the hash table.
    /// </summary>
    /// <param name="key">The key to insert.</param>
    /// <param name="value">The value associated with the key.</param>
    // T - O(1), with collision can increase to O(n)
    public void Put(string key, string value) {
        int index = GetIndex(key);
        HashEntry entry = new HashEntry(key, value);

        if (data[index] == null) {
            data[index] = entry;
        } else {
            HashEntry entries = data[index];
            while (entries.Next != null) {
                entries = entries.Next;
            }
            entries.Next = entry;
        }
    }

    /// <summary>
    /// Retrieves the value associated with the specified key.
    /// </summary>
    /// <param name="key">The key to search for.</param>
    /// <returns>The value associated with the key, or null if not found.</returns>
    // T - O(1) unless there's a collision, that would increase time to O(n)
    public string Get(string key) {
        int index = GetIndex(key);
        HashEntry entries = data[index];

        if (entries != null) {
            while (!(entries.Key == key) && entries.Next != null) {
                entries = entries.Next;
            }
            return entries.Value;
        } else {
            Console.WriteLine("Item not found in HashTable");
            return null;
        }
    }
}