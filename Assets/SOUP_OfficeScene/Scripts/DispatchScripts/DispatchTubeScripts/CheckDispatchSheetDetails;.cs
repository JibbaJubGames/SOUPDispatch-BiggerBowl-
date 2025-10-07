using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDispatchSheetDetails : MonoBehaviour
{
    [SerializeField] private CompareHeroToSheet heroCompare;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckTiers(DispatchEmergencyDetails emergencyTiers, DispatchInfoSet dispatchInfo)
    {
        if (emergencyTiers.tierOneEmergency && TierComparison.playerChoseOne)
        {
            dispatchInfo.emergencyTierCorrect = true;
        }
        else if (emergencyTiers.tierTwoEmergency && TierComparison.playerChoseTwo)
        {
            dispatchInfo.emergencyTierCorrect = true;
        }
        else if (emergencyTiers.tierThreeEmergency && TierComparison.playerChoseThree)
        {
            dispatchInfo.emergencyTierCorrect = true;
        }
        else dispatchInfo.emergencyTierCorrect = false;
    }

    public void CheckDispatch(DispatchInfoSet dispatchInfoSet)
    {
        Debug.Log("Made it to dispatch check script");
        if (!dispatchInfoSet.operatorNumberCorrect)
        {
            heroCompare.dispatchSheetCorrectlyFiled = false;
            MistakeMade.MistakeBannerShow("That operator isn't even real!");
        }
        else if (!dispatchInfoSet.dateCorrect) 
        {
            heroCompare.dispatchSheetCorrectlyFiled = false;
            MistakeMade.MistakeBannerShow("That's the wrong date! How are we supposed to file it properly?");
        }
        else if (!dispatchInfoSet.emergencyTierCorrect) 
        {
            heroCompare.dispatchSheetCorrectlyFiled = false;
            MistakeMade.MistakeBannerShow("That emergency tier doesn't match the code!");
        }
        else if (!dispatchInfoSet.addressNotPrankster) 
        {
            heroCompare.dispatchSheetCorrectlyFiled = false;
            MistakeMade.MistakeBannerShow("That was a prankster's address! What a waste of time!");
        }
        else if (!dispatchInfoSet.deniedForRightReason) 
        {
            heroCompare.dispatchSheetCorrectlyFiled = false;
            MistakeMade.MistakeBannerShow("That wasn't the right denial stamp! Keep your eyes open!");
        }
        else
        {
            heroCompare.dispatchSheetCorrectlyFiled = true;
        }
    }
}
