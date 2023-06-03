using System;
using System.Globalization;

class RandomizedQueue<Item> : IIterable<Item>
{
    int count;
    public Item[] sequence;
    Random rand = new Random();
    public RandomizedQueue()
    {
    }
    public bool isEmpty()
    {
    }
    public int size()
    {
    }
    public void enque(Item item)
    {
    }
    public Item dequeue()
    {
    }
    public Item sample()
    {
    }
    public IIterator<Item> iterator()
    {
    }
    private class IteratorImpl : IIterator<Item>
    {
        RandomizedQueue<Item> randomizedQueue;
        public bool HasNext
        {
            get
            {
            }
        }
        public IteratorImpl(RandomizedQueue<Item> randomizedQueue)
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
class RandomizedQueueTest
{
    public bool testRandomizedQueue()
    {
    }
    public bool testIsEmpty()
    {
    }
    public bool testSize()
    {
    }
    public bool testEnque()
    {
    }
    public bool testDeque()
    {
    }
    public bool testSample()
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