using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

[System.Serializable]

public class Stack<A>
{
    private Node<A> first, last;

    private int count;
    public int Count => count;

    public Stack()
    {

    }

    public void Push(A element)
    {
        count++;
        Node<A> node = new Node<A>();
        node.data = element;
        if (first == null)
        {
            first = last = node;
        }
        else
        {
            last.next = node;
            node.prev = last;
            last = node;
        }
    }

    public void Remove()
    {
        count--;
        last = last.prev;
        last.next = null;
    }
    
    public A Pop()
    {
        var data = last.data;
        Remove();
        return data;
    }

    public A Peek()
    {
        return last.data;
    }

    public class Node<A>
    {
        public A data;
        public Node<A> next, prev;
    }
}

public class Queue<A>
{
    private Node<A> first, last;

    private int count;
    public int Count => count;

    public Queue()
    {

    }

    public void Enqueue(A element)
    {
        count++;
        Node<A> node = new Node<A>();
        node.data = element;
        if (first == null)
        {
            first = last = node;
        }
        else
        {
            last.next = node;
            node.prev = last;
            last = node;
        }
    }

    public A Dequeue()
    {
        var data = first.data;
        count--;
        first = first.prev;
        first.next = null;
        return data;
    }

    public A Peek()
    {
        return last.data;
    }

    public class Node<A>
    {
        public A data;
        public Node<A> next, prev;
    }
}