using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void Instructions()
    {
        SceneManager.LoadScene("Instructions");
    }
    public void BackToTitle()
    {
        SceneManager.LoadScene("Title");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}