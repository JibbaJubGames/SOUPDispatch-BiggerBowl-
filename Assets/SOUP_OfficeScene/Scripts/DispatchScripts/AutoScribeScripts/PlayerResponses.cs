using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerResponses : MonoBehaviour
{
    [Header("Dispatch Types")]
    public AngryCallScript angryCaller;
    public CalmCallScript calmCaller;
    public ScaredCallScript scaredCaller;
    public ToThePointCallScript toThePointCaller;
    public PrankCallScript prankCaller;

    [Header("Dispatch Type Setter")]
    public static bool toThePointCallerSetter;
    public static bool scaredCallerSetter;
    public static bool angryCallerSetter;
    public static bool calmCallerSetter;
    public static bool prankCallerSetter;

    [Header("Address Minigame")]
    public Animator addressTrackerCaller;

    [Header("Player Responses")]
    public AutoscribeConvoScript convoHolder;
    public string playerTextForConvo;
    public GameObject[] findAddressResponses;
    public GameObject[] searchFailedResponses;
    public GameObject[] searchSuccessResponses;
    public GameObject[] playerGreetingResponses;
    public GameObject[] playerWhereResponses;
    public GameObject[] playerWhoResponses;
    public GameObject[] playerWhatResponses;
    public GameObject[] playerCalmDownResponses;
    public GameObject[] playerPrankAccusationResponses;
    public GameObject[] playerHangUpResponses;

    [Header("Impatience Setup")]
    public DispatchNotificationScript dispatchInfo;
    private float impatienceCounter;

    private void Update()
    {
        if (dispatchInfo.dispatchActive) 
        {
        
        }
    }

    private void Impatience()
    {
        impatienceCounter += Time.deltaTime;
        if (impatienceCounter > 10f)
        {
            if (angryCallerSetter)
            {
                Debug.Log("Impatiently angry!");
            }
            else if (calmCallerSetter)
            {
                Debug.Log("Impatiently calm");
            }
            else if (scaredCallerSetter)
            {
                Debug.Log("Impatiently scared");
            }
            else if (toThePointCallerSetter)
            {
                Debug.Log("Impatiently punctual");
            }
            impatienceCounter = 0;
        }
    }

    public void OpeningCallMessage()
    {
        if (angryCallerSetter)
        {
            angryCaller.Greetings();
            Debug.Log("Greetings from here");
        }
        else if (calmCallerSetter)
        {
            calmCaller.Greetings();
            Debug.Log("Greetings from here");
        }
        else if (scaredCallerSetter)
        {
            scaredCaller.Greetings();
            Debug.Log("Greetings from here");
        }
        else if (toThePointCallerSetter)
        {
            toThePointCaller.Greetings();
            Debug.Log("Greetings from here");
        }
        impatienceCounter = 0;
    }

    private void AskedWhere()
    {
        if (angryCallerSetter)
        {
            angryCaller.AddressInfo();
        }
        else if (calmCallerSetter)
        {
            calmCaller.AddressInfo();
        }
        else if (scaredCallerSetter)
        {
            scaredCaller.AddressInfo();
        }
        impatienceCounter = 0;
    }

    private void AskedEmergency()
    {
        if (angryCallerSetter)
        {
            angryCaller.EmergencyInfo();
        }
        else if (calmCallerSetter)
        {
            calmCaller.EmergencyInfo();
        }
        else if (scaredCallerSetter)
        {
            scaredCaller.EmergencyInfo();
        }
        impatienceCounter = 0;
    }

    private void AskedWho()
    {
        if (angryCallerSetter)
        {
            angryCaller.WhoseThereInfo();
        }
        else if (calmCallerSetter)
        {
            calmCaller.WhoseThereInfo();
        }
        else if (scaredCallerSetter)
        {
            scaredCaller.WhoseThereInfo();
        }
        impatienceCounter = 0;
    }

    private void CalmedCaller()
    {
        if (angryCallerSetter)
        {
            angryCaller.CalmDownCaller();
        }
        else if (scaredCallerSetter)
        {
            scaredCaller.CalmDownCaller();
        }

        impatienceCounter = 0;
    }

    public void FindAddress()
    {
        Invoke("PlayerFindAddressRequest", 1);
        addressTrackerCaller.SetTrigger("AddressUnknown");
    }

    private void PrankCalledOut()
    {
        Debug.Log("Called out prank");
        //TO DO:
        //      - Make it so the caller gets angry and player gets a demerit if they aren't
        //      - Make a check that has the pranker come clean or keep going and let the player push to question again
        //        or continue with dispatch (Player choice of course)
    }


    // vvvvvvvv put these on autoscribe buttons vvvvvv
    public void AddressMinigameResult(int foundAddress)
    {
        if (foundAddress == 1)
        {
            Invoke("BeatMazeGameResponse", 2);
        }
        else if (foundAddress == 0)
        {
            Invoke("LostMazeGameResponse", 2);
        }
    }

    private void PlayerFindAddressRequest()
    {
        int optionSelection = Random.Range(0, findAddressResponses.Length);
        playerTextForConvo = findAddressResponses[optionSelection].GetComponent<StringHolder>().stringToHold;
        convoHolder.playerMessageTime = true;
        convoHolder.SendAutoscribeMessage(playerTextForConvo);
        convoHolder.playerMessageTime = false;
    }

    private void LostMazeGameResponse()
    {
        Debug.Log("Couldn't find address...");
        int optionSelection = Random.Range(0, searchFailedResponses.Length);
        playerTextForConvo = searchFailedResponses[optionSelection].GetComponent<StringHolder>().stringToHold;
        convoHolder.playerMessageTime = true;
        convoHolder.SendAutoscribeMessage(playerTextForConvo);
        convoHolder.playerMessageTime = false;
    }

    private void BeatMazeGameResponse()
    {
        Debug.Log("Found Address!");
        int optionSelection = Random.Range(0, searchSuccessResponses.Length);
        playerTextForConvo = searchSuccessResponses[optionSelection].GetComponent<StringHolder>().stringToHold;
        convoHolder.playerMessageTime = true;
        convoHolder.SendAutoscribeMessage(playerTextForConvo);
        convoHolder.playerMessageTime = false;
    }

    public void PlayerGreeting()
    {
        int optionSelection = Random.Range(0, playerGreetingResponses.Length);
        playerTextForConvo = playerGreetingResponses[optionSelection].GetComponent<StringHolder>().stringToHold;
        convoHolder.playerMessageTime = true;
        convoHolder.SendAutoscribeMessage(playerTextForConvo);
        convoHolder.playerMessageTime = false;

        Invoke("OpeningCallMessage", 2);
    }

    public void PlayerWhereRequest()
    {
        int optionSelection = Random.Range(0, playerWhereResponses.Length);
        playerTextForConvo = playerWhereResponses[optionSelection].GetComponent<StringHolder>().stringToHold;
        convoHolder.playerMessageTime = true;
        convoHolder.SendAutoscribeMessage(playerTextForConvo);
        convoHolder.playerMessageTime = false;

        Invoke("AskedWhere", 2);
    }

    public void PlayerWhoRequest()
    {
        int optionSelection = Random.Range(0, playerWhoResponses.Length);
        playerTextForConvo = playerWhoResponses[optionSelection].GetComponent<StringHolder>().stringToHold;
        convoHolder.playerMessageTime = true;
        convoHolder.SendAutoscribeMessage(playerTextForConvo);
        convoHolder.playerMessageTime = false;

        Invoke("AskedWho", 2);
    }

    public void PlayerWhatRequest()
    {
        int optionSelection = Random.Range(0, playerWhatResponses.Length);
        playerTextForConvo = playerWhatResponses[optionSelection].GetComponent<StringHolder>().stringToHold;
        convoHolder.playerMessageTime = true;
        convoHolder.SendAutoscribeMessage(playerTextForConvo);
        convoHolder.playerMessageTime = false;

        Invoke("AskedEmergency", 2);
    }

    public void PlayerCalmResponse()
    {
        int optionSelection = Random.Range(0, playerCalmDownResponses.Length);
        playerTextForConvo = playerCalmDownResponses[optionSelection].GetComponent<StringHolder>().stringToHold;
        convoHolder.playerMessageTime = true;
        convoHolder.SendAutoscribeMessage(playerTextForConvo);
        convoHolder.playerMessageTime = false;

        Invoke("CalmedCaller", 2);
    }

    public void PlayerPrankResponse()
    {
        int optionSelection = Random.Range(0, playerPrankAccusationResponses.Length);
        playerTextForConvo = playerPrankAccusationResponses[optionSelection].GetComponent<StringHolder>().stringToHold;
        convoHolder.playerMessageTime = true;
        convoHolder.SendAutoscribeMessage(playerTextForConvo);
        convoHolder.playerMessageTime = false;

        Invoke("PrankCalledOut", 2);
    }

    public void PlayerHangUpResponse()
    {
        int optionSelection = Random.Range(0, playerHangUpResponses.Length);
        playerTextForConvo = playerHangUpResponses[optionSelection].GetComponent<StringHolder>().stringToHold;
        convoHolder.playerMessageTime = true;
        convoHolder.SendAutoscribeMessage(playerTextForConvo);
        convoHolder.playerMessageTime = false;
    }

    //^^^^^^^^ Put these on autoscribe buttons ^^^^^^^^


    public static void ResetCallerTypeSetters()
    {
        angryCallerSetter = false;
        calmCallerSetter = false;
        scaredCallerSetter = false;
        toThePointCallerSetter = false;
    }
}
