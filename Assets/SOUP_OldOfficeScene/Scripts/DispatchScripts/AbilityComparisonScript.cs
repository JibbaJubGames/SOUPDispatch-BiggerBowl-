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
            DispatchDeciderScript.PointCountUp();
        }
        else if (chosenHerosElement == "lightning" || chosenHerosElement == "Neutral")
        {
            DispatchDeciderScript.PointCountDown();
        }
    }
    public void CompareLightning()
    {
        if (chosenHerosElement == "Earth") 
        {
            DispatchDeciderScript.PointCountUp();
        }
        else if (chosenHerosElement == "Water" || chosenHerosElement == "Neutral")
        {
            DispatchDeciderScript.PointCountDown();
        }
    }
    public void CompareWater()
    {
        if (chosenHerosElement == "Lightning") 
        {
            DispatchDeciderScript.PointCountUp();
        }
        else if (chosenHerosElement == "Fire" || chosenHerosElement == "Neutral")
        {
            DispatchDeciderScript.PointCountDown();
        }
    }
    public void CompareFire()
    {
        if (chosenHerosElement == "Water") 
        {
            DispatchDeciderScript.PointCountUp();
        }
        else if (chosenHerosElement == "Earth" || chosenHerosElement == "Neutral")
        {
            DispatchDeciderScript.PointCountDown();
        }
    }


    private void CompareStrength()
    {
        if (chosenHerosSkill == "Speed")
        {
            DispatchDeciderScript.PointCountUp();
        }
        else if (chosenHerosSkill == "Strategy")
        {
            DispatchDeciderScript.PointCountDown();
        }
    }
    private void CompareStrategy()
    {
        if (chosenHerosSkill == "Strength")
        {
            DispatchDeciderScript.PointCountUp();
        }
        else if (chosenHerosSkill == "Speed")
        {
            DispatchDeciderScript.PointCountDown();
        }
    }
    private void CompareSpeed()
    {
        if (chosenHerosSkill == "Strategy")
        {
            DispatchDeciderScript.PointCountUp();
        }
        else if (chosenHerosSkill == "Strength")
        {
            DispatchDeciderScript.PointCountDown();
            Debug.Log("hero lost in skill category");
        }
    }

    public void CompareTier()
    {
        DispatchDeciderScript.dispatchDifficulty = tier - chosenHerosTier;
        DispatchDeciderScript.SetDifficulty();
        //To-Do; create script to track dispatch points, set necessary point value
    }
}
