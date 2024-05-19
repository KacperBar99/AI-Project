using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private float difficulty = 1.0f;
    [SerializeField]
    private float defaultTimeScale = 1.0f;//poziom trudnoœci i tak dalej
    [SerializeField]
    private GameObject MainMenu;
    [SerializeField]
    private List<Ghost> ghosts;
    private int pointsLeft = 377;
    private bool isPaused = false;//pauza


    // Start is called before the first frame update
    void Start()
    {
        this.MainMenu.SetActive(false);
        GameStatic.difficulty = difficulty;
        this.isPaused = false;
        Time.timeScale = defaultTimeScale;
        Application.targetFrameRate = -1;
        QualitySettings.vSyncCount = 0;

        Application.runInBackground = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (pointsLeft <= 0)
        {
            GameStatic.saveToLeaderBoards = true;
            GameStatic.points = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().getPoints();
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        }
        //Pauza gry
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            this.isPaused = !this.isPaused;
            if (this.isPaused)
            {
                Time.timeScale = 0.0f;
                this.MainMenu.SetActive(true);
            }
            else
            {
                this.MainMenu.SetActive(false);
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
    }
    public void PointsLess()
    {
        this.pointsLeft--;
    }
    public void exitGame()
    {
        Application.Quit();
    }
    public void exitToMenu()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
    public void PauseEnd()
    {
        this.MainMenu.SetActive(false);
        Time.timeScale = this.defaultTimeScale;
    }
}
