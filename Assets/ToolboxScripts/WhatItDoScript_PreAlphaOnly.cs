using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhatItDoScript_PreAlphaOnly : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ThisDoesWhat(string whatItDo)
    {
        Debug.Log($"The function of this button, or piece of game environment; {whatItDo}");
    }
}
