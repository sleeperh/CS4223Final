using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public void ToStart()
    {
        SceneManager.LoadScene("1Intro");
    }
    public void ToGame()
    {
        SceneManager.LoadScene("2Game");
    }

    public void ToExit()
    {
        SceneManager.LoadScene("3Exit");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
