using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
            return;
        }

        instance = this;
    }
    void Start()
    {
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            ReloadActiveScene();
        if (Input.GetKeyDown(KeyCode.P))
            Time.timeScale = 5;
        if (Input.GetKeyUp(KeyCode.P))
            Time.timeScale = 1;
    }

    public void ReloadActiveScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}