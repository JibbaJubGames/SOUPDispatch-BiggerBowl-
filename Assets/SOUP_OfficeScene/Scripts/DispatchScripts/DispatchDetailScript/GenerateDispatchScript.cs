using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GenerateDispatchScript : MonoBehaviour
{
    //Strings to read what the details are
    [SerializeField] public string operatorNumber;
    [SerializeField] public string date;
    [SerializeField] public string emergencyCode;
    [SerializeField] public static int tier;
    [SerializeField] public int fakeDetailThreshold;
    [SerializeField] public int wrongDetail;
    [SerializeField] public string address;
    [SerializeField] public string prankOrReal;
    [SerializeField] public GameObject currentDispatch;
    [SerializeField] private int chosenWrong;
    public GameObject dispatchPrefab;
    public Transform dispatchSpawn;

    public static bool dispatchActive;

    [Header("Address Tracker")]
    [SerializeField] private Animator addressTrackerAnim;
    [SerializeField] private AddressRandomizationScript randomAddressSelector;

    [Header("Debug purposes)")]
    [SerializeField] public bool ForceMistake;
    [SerializeField] public bool ForcePrankCall;
    [SerializeField] public bool ForceAddressFinder;
    [SerializeField] public bool ForceWrongDate;
    [SerializeField] public bool ForceFakeOperator;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void EnableBool(int targetBool)
    {
        if (targetBool == 1)
        {
            if (!ForceMistake)
            {
                ForceMistake = true;
            }
            else if (ForceMistake)
            {
                ForceMistake = false;
            }
        }
        else if (targetBool == 2)
        {
            if (!ForcePrankCall)
            {
                ForcePrankCall = true;
            }
            else if (ForcePrankCall)
            {
                ForcePrankCall = false;
            }
        }
        else if (targetBool == 3)
        {
            if (!ForceAddressFinder)
            {
                ForceAddressFinder = true;
            }
            else if (ForceAddressFinder)
            {
                ForceAddressFinder = false;
            }
        }
        else if (targetBool == 4)
        {
            if (!ForceWrongDate)
            {
                ForceWrongDate = true;
            }
            else if (ForceWrongDate)
            {
                ForceWrongDate = false;
            }
        }
        else if (targetBool == 5)
        {
            if (!ForceFakeOperator)
            {
                ForceFakeOperator = true;
            }
            else if (ForceFakeOperator)
            {
                ForceFakeOperator = false;
            }
        }
    }

    public void GenerateTier()
    {

        if (PhoneLineOpenClose.lineOpen && !UsePhone.onPhone && !dispatchActive && ShiftTimerFill.clockedIn)
        {
            Debug.Log("PhoneRinging");
            dispatchActive = true;
            currentDispatch = Instantiate(dispatchPrefab, dispatchSpawn);
            if (currentDispatch.GetComponent<DispatchInfoSet>().dispatchGenerated == false)
            {
                tier = Random.Range(0, 3); //Change likelihood of each tier after deciding which heroes are what rank, so that it's a fair chance
                wrongDetail = Random.Range(0, 10);
                if (ForceMistake || wrongDetail < fakeDetailThreshold)
                {
                    Debug.Log("This is called here");
                    if (GameManager.DayCounter >= 16)
                    {
                        //Get rid of this line when done building system
                        if (!ForceMistake)
                        {
                            chosenWrong = Random.Range(0, 4);
                        }
                        else if (ForceMistake)
                        {
                            chosenWrong = 5;
                        }
                        if (chosenWrong == 0 || ForcePrankCall)
                        {
                            Debug.Log("Call prank caller method 4");
                            randomAddressSelector.GenPrankAddress();
                            currentDispatch.GetComponent<DispatchEmergencyDetails>().SetTier();
                            currentDispatch.GetComponent<DispatchOperatorDetails>().GenBadgeNumber();
                            currentDispatch.GetComponent<DispatchDateDetails>().CorrectDate();
                            currentDispatch.GetComponent<DispatchInfoSet>().deniedForRightReason = true;
                            currentDispatch.GetComponent<DispatchInfoSet>().dispatchGenerated = true;
                        }
                        else if (chosenWrong == 1 || ForceAddressFinder)
                        {
                            randomAddressSelector.addressOnSheet = currentDispatch.transform.GetChild(0).transform.GetChild(5).GetComponent<TMP_Text>();
                            randomAddressSelector.unknownSectorOnSheet = currentDispatch.transform.GetChild(0).transform.GetChild(6).GetComponent<TMP_Text>();
                            randomAddressSelector.addressOnSheet.text = "Unknown Address";
                            randomAddressSelector.unknownSectorOnSheet.text = "Sector ???";
                            addressTrackerAnim.SetTrigger("AddressUnknown");
                            currentDispatch.GetComponent<DispatchEmergencyDetails>().SetTier();
                            currentDispatch.GetComponent<DispatchOperatorDetails>().GenBadgeNumber();
                            currentDispatch.GetComponent<DispatchDateDetails>().CorrectDate();
                            currentDispatch.GetComponent<DispatchInfoSet>().deniedForRightReason = true;
                            currentDispatch.GetComponent<DispatchInfoSet>().dispatchGenerated = true;
                        }
                        else if (chosenWrong == 2 || ForceWrongDate)
                        {
                            Debug.Log("Call wrong date method 2");
                            randomAddressSelector.GenAddress();
                            currentDispatch.GetComponent<DispatchDateDetails>().IncorrectDate();
                            currentDispatch.GetComponent<DispatchEmergencyDetails>().SetTier();
                            currentDispatch.GetComponent<DispatchOperatorDetails>().GenBadgeNumber();
                            currentDispatch.GetComponent<DispatchInfoSet>().deniedForRightReason = true;
                            currentDispatch.GetComponent<DispatchInfoSet>().dispatchGenerated = true;
                        }
                        else if (chosenWrong == 3 || ForceFakeOperator)
                        {
                            Debug.Log("Call incorrect badge number method 1");
                            randomAddressSelector.GenAddress();
                            currentDispatch.GetComponent<DispatchOperatorDetails>().GenFakeBadge();
                            currentDispatch.GetComponent<DispatchEmergencyDetails>().SetTier();
                            currentDispatch.GetComponent<DispatchDateDetails>().CorrectDate();
                            currentDispatch.GetComponent<DispatchInfoSet>().deniedForRightReason = true;
                            currentDispatch.GetComponent<DispatchInfoSet>().dispatchGenerated = true;
                        }

                        //Select fake event: prank call (day 4), incorrect badge Day 16, wrong date day 14, no address day 10
                    }
                    else if (GameManager.DayCounter >= 14)
                    {
                        chosenWrong = Random.Range(0, 3);
                        if (chosenWrong == 0)
                        {
                            Debug.Log("Call prank caller method 3");
                        }
                        else if (chosenWrong == 1)
                        {
                            randomAddressSelector.addressOnSheet.text = "Unknown Address";
                            randomAddressSelector.unknownSectorOnSheet.text = "Sector ???";
                            addressTrackerAnim.SetTrigger("AddressUnknown");
                            currentDispatch.GetComponent<DispatchEmergencyDetails>().SetTier();
                            currentDispatch.GetComponent<DispatchOperatorDetails>().GenBadgeNumber();
                            currentDispatch.GetComponent<DispatchDateDetails>().CorrectDate();
                            currentDispatch.GetComponent<DispatchInfoSet>().deniedForRightReason = true;
                            currentDispatch.GetComponent<DispatchInfoSet>().dispatchGenerated = true;
                        }
                        else if (chosenWrong == 2)
                        {
                            randomAddressSelector.GenAddress();
                            currentDispatch.GetComponent<DispatchDateDetails>().IncorrectDate();
                            currentDispatch.GetComponent<DispatchEmergencyDetails>().SetTier();
                            currentDispatch.GetComponent<DispatchOperatorDetails>().GenBadgeNumber();
                            currentDispatch.GetComponent<DispatchInfoSet>().deniedForRightReason = true;
                            currentDispatch.GetComponent<DispatchInfoSet>().dispatchGenerated = true;
                        }
                    }
                    else if (GameManager.DayCounter >= 10)
                    {
                        chosenWrong = Random.Range(0, 2);
                        if (chosenWrong == 0)
                        {
                            Debug.Log("Call prank caller method 2");
                        }
                        else if (chosenWrong == 1)
                        {
                            randomAddressSelector.addressOnSheet.text = "Unknown Address";
                            randomAddressSelector.unknownSectorOnSheet.text = "Sector ???";
                            addressTrackerAnim.SetTrigger("AddressUnknown");
                            currentDispatch.GetComponent<DispatchEmergencyDetails>().SetTier();
                            currentDispatch.GetComponent<DispatchOperatorDetails>().GenBadgeNumber();
                            currentDispatch.GetComponent<DispatchDateDetails>().CorrectDate();
                            currentDispatch.GetComponent<DispatchInfoSet>().deniedForRightReason = true;
                            currentDispatch.GetComponent<DispatchInfoSet>().dispatchGenerated = true;
                        }
                    }
                    else if (GameManager.DayCounter >= 4)
                    {
                        //Call prank caller address method
                        Debug.Log("Call prank caller method 1");
                    }
                    else if (GameManager.DayCounter <= 3)
                    {
                        currentDispatch.GetComponent<DispatchEmergencyDetails>().SetTier();
                        currentDispatch.GetComponent<DispatchOperatorDetails>().GenBadgeNumber();
                        currentDispatch.GetComponent<DispatchDateDetails>().CorrectDate();
                        randomAddressSelector.GenAddress();
                        currentDispatch.GetComponent<DispatchInfoSet>().deniedForRightReason = true;
                        currentDispatch.GetComponent<DispatchInfoSet>().dispatchGenerated = true;
                    }
                    fakeDetailThreshold = 1;
                }
                else
                {
                    fakeDetailThreshold++;
                    currentDispatch.GetComponent<DispatchDateDetails>().CorrectDate();
                    currentDispatch.GetComponent<DispatchInfoSet>().dispatchGenerated = true;
                    currentDispatch.GetComponent<DispatchInfoSet>().deniedForRightReason = true;
                    currentDispatch.GetComponent<DispatchInfoSet>().dispatchPageFilled = true;
                }
            }
        }
    }
}
