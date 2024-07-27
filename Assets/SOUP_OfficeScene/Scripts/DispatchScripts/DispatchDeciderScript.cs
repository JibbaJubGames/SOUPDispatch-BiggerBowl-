using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispatchDeciderScript : MonoBehaviour
{
    public static int dispatchDifficulty;
    public static int dispatchSuccessPoints;
    public static int dispatchFailurePoints;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    private void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void SetDifficulty()
    {
        Debug.Log("Difficulty level is " + dispatchDifficulty);
    }

    public static void PointCountUp()
    {
        dispatchSuccessPoints++;
    }

    public static void PointCountDown()
    {
        dispatchSuccessPoints--; dispatchFailurePoints++; Debug.Log("+1 fail point");
    }

    public static void CompareWinOrLoss()
    {
        Debug.Log("Got " + dispatchSuccessPoints);

        if (dispatchSuccessPoints >= dispatchDifficulty)
        {
            Debug.Log("Whooppeee the day is saved!");
            if (dispatchFailurePoints == 0)
            {
                DispatchManager.perfectDispatchCount++;
                Debug.Log("Should be perfect");
            }
            else if (dispatchSuccessPoints != 2 && dispatchSuccessPoints >= dispatchDifficulty) DispatchManager.goodDispatchCount++;
        }

        else if (dispatchSuccessPoints < dispatchDifficulty)
        {
            Debug.Log("Oh no... we lost");
            DispatchManager.badDispatchCount++;
        }
        dispatchSuccessPoints = 0;
        dispatchFailurePoints = 0;
        Debug.Log($"Current standings are {DispatchManager.perfectDispatchCount} dispatches done perfectly;" +
            $" {DispatchManager.goodDispatchCount} dispatches done successfully," +
            $" and {DispatchManager.badDispatchCount} dispatches done poorly");
    }
}
