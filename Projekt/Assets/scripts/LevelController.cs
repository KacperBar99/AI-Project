using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    private field[] fields;

    public class PriorityQueu<T>
    {
        private class node
        {
            T value;
            node next;
            int priority;
            public node(T value,int priority)
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
            public int getPriority()
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
        public void insert(T item, int priority)
        {
            this.size++;
            node tmp = new node(item,priority);
            if (head.getPriority() < priority)
            {
                tmp.setNext(head);
                this.head = tmp;
            }
            else
            {
                node before = head;
                node current = head.getNext();
                while(current!=null && current.getPriority() > priority)
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
            this.size--;
            T item=this.head.getValue();
            this.head=this.head.getNext();
            return item;
        }
        public T peek()
        {
            T item = this.head.getValue();
            return item;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        this.fields = this.GetComponentsInChildren<field>();
        foreach (field field in this.fields)
        {
            List<field> tmp = new List<field>();
            field.setWeight(Random.Range(1,10));
            foreach (field field2 in this.fields)
            {
                if(field2 != field)
                {
                    var pos1 = field.getPosition();
                    var pos2 = field2.getPosition();

                    if(Mathf.Abs(pos1.x - pos2.x)==1 && pos1.y == pos2.y)
                    {
                        if(!tmp.Contains(field2))tmp.Add(field2);
                    }
                    if (Mathf.Abs(pos1.y - pos2.y) == 1 && pos1.x == pos2.x)
                    {
                        if (!tmp.Contains(field2)) tmp.Add(field2);
                    }
                    field.setNeighbours(tmp.ToArray());
                }
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<Vector2> findPath(Vector2 start, Vector2 end)
    {
        List<Vector2> path = new List<Vector2>();


        return path;
    }
}
