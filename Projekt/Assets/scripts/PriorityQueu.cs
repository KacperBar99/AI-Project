using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriorityQueu<T>
{

    private class node
    {
        T value;
        node next;
        float priority;
        public node(T value, float priority)
        {
            this.value = value;
            this.priority = priority;
        }
        public void setNext(node next)
        {
            this.next = next;
        }
        public node getNext()
        {
            return this.next;
        }
        public T getValue()
        {
            return this.value;
        }
        public float getPriority()
        {
            return this.priority;
        }
    }
    node head;
    int size;
    public PriorityQueu()
    {
        head = null;
        size = 0;
    }
    public int getSize()
    {
        return this.size;
    }
    public void insert(T item, float priority)
    {
        node tmp = new node(item, priority);
        if (this.size == 0)
        {
            this.head = tmp;
            this.size++;
            return;
        }
        this.size++;

        if (head.getPriority() > priority)
        {
            tmp.setNext(head);
            this.head = tmp;
        }
        else
        {
            node before = head;
            node current = head.getNext();
            while (current != null && current.getPriority() < priority)
            {
                before = current;
                current = current.getNext();
            }
            tmp.setNext(current);
            before.setNext(tmp);
        }
    }
    public T pull()
    {
        if (head == null) return default(T);
        this.size--;
        T item = this.head.getValue();
        this.head = this.head.getNext();
        return item;
    }
    public T peek()
    {
        T item = this.head.getValue();
        return item;
    }
    public void print()
    {
        node it = this.head;
        string res="Kolejka ";
        while (it != null)
        {
            res += " " + it.getPriority();
            it = it.getNext();
        }
        Debug.Log(res);
    }
}
