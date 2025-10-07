using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PreAlphaOnly_TurnOnPlaytestSheets : MonoBehaviour
{
    public GameObject tempTut;
    public static GameObject tempDisc;
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.isAlpha)
        {
            GameManager.DayCounter = 16;
            Debug.Log ("Game manager says we're on the " + GameManager.DayCounter + " day");
        }
        tempDisc = this.gameObject;
        tempDisc.SetActive(false);
        TurnOnTut();
    }

    private void TurnOnTut()
    {
        if (GameManager.isAlpha)
        {
            tempTut.SetActive(true);
        }
    }

    public static void TurnOnDisc()
    {
        if (GameManager.isAlpha)
        {
            tempDisc.SetActive(true);
        }
    } 

    // Update is called once per frame
    void Update()
    {
        
    }
}
