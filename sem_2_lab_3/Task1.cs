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
        sequence = new Item[100];
        head = sequence.Length;
        tail = -1;
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
    public void addFirst(Item item)
    {
        count++;
        head = head - 1;
        if (head < 0) head = sequence.Length + head;
        sequence[head] = item;
        if (size() == sequence.Length) Expand();
    }
    public void addLast(Item item)
    {
        count++;
        tail = (tail + 1) % sequence.Length;
        sequence[tail] = item;
        if (size() == sequence.Length) Expand();
    }
    public Item removeFirst()
    {
        if (isEmpty())
        {
            throw new InvalidOperationException();
        }
        Item res = sequence[head];
        head = (head + 1) % sequence.Length;
        count--;
        return res;
    }
    public Item removeLast()
    {
        if (isEmpty())
        {
            throw new InvalidOperationException();
        }
        Item res = sequence[tail];
        tail = tail - 1;
        if (tail < 0) tail = sequence.Length + tail;
        count--;
        return res;
    }
    public IIterator<Item> iterator()
    {
        return new IteratorImpl(this);
    }
    private class IteratorImpl: IIterator<Item>
    {
        Deque<Item> deque;
        private int counter;
        public bool HasNext
        {
            get
            {
                return ((counter >= deque.head && counter - deque.head < deque.size()) || (counter <= deque.tail && deque.tail - counter < deque.size()));
            }
        }
        public IteratorImpl(Deque<Item> deque)
        {
            this.deque = deque;
            counter = deque.head;
        }
        public Item MoveNext()
        {
            if (!this.HasNext)
            {
                throw new IndexOutOfRangeException();
            }
            Item res = deque.sequence[counter];
            counter = (counter + 1) % deque.sequence.Length;
            return res;
        }
    }
    void Expand()
    {
        Item[] temp = sequence;
        sequence = new Item[temp.Length * 2];
        int i = sequence.Length - size() / 2;
        int j = head;
        while (i >= sequence.Length - (size() / 2) || i < size()/2 + size() % 2)
        {
            sequence[i] = temp[j];
            i = (i + 1) % sequence.Length;
            j = (j + 1) % temp.Length;
        }
    }
}
class DequeTest
{
    public bool testDeque()
    {
        Deque<int> deque = new Deque<int>();
        if (deque.sequence == null || deque.head == null || deque.tail == null) return false;
        return true;
    }
    public bool testIsEmpty()
    {
        Deque<int> deque = new Deque<int>();
        if (!deque.isEmpty()) return false;
        deque.addFirst(1);
        if (deque.isEmpty()) return false;
        return true;
    }
    public bool testSize()
    {
        Deque<int> deque = new Deque<int>();
        if (deque.size() != 0) return false;
        deque.addFirst(1);
        if (deque.size() != 1) return false;
        return true;
    }
    public bool testAddFirst()
    {
        Deque<int> deque = new Deque<int>();
        deque.addFirst(1);
        if (deque.sequence[deque.head] != 1) return false;
        return true;
    }
    public bool testAddLast()
    {
        Deque<int> deque = new Deque<int>();
        deque.addLast(1);
        if (deque.sequence[deque.tail] != 1) return false;
        return true;
    }
    public bool testRemoveFirst()
    {
        Deque<int> deque = new Deque<int>();
        deque.addFirst(1);
        if (deque.removeFirst() != 1) return false;
        return true;
    }
    public bool testRemoveLast()
    {
        Deque<int> deque = new Deque<int>();
        deque.addLast(1);
        if (deque.removeLast() != 1) return false;
        return true;
    }
    public bool testIterator()
    {
        Deque<int> deque = new Deque<int>();
        deque.addLast(2);
        deque.addFirst(1);
        IIterator<int> iterator = deque.iterator();
        if (!iterator.HasNext || iterator.MoveNext() != 1 || iterator.MoveNext() != 2 || iterator.HasNext) return false;
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
        DequeTest dequeTest = new DequeTest();
        if (dequeTest.testDeque() && dequeTest.testIsEmpty() && dequeTest.testSize()
            && dequeTest.testAddFirst() && dequeTest.testAddLast() && dequeTest.testRemoveFirst()
            && dequeTest.testRemoveLast() && dequeTest.testIterator()) Console.WriteLine("All tests was passed");
        else Console.WriteLine("Program work uncorrectly");
    }
}