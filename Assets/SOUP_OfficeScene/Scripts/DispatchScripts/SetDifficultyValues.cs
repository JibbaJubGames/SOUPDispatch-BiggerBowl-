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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDifficultyPiece()
    {
        dispatchDifficulty = GameObject.FindGameObjectWithTag("HeroCanvas").GetComponent<AbilityComparisonScript>();
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
                dispatchDifficulty.strategy = true;
            }
            else if (strength)
            {
                dispatchDifficulty.strength = true;
            }
            else if (speed)
            {
                dispatchDifficulty.speed = true;
            }
        }
        else
        {
            ResetSkill();
        }
    }

    private void ResetSkill()
    {
        dispatchDifficulty.strategy = false;
        dispatchDifficulty.strength = false;
        dispatchDifficulty.speed = false;
    }

    private void SetElement()
    {
        if (affectsElement)
        {
            if (earth)
            {
                dispatchDifficulty.earth = true;
            }
            else if (lightning)
            {
                dispatchDifficulty.lightning = true;
            }
            else if (water)
            {
                dispatchDifficulty.water = true;
            }
            else if (fire)
            {
                dispatchDifficulty.fire = true;
            }
        }
        else
        {
            ResetElement();
        }
    }

    private void ResetElement()
    {
        dispatchDifficulty.earth = false;
        dispatchDifficulty.lightning = false;
        dispatchDifficulty.water = false;
        dispatchDifficulty.fire = false;
    }
}
