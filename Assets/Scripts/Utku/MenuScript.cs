using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField] private string newGameLevel = "Utku asdfgh";

    public void NewGameButton()
    {
        SceneManager.LoadScene(newGameLevel);
    }

    public void QuitGame()
    {
        print("QUIT");
        Application.Quit();
    }
}
