using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DispatchTubeContentsChecker : MonoBehaviour
{
    public TMP_Text tubeInfo;
    public int profileCount;
    public int dispatchSheetCount;
    public static bool dispatchSheetGiven;
    public static bool profileGiven;
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
        tubeInfo.text = $"DISPATCH SHEET {dispatchSheetCount}/1 \r\n HERO PROFILE {profileCount}/1";
    }


}
