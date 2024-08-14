using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DispatchNotificationScript : MonoBehaviour
{
    [Header("Dispatch Info")]
    public bool dispatchWaiting;
    public bool dispatchActive;

    [Header("Dispatch Countdown Info")]
    public bool dispatchWaitTimeSet;
    public int dispatchWaitTime;
    public int maxDispatchWaitTime;
    public float dispatchTimer = 0;

    [Header("Dispatch Image Holders")]
    public Image dispatchNotif;
    public Button endDispatch;

    [Header("Chat Clear Script")]
    public AutoscribeConvoScript clearChatScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!dispatchWaiting && !dispatchActive)
        {
            NewDispatch();
        }
    }

    public void NewDispatch()
    {
        if (!dispatchWaitTimeSet)
        {
            dispatchWaitTime = Random.Range(0, maxDispatchWaitTime);
            dispatchWaitTimeSet = true;

        }
        dispatchTimer += Time.deltaTime;
        Debug.Log($"Dispatch timer is currently at: {dispatchTimer}");
        if (dispatchTimer > dispatchWaitTime)
        {
            Debug.Log("Made it here");
            dispatchNotif.gameObject.SetActive(true);
            dispatchWaiting = true;
            dispatchWaitTimeSet = false;
            dispatchTimer = 0;
        }
    }

    public void AnsweredDispatch()
    {
        if (dispatchWaiting)
        {
            dispatchNotif.gameObject.SetActive(false);
            dispatchActive = true;
            dispatchWaiting = false;

            DispatchDetailGeneratorScript.GenerateDispatch();
            //To Do: Create function to generate new dispatch
        }
        else return;
    }

    public void EndedDispatch()
    {
        if (dispatchActive)
        {
            PlayerResponses.ResetCallerTypeSetters();
            dispatchActive = false;
            clearChatScript.ResetConvo();
        }
        else return;
    }

    public void CheckCloseButton()
    {
        if (dispatchActive)
        {
            endDispatch.gameObject.SetActive(true);
        }
        else return;
    }
}
