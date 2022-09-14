using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUi;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)&&!GameManager.instance.player.dead)
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        if (GameManager.instance.player.dead) Resume();
    }
    
    public void Resume()
    {
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    
    public void Settings()
    {
            
    }

    public void Quit()
    {
        GameManager.instance.SaveState();
        Time.timeScale = 1f;

        SceneManager.LoadScene("Menu");
    }
    
    public void TryAgain()
    {
        GameManager.instance.SaveState();
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
