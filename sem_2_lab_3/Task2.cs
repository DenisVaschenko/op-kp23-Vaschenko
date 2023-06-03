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
class Program
{
    static void Main(string[] args)
    {
    }
}