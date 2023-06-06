
using System.Data;
using System.Diagnostics.Tracing;

public class HashTable<KItem, VItem> where KItem : IEquatable<KItem>
{
    (KItem, VItem)[] dictionary;
    int[] color;
    int capacity;
    int count = 0;
    public HashTable()
    {
    }
    public HashTable(int initialCapacity)
    {
    }
    public void Add(KItem key, VItem value)
    {
    }
    int GetIndex(KItem key)
    {
    }
    public void Remove(KItem key)
    {
    }
    public VItem Get(KItem key)
    {
    }
    public bool Contains(KItem key)
    {
    }
    public void clear()
    {
    }
    public int size()
    {
    }
    int GetHashCode(KItem key)
    {
    }
}
class HashTableTest
{
    public bool TestHashTable()
    {
        try
        {
            HashTable<string, string> hashTable = new HashTable<string, string>();
            return true;
        }
        catch { return false; }
    }
    public bool TestAdd()
    {
        HashTable<string, string> hashTable = new HashTable<string, string>();
        hashTable.Add("code1","val1");
        return hashTable.Get("code1") == "val1";
    }
    public bool TestRemove()
    {
        HashTable<string, string> hashTable = new HashTable<string, string>();
        hashTable.Add("code1", "val1");
        hashTable.Remove("code1");
        try
        {
            hashTable.Get("code1");
            return false;
        }
        catch { return true; }
    }
    public bool TestContains()
    {
        HashTable<string, string> hashTable = new HashTable<string, string>();
        hashTable.Add("code1", "val1");
        hashTable.Add("code2", "val2");
        hashTable.Remove("code1");
        return hashTable.Contains("code2") && !hashTable.Contains("code1");
    }
    public bool TestClear()
    {
        HashTable<string, string> hashTable = new HashTable<string, string>();
        hashTable.Add("code1", "val1");
        hashTable.Add("code2", "val2");
        hashTable.clear();
        return !hashTable.Contains("code2") && !hashTable.Contains("code1");
    }
    public bool TestSize()
    {
        HashTable<string, string> hashTable = new HashTable<string, string>();
        hashTable.Add("code1", "val1");
        hashTable.Add("code2", "val2");
        HashTable<string, string> hashTable2 = new HashTable<string, string>();
        hashTable2.Add("code1", "val1");
        hashTable2.Add("code2", "val2");
        hashTable2.clear();
        return hashTable.size() == 2 && hashTable2.size() == 0;
    }

}
class Program
{
    static string words;
    static void Main(string[] args)
    {
    }
}