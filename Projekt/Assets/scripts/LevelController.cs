using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    private field[] fields;


    // Start is called before the first frame update
    void Start()
    {
        
        this.fields = this.GetComponentsInChildren<field>();
        foreach (field field in this.fields)
        {
            List<field> tmp = new List<field>();
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
    

    public field findPath(Vector2 first, Vector2 end)
    {
        field start=null;
        field target=null;
        first = new Vector2 (Mathf.Round(first.x), Mathf.Round(first.y));
        end = new Vector2(Mathf.Round(end.x), Mathf.Round(end.y));
        //resetowanie p�l
        foreach(field field in this.fields)
        {
            field.cost = 0;
            field.costDistance = 0;
            field.setParent(null);
        }
        //finding start field
        foreach(var field in this.fields)
        {
            if(field.getPosition() == first)
            {
                start = field;
                break;
            }
        }
        //finding end field 
        foreach (var field in this.fields)
        {
            if (field.getPosition() == end)
            {
                target = field;
                break;
            }
        }
        //proper BFS
        var queu = new PriorityQueu<field>();
        List<field> visited = new List<field>();
        visited.Add(start);
        queu.insert(start, this.getPriority(start.getPosition(),target.getPosition(),0));
        while (queu.getSize() > 0)
        {
            field min = queu.pull();
            var neighbours = min.getNeighbours();
            foreach (var field in neighbours) 
            {
                if (!visited.Contains(field))
                {
                    if (field == target)
                    {
                        field.setParent(min);
                        return field;
                    }
                    else
                    {
                        field.setParent(min);
                        field.cost = field.getWeight() + min.cost;
                        visited.Add(field);
                        queu.insert(field, this.getPriority(field.getPosition(), target.getPosition(), field.cost));
                        field.costDistance=(this.getPriority(field.getPosition(), target.getPosition(), field.cost));
                    }
                }
            }
        }

        return null;
    }
    private float getPriority(Vector2 pos,Vector2 finish,float cost)
    {
        return cost + Vector2.Distance(pos, finish);
    }
    public field getField(Vector2 position)
    {
        Vector2 toFind = new Vector2(Mathf.Round(position.x), Mathf.Round(position.y));
        foreach(var field in fields)
        {
            if(field.getPosition() == toFind) return field;
        }
        return null;
    }
    public void SetDefaultColors()
    {
        foreach(var field in fields)
        {
            field.backToDefault();
        }
    }
}