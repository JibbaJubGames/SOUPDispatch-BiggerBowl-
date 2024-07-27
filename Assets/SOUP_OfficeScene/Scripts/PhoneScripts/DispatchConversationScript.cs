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

    // Start is called before the first frame update
    void Start()
    {
        //Figure out which day to start including filler
        if (GameManager.DayCounter >= 0) fillerAvailable = true;
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
        whoSelection = Random.Range(0, whoseInvolved.Length);
        dispatchConversation.text = whoseInvolved[whoSelection].GetComponent<StringHolder>().stringToHold;
    }

    public void AskedWhere()
    {
        RunFiller();
        whereSelection = Random.Range (0, whereIsIt.Length);
        dispatchConversation.text = whereIsIt[whereSelection].GetComponent<StringHolder>().stringToHold;
    }

    public void AskedWhat()
    {
        RunFiller();
        whatSelection = Random.Range(0,whatsHappening.Length);
        dispatchConversation.text = whatsHappening[whatSelection].GetComponent<StringHolder>().stringToHold;
    }

    public void RunFiller()
    {
        if (fillerAvailable && !fillerUsed)
        {
            int useFiller = Random.Range(1, 10);
            if (useFiller == 1)
            {
                fillerSelection = Random.Range(0, fillerText.Length);
                dispatchConversation.text = fillerText[fillerSelection].GetComponent<StringHolder>().stringToHold;
                fillerUsed = true;
            }
        }
        else return;
    }
}
