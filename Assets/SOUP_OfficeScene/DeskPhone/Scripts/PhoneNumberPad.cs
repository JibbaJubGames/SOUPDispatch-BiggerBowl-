using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PhoneNumberPad : MonoBehaviour
{
    [SerializeField] private DialedNumberTimer dialCountdown;
    [SerializeField] private int thisButtonValue;
    [SerializeField] private TMP_Text dialedNumberBox;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PressNumber()
    {
        if (dialCountdown.characterCount == 2)
        {
            dialedNumberBox.text = dialedNumberBox.text + thisButtonValue.ToString() + " - ";
            dialCountdown.characterCount++;
            dialCountdown.timeToClearNumbersCountdown = 0;
        }
        else if (dialCountdown.characterCount == 6)
        {
            dialedNumberBox.text = dialedNumberBox.text + thisButtonValue.ToString();
            dialCountdown.characterCount++;
            dialCountdown.timeToClearNumbersCountdown = 0;
            dialCountdown.CallNumber();
        }
        else
        {
            dialedNumberBox.text = dialedNumberBox.text + thisButtonValue.ToString();
            dialCountdown.characterCount++;
            dialCountdown.timeToClearNumbersCountdown = 0;
        }
    }
}
