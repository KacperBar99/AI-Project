using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private float difficulty = 1.0f;
    [SerializeField]
    private float defaultTimeScale = 1.0f;//poziom trudnoœci i tak dalej
    private bool isPaused = false;//pauza
    [SerializeField]
    private List<Ghost> ghosts;
    // Start is called before the first frame update
    void Start()
    {
        this.isPaused = false;
        Time.timeScale = defaultTimeScale;
        Application.targetFrameRate = -1;
        QualitySettings.vSyncCount = 0;

        Application.runInBackground = false;
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
        foreach(Ghost ghost in this.ghosts)
        {
            if(ghost == null)
            {
                this.ghosts.Remove(ghost);
                break;
            }
        }
        if(this.ghosts.Count == 0)
        {
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        }
    }
}
