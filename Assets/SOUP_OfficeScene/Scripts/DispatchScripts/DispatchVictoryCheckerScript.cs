using DG.Tweening.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DispatchVictoryCheckerScript : MonoBehaviour
{
    public static int dispatchSuccessValue = 0;
    public static int perfectDispatchCheck = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void SetDispatchDifficulty(int difficulty)
    {
        dispatchSuccessValue += difficulty;
    }
    public static void SetHeroStrength(int heroTier)
    {
        dispatchSuccessValue -= heroTier;
    }
    public static void CompareElements()
    {
        if (DispatchMatchupSetup.DispatchElement == "Earth" && DispatchMatchupSetup.HeroElement == "Fire")
        {
            dispatchSuccessValue--;
            perfectDispatchCheck++;
        }
        else if (DispatchMatchupSetup.DispatchElement == "Lightning" && DispatchMatchupSetup.HeroElement == "Earth")
        {
            dispatchSuccessValue--;
            perfectDispatchCheck++;
        }
        else if (DispatchMatchupSetup.DispatchElement == "Water" && DispatchMatchupSetup.HeroElement == "Lightning")
        {
            dispatchSuccessValue--;
            perfectDispatchCheck++;
        }
        else if (DispatchMatchupSetup.DispatchElement == "Fire" && DispatchMatchupSetup.HeroElement == "Water")
        {
            dispatchSuccessValue--;
            perfectDispatchCheck++;
        }
    }

    public static void CompareSkill()
    {
        if (DispatchMatchupSetup.DispatchSkill == "Strategy" && DispatchMatchupSetup.HeroSkill == "Strength")
        {
            dispatchSuccessValue--;
            perfectDispatchCheck++;
        }
        else if (DispatchMatchupSetup.DispatchSkill == "Speed" && DispatchMatchupSetup.HeroSkill == "Strategy")
        {
            dispatchSuccessValue--; 
            perfectDispatchCheck++;
        }
        else if (DispatchMatchupSetup.DispatchSkill == "Strength" && DispatchMatchupSetup.HeroSkill == "Speed")
        {
            dispatchSuccessValue--; 
            perfectDispatchCheck++;
        }
    }

    public static void CompareVictory()
    {
        CompareElements();
        CompareSkill();
        if (perfectDispatchCheck == 2)
        {
            DispatchManager.PerfectDispatch();
            Debug.Log("This was a perfect dispatch!");
        }
        else if (dispatchSuccessValue <= 0)
        {
            DispatchManager.GoodDispatch();
            Debug.Log("This was a good dispatch");
        }
        else
        {
            DispatchManager.BadDispatch();
            Debug.Log("This was a bad dispatch");
        }
        DispatchMatchupSetup.ResetElements();
    }


}
