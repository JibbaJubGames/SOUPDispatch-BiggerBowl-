using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class PlayerData
{
    [Header("Basics")]
    public int DayCounter;

    [Header("Relationships")]
    public int FawnRelationCounter;
    public int FawnRelationLevel;

    public int RichardRelationCounter;
    public int RichardRelationLevel;

    public int SergeiRelationCounter;
    public int SergeiRelationLevel;

    public float effectsVolume;
    public float voicesVolume;
    public float musicVolume;

    [Header("Tutorials")]
    public bool seenEnergyTutorial;
    public bool seenDesktopTutorial;

    [Header("Emails")]
    public int emailCount;
}

public class SaveAndLoad : MonoBehaviour
{
    private AudioManager audioMixer;

    public static PlayerData playerSave = new PlayerData();

    void Start()
    {
        audioMixer = GameObject.FindGameObjectWithTag("AudioManger").GetComponent<AudioManager>();
    }

    public static void SaveToJson()
    {
        playerSave = new PlayerData
        {
            DayCounter = GameManager.DayCounter,


            FawnRelationCounter = GameManager.FawnRelationCounter,
            FawnRelationLevel = GameManager.FawnRelationLevel,

            RichardRelationCounter = GameManager.RichardRelationCounter,
            RichardRelationLevel = GameManager.RichardRelationLevel,

            SergeiRelationCounter = GameManager.SergeiRelationCounter,
            SergeiRelationLevel = GameManager.SergeiRelationLevel,

            effectsVolume = AudioManager.effectsVolume,
            voicesVolume = AudioManager.voiceVolume,
            musicVolume = AudioManager.musicVolume,

            seenEnergyTutorial = GameManager.seenEnergyTutorial,
            seenDesktopTutorial = GameManager.seenDesktopTutorial,

            emailCount = GameManager.emailCount,
        };
        string jsonSave = JsonUtility.ToJson(playerSave);
        Debug.Log($"Successfully saved the following information: {jsonSave}");

        string jsonFilePath = Application.persistentDataPath + "/SaveData.json";

        System.IO.File.WriteAllText(jsonFilePath, jsonSave);
    }

    public static void LoadFromJson()
    {
        string jsonFilePath = Application.persistentDataPath + "/SaveData.json";
        string jsonSave = System.IO.File.ReadAllText(jsonFilePath);

        playerSave = JsonUtility.FromJson<PlayerData>(jsonSave);
        Debug.Log($"Successfully loaded the following information: {jsonSave}");

        GameManager.SetPlayerSave();

        AudioManager.LoadAudioPrefs();

        CutsceneManager.CheckCutscene("OfficeScene");

        EmailManager.SetEmailInbox();
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