using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class field : MonoBehaviour
{
    [SerializeField]
    private Vector2 position = Vector2.zero;
    [SerializeField]
    private int weight = 0;


    private field[] neighbours;


    // Start is called before the first frame update
    private void Awake()
    { 
        this.position=this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void setNeighbours(field[] neighbours)
    {
        this.neighbours = neighbours;
    }
    public Vector2 getPosition()
    {
        return this.position;
    }
    public int getWeight()
    {
        return this.weight;
    }
    public field[] getNeighbours()
    {
        return this.neighbours;
    }
}
