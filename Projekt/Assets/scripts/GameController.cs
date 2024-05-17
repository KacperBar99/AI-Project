using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private float defaultTimeScale = 1.0f;//poziom trudnoœci i tak dalej
    private bool isPaused = false;//pauza 
    // Start is called before the first frame update
    void Start()
    {
        this.isPaused = false;
        Time.timeScale = defaultTimeScale;
    }

    // Update is called once per frame
    void Update()
    {
        //Pauza gry
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            this.isPaused = !this.isPaused;
            if (this.isPaused)
            {
                Time.timeScale = 0.0f;
            }
            else
            {
                Time.timeScale = this.defaultTimeScale;
            }
        }
    }
}
