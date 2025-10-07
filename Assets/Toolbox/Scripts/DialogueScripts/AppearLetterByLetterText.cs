using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class AppearLetterByLetterText : MonoBehaviour
{
    public string testString;
    public static string currentText;
    public static TMP_Text textBox;

    public float delay;

    public static MentionNextDetailScript nextDetailScript;

    public static UsePhone optional;
    // Start is called before the first frame update
    void Start()
    {
        if (GetComponent<UsePhone>() != null)
        {
            optional = GetComponent<UsePhone>();
        }
        nextDetailScript = GetComponent<MentionNextDetailScript>();
        nextDetailScript.badgeSaid = true;
        textBox = GetComponentInChildren<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static IEnumerator TypewriterText(string stringToConvert, float delay)
    {
        optional.PlayOperatorWeh();
        for (int i = 0; i < stringToConvert.Length; i++)
        {
            currentText = stringToConvert.Substring(0, i);
            textBox.text = currentText;
            yield return new WaitForSeconds(delay);
            Debug.Log(currentText);
            Debug.Log(stringToConvert);
        }
            Debug.Log("Playing next string");
            yield return new WaitForSeconds(2.5f);
            if (nextDetailScript.badgeSaid && !nextDetailScript.addressSaid)
            {
                nextDetailScript.BringUpAddress();
            }
            else if (nextDetailScript.badgeSaid && nextDetailScript.addressSaid && !nextDetailScript.emergencySaid)
            {
                nextDetailScript.BringUpEmergency();
            }
            else if (nextDetailScript.badgeSaid && nextDetailScript.addressSaid && nextDetailScript.emergencySaid)
            {
            Debug.Log("We've said everything to say");
            optional.PickUpPhone();
            }
    }
    
}
