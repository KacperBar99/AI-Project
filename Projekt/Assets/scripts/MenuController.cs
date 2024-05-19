using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using System.Linq;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject mainMenu;
    [SerializeField]
    private GameObject difficulty;
    [SerializeField]
    private GameObject leaderBoards;
    [SerializeField]
    private GameObject input;
    [SerializeField]
    private DisplayButtons[] displayButtons;
    private int points;
    private Result[] results;


    private class Result
    {
        public string name;
        public int res;
    }
    private void Start()
    {
        this.input.SetActive(false);
        this.results = new Result[8];
        for (int i = 0; i < 8; i++) 
        {
            this.results[i] = new Result();
            this.results[i].name = "";
            this.results[i].res = 0;
        }
        if (!GameStatic.saveToLeaderBoards)
        {
            this.mainMenu.SetActive(true);
            this.leaderBoards.SetActive(false);
            this.difficulty.SetActive(false);
        }
        else
        {
            this.points = (int)(GameStatic.points * GameStatic.difficulty);
            this.input.SetActive(true);
            this.mainMenu.SetActive(false);
            this.leaderBoards.SetActive(true);
            this.difficulty.SetActive(false);
            GameStatic.saveToLeaderBoards = false;
        }
        
        Application.targetFrameRate = -1;
        QualitySettings.vSyncCount = 0;

        Application.runInBackground = false;
        this.LoadScores();
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void StartGame()
    {
        this.mainMenu.SetActive(false);
        this.difficulty.SetActive(true);
    }
    public void GoToLeaderBoard()
    {
        this.mainMenu.SetActive(false);
        this.leaderBoards.SetActive(true);
    }
    public void BackToMenu()
    {
        this.mainMenu.SetActive(true);
        this.leaderBoards.SetActive(false);
        this.difficulty.SetActive(false);
    }

    public void playEasy()
    {
        SceneManager.LoadScene("Easy", LoadSceneMode.Single);
    }
    public void playNormal()
    {
        SceneManager.LoadScene("Normal", LoadSceneMode.Single);
    }
    public void playHard()
    {
        SceneManager.LoadScene("Hard", LoadSceneMode.Single);
    }
    private void LoadScores()
    {
        int i = 0;

        using(StreamReader reader = new StreamReader(@"score.score"))
        {
            string line1;
            string line2;
            while((line1=reader.ReadLine()) != null && i<8 && line1!="0")
            {
                line2 = reader.ReadLine();
                this.results[i].name = line1;
                this.results[i].res = int.Parse(line2);
                i++;
            }
        }
        for ( i = 0; i < this.results.Length; i++) 
        {
            this.displayButtons[i].nickname.text = this.results[i].name;
            this.displayButtons[i].res.text = this.results[i].res.ToString();
        }
    }
    public void SaveScore()
    {
        string value = this.input.GetComponent<TMP_InputField>().text;
        var queu = new PriorityQueu<Result>();
        foreach(Result res in this.results)
        {
            queu.insert(res, -res.res);
        }
        Result result = new Result();
        result.name = value;
        result.res = this.points;
        queu.insert(result, -result.res);
        for(int i=0;i<this.results.Length;i++) 
        {
            var tmp = queu.pull();
            this.results[i] = tmp;
        }
        using (StreamWriter writer = new StreamWriter(@"score.score"))
        {
            for (int i = 0; i < 8; i++) 
            {
                writer.WriteLine(this.results[i].name);
                writer.WriteLine(this.results[i].res);
            }
        }
        this.input.SetActive(false);
        for (int i = 0; i < this.results.Length; i++)
        {
            this.displayButtons[i].nickname.text = this.results[i].name;
            this.displayButtons[i].res.text = this.results[i].res.ToString();
        }
    }
}
