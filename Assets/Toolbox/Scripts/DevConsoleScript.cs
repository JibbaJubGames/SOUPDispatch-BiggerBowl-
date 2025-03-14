using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DevConsoleScript : MonoBehaviour
{
    public TMP_Text fawnRelationLvlTxt;
    public TMP_Text sergeiRelationLvlTxt;
    public TMP_Text richardRelationLvlTxt;
    public TMP_Text bettyRelationLvlTxt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void OnEnable()
    {
        fawnRelationLvlTxt.text = GameManager.FawnRelationLevel.ToString();
        sergeiRelationLvlTxt.text = GameManager.SergeiRelationLevel.ToString();
        bettyRelationLvlTxt.text = GameManager.BettyRelationLevel.ToString();
        richardRelationLvlTxt.text = GameManager.RichardRelationLevel.ToString();
    }

    public void UnlockAllComics(bool triggerValue)
    {
        GameManager.allComicsUnlocked = triggerValue;
    }

    public void UnlockAllEndings(bool triggerValue)
    {
        GameManager.allEndingsUnlocked = triggerValue;
    }

    public void UnlockAllCompSkins(bool triggerValue)
    {
        GameManager.allCompSkinsUnlocked = triggerValue;
    }

    public void AddFundstoWallet(int buttonValue)
    {
        GameManager.moneyInWallet += buttonValue;
        SaveAndLoad.SaveToJson();
    }

    public void DayIncrease()
    {
        GameManager.DayCounter++;

        SaveAndLoad.SaveToJson();
    }

    public void DayDecrease()
    {
        GameManager.DayCounter--;
        SaveAndLoad.SaveToJson();
    }

    public void FawnRelationIncrease()
    {
        if(GameManager.FawnRelationLevel < 5)
        {
            GameManager.FawnRelationLevel++;
            fawnRelationLvlTxt.text = GameManager.FawnRelationLevel.ToString();
        }
        SaveAndLoad.SaveToJson();
    }

    public void FawnRelationDecrease()
    {
        if (GameManager.FawnRelationLevel > 0)
        {
            GameManager.FawnRelationLevel--;
            fawnRelationLvlTxt.text = GameManager.FawnRelationLevel.ToString();
        }
        SaveAndLoad.SaveToJson();
    }

    public void SergeiRelationIncrease()
    {
        if(GameManager.SergeiRelationLevel < 5)
        {
            GameManager.SergeiRelationLevel++;
            sergeiRelationLvlTxt.text = GameManager.SergeiRelationLevel.ToString();
        }
        SaveAndLoad.SaveToJson();
    }

    public void SergeiRelationDecrease()
    {
        if (GameManager.SergeiRelationLevel > 0)
        {
            GameManager.SergeiRelationLevel--;
            sergeiRelationLvlTxt.text = GameManager.SergeiRelationLevel.ToString();
        }
        SaveAndLoad.SaveToJson();
    }

    public void RichardRelationIncrease()
    {
        if(GameManager.RichardRelationLevel < 5)
        {
            GameManager.RichardRelationLevel++;
            richardRelationLvlTxt.text = GameManager.RichardRelationLevel.ToString();
        }
        SaveAndLoad.SaveToJson();
    }

    public void RichardRelationDecrease()
    {
        if (GameManager.RichardRelationLevel > 0)
        {
            GameManager.RichardRelationLevel--;
            richardRelationLvlTxt.text = GameManager.RichardRelationLevel.ToString();
        }
        SaveAndLoad.SaveToJson();
    }

    public void BettyRelationIncrease()
    {
        if(GameManager.BettyRelationLevel < 5)
        {
            GameManager.BettyRelationLevel++;
            bettyRelationLvlTxt.text = GameManager.BettyRelationLevel.ToString();
        }
        SaveAndLoad.SaveToJson();
    }

    public void BettyRelationDecrease()
    {
        if (GameManager.BettyRelationLevel > 0)
        {
            GameManager.BettyRelationLevel--;
            bettyRelationLvlTxt.text = GameManager.BettyRelationLevel.ToString();
        }
        SaveAndLoad.SaveToJson();
    }
}
