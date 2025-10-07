using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DispatchEmergencyDetails : MonoBehaviour
{
    [SerializeField] private string[] tierOneCodes;
    [SerializeField] private string[] tierTwoCodes;
    [SerializeField] private string[] tierThreeCodes;
    [SerializeField] public bool tierOneEmergency;
    [SerializeField] public bool tierTwoEmergency;
    [SerializeField] public bool tierThreeEmergency;
    public int emergencyTier;
    [SerializeField] private TMP_Text activeEmergency;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void SetTier()
    {
        tierOneEmergency = false;
        tierTwoEmergency = false;
        tierThreeEmergency = false;
        if (GenerateDispatchScript.tier == 0)
        {
            activeEmergency.text = tierOneCodes[Random.Range(0, tierOneCodes.Length)];
            tierOneEmergency = true;
            emergencyTier = 1;
        }
        else if (GenerateDispatchScript.tier == 1)
        {
            activeEmergency.text = tierTwoCodes[Random.Range(0, tierOneCodes.Length)];
            tierTwoEmergency = true;
            emergencyTier = 2;
        }
        else if (GenerateDispatchScript.tier == 2)
        {
            activeEmergency.text = tierThreeCodes[Random.Range(0, tierOneCodes.Length)];
            tierThreeEmergency = true;
            emergencyTier = 3;
        }
        Debug.Log(activeEmergency.text);
        string emergencyInfo = "We've got a code " + activeEmergency.text + ".";
        StartCoroutine(AppearLetterByLetterText.TypewriterText(emergencyInfo, 0.05f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
