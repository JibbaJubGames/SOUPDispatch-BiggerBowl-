using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSettingsScript : MonoBehaviour
{
    bool settingsMenuOpen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SettingsSwitch(Animator pauseMenu)
    {
        if (!settingsMenuOpen)
        {
            pauseMenu.SetTrigger("SettingsOpen");
            settingsMenuOpen = true;
        }
        else
        {
            pauseMenu.SetTrigger("SettingsClose");
            settingsMenuOpen = false;
        }
    }
}
