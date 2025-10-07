using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DispatchOperatorDetails : MonoBehaviour
{
    [Range(0, 50)]
    [SerializeField] private int operatorNumber;
    [SerializeField] private bool fakeBadge;
    [SerializeField] private TMP_Text badgeNumberOnSheet;

    public DispatchInfoSet dispatchPage;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenBadgeNumber()
    {
        fakeBadge = false;
        badgeNumberOnSheet.text = new string($"0-{OperatorsOnDutyList.operatorNumbers[Random.Range(0, 15)]}");
        Debug.Log("Real operator");
        dispatchPage.operatorNumberCorrect = true;
        string operatorGreeting = "Hello desk jockey! This is operator " + badgeNumberOnSheet.text + ". ";
        StartCoroutine(AppearLetterByLetterText.TypewriterText(operatorGreeting, 0.05f));
    }

    public void GenFakeBadge()
    {
            fakeBadge = true;
        operatorNumber = Random.Range(1000, 10000);
            badgeNumberOnSheet.text = new string($"O-{operatorNumber}");
        for (int i = 0; i < OperatorsOnDutyList.operatorNumbers.Length; i++)
        {
            if (operatorNumber == OperatorsOnDutyList.operatorNumbers[i])
            {
                GenFakeBadge();
            }
        }
        Debug.Log("Fake operator");
    }
}
