using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TierComparison : MonoBehaviour
{
    public static bool playerChoseOne;
    public static bool playerChoseTwo;
    public static bool playerChoseThree;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerChoseTierOne()
    {
        Debug.Log("Player selected this as a tier one emergency");
            playerChoseOne = true;
            playerChoseTwo = false;
            playerChoseThree = false;
    }

    public void PlayerChoseTierTwo()
    {
        Debug.Log("Player selected this as a tier two emergency");
        playerChoseOne = false;
            playerChoseTwo = true;
            playerChoseThree = false;
    }

    public void PlayerChoseTierThree()
    {
        Debug.Log("Player selected this as a tier three emergency");
        playerChoseOne = false;
            playerChoseTwo = false;
            playerChoseThree = true;
    }
}
