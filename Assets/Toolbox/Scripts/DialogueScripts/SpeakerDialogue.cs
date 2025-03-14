using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpeakerDialogue : MonoBehaviour
{
    [Header("Dialogue Setup")]
    public TMP_Text speakerText;
    public string[] speakerDialogue;
    public int dialogueCount;

    [Header("Greetings Setup")]
    public int lvlOneGreetingStart;
    public int lvlOneGreetingEnd;

    public int lvlTwoGreetingStart;
    public int lvlTwoGreetingEnd;

    public int lvlThreeGreetingStart;
    public int lvlThreeGreetingEnd;

    public int lvlFourGreetingStart;
    public int lvlFourGreetingEnd;

    public int lvlFiveGreetingStart;
    public int lvlFiveGreetingEnd;

    [Header("Hangout Responses")]
    public int lvlOneHangoutStart;
    public int lvlOneHangoutEnd;

    public int lvlTwoHangoutStart;
    public int lvlTwoHangoutEnd;

    public int lvlThreeHangoutStart;
    public int lvlThreeHangoutEnd;

    public int lvlFourHangoutStart;
    public int lvlFourHangoutEnd;

    public int lvlFiveHangoutStart;
    public int lvlFiveHangoutEnd;

    [Header("CoffeeShopReccomendations")]
    public int reccommendationStart;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextLine()
    {
        dialogueCount++;
        speakerText.text = speakerDialogue[dialogueCount];
    }

    public void JumpTo(int targetLine)
    {
        speakerText.text = speakerDialogue[targetLine];
    }

    public void CafeGreetings()
    {
        if (GameManager.FawnRelationLevel == 1)
        {
            int greetingChoice = Random.Range(lvlOneGreetingStart, lvlOneGreetingEnd + 1);
            speakerText.text = speakerDialogue[greetingChoice];
            Debug.Log(speakerDialogue[greetingChoice]);
        }
        else if (GameManager.FawnRelationLevel == 2)
        {
            int greetingChoice = Random.Range(lvlTwoGreetingStart, lvlTwoGreetingEnd + 1);
            speakerText.text = speakerDialogue[greetingChoice];
        }
        else if (GameManager.FawnRelationLevel == 3)
        {
            int greetingChoice = Random.Range(lvlThreeGreetingStart, lvlThreeGreetingEnd + 1);
            speakerText.text = speakerDialogue[greetingChoice];
        }
        else if (GameManager.FawnRelationLevel == 4)
        {
            int greetingChoice = Random.Range(lvlFourGreetingStart, lvlFourGreetingEnd + 1);
            speakerText.text = speakerDialogue[greetingChoice];
        }
        else if (GameManager.FawnRelationLevel == 5)
        {
            int greetingChoice = Random.Range(lvlFiveGreetingStart, lvlFiveGreetingEnd + 1);
            speakerText.text = speakerDialogue[greetingChoice];
        }
    }

    public void CafeHangout()
    {
        if (GameManager.FawnRelationLevel == 1)
        {
            int greetingChoice = Random.Range(lvlOneHangoutStart, lvlOneHangoutEnd + 1);
            speakerText.text = speakerDialogue[greetingChoice];
        }
        else if (GameManager.FawnRelationLevel == 2)
        {
            int greetingChoice = Random.Range(lvlTwoHangoutStart, lvlTwoHangoutEnd + 1);
            speakerText.text = speakerDialogue[greetingChoice];
        }
        else if (GameManager.FawnRelationLevel == 3)
        {
            int greetingChoice = Random.Range(lvlThreeHangoutStart, lvlThreeHangoutEnd + 1);
            speakerText.text = speakerDialogue[greetingChoice];
        }
        else if (GameManager.FawnRelationLevel == 4)
        {
            int greetingChoice = Random.Range(lvlFourHangoutStart, lvlFourHangoutEnd + 1);
            speakerText.text = speakerDialogue[greetingChoice];
        }
        else if (GameManager.FawnRelationLevel == 5)
        {
            int greetingChoice = Random.Range(lvlFiveHangoutStart, lvlFiveHangoutEnd + 1);
            speakerText.text = speakerDialogue[greetingChoice];
        }
    }

    public void ComicGreetings()
    {
        if (GameManager.RichardRelationLevel == 1)
        {
            int greetingChoice = Random.Range(lvlOneGreetingStart, lvlOneGreetingEnd + 1);
            speakerText.text = speakerDialogue[greetingChoice];
        }
        else if (GameManager.RichardRelationLevel == 2)
        {
            int greetingChoice = Random.Range(lvlTwoGreetingStart, lvlTwoGreetingEnd + 1);
            speakerText.text = speakerDialogue[greetingChoice];
        }
        else if (GameManager.RichardRelationLevel == 3)
        {
            int greetingChoice = Random.Range(lvlThreeGreetingStart, lvlThreeGreetingEnd + 1);
            speakerText.text = speakerDialogue[greetingChoice];
        }
        else if (GameManager.RichardRelationLevel == 4)
        {
            int greetingChoice = Random.Range(lvlFourGreetingStart, lvlFourGreetingEnd + 1);
            speakerText.text = speakerDialogue[greetingChoice];
        }
        else if (GameManager.RichardRelationLevel == 5)
        {
            int greetingChoice = Random.Range(lvlFiveGreetingStart, lvlFiveGreetingEnd + 1);
            speakerText.text = speakerDialogue[greetingChoice];
        }
    }

    public void ComicsHangout()
    {
        if (GameManager.RichardRelationLevel == 1)
        {
            int greetingChoice = Random.Range(lvlOneHangoutStart, lvlOneHangoutEnd + 1);
            speakerText.text = speakerDialogue[greetingChoice];
        }
        else if (GameManager.RichardRelationLevel == 2)
        {
            int greetingChoice = Random.Range(lvlTwoHangoutStart, lvlTwoHangoutEnd + 1);
            speakerText.text = speakerDialogue[greetingChoice];
        }
        else if (GameManager.RichardRelationLevel == 3)
        {
            int greetingChoice = Random.Range(lvlThreeHangoutStart, lvlThreeHangoutEnd + 1);
            speakerText.text = speakerDialogue[greetingChoice];
        }
        else if (GameManager.RichardRelationLevel == 4)
        {
            int greetingChoice = Random.Range(lvlFourHangoutStart, lvlFourHangoutEnd + 1);
            speakerText.text = speakerDialogue[greetingChoice];
        }
        else if (GameManager.RichardRelationLevel == 5)
        {
            int greetingChoice = Random.Range(lvlFiveHangoutStart, lvlFiveHangoutEnd + 1);
            speakerText.text = speakerDialogue[greetingChoice];
        }
    }

    public void CompGreetings()
    {
        if (GameManager.SergeiRelationLevel == 1)
        {
            int greetingChoice = Random.Range(lvlOneGreetingStart, lvlOneGreetingEnd + 1);
            speakerText.text = speakerDialogue[greetingChoice];
        }
        else if (GameManager.SergeiRelationLevel == 2)
        {
            int greetingChoice = Random.Range(lvlTwoGreetingStart, lvlTwoGreetingEnd + 1);
            speakerText.text = speakerDialogue[greetingChoice];
        }
        else if (GameManager.SergeiRelationLevel == 3)
        {
            int greetingChoice = Random.Range(lvlThreeGreetingStart, lvlThreeGreetingEnd + 1);
            speakerText.text = speakerDialogue[greetingChoice];
        }
        else if (GameManager.SergeiRelationLevel == 4)
        {
            int greetingChoice = Random.Range(lvlFourGreetingStart, lvlFourGreetingEnd + 1);
            speakerText.text = speakerDialogue[greetingChoice];
        }
        else if (GameManager.SergeiRelationLevel == 5)
        {
            int greetingChoice = Random.Range(lvlFiveGreetingStart, lvlFiveGreetingEnd + 1);
            speakerText.text = speakerDialogue[greetingChoice];
        }
    }

    public void CompHangout()
    {
        if (GameManager.SergeiRelationLevel == 1)
        {
            int greetingChoice = Random.Range(lvlOneHangoutStart, lvlOneHangoutEnd + 1);
            speakerText.text = speakerDialogue[greetingChoice];
        }
        else if (GameManager.SergeiRelationLevel == 2)
        {
            int greetingChoice = Random.Range(lvlTwoHangoutStart, lvlTwoHangoutEnd + 1);
            speakerText.text = speakerDialogue[greetingChoice];
        }
        else if (GameManager.SergeiRelationLevel == 3)
        {
            int greetingChoice = Random.Range(lvlThreeHangoutStart, lvlThreeHangoutEnd + 1);
            speakerText.text = speakerDialogue[greetingChoice];
        }
        else if (GameManager.SergeiRelationLevel == 4)
        {
            int greetingChoice = Random.Range(lvlFourHangoutStart, lvlFourHangoutEnd + 1);
            speakerText.text = speakerDialogue[greetingChoice];
        }
        else if (GameManager.SergeiRelationLevel == 5)
        {
            int greetingChoice = Random.Range(lvlFiveHangoutStart, lvlFiveHangoutEnd + 1);
            speakerText.text = speakerDialogue[greetingChoice];
        }
    }

    public void PawnGreetings()
    {
        if (GameManager.BettyRelationLevel == 1)
        {
            int greetingChoice = Random.Range(lvlOneGreetingStart, lvlOneGreetingEnd + 1);
            speakerText.text = speakerDialogue[greetingChoice];
        }
        else if (GameManager.BettyRelationLevel == 2)
        {
            int greetingChoice = Random.Range(lvlTwoGreetingStart, lvlTwoGreetingEnd + 1);
            speakerText.text = speakerDialogue[greetingChoice];
        }
        else if (GameManager.BettyRelationLevel == 3)
        {
            int greetingChoice = Random.Range(lvlThreeGreetingStart, lvlThreeGreetingEnd + 1);
            speakerText.text = speakerDialogue[greetingChoice];
        }
        else if (GameManager.BettyRelationLevel == 4)
        {
            int greetingChoice = Random.Range(lvlFourGreetingStart, lvlFourGreetingEnd + 1);
            speakerText.text = speakerDialogue[greetingChoice];
        }
        else if (GameManager.BettyRelationLevel == 5)
        {
            int greetingChoice = Random.Range(lvlFiveGreetingStart, lvlFiveGreetingEnd + 1);
            speakerText.text = speakerDialogue[greetingChoice];
        }
    }

    public void PawnHangout()
    {
        if (GameManager.BettyRelationLevel == 1)
        {
            int greetingChoice = Random.Range(lvlOneHangoutStart, lvlOneHangoutEnd + 1);
            speakerText.text = speakerDialogue[greetingChoice];
        }
        else if (GameManager.BettyRelationLevel == 2)
        {
            int greetingChoice = Random.Range(lvlTwoHangoutStart, lvlTwoHangoutEnd + 1);
            speakerText.text = speakerDialogue[greetingChoice];
        }
        else if (GameManager.BettyRelationLevel == 3)
        {
            int greetingChoice = Random.Range(lvlThreeHangoutStart, lvlThreeHangoutEnd + 1);
            speakerText.text = speakerDialogue[greetingChoice];
        }
        else if (GameManager.BettyRelationLevel == 4)
        {
            int greetingChoice = Random.Range(lvlFourHangoutStart, lvlFourHangoutEnd + 1);
            speakerText.text = speakerDialogue[greetingChoice];
        }
        else if (GameManager.BettyRelationLevel == 5)
        {
            int greetingChoice = Random.Range(lvlFiveHangoutStart, lvlFiveHangoutEnd + 1);
            speakerText.text = speakerDialogue[greetingChoice];
        }
    }
}
