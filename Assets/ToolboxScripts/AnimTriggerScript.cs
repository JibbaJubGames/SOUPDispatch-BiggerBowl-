using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimTriggerScript : MonoBehaviour
{
    [SerializeField]
    private Animator targetAnimator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void runTrigger(string targetTrigger)
    {
        targetAnimator.SetTrigger(targetTrigger);
    }
}
