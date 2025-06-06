using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DispatchNotificationScript : MonoBehaviour
{
    [Header("Dispatch Info")]
    public bool dispatchWaiting;
    public bool dispatchActive;
    public Animator autoScribeAnim;
    public RandomLocationScript dispatchSpawn;

    [Header("Dispatch Countdown Info")]
    public bool dispatchWaitTimeSet;
    public int dispatchWaitTime;
    public int maxDispatchWaitTime;
    public float dispatchTimer = 0;
    public DispatchTimerBar timeLimit;
    public Button endChatButton;

    [Header("Dispatch Image Holders")]
    public Image dispatchNotif;
    public Button endDispatch;

    [Header("Chat Setup Scripts")]
    public AutoscribeConvoScript clearChatScript;
    public PlayerResponses chatSetupScript;
    public Animator addressTrackerAnim;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Add this after !dispatchActive once the email dispatches are working;  && GameManager.DayCounter >= 4
        if (!dispatchWaiting && !dispatchActive)
        {
            NewDispatch();
        }
    }

    public void NewDispatch()
    {
        if (DailyClockScript.clockedIn)
        {
            if (!dispatchWaitTimeSet)
            {
                dispatchWaitTime = Random.Range(0, maxDispatchWaitTime);
                dispatchWaitTimeSet = true;

            }
            dispatchTimer += Time.deltaTime;
            if (dispatchTimer > dispatchWaitTime)
            {
                dispatchNotif.gameObject.SetActive(true);
                dispatchWaiting = true;
                dispatchWaitTimeSet = false;
                dispatchTimer = 0;
                dispatchSpawn.RandomDispatchChoice();
            }
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
            autoScribeAnim.SetTrigger("OpenedAutoScribe");
            timeLimit.ResetDispatchTimer();
            chatSetupScript.PlayerGreeting();
        }
        else return;
    }

    public void EndedDispatch()
    {
        if (dispatchActive)
        {
            PlayerResponses.ResetCallerTypeSetters();
            dispatchActive = false;
            endDispatch.gameObject.SetActive(false);
            clearChatScript.ResetConvo();
            if (addressTrackerAnim.GetCurrentAnimatorStateInfo(0).IsName("NeedAddressTracker"))
            {
                addressTrackerAnim.SetTrigger("TrackerUnused");
            }
            if (autoScribeAnim.GetCurrentAnimatorStateInfo(0).IsName("AutoscribePopIn"))
            {
                autoScribeAnim.SetTrigger("ClosedAutoScribe");
            }
            dispatchSpawn.DispatchOver();
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
