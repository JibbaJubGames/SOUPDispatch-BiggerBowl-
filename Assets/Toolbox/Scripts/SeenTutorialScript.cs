using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SeenTutorialScript : MonoBehaviour
{
    public GameObject tutorialToDisplay;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnergyTutorialDisplay()
    {
        if (!GameManager.seenEnergyTutorial)
        {
            tutorialToDisplay.SetActive(true);
            GameManager.seenEnergyTutorial = true;
        }
        else return;
    }
    public void ScreenTutorialDisplay()
    {
        if (!GameManager.seenDesktopTutorial)
        {
            tutorialToDisplay.SetActive(true);
            GameManager.seenDesktopTutorial = true;
        }
        else return;
    }
}
