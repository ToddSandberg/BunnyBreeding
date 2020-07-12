using System.Collections;
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
    public GameObject BunnyPink;
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
        string bunniesWh = BunnyStats.getWhiteBunnyCount().ToString();
        BunnyWhite.GetComponent<Text>().text = bunniesWh;
        string bunniesBl = BunnyStats.getBlackBunnyCount().ToString();
        BunnyBlack.GetComponent<Text>().text = bunniesBl;
        string bunniesGr = BunnyStats.getGrayBunnyCount().ToString();
        BunnyGray.GetComponent<Text>().text = bunniesGr;
        string bunniesRe = BunnyStats.getRedBunnyCount().ToString();
        BunneyRed.GetComponent<Text>().text = bunniesRe;
        string bunniesBlu = BunnyStats.getBlueBunnyCount().ToString();
        BunneyBlue.GetComponent<Text>().text = bunniesBlu;
        string bunniesYe = BunnyStats.getYellowBunnyCount().ToString();
        BunneyYellow.GetComponent<Text>().text = bunniesYe;
        string bunniesBr = BunnyStats.getBrownBunnyCount().ToString();
        BunnyBrown.GetComponent<Text>().text = bunniesBr;
        string bunniesPu = BunnyStats.getPurpleBunnyCount().ToString();
        BunnyPurple.GetComponent<Text>().text = bunniesPu;
        string bunniesPi = BunnyStats.getPinkBunnyCount().ToString();
        BunnyPink.GetComponent<Text>().text = bunniesPi;
        string bunniesGre = BunnyStats.getGreenBunnyCount().ToString();
        BunnyGreen.GetComponent<Text>().text = bunniesGre;
        string bunniesOr = BunnyStats.getOrangeBunnyCount().ToString();
        BunnyOrange.GetComponent<Text>().text = bunniesOr;
        string bunniesCr = BunnyStats.getCrystalBunnyCount().ToString();
        BunnyCrystal.GetComponent<Text>().text = bunniesCr;
        string bunniesCy = BunnyStats.getCyanBunnyCount().ToString();
        BunnyCyan.GetComponent<Text>().text = bunniesCy;
        string bunniesGo = BunnyStats.getGoldenBunnyCount().ToString();
        BunnyGolden.GetComponent<Text>().text = bunniesGo;
        string bunniesQz = BunnyStats.getRoseQuartzBunnyCount().ToString();
        BunnyRoseQuartz.GetComponent<Text>().text = bunniesQz;
        string bunniesAd = BunnyStats.getAdventurineBunnyCount().ToString();
        BunnyAdventurine.GetComponent<Text>().text = bunniesAd;
        string bunniesTo = BunnyStats.getTourmalineBunnyCount().ToString();
        BunnyTourmaline.GetComponent<Text>().text = bunniesTo;
        string bunniesSi = BunnyStats.getSilverBunnyCount().ToString();
        BunnySilver.GetComponent<Text>().text = bunniesSi;
        string bunniesEm = BunnyStats.getEmeraldBunnyCount().ToString();
        BunnyEmerald.GetComponent<Text>().text = bunniesEm;
        string bunniesAm = BunnyStats.getAmethystBunnyCount().ToString();
        BunnyAmathyst.GetComponent<Text>().text = bunniesAm;

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
