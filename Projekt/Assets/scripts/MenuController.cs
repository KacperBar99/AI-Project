using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject mainMenu;
    private void Start()
    {
        Application.targetFrameRate = -1;
        QualitySettings.vSyncCount = 0;

        Application.runInBackground = false;
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Normal", LoadSceneMode.Single);
    }
    public void GoToLeaderBoard()
    {
        this.mainMenu.SetActive(false);
    }

}
