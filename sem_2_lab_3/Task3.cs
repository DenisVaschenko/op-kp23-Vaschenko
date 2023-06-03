using System;
using System.Globalization;

class RandomizedQueue<Item> : IIterable<Item>
{
    int count;
    public Item[] sequence;
    Random rand = new Random();
    public RandomizedQueue()
    {
        sequence = new Item[100];
        count = 0;
    }
    public bool isEmpty()
    {
        return count == 0;
    }
    public int size()
    {
        return count;
    }
    public void enque(Item item)
    {
        sequence[size()] = item;
        count++;
        if (size() == sequence.Length) Expand();
        
    }
    public Item dequeue()
    {
        if (isEmpty())
        {
            throw new InvalidOperationException();
        }
        int i = rand.Next(size());
        Item res = sequence[i];
        count--;
        sequence[i] = sequence[size()];
        return res;
    }
    public Item sample()
    {
        if (isEmpty())
        {
            throw new InvalidOperationException();
        }
        return sequence[rand.Next(count)];
    }
    public IIterator<Item> iterator()
    {
        return new IteratorImpl(this);
    }
    private class IteratorImpl : IIterator<Item>
    {
        RandomizedQueue<Item> randomizedQueue;
        public bool HasNext
        {
            get
            {
                return randomizedQueue.size() > 0;
            }
        }
        public IteratorImpl(RandomizedQueue<Item> randomizedQueue)
        {
            this.randomizedQueue = randomizedQueue;
        }
        public Item MoveNext()
        {
            if (!this.HasNext)
            {
                throw new IndexOutOfRangeException();
            }
            return randomizedQueue.dequeue();
        }
    }
    void Expand()
    {
        Item[] temp = sequence;
        sequence = new Item[temp.Length * 2];
        int i = 0;
        while (i < temp.Length)
        {
            sequence[i] = temp[i];
            i++;
        }
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