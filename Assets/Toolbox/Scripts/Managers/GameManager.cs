using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("DevConsole")]
    public GameObject DevConsole;
    public bool DevConsoleOpen = false;

    public static bool allComicsUnlocked = false;
    public static bool allEndingsUnlocked = false;
    public static bool allCompSkinsUnlocked = false;

    [Header("Basics")]
    public static bool isAlpha = true;
    public GameObject pauseMenu;
    public bool paused;

    public static int DayCounter = 1;

    public static int playerEnergy = 5;

    public static string PlayerName;

    [Header("Relationships")]
    public static int FawnRelationCounter;
    public static int FawnRelationLevel;

    public static int RichardRelationCounter;
    public static int RichardRelationLevel;

    public static int SergeiRelationCounter;
    public static int SergeiRelationLevel;

    public static int BettyRelationCounter;
    public static int BettyRelationLevel;

    [Header("Tutorials")]
    public static bool seenEnergyTutorial;
    public static bool seenDesktopTutorial;

    [Header("Emails")]
    public static int emailCount;

    [Header("Finances")]
    public static int moneyInWallet;

    [Header("Prank Addresses")]
    public static Dictionary<int, bool> prankCallAddresses = new Dictionary<int, bool>();

    //[Header("Fallen Heroes")]

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Alpha0))
        {
            SceneManager.LoadScene("MainMenuScene");
        }
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name != "MainMenuScene")
        {
            if (pauseMenu == null || pauseMenu != GameObject.FindGameObjectWithTag("PauseMenu"))
            {
                pauseMenu = null;
                pauseMenu = GameObject.FindGameObjectWithTag("PauseMenu");
            }
            if (!paused)
            {
                pauseMenu.GetComponent<Animator>().SetTrigger("Paused");
                Time.timeScale = 0f;
                paused = true;
            }
            else
            {
                paused = false;
                pauseMenu.GetComponent<Animator>().SetTrigger("Unpaused");
                Time.timeScale = 1f;
            }
        }

        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.C))
        {
            DevConsole.SetActive(true);
            DevConsoleOpen = true;
        }

        if (Input.GetButton("SeeThroughMode") && FocusHolders.homeObject != null)
        {
            GameObject seeThroughOne = FocusHolders.homeObject.transform.GetChild(1).gameObject;
            if (seeThroughOne.transform.childCount > 0)
            {
                for (int i = 0; i < seeThroughOne.transform.childCount; i++)
                {
                    if (seeThroughOne.transform.GetChild(i).name == "HeroFolderSlot")
                    {
                        for (int j = 0; j < seeThroughOne.transform.GetChild(i).childCount; j++)
                        {
                            seeThroughOne.transform.GetChild(i).GetChild(j).GetComponent<Image>().color = new Color(1, 1, 1, .5f);
                            seeThroughOne.transform.GetChild(i).GetChild(j).GetComponent<Image>().raycastTarget = false;
                        }
                    }
                    else
                    {
                        seeThroughOne.transform.GetChild(i).GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
                        seeThroughOne.transform.GetChild(i).GetComponent<Image>().raycastTarget = false;
                    }
                }
            }
            GameObject seeThroughTwo = FocusHolders.homeObject.transform.GetChild(0).gameObject;
            if (seeThroughTwo.transform.childCount > 0)
            {
                for (int i = 0; i < seeThroughTwo.transform.childCount; i++)
                {
                    if (seeThroughTwo.transform.GetChild(i).name == "HeroFolderSlot")
                    {
                        for (int j = 0; j < seeThroughTwo.transform.GetChild(i).childCount; j++)
                        {
                            seeThroughTwo.transform.GetChild(i).GetChild(j).GetComponent<Image>().color = new Color(1, 1, 1, .5f);
                            seeThroughTwo.transform.GetChild(i).GetChild(j).GetComponent<Image>().raycastTarget = false;
                        }
                    }
                    else
                    {
                        seeThroughTwo.transform.GetChild(i).GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
                        seeThroughTwo.transform.GetChild(i).GetComponent<Image>().raycastTarget = false;
                    }
                }
            }
        }
        if (!Input.GetButton("SeeThroughMode") && FocusHolders.homeObject != null)
        {
            GameObject seeThroughOne = FocusHolders.homeObject.transform.GetChild(1).gameObject;
            if (seeThroughOne.transform.childCount > 0)
            {
                for (int i = 0; i < seeThroughOne.transform.childCount; i++)
                {
                    if (seeThroughOne.transform.GetChild(i).name == "HeroFolderSlot")
                    {
                        for (int j = 0; j < seeThroughOne.transform.GetChild(i).childCount; j++)
                        {
                            seeThroughOne.transform.GetChild(i).GetChild(j).GetComponent<Image>().color = new Color(1, 1, 1, 1f);
                            seeThroughOne.transform.GetChild(i).GetChild(j).GetComponent<Image>().raycastTarget = true;
                        }
                    }
                    else
                    {
                        seeThroughOne.transform.GetChild(i).GetComponent<Image>().color = new Color(1, 1, 1, 1f);
                        seeThroughOne.transform.GetChild(i).GetComponent<Image>().raycastTarget = true;
                    }
                }
            }
            GameObject seeThroughTwo = FocusHolders.homeObject.transform.GetChild(0).gameObject;
            if (seeThroughTwo.transform.childCount > 0)
            {
                for (int i = 0; i < seeThroughTwo.transform.childCount; i++)
                {
                    if (seeThroughTwo.transform.GetChild(i).name == "HeroFolderSlot")
                    {
                        for (int j = 0; j < seeThroughTwo.transform.GetChild(i).childCount; j++)
                        {
                            seeThroughTwo.transform.GetChild(i).GetChild(j).GetComponent<Image>().color = new Color(1, 1, 1, 1f);
                            seeThroughTwo.transform.GetChild(i).GetChild(j).GetComponent<Image>().raycastTarget = true;
                        }
                    }
                    else
                    {
                        seeThroughTwo.transform.GetChild(i).GetComponent<Image>().color = new Color(1, 1, 1, 1f);
                        seeThroughTwo.transform.GetChild(i).GetComponent<Image>().raycastTarget = true;
                    }
                }
            }
        }
    }

    public void NextDay()
    {
        DayCounter++;

        SaveAndLoad.SaveToJson();
    }

    public static void LoadPlayerSave()
    {
        SaveAndLoad.LoadFromJson();
    }

    public static void SetPlayerSave()
    {
        DayCounter = SaveAndLoad.playerSave.DayCounter;
        playerEnergy = SaveAndLoad.playerSave.PlayerEnergy;
        PlayerName = SaveAndLoad.playerSave.PlayerName;

        FawnRelationCounter = SaveAndLoad.playerSave.FawnRelationCounter;
        FawnRelationLevel = SaveAndLoad.playerSave.FawnRelationLevel;

        RichardRelationCounter = SaveAndLoad.playerSave.RichardRelationCounter;
        RichardRelationLevel = SaveAndLoad.playerSave.RichardRelationLevel;

        SergeiRelationCounter = SaveAndLoad.playerSave.SergeiRelationCounter;
        SergeiRelationLevel = SaveAndLoad.playerSave.SergeiRelationLevel;

        BettyRelationCounter = SaveAndLoad.playerSave.BettyRelationCounter;
        BettyRelationLevel = SaveAndLoad.playerSave.BettyRelationLevel;

        seenEnergyTutorial = SaveAndLoad.playerSave.seenEnergyTutorial;
        seenDesktopTutorial = SaveAndLoad.playerSave.seenDesktopTutorial;

        emailCount = SaveAndLoad.playerSave.emailCount;

        moneyInWallet = SaveAndLoad.playerSave.moneyInWallet;

        for ( int i = 0; i < 130; i++)
        {
            if (SaveAndLoad.playerSavePranks.prankingAddresses[i] != 0 && !prankCallAddresses.ContainsKey(SaveAndLoad.playerSavePranks.prankingAddresses[i]))
            {
                prankCallAddresses.Add(SaveAndLoad.playerSavePranks.prankingAddresses[i], true);
            }
        }
    }

    public static void NewGameSave()
    {
        DayCounter = 1;
        playerEnergy = 5;
        PlayerName = null;

        FawnRelationCounter = 0;
        FawnRelationLevel= 0;

        RichardRelationCounter = 0;
        RichardRelationLevel= 0;

        SergeiRelationCounter = 0;
        SergeiRelationLevel = 0;

        BettyRelationCounter = 0;
        BettyRelationLevel = 0;

        seenEnergyTutorial = false;
        seenDesktopTutorial = false;

        emailCount = 0;

        moneyInWallet = 0;

        SaveAndLoad.SaveToJson();

        SaveAndLoad.NewSavePrankInfo();

        SaveAndLoad.LoadFromJson();
    }
}
