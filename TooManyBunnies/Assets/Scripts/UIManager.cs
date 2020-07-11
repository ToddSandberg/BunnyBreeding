using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;
using Debug = UnityEngine.Debug;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public static bool IsPaused = false;
    public static bool WinCondition = false;
    public static bool LossCondition = false;

    public GameObject pauseUI;
    public GameObject winUI; 
    public GameObject loseUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        if (WinCondition) {
            Winner();
        }

        if (LossCondition)
        {
            Loser();
        }

    }

    void Loser()
    {
        winUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    void Pause()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
    }

    public void RestartGame()
    {

        Time.timeScale = 1f;
        Debug.Log("Resetting Game...");
        IsPaused = false;
        WinCondition = false;
        LossCondition = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void Resume()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }

    void Winner()
    {
        winUI.SetActive(true);
        Time.timeScale = 0f;
    }
}
