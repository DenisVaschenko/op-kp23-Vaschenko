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
        RandomizedQueue<int> RandomizedQueue = new RandomizedQueue<int>();
        if (RandomizedQueue.sequence == null) return false;
        return true;
    }
    public bool testIsEmpty()
    {
        RandomizedQueue<int> RandomizedQueue = new RandomizedQueue<int>();
        if (!RandomizedQueue.isEmpty()) return false;
        RandomizedQueue.enque(1);
        if (RandomizedQueue.isEmpty()) return false;
        return true;
    }
    public bool testSize()
    {
        RandomizedQueue<int> RandomizedQueue = new RandomizedQueue<int>();
        if (RandomizedQueue.size() != 0) return false;
        RandomizedQueue.enque(1);
        if (RandomizedQueue.size() != 1) return false;
        return true;
    }
    public bool testEnque()
    {
        RandomizedQueue<int> RandomizedQueue = new RandomizedQueue<int>();
        RandomizedQueue.enque(1);
        if (RandomizedQueue.sequence[0] != 1) return false;
        return true;
    }
    public bool testDeque()
    {
        RandomizedQueue<int> RandomizedQueue = new RandomizedQueue<int>();
        RandomizedQueue.enque(1);
        RandomizedQueue.enque(2);
        int res1 = RandomizedQueue.dequeue();
        int res2 = RandomizedQueue.dequeue();
        if (res1 == res2 || !(res1 == 1 || res1 == 2) || !(res2 ==1 || res2==2)) return false;
        return true;
    }
    public bool testSample()
    {
        RandomizedQueue<int> RandomizedQueue = new RandomizedQueue<int>();
        RandomizedQueue.enque(1);
        RandomizedQueue.enque(2);
        int res1 = RandomizedQueue.sample();
        int res2 = RandomizedQueue.sample();
        if (!(res1 == 1 || res1 == 2) || !(res2 == 1 || res2 == 2)) return false;
        return true;
    }
    public bool testIterator()
    {
        RandomizedQueue<int> RandomizedQueue = new RandomizedQueue<int>();
        RandomizedQueue.enque(1);
        RandomizedQueue.enque(2);
        IIterator<int> iterator = RandomizedQueue.iterator();
        int res1 = iterator.MoveNext();
        int res2 = iterator.MoveNext();
        if (!(res1 == 1 || res1 == 2) || !(res2 == 1 || res2 == 2) || res1 == res2 || iterator.HasNext) return false;
        return true;
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
        RandomizedQueueTest RandomizedQueueTest = new RandomizedQueueTest();
        if (RandomizedQueueTest.testRandomizedQueue() && RandomizedQueueTest.testIsEmpty() && RandomizedQueueTest.testSize()
            && RandomizedQueueTest.testEnque() && RandomizedQueueTest.testDeque() && RandomizedQueueTest.testSample()
            && RandomizedQueueTest.testIterator()) Console.WriteLine("All tests was passed");
        else Console.WriteLine("Program work uncorrectly");
    }
}