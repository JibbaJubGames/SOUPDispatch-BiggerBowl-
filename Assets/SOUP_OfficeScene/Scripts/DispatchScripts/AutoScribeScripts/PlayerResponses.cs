using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public GameObject[] findAddressResponses;
    public Animator addressTrackerCaller;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
    }

    public void AskedWhere()
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
        else if (toThePointCallerSetter)
        {
            toThePointCaller.AddressInfo();
        }
    }

    public void AskedEmergency()
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
        else if (toThePointCallerSetter)
        {
            toThePointCaller.EmergencyInfo();
        }
    }

    public void AskedWho()
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
        else if (toThePointCallerSetter)
        {
            toThePointCaller.WhoseThereInfo();
        }
    }

    public void CalmedCaller()
    {
        if (angryCallerSetter)
        {
            angryCaller.CalmDownCaller();
        }
        else if (scaredCallerSetter)
        {
            scaredCaller.CalmDownCaller();
        }
        else if (toThePointCallerSetter)
        {
            toThePointCaller.CalmDownCaller();
        }
    }

    public void FindAddress()
    {
        //Make player message say they'll find the address
        addressTrackerCaller.SetTrigger("AddressUnknown");
    }

    public static void ResetCallerTypeSetters()
    {
        angryCallerSetter = false;
        calmCallerSetter = false;
        scaredCallerSetter = false;
        toThePointCallerSetter = false;
        ShowSetterValues();
    }

    public static void ShowSetterValues()
    {
        Debug.Log("Angry: "+ angryCallerSetter); ;
        Debug.Log("Calm: "+ calmCallerSetter); ;
        Debug.Log("Scared: "+ scaredCallerSetter); ;
        Debug.Log("TTP: "+ toThePointCallerSetter);
    }
}
