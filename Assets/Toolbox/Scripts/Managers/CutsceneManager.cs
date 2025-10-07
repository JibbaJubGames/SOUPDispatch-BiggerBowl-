using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneManager : MonoBehaviour
{
    private bool initialized = false;
    public static Dictionary<int, string> CutsceneDays = new Dictionary<int, string>();
    public int[] daysWithCutscene;
    public string[] cutsceneSceneID;

    // Start is called before the first frame update
    void Start()
    {
        if (!initialized)
        {
            for (int i = 0; i < daysWithCutscene.Length; i++)
            {
                CutsceneDays.Add(daysWithCutscene[i], cutsceneSceneID[i]);
                Debug.Log("Day " + daysWithCutscene[i] + " will lead to cutscene ID " + cutsceneSceneID[i]);
            }
            initialized = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void CheckCutscene(string fallbackScene)
    {
        if (CutsceneDays.ContainsKey(GameManager.DayCounter))
        {
            SceneManager.LoadScene(CutsceneDays[GameManager.DayCounter]);
            Debug.Log("Loading scene from cutscene manager");
        }
        else SceneManager.LoadScene(fallbackScene);
    }
}
