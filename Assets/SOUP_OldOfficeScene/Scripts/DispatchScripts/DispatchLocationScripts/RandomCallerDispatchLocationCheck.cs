using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCallerDispatchLocationCheck : MonoBehaviour
{

    public bool dispatchCallerHere;
    [SerializeField] public DispatchNotificationScript autoscribe;
    [SerializeField] public RandomLocationScript dispatchAddress;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckAndAnswer()
    {
        if (dispatchCallerHere)
        {
            Debug.Log("Answered call");
            autoscribe.AnsweredDispatch();
            dispatchAddress.AnsweredCall();
        }
    }
}
