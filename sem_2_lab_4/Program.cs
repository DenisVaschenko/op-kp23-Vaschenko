
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
        capacity = 50;
        dictionary = new (KItem, VItem)[capacity * 2];
        color = new int[capacity * 2];
    }
    public HashTable(int initialCapacity)
    {
        capacity = initialCapacity;
        dictionary = new (KItem, VItem)[capacity * 2];
        color = new int[capacity * 2];
    }
    public void Add(KItem key, VItem value)
    {
        try
        {
            GetIndex(key);
            Console.WriteLine("You are trying to add already existing key");
        }
        catch
        {
            int index = GetHashCode(key) % dictionary.Length;
            if (index < 0) index = dictionary.Length + index;
            int i = 0;
            while (color[(index + i * i) % dictionary.Length] != 0)
            {
                i++;
            }
            color[(index + i * i) % dictionary.Length] = 2;
            dictionary[(index + i * i) % dictionary.Length] = (key, value);
            count++;
        }
    }
    int GetIndex(KItem key)
    {
        int index = GetHashCode(key) % dictionary.Length;
        if (index < 0) index = dictionary.Length + index;
        int i = 0;
        while (dictionary[(index + i * i) % dictionary.Length].Item1 == null || !dictionary[(index + i*i) % dictionary.Length].Item1.Equals(key) || color[(index + i * i) % dictionary.Length] != 2)
        {
            if (color[(index + i * i) % dictionary.Length] == 0) throw new IndexOutOfRangeException();
            i++;
        }
        return (index + i * i) % dictionary.Length;
    }
    public void Remove(KItem key)
    {
        int index = GetIndex(key);
        color[index] = 1;
        count--;
    }
    public VItem Get(KItem key)
    {
        return dictionary[GetIndex(key)].Item2;
    }
    public bool Contains(KItem key)
    {
        try
        {
            GetIndex(key);
            return true;
        }
        catch { return false; }
    }
    public void clear()
    {
        for(int i = 0; i < color.Length; i++)
        {
            color[i] = 0;
        }
        count = 0;
    }
    public int size()
    {
        return count;
    }
    int GetHashCode(KItem key)
    {
        unchecked
        {
            int hashcode = 3648978;
            hashcode = (hashcode *764891)^key.GetHashCode();
            return hashcode;
        }
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
    static string words = "differ\ngrave\ntape\nmanual" +
    "\ntycoon\nwording\nvirgin\nregistration" +
    "\ndrum\nfacility\nspy\nexclude" +
    "\nscrap\nboot\nreign\necho" +
    "\nrelease\nbattlefield\nsense" +
    "\ntribe\nbelly\nrelevance\ntempt" +
    "\nbenefit\nconcert\nanxiety\ndistance" +
    "\nrescue\nraw\ncooperation\nshed\nfunctional" +
    "\ntumour\nlip\nvein\nopen\neat\ncount" +
    "\ncomposer\npreference\nembrace\nunion" +
    "\nby\nneedle\nfraud\ndiplomat\nparallel" +
    "\nfavorable\nbold\nnursery";
    static void Main(string[] args)
    {
        HashTableTest hs = new HashTableTest();
        if (hs.TestHashTable() && hs.TestAdd() && hs.TestRemove() && hs.TestContains()
            && hs.TestClear() && hs.TestSize()) Console.WriteLine("All tests were passed");
        else Console.WriteLine("Program work uncorrectly");
        HashTable<string, bool> hashTable = new HashTable<string, bool>(100);
        string s = "";
        for (int i = 0; i < words.Length; i++)
        {
            if (words[i] == '\n')
            {
                hashTable.Add(s, false);
                s = "";
            }
            else
            {
                s += words[i];
            }
        }
        hashTable.Add(s, false);
        Console.WriteLine("Enter 1 word per line");
        s = Console.ReadLine();
        while (s != "stop")
        {
            if (hashTable.Contains(s)) Console.WriteLine("OK");
            else Console.WriteLine("WrongSpelling");
            s = Console.ReadLine();
        }
    }
}