using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalmCallScript : MonoBehaviour
{
    public GameObject[] openingLines;
    public GameObject[] emergencyLines;
    public GameObject[] addressLines;
    public GameObject[] unknownAddressLines;
    public GameObject[] whoseInvolvedLines;

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
            optionSelection = Random.Range(0, emergencyLines.Length);
            textForConvo = emergencyLines[optionSelection].GetComponent<StringHolder>().stringToHold;
            convoHolder.SendAutoscribeMessage(textForConvo);
    }

    public void AddressInfo()
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

    public void WhoseThereInfo()
    {
        {
            optionSelection = Random.Range(0, whoseInvolvedLines.Length);
            textForConvo = whoseInvolvedLines[optionSelection].GetComponent<StringHolder>().stringToHold;
            convoHolder.SendAutoscribeMessage(textForConvo);
        }
    }
}
