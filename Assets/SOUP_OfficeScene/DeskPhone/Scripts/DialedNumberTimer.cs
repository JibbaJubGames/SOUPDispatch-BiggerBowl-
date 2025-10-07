using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialedNumberTimer : MonoBehaviour
{
    public float timeToClearNumbersCountdown;
    public int timeToClearNumbers;
    public int characterCount;
    public TMP_Text numberDialBox;

    [SerializeField] private GameObject hangUpPhoneButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (characterCount > 0 && characterCount < 7)
        {
            timeToClearNumbersCountdown += Time.deltaTime;
        }
        if (timeToClearNumbersCountdown >= timeToClearNumbers)
        {
            numberDialBox.text = null;
            characterCount = 0;
            timeToClearNumbersCountdown = 0;
        }
    }

    public void CallNumber()
    {
        hangUpPhoneButton.SetActive(true);
        Debug.Log("Phone is ringing!");
    }

    public void EndCall()
    {
        numberDialBox.text = null;
        characterCount = 0;
        timeToClearNumbersCountdown = 0;
        hangUpPhoneButton.SetActive(false);
    }
}
