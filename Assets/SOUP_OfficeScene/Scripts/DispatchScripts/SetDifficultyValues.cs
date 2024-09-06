using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDifficultyValues : MonoBehaviour
{
    private AbilityComparisonScript dispatchDifficulty;

    public bool affectsElement;
    public bool earth;
    public bool lightning;
    public bool water;
    public bool fire;

    public bool affectsSkill;
    public bool strategy;
    public bool strength;
    public bool speed;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void SetDifficultyPiece()
    {
        ResetElement();
        SetElement();
        ResetSkill();
        SetSkill();
    }

    private void SetSkill()
    {
        if (affectsSkill)
        {
            if (strategy)
            {
                DispatchMatchupSetup.SetDispatchSkill("Strength");
            }
            else if (strength)
            {
                DispatchMatchupSetup.SetDispatchSkill("Speed");
            }
            else if (speed)
            {
                DispatchMatchupSetup.SetDispatchSkill("Strategy");
            }
        }
        else
        {
            ResetSkill();
        }
    }

    private void ResetSkill()
    {
        DispatchMatchupSetup.DispatchElement = null;
    }

    private void SetElement()
    {
        if (affectsElement)
        {
            if (earth)
            {
                DispatchMatchupSetup.SetDispatchElement("Fire");
            }
            else if (lightning)
            {
                DispatchMatchupSetup.SetDispatchElement("Earth");
            }
            else if (water)
            {
                DispatchMatchupSetup.SetDispatchElement("Lightning");
            }
            else if (fire)
            {
                DispatchMatchupSetup.SetDispatchElement("Water");
            }
        }
        else
        {
            ResetElement();
        }
    }

    private void ResetElement()
    {
        DispatchMatchupSetup.DispatchSkill = null;
    }
}
