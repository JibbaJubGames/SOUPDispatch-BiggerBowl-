using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class PlayerData
{
    [Header("Basics")]
    public int DayCounter;

    public int PlayerEnergy;

    public string PlayerName;

    [Header("Relationships")]
    public int FawnRelationCounter;
    public int FawnRelationLevel;

    public int RichardRelationCounter;
    public int RichardRelationLevel;

    public int SergeiRelationCounter;
    public int SergeiRelationLevel;

    public int BettyRelationCounter;
    public int BettyRelationLevel;

    public float effectsVolume;
    public float voicesVolume;
    public float musicVolume;

    [Header("Tutorials")]
    public bool seenEnergyTutorial;
    public bool seenDesktopTutorial;

    [Header("Emails")]
    public int emailCount;

    [Header("Finances")]
    public int moneyInWallet;
    //[Header("Fallen Heroes")]
}

[System.Serializable]
public class PrankAddresses
{
    public int[] prankingAddresses = new int[130];
}

public class SaveAndLoad : MonoBehaviour
{
    private AudioManager audioMixer;

    public static PlayerData playerSave = new PlayerData();

    public static PrankAddresses playerSavePranks = new PrankAddresses();

    void Start()
    {
        audioMixer = GameObject.FindGameObjectWithTag("AudioManger").GetComponent<AudioManager>();
    }

    public static void SaveToJson()
    {
        playerSave = new PlayerData
        {
            DayCounter = GameManager.DayCounter,
            PlayerEnergy = GameManager.playerEnergy,
            PlayerName = GameManager.PlayerName,

            FawnRelationCounter = GameManager.FawnRelationCounter,
            FawnRelationLevel = GameManager.FawnRelationLevel,

            RichardRelationCounter = GameManager.RichardRelationCounter,
            RichardRelationLevel = GameManager.RichardRelationLevel,

            SergeiRelationCounter = GameManager.SergeiRelationCounter,
            SergeiRelationLevel = GameManager.SergeiRelationLevel,

            BettyRelationCounter = GameManager.BettyRelationCounter,
            BettyRelationLevel = GameManager.BettyRelationLevel,

            effectsVolume = AudioManager.effectsVolume,
            voicesVolume = AudioManager.voiceVolume,
            musicVolume = AudioManager.musicVolume,

            seenEnergyTutorial = GameManager.seenEnergyTutorial,
            seenDesktopTutorial = GameManager.seenDesktopTutorial,

            emailCount = GameManager.emailCount,

            moneyInWallet = GameManager.moneyInWallet,


        };
        string jsonSave = JsonUtility.ToJson(playerSave);
        Debug.Log($"Successfully saved the following information: {jsonSave}");

        string jsonFilePath = Application.persistentDataPath + "/SaveData.json";

        System.IO.File.WriteAllText(jsonFilePath, jsonSave);
    }

    public static void NewSavePrankInfo()
    {
        playerSavePranks = new PrankAddresses
        {
            prankingAddresses = new int[130],
        };
        for (int i = 0; i < 20; i++)
        {
            if (playerSavePranks.prankingAddresses[i] == 0)
            {
                playerSavePranks.prankingAddresses[i] = Random.Range(1, 21);
            }
        }
        string prankSaveJson = JsonUtility.ToJson(playerSavePranks);
        string prankFilePath = Application.persistentDataPath + "/PrankAddresses.json";
        System.IO.File.WriteAllText(prankFilePath, prankSaveJson);
        Debug.Log($"{prankSaveJson}");
    }

    public static void LoadFromJson()
    {
        string jsonFilePath = Application.persistentDataPath + "/SaveData.json";
        string jsonSave = System.IO.File.ReadAllText(jsonFilePath);
        playerSave = JsonUtility.FromJson<PlayerData>(jsonSave);
        string prankFilePath = Application.persistentDataPath + "/PrankAddresses.json";
        string prankSaveJson = System.IO.File.ReadAllText(prankFilePath);
        playerSavePranks = JsonUtility.FromJson<PrankAddresses>(prankSaveJson);
        Debug.Log($"Successfully loaded the following information: {jsonSave}");
        Debug.Log($"Successfully found prank address integers to be: {prankSaveJson}");

        GameManager.SetPlayerSave();
        Debug.Log("Set player save line");
        AudioManager.LoadAudioPrefs();
        Debug.Log("Set audio info");
        CutsceneManager.CheckCutscene("OfficeScene");
        Debug.Log("Checked cutscene");
    }

    public static void SetAudioPrefs()
    {
        string jsonFilePath = Application.persistentDataPath + "/SaveData.json";
        string jsonSave = System.IO.File.ReadAllText(jsonFilePath);

        playerSave = JsonUtility.FromJson<PlayerData>(jsonSave);
        Debug.Log($"Successfully loaded the following information: {jsonSave}");

        GameManager.SetPlayerSave();

        AudioManager.LoadAudioPrefs();
    }
}