using System;
using System.Globalization;
class Node<T>
{
    public T value;
    public Node<T> prevNode;
    public Node<T> nextNode;
    public Node(T value)
    {
    }
}
class Deque<Item> : IIterable<Item>
{
    public Node<Item> head;
    public Node<Item> tail;
    int count;
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
    private class IteratorImpl : IIterator<Item>
    {
        Deque<Item> deque;
        private Node<Item> counter;
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
class DequeTest
{
    public bool testDeque()
    {
        try
        {
            Deque<int> deque = new Deque<int>();
            return true;
        }
        catch
        {
            return false;
        }
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
        if (deque.head.value != 1) return false;
        return true;
    }
    public bool testAddLast()
    {
        Deque<int> deque = new Deque<int>();
        deque.addLast(1);
        if (deque.tail.value != 1) return false;
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