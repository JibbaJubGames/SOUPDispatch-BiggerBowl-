using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class NameTagResponsesScript : MonoBehaviour
{
    [SerializeField] private string[] nameTagTriggers;
    [SerializeField] private string[] nameTagResponses;
    public bool specialResponse;

    public TMP_Text bozmunResponse;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NameTagBackForth(string inputText)
    {
        for (int i = 0; i < nameTagTriggers.Length; i++)
        {
            Debug.Log("This works");
            if (inputText == nameTagTriggers[i])
            {
                Debug.Log(inputText + "!= nameTagTriggers[i]");
                bozmunResponse.text = (nameTagResponses[i]);
                specialResponse = true;
            }
            else if (!specialResponse)
            {
                bozmunResponse.text = $"Your name is {inputText}? That's what you're going with..?";
            }
        }
    }

    public void IdentityTheft(string nameTagText)
    {
        Debug.Log("Script on this object");
        bozmunResponse.text = $"YOU'RE {nameTagText}? Really..?";
    }
}
