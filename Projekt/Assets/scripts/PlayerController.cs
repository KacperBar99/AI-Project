using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 forward = new Vector3(-1f,0f,0f);
    [SerializeField]
    private float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += this.forward*Time.deltaTime*this.speed;
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            this.forward = new Vector3(-1, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
            this.forward = new Vector3(1, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow)) 
        {
            this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 270));
            this.forward = new Vector3(0, 1, 0);
        } 
        else if (Input.GetKeyDown(KeyCode.DownArrow)) 
        {
            this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
            this.forward = new Vector3(0, -1, 0);
        }
        
    }
}
