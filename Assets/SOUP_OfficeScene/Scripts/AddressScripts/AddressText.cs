using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AddressText : MonoBehaviour
{
    [SerializeField] public string addressText;
    [SerializeField] public string sectorTextForPrankCall;
    public TMP_Text textHolder;
    // Start is called before the first frame update
    void Start()
    {
        addressText = textHolder.text;
    }
    // FIGURE OUT HOW TO MAKE THE PAGE TURN OFF AFTER ALL THE TEXTS HAVE UPDATED

    // Update is called once per frame
    void Update()
    {
        
    }
}
