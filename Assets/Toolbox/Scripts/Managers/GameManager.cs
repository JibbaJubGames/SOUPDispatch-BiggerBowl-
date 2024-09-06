using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Basics")] 
    public static int DayCounter;

    public static int playerEnergy = 5;

    [Header("Relationships")]
    public static int FawnRelationCounter;
    public static int FawnRelationLevel;

    public static int RichardRelationCounter;
    public static int RichardRelationLevel;

    public static int SergeiRelationCounter;
    public static int SergeiRelationLevel;

    [Header("Tutorials")]
    public static bool seenEnergyTutorial;

    //TEMPORARY UNTIL TUTORIAL IS IMPLEMENTED FULLY
    public static bool seenDesktopTutorial;

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
        if (Input.GetKey(KeyCode.Escape) && Input.GetKey(KeyCode.LeftShift))
        {
            SceneManager.LoadScene(0);
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

        FawnRelationCounter = SaveAndLoad.playerSave.FawnRelationCounter;
        FawnRelationLevel = SaveAndLoad.playerSave.FawnRelationLevel;

        RichardRelationCounter = SaveAndLoad.playerSave.RichardRelationCounter;
        RichardRelationLevel = SaveAndLoad.playerSave.RichardRelationLevel;

        SergeiRelationCounter = SaveAndLoad.playerSave.SergeiRelationCounter;
        SergeiRelationLevel = SaveAndLoad.playerSave.SergeiRelationLevel;

        seenEnergyTutorial = SaveAndLoad.playerSave.seenEnergyTutorial;
    }

    public static void NewGameSave()
    {
        DayCounter = 0;

        FawnRelationCounter = 0;
        FawnRelationLevel= 0;

        RichardRelationCounter = 0;
        RichardRelationLevel= 0;

        SergeiRelationCounter = 0;
        SergeiRelationLevel = 0;

        seenEnergyTutorial = false;

        SaveAndLoad.SaveToJson();

        SaveAndLoad.LoadFromJson();
    }
}
