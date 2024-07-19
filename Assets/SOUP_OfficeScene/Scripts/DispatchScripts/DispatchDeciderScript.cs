using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispatchDeciderScript : MonoBehaviour
{
    public static int dispatchDifficulty;
    public static int dispatchSuccessPoints;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void SetDifficulty()
    {
        Debug.Log("Difficulty level is " + dispatchDifficulty);
        CompareWinOrLoss();
    }

    public static void PointCount(string WinOrLose)
    {
        if (WinOrLose == "Win") dispatchSuccessPoints++;

        else if (WinOrLose == "Lose") dispatchSuccessPoints--;
    }  

    public static void CompareWinOrLoss()
    {
        Debug.Log("Got " + dispatchSuccessPoints);

        if (dispatchSuccessPoints >= dispatchDifficulty) Debug.Log("Whooppeee the day is saved!");

        else if (dispatchSuccessPoints < dispatchDifficulty) Debug.Log("Oh no... we lost");
    }
}
