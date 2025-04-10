using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispatchDetailGeneratorScript : MonoBehaviour
{
    public static bool prankCall;
    public static bool knowsAddress;
    public static int callerType;
    public static bool emergencyDispatch;

    public static void GenerateDispatch()
    {
        ResetDispatchDetailGenerator();

        SetEmergencyValue();

        SetPrankValue();

        SetAddressValue();

        Debug.Log($"This is an emergency call: {emergencyDispatch}" +
            $"This is a prank call: {prankCall}" +
            $"This caller knows their address: {knowsAddress}" +
            $"This caller is a {callerType} caller");
    }

    private static void SetEmergencyValue()
    {
        if (GameManager.DayCounter >= 10)
        {
            int redAlert = Random.Range(0, GameManager.DayCounter);
            if (redAlert >= 9)
            {
                emergencyDispatch = true;
            }
        }
    }

    private static void SetAddressValue()
    {
        if (!emergencyDispatch)
        {
            int addressOrNo = Random.Range(0, 10);
            if (addressOrNo >= 6)
            {
                knowsAddress = false;
            }
            else knowsAddress = true;
        }
        else return;
    }

    private static void SetPrankValue()
    {
        if (!emergencyDispatch)
        {
            int prankOrNo = Random.Range(0, 10);
            if (prankOrNo >= 7)
            {
                prankCall = true;
                PlayerResponses.prankCallerSetter = true;
            }
            else return;
        }
        else return;        
    }

    public static void ResetDispatchDetailGenerator()
    {
        prankCall = false;
        knowsAddress = true;
        emergencyDispatch = false;
        callerType = 0;
    }
}
