using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimTriggerScript : MonoBehaviour
{
    [SerializeField]
    private Animator targetAnimator;
    public string targetTrigger;

    public float waitTimer;
    public int waitLength;
    public bool triggerDelayed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (triggerDelayed)
        {
            waitTimer += Time.deltaTime;
        }
        if (waitTimer > waitLength)
        {
            targetAnimator.SetTrigger(targetTrigger);
            triggerDelayed = false;
            waitTimer = 0;
        }
    }

    public void runTrigger(string triggerToCall)
    {
        targetTrigger = triggerToCall;
        targetAnimator.SetTrigger(targetTrigger);
    }

    public void DelayTrigger(int secToWait)
    {
        waitLength = secToWait;
        triggerDelayed = true;
    }
}
