using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
