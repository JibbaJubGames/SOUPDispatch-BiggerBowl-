using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityComparisonScript : MonoBehaviour
{
    [Header("Elements")]
    public bool earth;
    public bool lightning;
    public bool water;
    public bool fire;
    public string chosenHerosElement;

    [Header("Skills")]
    public bool strength;
    public bool strategy;
    public bool speed;
    public string chosenHerosSkill;

    [Header("Tier")]
    public int tier;
    public int chosenHerosTier;

    // Start is called before the first frame update
    void Start()
    {
        CheckElement();
        CheckSkill();
        CompareTier();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckElement()
    {
        if (earth) { CompareEarth(); }
        else if (lightning) { CompareLightning(); }
        else if (water) { CompareWater(); }
        else if (fire) { CompareFire(); }
    }
    public void CheckSkill()
    {
        if (strength) { CompareStrength(); }
        if (strategy) { CompareStrategy(); }
        if (speed) { CompareSpeed(); } 
    }

    public void CompareEarth()
    {
        if (chosenHerosElement == "Fire") 
        {
            DispatchDeciderScript.PointCount("Win");
        }
        else if (chosenHerosElement == "lightning")
        {
            DispatchDeciderScript.PointCount("Lose");
        }
    }
    public void CompareLightning()
    {
        if (chosenHerosElement == "Earth") 
        {
            DispatchDeciderScript.PointCount("Win");
        }
        else if (chosenHerosElement == "Water")
        {
            DispatchDeciderScript.PointCount("Lose");
        }
    }
    public void CompareWater()
    {
        if (chosenHerosElement == "Lightning") 
        {
            DispatchDeciderScript.PointCount("Win");
        }
        else if (chosenHerosElement == "Fire")
        {
            DispatchDeciderScript.PointCount("Lose");
        }
    }
    public void CompareFire()
    {
        if (chosenHerosElement == "Water") 
        {
            DispatchDeciderScript.PointCount("Win");
        }
        else if (chosenHerosElement == "Earth")
        {
            DispatchDeciderScript.PointCount("Lose");
        }
    }


    private void CompareStrength()
    {
        if (chosenHerosSkill == "Speed")
        {
            DispatchDeciderScript.PointCount("Win");
        }
        else if (chosenHerosSkill == "Strategy")
        {
            DispatchDeciderScript.PointCount("Lose");
        }
    }
    private void CompareStrategy()
    {
        if (chosenHerosSkill == "Strength")
        {
            DispatchDeciderScript.PointCount("Win");
        }
        else if (chosenHerosSkill == "Speed")
        {
            DispatchDeciderScript.PointCount("Lose");
        }
    }
    private void CompareSpeed()
    {
        if (chosenHerosSkill == "Strategy")
        {
            DispatchDeciderScript.PointCount("Win");
        }
        else if (chosenHerosSkill == "Strength")
        {
            DispatchDeciderScript.PointCount("Lose");
        }
    }

    public void CompareTier()
    {
        DispatchDeciderScript.dispatchDifficulty = tier - chosenHerosTier;
        DispatchDeciderScript.SetDifficulty();
        //To-Do; create script to track dispatch points, set necessary point value
    }
}
