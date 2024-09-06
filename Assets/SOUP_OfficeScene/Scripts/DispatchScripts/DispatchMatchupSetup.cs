using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispatchMatchupSetup : MonoBehaviour
{

    public static string DispatchElement;
    public static string DispatchSkill;
    public static int DispatchTier;

    public static string HeroElement;
    public static string HeroSkill;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public static void ResetElements()
    {
        DispatchElement = null;
        DispatchSkill = null;
        HeroElement = null;
        HeroSkill = null;
        DispatchTier = 0;
        Debug.Log($"{DispatchElement}, {DispatchSkill}, {DispatchTier}");
    }

    public static void SetDispatchElement(string elementNeeded)
    {
        DispatchElement = elementNeeded;
        Debug.Log($"We need a {DispatchElement} affinity hero!");
    }
    public static void SetDispatchSkill(string skillNeeded)
    {
        DispatchSkill = skillNeeded;
        Debug.Log($"We need a {DispatchSkill} style hero!");
    }

    public static void SetHeroElement(string heroElement)
    {
        HeroElement = heroElement;
        Debug.Log($"This hero is a {heroElement} type hero!");
    }

    public static void SetHeroSkill(string heroSkill)
    {
        HeroSkill = heroSkill;
        Debug.Log($"This hero is especially skilledi n {heroSkill}");
    }
}
