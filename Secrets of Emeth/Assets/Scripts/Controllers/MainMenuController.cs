using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Overworld");
    }

    public void QuitGame()
    {
        Debug.Log("Game closed.");
        Application.Quit();
    }
}
