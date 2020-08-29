using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject player;
    public RoomController room;

    public void StartGame()
    {
        SceneManager.LoadScene("Overworld");
        GameManager.Instance.Player = player;
        GameManager.Instance.currentRoom = room;
    }

    public void QuitGame()
    {
        Debug.Log("Game closed.");
        Application.Quit();
    }
}
