using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallerStyleSelectionScript : MonoBehaviour
{
    public GameObject[] typesOfCallers;
    public int callerType;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickCallerType()
    {
        callerType = Random.Range(0, typesOfCallers.Length);
        typesOfCallers[callerType].GetComponent<DispatchConversationScript>().GenerateDispatch();
    }

    public void WhoButton()
    {
        typesOfCallers[callerType].GetComponent<DispatchConversationScript>().AskedWho();
    }

    public void WhatButton()
    {
        typesOfCallers[callerType].GetComponent<DispatchConversationScript>().AskedWhat();
    }

    public void WhereButton()
    {
        typesOfCallers[callerType].GetComponent<DispatchConversationScript>().AskedWhere();
    }

    public void CalmButton()
    {
        typesOfCallers[callerType].GetComponent<DispatchConversationScript>().AskedToCalm();
    }
}
