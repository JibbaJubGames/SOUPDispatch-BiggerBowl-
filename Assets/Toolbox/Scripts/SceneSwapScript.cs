using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwapScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene(string sceneName)
    {
        if (GameManager.DayCounter == 10 && SceneManager.GetActiveScene().name == "OfficeScene")
        {
            SceneManager.LoadScene(10);
        }
        else
        {
        SceneManager.LoadScene(sceneName);
        }
    }

    public void CheckForCutscene(string sceneName)
    {
        CutsceneManager.CheckCutscene(sceneName);
    }
}
