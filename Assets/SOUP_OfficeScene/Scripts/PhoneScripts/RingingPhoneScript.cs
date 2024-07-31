using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RingingPhoneScript : MonoBehaviour
{
    private Animator phoneAnimController;
    public Button answerButton;
    private bool phoneRinging = false;
    private float ringCountdown;
    private int newCallerTime;
    private bool onCall = false;

    public CallerStyleSelectionScript callerTypeChoice;

    // Start is called before the first frame update
    void Start()
    {
        phoneAnimController = GetComponent<Animator>();
        answerButton = GetComponentInChildren<Button>();
        answerButton.interactable = false;
        SetCallerWaitTime(10);
    }

    private void SetCallerWaitTime(int maxWait)
    {
        newCallerTime = Random.Range(2, maxWait);
        Debug.Log($"Calling at {newCallerTime} seconds");
    }

    // Update is called once per frame
    void Update()
    {
        if (!phoneRinging && !onCall)
        {
            WaitForCall();
        }
        if (ringCountdown >= newCallerTime && !phoneRinging && !onCall)
        {
            RingPhone();
        }
        if (phoneRinging && !onCall)
        {
            WaitToMissCall();
        }
    }

    private void WaitForCall()
    {
        answerButton.interactable = false;
        ringCountdown += Time.deltaTime;
    }

    private void RingPhone()
    {
        ringCountdown = 5;
        phoneRinging = true;
        phoneAnimController.SetTrigger("NewCaller");
        answerButton.interactable = true;
    }
    private void WaitToMissCall()
    {
        ringCountdown -= Time.deltaTime;
        if (phoneRinging && ringCountdown <= 0)
        {
            MissedCall();
        }
    }
    private void MissedCall()
    {
        SetCallerWaitTime(10);
        phoneAnimController.SetTrigger("MissedCall");
        ringCountdown = 0;
        phoneRinging = false;       
    }



    public void AnsweredPhone()
    {
        phoneAnimController.SetTrigger("AnsweredCall");
        onCall = true;
        CallerPopTrigger.CallPopSwap();
        callerTypeChoice.PickCallerType();
        ringCountdown = 0;
    }

    public void TestingPurposeEndCall() 
    {
        if (onCall)
        {
            SetCallerWaitTime(10);
            onCall = false;
            phoneAnimController.SetTrigger("CallOver");
            phoneRinging = false;
            answerButton.interactable = false;
            ringCountdown = 0;
            CallerPopTrigger.CallPopSwap();
        }
    }
}
