using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DispatchConversationScript : MonoBehaviour
{
    [Header("Dispatch Piece Holders")]
    public TMP_Text dispatchConversation;

    public GameObject[] greetings;
    public int greetingsSelection;

    public GameObject[] whoseInvolved;
    public int whoSelection;

    public GameObject[] whereIsIt;
    public int whereSelection;

    public GameObject[] whatsHappening;
    public int whatSelection;

    public GameObject[] fillerText;
    public int fillerSelection;
    public bool fillerUsed;
    public bool fillerAvailable;
    public bool fillerStyleCaller;
    public bool fillerActive;

    public GameObject[] calmedText;
    public int calmedSelection;

    [Header("Animation Holder")]
    public AnimTriggerScript buttonAnimations;

    // Start is called before the first frame update
    void Start()
    {
        //Figure out which day to start including filler
        if (GameManager.DayCounter >= 0 && fillerStyleCaller) fillerAvailable = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateDispatch()
    {
        greetingsSelection = Random.Range(0, greetings.Length);
        dispatchConversation.text = greetings[greetingsSelection].GetComponent<StringHolder>().stringToHold;
    }

    public void AskedWho()
    {
        RunFiller();
        if (fillerActive)
        {
            fillerSelection = Random.Range(0, fillerText.Length);
            dispatchConversation.text = fillerText[fillerSelection].GetComponent<StringHolder>().stringToHold;
        }
        else
        {
            whoSelection = Random.Range(0, whoseInvolved.Length);
            dispatchConversation.text = whoseInvolved[whoSelection].GetComponent<StringHolder>().stringToHold;
            buttonAnimations.runTrigger("AskedWho");
            whoseInvolved[whoSelection].GetComponent<SetDifficultyValues>().SetDifficultyPiece();
        }
        
    }

    public void AskedWhere()
    {
        RunFiller();
        if (fillerActive)
        {
            fillerSelection = Random.Range(0, fillerText.Length);
            dispatchConversation.text = fillerText[fillerSelection].GetComponent<StringHolder>().stringToHold;
        }
        else
        {
            whereSelection = Random.Range (0, whereIsIt.Length);
            dispatchConversation.text = whereIsIt[whereSelection].GetComponent<StringHolder>().stringToHold;
            buttonAnimations.runTrigger("AskedWhere");
            whereIsIt[whereSelection].GetComponent<SetDifficultyValues>().SetDifficultyPiece();
        }
        
    }

    public void AskedWhat()
    {
        RunFiller();
        if (fillerActive)
        {
            fillerSelection = Random.Range(0, fillerText.Length);
            dispatchConversation.text = fillerText[fillerSelection].GetComponent<StringHolder>().stringToHold;
        }
        else
        {
            whatSelection = Random.Range(0,whatsHappening.Length);
            dispatchConversation.text = whatsHappening[whatSelection].GetComponent<StringHolder>().stringToHold;
            buttonAnimations.runTrigger("AskedWhat");
            whatsHappening[whatSelection].GetComponent<SetDifficultyValues>().SetDifficultyPiece();
        }
        
    }

    public void AskedToCalm()
    {
        if (fillerActive)
        {
            calmedSelection = Random.Range(0, calmedText.Length);
            dispatchConversation.text = calmedText[calmedSelection].GetComponent<StringHolder>().stringToHold;
            buttonAnimations.runTrigger("AskedToCalm");
            fillerActive = false;
        }
        else return;
    }

    public void RunFiller()
    {
        if (fillerAvailable && !fillerActive)
        {
            int useFiller = Random.Range(1, 3);
            if (useFiller == 1)
            {
                fillerSelection = Random.Range(0, fillerText.Length);
                dispatchConversation.text = fillerText[fillerSelection].GetComponent<StringHolder>().stringToHold;
                fillerActive = true;
                if (fillerUsed)
                {
                    buttonAnimations.runTrigger("FreakingOut");
                }
                else fillerUsed = true;
            }
        }
        else return;
    }
}
