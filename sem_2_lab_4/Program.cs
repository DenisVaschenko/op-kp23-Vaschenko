
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
    }
    public bool TestAdd()
    {
    }
    public bool TestRemove()
    {
    }
    public bool TestContains()
    {
    }
    public bool TestClear()
    {
    }
    public bool TestSize()
    {
    }

}
class Program
{
    static string words;
    static void Main(string[] args)
    {
    }
}