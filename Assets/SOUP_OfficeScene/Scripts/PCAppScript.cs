using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCAppScript : MonoBehaviour
{
    [SerializeField] private bool appOpen;
    [SerializeField] private Animator appAnimController;
    public void OpenAppSwitch()
    {
        if (appAnimController.GetCurrentAnimatorStateInfo(0).IsName("IDLE"))
        {
            appOpen = true;
            appAnimController.SetTrigger("OpenApp");
        }
        else if (appAnimController.GetCurrentAnimatorStateInfo(0).IsName("PhoneOut"))
        {
            appOpen = false;
            appAnimController.SetTrigger("CloseApp");
        }
    }
}
