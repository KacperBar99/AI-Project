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
        //delete later
        Application.targetFrameRate = -1;
        QualitySettings.vSyncCount = 0;

        Application.runInBackground = false;
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

        //test kolejki
        var queu = new PriorityQueu<field>();
        for(int i=0;i<fields.Length;i++)
        {
            queu.insert(fields[i],i);
            Debug.Log(i);
        }
        for(int i=0; i<fields.Length;i++)
        {
            var tmp = queu.pull();
           
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