using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispatchHoverScript : MonoBehaviour
{
    [SerializeField] public Animator dispatchGrowth;
    [SerializeField] private bool dispatchLocked;

    [SerializeField] private GameObject whoScribbles;
    [SerializeField] private GameObject whatScribbles;
    [SerializeField] private GameObject whereScribbles;

    [SerializeField] private bool topDispatch;
    [SerializeField] private bool bottomDispatch;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        if (topDispatch)
        {
            HoveringThisLocation();
            LockedDispatch();
        }
        else if (bottomDispatch)
        {
            HoveringThisLocationBottom();
            LockedDispatch();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HoveringThisLocation()
    {
        if (!dispatchLocked)
        {
            dispatchGrowth.ResetTrigger("Deactivated");
            dispatchGrowth.SetTrigger("Viewing");
        }
    }
    public void HoveringThisLocationBottom()
    {
        if (!dispatchLocked)
        {
            dispatchGrowth.ResetTrigger("Deactivated");
            dispatchGrowth.SetTrigger("ViewingBottom");
        }
    }

    public void LockedDispatch()
    {
        if (!dispatchLocked) 
        {
            if (SelectedDispatchDetails.hoveringChosenDispatch != this.gameObject && SelectedDispatchDetails.hoveringChosenDispatch != null)
            {
                SelectedDispatchDetails.hoveringChosenDispatch.GetComponent<DispatchHoverScript>().dispatchLocked = false;
                SelectedDispatchDetails.hoveringChosenDispatch.GetComponent<Animator>().SetTrigger("Deactivated");
                Debug.Log("Deactivated selected dispatch");
            }
        SelectedDispatchDetails.hoveringChosenDispatch = this.gameObject;
        dispatchLocked = true;
        dispatchGrowth.SetTrigger("LockedView");
        SetScribbles();
        }
        else if (dispatchLocked)
        {
            dispatchLocked = false;
        }
        
    }

    public void StoppedHoveringLocation()
    {
        if (dispatchLocked)
        {
            return;
        }
        else
        {
            dispatchGrowth.SetTrigger("Deactivated");
            Debug.Log("Stopped Hovering this dispatch");
        }
    }

    public void SetScribbles()
    {
        Debug.Log("Scribbles set");
        SelectedDispatchDetails.whoScribbles = whoScribbles;
        SelectedDispatchDetails.whatScribbles = whatScribbles;
        SelectedDispatchDetails.whereScribbles = whereScribbles;
    }
}
