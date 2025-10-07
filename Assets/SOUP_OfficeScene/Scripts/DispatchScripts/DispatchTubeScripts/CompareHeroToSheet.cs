using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CompareHeroToSheet : MonoBehaviour
{
    public GameObject heroSheet;
    public GameObject dispatchSheet;
    public bool dispatchSheetCorrectlyFiled;
    private bool heroStrongEnough;
    private bool heroOnDuty;
    private bool sectorCorrect;
    [SerializeField] private CheckDispatchSheetDetails dispatchDetailsScript;
    [SerializeField] public Animator phoneAppPC;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CompareSheets()
    {
        Debug.Log("Comparing dispatch sheet and hero sheet");
        dispatchDetailsScript.CheckTiers(dispatchSheet.gameObject.GetComponent<DispatchEmergencyDetails>(), dispatchSheet.gameObject.GetComponent<DispatchInfoSet>());
        dispatchDetailsScript.CheckDispatch(dispatchSheet.gameObject.GetComponent<DispatchInfoSet>());
        //Check dispatch sheet is filled first, if all dispatch sheet info correct, call this method
        if (dispatchSheetCorrectlyFiled)
        {
            CompareWorkSchedule();
            if (heroOnDuty) 
            {
                CompareTiers();
                if (heroStrongEnough)
                {
                    CompareAddressSector();
                    if (sectorCorrect)
                        {
                        Debug.Log("WE SUCCESSFULLY SAVED THE DAY");
                        }
                }
            }
           
        }
        Destroy(heroSheet.gameObject);
        Destroy(dispatchSheet.gameObject);
        heroSheet = null;
        dispatchSheet = null;
        DispatchTubeContentsChecker.contentsChecked = false;
        GenerateDispatchScript.dispatchActive = false;
        if (phoneAppPC.GetCurrentAnimatorStateInfo(0).IsName("PhoneOut"))
        {
            phoneAppPC.SetTrigger("CloseApp");
        }
    }

    private void CompareAddressSector()
    {
        sectorCorrect = false;
        for (int i = 0; i < heroSheet.GetComponentInChildren<HeroSectorsWorking>().sectorsHeroWorks.Length; i++)
        {
            if (heroSheet.GetComponentInChildren<HeroSectorsWorking>().sectorsHeroWorks[i] == dispatchSheet.GetComponent<AddressRandomizationScript>().sectorOnSheet)
            {
                Debug.Log("This hero can reach this emergency");
                sectorCorrect = true;
            }
            else
            {
                Debug.Log($"Hero work sector {i} does not equal the needed sector");
            }
        }
        if (!sectorCorrect)
        {
            MistakeMade.MistakeBannerShow("The hero doesn't work\nin that area!");
        }
    }

    private void CompareTiers()
    {
         heroStrongEnough = false;
        if (heroSheet.GetComponentInChildren<HeroTierRanking>().heroTier >= dispatchSheet.gameObject.GetComponent<DispatchEmergencyDetails>().emergencyTier)
        {
            Debug.Log("Hero can win");
            heroStrongEnough = true;
        }
        

        if (!heroStrongEnough)
        {
            Debug.Log("Hero can't win");
            MistakeMade.MistakeBannerShow("This hero isn't strong enough for that...\nCan't you count?");
        }
    }

    private void CompareWorkSchedule()
    {
        heroOnDuty = false;
        if (CurrentDateUpdater.currentDay == 0)
        {
            if (heroSheet.GetComponentInChildren<HeroWorkSchedule>().worksMonday)
            {
                heroOnDuty = true;
            }
        }
        else if (CurrentDateUpdater.currentDay == 1)
        {
            if (heroSheet.GetComponentInChildren<HeroWorkSchedule>().worksTuesday)
            {
                heroOnDuty = true;
            }
        }
        else if (CurrentDateUpdater.currentDay == 2)
        {
            if (heroSheet.GetComponentInChildren<HeroWorkSchedule>().worksWednesday)
            {
                heroOnDuty = true;
            }
        }
        else if (CurrentDateUpdater.currentDay == 3)
        {
            if (heroSheet.GetComponentInChildren<HeroWorkSchedule>().worksThursday)
            {
                heroOnDuty = true;
            }
        }
        else if (CurrentDateUpdater.currentDay == 4)
        {
            if (heroSheet.GetComponentInChildren<HeroWorkSchedule>().worksFriday)
            {
                heroOnDuty = true;
            }
        }
        else if (CurrentDateUpdater.currentDay == 5)
        {
            if (heroSheet.GetComponentInChildren<HeroWorkSchedule>().worksSaturday)
            {
                heroOnDuty = true;
            }
        }
        else if (CurrentDateUpdater.currentDay == 6)
        {
            if (heroSheet.GetComponentInChildren<HeroWorkSchedule>().worksSunday)
            {
                heroOnDuty = true;
            }
        }
        else
        {
            MistakeMade.MistakeBannerShow("That hero isn't working today!");
        }
    }
}
