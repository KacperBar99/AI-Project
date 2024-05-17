using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 forward = new Vector3(-1f,0f,0f);
    [SerializeField]
    private float speed = 2f;
    [SerializeField]
    private TextMeshProUGUI text;
    [SerializeField]
    private TextMeshProUGUI text2;
    private LevelController levelController;
    private field currentField;
    private int points = 0;
    private bool powerUp = false;
    private float powerUpTime = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        this.levelController=GameObject.FindGameObjectWithTag("LevelController").GetComponent<LevelController>();
        this.text.text = "0";
        this.points = 0;
        this.powerUpTime = 0.0f;
        this.text2.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        this.text2.text=this.powerUpTime.ToString("n");
        if(this.powerUpTime > 0.0f)
        {
            this.powerUpTime -= Time.deltaTime;
            if(this.powerUpTime < 0.0f)
            {
                this.powerUpTime = 0.0f;
                this.powerUp = false;
            }
        }

        this.currentField = this.levelController.getField(this.transform.position);
        if (this.currentField == null) Debug.Log("Mamy problem");
        if (this.currentField.getWeight() > 1) this.speed = 1.0f;
        else this.speed = 2.0f;
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
    public void getPoint(int value)
    {
        this.points+=value;
        this.text.text=this.points.ToString();
    }
    public void getPower()
    {
        this.getPoint(10);
        this.powerUpTime += 10;
        powerUp = true;
    }
    public bool isPowerUp() 
    {
        return powerUp;
    }
}
