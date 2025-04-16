using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCAppScript : MonoBehaviour
{
    [SerializeField] private bool hoveringApp;
    [SerializeField] private bool appOpen;
    [SerializeField] private Animator appAnimController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HoverAppOn()
    {
        if (appAnimController.GetCurrentAnimatorStateInfo(0).IsName("IDLE"))
        {
            appAnimController.SetTrigger("Hovering");
        }
    }

    public void HoverAppOff()
    {
        if (appAnimController.GetCurrentAnimatorStateInfo(0).IsName("Hovering"))
        {
            appAnimController.SetTrigger("HoveringStop");
        }
    }

    public void OpenAppSwitch()
    {
        if (!appOpen)
        {
            appOpen = true;
            appAnimController.SetTrigger("OpenApp");
        }
        else if (appOpen)
        {
            appOpen = false;
            appAnimController.SetTrigger("CloseApp");
        }
    }
}
