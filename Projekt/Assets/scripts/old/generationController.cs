using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class generationController : MonoBehaviour
{
    public bool ready = false;
    public GameObject block;
    public GameObject[,] blocks;
    public int a;
    public int c;
    public int m;
    public int size = 10;
    Losow los;
    // Start is called before the first frame update
    void Start()
    {
        ready = false;
        blocks = new GameObject[size, size];
        TimeSpan t = DateTime.UtcNow - new DateTime(1970, 1, 1);
        int secondsSinceEpoch = (int)t.TotalSeconds;
        los = new Losow(secondsSinceEpoch, a, c, m);
        //Debug.Log(secondsSinceEpoch);
        generate();
    }
    public void generate()
    {
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                
                var tmp = Instantiate(block, new Vector2(i, j), Quaternion.identity, this.transform);
                blocks[i, j] = tmp;
                tmp.GetComponent<tile>().setCord(i, j);
                
                
                long v = los.losuj()%100;
                //Debug.Log(v);
                if (v <= 40)
                {
                    tmp.GetComponent<tile>().weight = 5;
                    tmp.GetComponentInChildren<SpriteRenderer>().color = Color.blue;
                }
                else if (v > 40 && v < 50)
                {
                    tmp.GetComponent<tile>().weight = 4;
                    tmp.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                }
                else if (v >= 50 && v < 70)
                {
                    tmp.GetComponent<tile>().weight = 3;
                    tmp.GetComponentInChildren<SpriteRenderer>().color = Color.green;
                }
                else {
                    tmp.GetComponent<tile>().weight = 1;
                    tmp.GetComponentInChildren<SpriteRenderer>().color = Color.yellow; 
                }


            }
        }
        ready = true;
    }
}
class Losow
{
    long obecna = 0;
    int a= 9;
    int c= 221589;
    int m= 1048576;
    public Losow(int ziarno=0,int a= 6145,int c= 886359, int m= 4194304)
    {
        obecna = ziarno;
    }
    public long losuj()
    {
        obecna = (a * obecna + c) % m;
        return obecna;
    }
}
