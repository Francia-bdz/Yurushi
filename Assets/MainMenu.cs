using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour

{

    public string LevelToLoad;
    public string Histoire;

    public void PlayGame()
    {
        SceneManager.LoadScene(LevelToLoad);
    }

    public void PlayHistory()
    {
        SceneManager.LoadScene(Histoire);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
