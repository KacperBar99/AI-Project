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
    [SerializeField]
    private field parent = null;

    public float costDistance;
    public float cost;

    private Color defaultColor;
    private SpriteRenderer sprite;

    private field[] neighbours;


    // Start is called before the first frame update
    private void Awake()
    { 
        this.position=this.transform.position;
        this.sprite = this.gameObject.GetComponent<SpriteRenderer>();
        this.defaultColor = sprite.color;
        if (this.weight == 999) this.weight = int.MaxValue;
    }

    // Update is called once per frame
    void Update()
    {

    }

    
    public void setNeighbours(field[] neighbours)
    {
        List<field> tmp = new List<field>();
        foreach(field field in neighbours)
        {
            if(field.weight!=int.MaxValue)tmp.Add(field);
        }
        this.neighbours = tmp.ToArray();
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
    public void setParent(field parent)
    {
        this.parent = parent;
    }
    public field getParent()
    {
        return this.parent;
    }
    public void backToDefault()
    {
        this.sprite.color = defaultColor;
    }
}
