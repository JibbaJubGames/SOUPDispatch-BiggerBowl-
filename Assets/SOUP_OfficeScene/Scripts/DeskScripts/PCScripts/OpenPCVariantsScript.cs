using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenPCVariantsScript : MonoBehaviour
{
    [SerializeField] public string unfocusedOpen;
    [SerializeField] public string focusedOpen;
    [SerializeField] public string focus;
    [SerializeField] public string unfocus;
    [SerializeField] public bool PCFocused;

    [SerializeField] public Animator compAnim;
    [SerializeField] public GameObject[] compObjects;
    // Start is called before the first frame update
    void Start()
    {
        compAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PCFocused && Input.GetButtonDown("SeeThroughMode"))
        {
            for (int i = 0; i < compObjects.Length; i++)
            {
                compObjects[i].transform.GetComponent<Image>().color = new Color (1f, 1f, 1f, 0.5f);
                compObjects[i].transform.GetComponent<Image>().raycastTarget = false;
            }
        }
        if (PCFocused && Input.GetButtonUp("SeeThroughMode"))
        {
            for (int i = 0; i < compObjects.Length; i++)
            {
                compObjects[i].transform.GetComponent<Image>().color = new Color (1f, 1f, 1f, 1f);
                compObjects[i].transform.GetComponent<Image>().raycastTarget = true;
            }
        }
        if (FocusHolders.focusSpaceOneFull && compAnim.GetCurrentAnimatorStateInfo(0).IsName("ComputerIn"))
        {
            compAnim.SetTrigger(unfocus);
        }
        else if (!FocusHolders.focusSpaceOneFull && compAnim.GetCurrentAnimatorStateInfo(0).IsName("ComputerHalfFocusIn"))
        {
            compAnim.SetTrigger(focus);
        }
    }

    public void OpenPC()
    {
        if (FocusHolders.focusSpaceOneFull)
        {
            compAnim.SetTrigger(unfocusedOpen);
        }
        else if (!FocusHolders.focusSpaceOneFull && !FocusHolders.focusSpaceTwoFull) 
        {
            compAnim.SetTrigger (focusedOpen);
        }
        PCFocused = true;
        FocusHolders.focusSpaceTwoFull = true;
    }

    public void ClosePC()
    {
        FocusHolders.focusSpaceTwoFull = false;
        PCFocused = false;
        compAnim.SetTrigger("ClosedPC");
    }
}
