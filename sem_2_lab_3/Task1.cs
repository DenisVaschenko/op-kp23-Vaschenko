using System;
using System.Globalization;

class Deque<Item> : IIterable<Item>
{
    public int head;
    public int tail;
    int count;
    public Item[] sequence;
    public Deque()
    {
    }
    public bool isEmpty()
    {
    }
    public int size()
    {
    }
    public void addFirst(Item item)
    {
    }
    public void addLast(Item item)
    {
    }
    public Item removeFirst()
    {
    }
    public Item removeLast()
    {
    }
    public IIterator<Item> iterator()
    {
    }
    private class IteratorImpl: IIterator<Item>
    {
        Deque<Item> deque;
        private int counter;
        public bool HasNext
        {
            get
            {
            }
        }
        public IteratorImpl(Deque<Item> deque)
        {
        }
        public Item MoveNext()
        {
        }
    }
    void Expand()
    {
    }
}
class DequeTest
{
    public bool testDeque()
    {
    }
    public bool testIsEmpty()
    {
    }
    public bool testSize()
    {
    }
    public bool testAddFirst()
    {
    }
    public bool testAddLast()
    {
    }
    public bool testRemoveFirst()
    {
    }
    public bool testRemoveLast()
    {
    }
    public bool testIterator()
    {
    }
}
interface IIterable<T>
{
    public IIterator<T> iterator();
}
interface IIterator<T>
{
    bool HasNext { get; }
    T MoveNext();
}
class Program
{
    static void Main(string[] args)
    {
    }
}