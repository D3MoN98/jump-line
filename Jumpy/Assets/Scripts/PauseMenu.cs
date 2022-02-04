using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isGamePause = false;

    public GameObject pauseMenuUI;

    public GameObject pauseButton;

    public void PauseGame()
    {
        if (!isGamePause)
        {
            Time.timeScale = 0f;
            isGamePause = true;
            pauseMenuUI.SetActive(true);
            pauseButton.SetActive(false);
        }

    }

    public void ResumeGame()
    {
        Debug.Log("resume");
        if (isGamePause)
        {
            Time.timeScale = 1f;
            isGamePause = false;
            pauseMenuUI.SetActive(false);
            pauseButton.SetActive(true);
        }
    }

    public void ReplayButton()
    {
        Time.timeScale = 1f;
        isGamePause = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
