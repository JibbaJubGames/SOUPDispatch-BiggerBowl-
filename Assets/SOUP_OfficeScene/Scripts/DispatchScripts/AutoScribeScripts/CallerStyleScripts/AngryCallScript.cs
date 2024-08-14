using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryCallScript : MonoBehaviour
{
    public GameObject[] openingLines;
    public GameObject[] emergencyLines;
    public GameObject[] addressLines;
    public GameObject[] unknownAddressLines;
    public GameObject[] whoseInvolvedLines;
    public GameObject[] fillerLines;
    public GameObject[] calmedDownLines;

    public bool fillerActive = false;

    public int optionSelection;
    public static string textForConvo;

    public AutoscribeConvoScript convoHolder;
    public PlayerResponses playerChat;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Greetings()
    {
            optionSelection = Random.Range(0, openingLines.Length);
            textForConvo = openingLines[optionSelection].GetComponent<StringHolder>().stringToHold;
            convoHolder.SendAutoscribeMessage(textForConvo);
    }

    public void EmergencyInfo()
    {
        RunFiller();
        if (!fillerActive)
        {
            optionSelection = Random.Range(0, emergencyLines.Length);
            textForConvo = emergencyLines[optionSelection].GetComponent<StringHolder>().stringToHold;
            convoHolder.SendAutoscribeMessage(textForConvo);
        }
        else return;
    }

    public void AddressInfo()
    {
        RunFiller();
        if (!fillerActive)
        {
            if (DispatchDetailGeneratorScript.knowsAddress)
            {
                optionSelection = Random.Range(0, addressLines.Length);
                textForConvo = addressLines[optionSelection].GetComponent<StringHolder>().stringToHold;
                convoHolder.SendAutoscribeMessage(textForConvo);
            }
            else if (!DispatchDetailGeneratorScript.knowsAddress)
            {
                optionSelection = Random.Range(0, unknownAddressLines.Length);
                textForConvo = unknownAddressLines[optionSelection].GetComponent<StringHolder>().stringToHold;
                convoHolder.SendAutoscribeMessage(textForConvo);
                playerChat.FindAddress();
            }
        }
        else return;
    }

    public void WhoseThereInfo()
    {
        RunFiller();
        if (!fillerActive)
        {
            optionSelection = Random.Range(0, whoseInvolvedLines.Length);
            textForConvo = whoseInvolvedLines[optionSelection].GetComponent<StringHolder>().stringToHold;
            convoHolder.SendAutoscribeMessage(textForConvo);
        }
        else return;
    }

    public void CalmDownCaller()
    {
        if (fillerActive)
        {
            optionSelection = Random.Range(0, calmedDownLines.Length);
            textForConvo = calmedDownLines[optionSelection].GetComponent<StringHolder>().stringToHold;
            convoHolder.SendAutoscribeMessage(textForConvo);
            fillerActive = false;
        }
        else return;
    }

    public void RunFiller()
    {
        int fillerChance = Random.Range(0, 10);
        if (fillerChance > 6)
        {
            Debug.Log("Looking for filler");
            optionSelection = Random.Range(0, fillerLines.Length);
            textForConvo = fillerLines[optionSelection].GetComponent<StringHolder>().stringToHold;
            convoHolder.SendAutoscribeMessage(textForConvo);
            fillerActive = true;
        }
        else return;
    }
}
