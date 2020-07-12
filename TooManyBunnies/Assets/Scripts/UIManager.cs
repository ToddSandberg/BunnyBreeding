﻿using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;
using Debug = UnityEngine.Debug;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;

public class UIManager : MonoBehaviour
{

    public static bool IsPaused;
    public static bool WinCondition;
    public static bool LossCondition;

    public GameObject pauseUI;
    public GameObject winUI; 
    public GameObject loseUI;
    public GameObject BunnyNumA;
    public GameObject BunnyNumH;
    public GameObject GoldNumA;
    public GameObject GoldNumH;
    public GameObject BunnyWhite;
    public GameObject BunnyBlack;
    public GameObject BunnyGray;
    public GameObject BunneyRed;
    public GameObject BunneyBlue;
    public GameObject BunneyYellow;
    public GameObject BunnyBrown;
    public GameObject BunnyPurple;
    public GameObject BunnyGreen;
    public GameObject BunnyOrange;
    public GameObject BunnyCrystal;
    public GameObject BunnyCyan;
    public GameObject BunnyGolden;
    public GameObject BunnyRoseQuartz;
    public GameObject BunnyAdventurine;
    public GameObject BunnyTourmaline;
    public GameObject BunnySilver;
    public GameObject BunnyEmerald;
    public GameObject BunnyAmathyst;
    public GameObject CompletedTasks;


    void Start()
    {
        IsPaused = false;
        WinCondition = false;
        LossCondition = false;
        pauseUI.SetActive(false);
        loseUI.SetActive(false);
        winUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        BunnyUpdate();
        GoldUpdate();
        TaskUpdate();

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

    public void BunnyUpdate()
    {
        string bunnies = BunnyStats.getBunnyCount().ToString();
        BunnyNumA.GetComponent<Text>().text = bunnies;
        BunnyNumH.GetComponent<Text>().text = bunnies;

    }

    public void GoldUpdate()
    {
        string gold = BunnyStats.getGold().ToString();
        GoldNumA.GetComponent<Text>().text = gold;
        GoldNumH.GetComponent<Text>().text = gold;
    }

    public void TaskUpdate()
    {
        string task = BunnyStats.getCompletedTask().ToString();
        CompletedTasks.GetComponent<Text>().text = task;
    }


    void Loser()
    {
        loseUI.SetActive(true);
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
