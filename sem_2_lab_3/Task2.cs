using System;
using System.Globalization;
class Node<T>
{
    public T value;
    public Node<T> prevNode;
    public Node<T> nextNode;
    public Node(T value)
    {
        this.value = value;
    }
}
class Deque<Item> : IIterable<Item>
{
    public Node<Item> head;
    public Node<Item> tail;
    int count;
    public Deque()
    {
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
        Node<Item> node = new Node<Item>(item);
        if (size() == 0)
        {
            head = node;
            tail = node;
        }
        else
        {
            node.nextNode = head;
            head.prevNode = node;
            head = node;
        }
        count++;
    }
    public void addLast(Item item)
    {
        Node<Item> node = new Node<Item>(item);
        if (size() == 0)
        {
            head = node;
            tail = node;
        }
        else
        {
            node.prevNode = tail;
            tail.nextNode = node;
            tail = node;
        }
        count++;
    }
    public Item removeFirst()
    {
        if (isEmpty())
        {
            throw new InvalidOperationException();
        }
        count--;
        Item res = head.value;
        if (!isEmpty())
        {
            head.nextNode.prevNode = null;
            head = head.nextNode;
        }
        else
        {
            head = null;
            tail = null;
        }
        return res;
    }
    public Item removeLast()
    {
        if (isEmpty())
        {
            throw new InvalidOperationException();
        }
        count--;
        Item res = tail.value;
        if (!isEmpty())
        {
            tail.prevNode.nextNode = null;
            tail = tail.prevNode;
        }
        else
        {
            head = null;
            tail = null;
        }
        return res;
    }
    public IIterator<Item> iterator()
    {
        return new IteratorImpl(this);
    }
    private class IteratorImpl : IIterator<Item>
    {
        Deque<Item> deque;
        private Node<Item> counter;
        public bool HasNext
        {
            get
            {
                return counter != null;
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
            Item res = counter.value;
            counter = counter.nextNode;
            return res;
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