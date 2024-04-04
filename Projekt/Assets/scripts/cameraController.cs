using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public generationController controller;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(5, 5, -1);
        this.GetComponent<Camera>().orthographicSize = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") > 0) transform.position = new Vector2(transform.position.x+speed*Time.deltaTime, transform.position.y);
        if (Input.GetAxisRaw("Horizontal") < 0) transform.position = new Vector2(transform.position.x-speed*Time.deltaTime, transform.position.y);
        if (Input.GetAxisRaw("Vertical") > 0) transform.position = new Vector2(transform.position.x, transform.position.y+speed*Time.deltaTime);
        if (Input.GetAxisRaw("Vertical") < 0) transform.position = new Vector2(transform.position.x, transform.position.y-speed*Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Q) && GetComponent<Camera>().orthographicSize>1) GetComponent<Camera>().orthographicSize--;
        if (Input.GetKeyDown(KeyCode.E)) GetComponent<Camera>().orthographicSize++;
        transform.position=new Vector3(transform.position.x, transform.position.y, -10);
    }
}
