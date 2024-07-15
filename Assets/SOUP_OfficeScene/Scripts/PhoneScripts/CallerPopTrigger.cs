using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallerPopTrigger : MonoBehaviour
{
    private static bool callPopped;
    public static Animator callPopController;

    private void Awake()
    {
        callPopController = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void CallPopSwap()
    {
        if (!callPopped)
        {
            callPopController.SetTrigger("AnsweredCall");
            callPopped = true;
        }
        else if (callPopped)
        {
            callPopController.SetTrigger("CallOver");
            callPopped = false;
        }

    }
}
