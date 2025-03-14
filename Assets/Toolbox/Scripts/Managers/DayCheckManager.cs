using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DayCheckManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text textToAlter;
    [SerializeField]
    private int dayToCheckFor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AlterText(string newText)
    {
        if (GameManager.DayCounter == dayToCheckFor)
        {
            textToAlter.text = newText;
        }
        else
        {
            textToAlter.text = "";
        }
    }
}
