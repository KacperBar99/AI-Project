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

    private SpriteRenderer spriteRenderer;

    private field[] neighbours;


    // Start is called before the first frame update
    private void Awake()
    {
        this.spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        this.position=this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setWeight(int weight)
    {
        if(this.spriteRenderer != null)
        {
            this.spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        }
        this.weight = weight;
        float color = Mathf.Max(0.1f, 0.1f*weight);
        
        this.spriteRenderer.color=new Color(color,color,color,1);
        
    }
    public void setNeighbours(field[] neighbours)
    {
        this.neighbours = neighbours;
    }
    public Vector2 getPosition()
    {
        return this.position;
    }
}
