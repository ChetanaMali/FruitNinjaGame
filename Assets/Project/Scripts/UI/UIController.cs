using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    
    [SerializeField] GameObject pauseMenuGO;

    public void RestartLevel()
    {
        SoundController.Instance.GameStartPlay();
        SceneManager.LoadScene(1);
        Time.timeScale = 1.0f;
    }
    public void QuitApplication()
    {
        Application.Quit();
    }
    public void PauseMenu()
    {
        if (Application.isPlaying)
        {
            Time.timeScale = 0.0f;
            pauseMenuGO.SetActive(true);
        }
    }
    public void PlayMenu()
    {
        Time.timeScale = 1;
        pauseMenuGO.SetActive(false);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
}
