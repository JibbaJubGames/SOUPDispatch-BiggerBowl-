using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DispatchTubeContentsChecker : MonoBehaviour
{
    public int profileCount;
    public int dispatchSheetCount;
    public static bool dispatchSheetGiven;
    public static bool profileGiven;
    [SerializeField] public static bool contentsChecked;
    [SerializeField] private bool dispatchChecked;
    [SerializeField] private CompareHeroToSheet comparisonScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dispatchSheetGiven)
        {
            dispatchSheetCount = 1;
        }
        if (profileGiven)
        {
            profileCount = 1;
        }
        if (dispatchSheetGiven && profileGiven && !contentsChecked)
        {
            contentsChecked = true;
            dispatchSheetGiven = false;
            profileGiven = false;
            profileCount = 0;
            dispatchSheetCount = 0;
            Debug.Log("Comparing sheets");
            comparisonScript.CompareSheets();
        }
    }


}
