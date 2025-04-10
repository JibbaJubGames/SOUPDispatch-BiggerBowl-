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


    private static bool askedWhere = false;
    private static bool askedWho = false;
    private static bool askedWhat = false;

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
        if (!askedWhat)
        {
            optionSelection = Random.Range(0, emergencyLines.Length);
            textForConvo = emergencyLines[optionSelection].GetComponent<StringHolder>().stringToHold;
            emergencyLines[optionSelection].GetComponent<SetDifficultyValues>().SetDifficultyPiece();
            convoHolder.SendAutoscribeMessage(textForConvo);
        }
            
    }

    public void AddressInfo()
    {
        if (!askedWhere)
        {
            if (DispatchDetailGeneratorScript.knowsAddress)
            {
                optionSelection = Random.Range(0, addressLines.Length);
                textForConvo = addressLines[optionSelection].GetComponent<StringHolder>().stringToHold;
                //addressLines[optionSelection].GetComponent<SetDifficultyValues>().SetDifficultyPiece();
                convoHolder.SendAutoscribeMessage(textForConvo);
            }
            else if (!DispatchDetailGeneratorScript.knowsAddress)
            {
                optionSelection = Random.Range(0, unknownAddressLines.Length);
                textForConvo = unknownAddressLines[optionSelection].GetComponent<StringHolder>().stringToHold;
                convoHolder.SendAutoscribeMessage(textForConvo);
                playerChat.FindAddress();
            }
            askedWhere = true;
        }
    }

    public void WhoseThereInfo()
    {
        if (!askedWho)
        {
            optionSelection = Random.Range(0, whoseInvolvedLines.Length);
            textForConvo = whoseInvolvedLines[optionSelection].GetComponent<StringHolder>().stringToHold;
            //whoseInvolvedLines[optionSelection].GetComponent<SetDifficultyValues>().SetDifficultyPiece();
            convoHolder.SendAutoscribeMessage(textForConvo);
            askedWho = true;
        }
    }

    public static void QuestionsReset()
    {
        askedWho = false;
        askedWhere = false;
        askedWhat = false;
    }
}
