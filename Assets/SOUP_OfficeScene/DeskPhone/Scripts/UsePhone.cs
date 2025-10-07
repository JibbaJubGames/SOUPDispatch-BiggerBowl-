using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsePhone : MonoBehaviour
{
    public static bool onPhone;
    [SerializeField] private GameObject phoneMenu;
    [SerializeField] private PhoneLineOpenClose phoneSwitch;
    private Animator phoneAnim;
    public PhoneDialogueNoises operatorSpeech;
    // Start is called before the first frame update
    void Start()
    {
        operatorSpeech = GetComponentInChildren<PhoneDialogueNoises>();
        phoneAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickUpPhone()
    {
        if (!PhoneLineOpenClose.lineOpen && !onPhone)
        {
            phoneMenu.SetActive(true);
        }
        else if (!onPhone && PhoneLineOpenClose.lineOpen && ShiftTimerFill.clockedIn && !GenerateDispatchScript.dispatchActive)
        {
            this.gameObject.GetComponent<GenerateDispatchScript>().GenerateTier();
            this.gameObject.GetComponent<GenerateDispatchScript>().currentDispatch.GetComponent<DispatchOperatorDetails>().GenBadgeNumber();
            phoneSwitch.SwitchLine();
            onPhone = true;
            phoneAnim.SetTrigger("AnswerPhone");
            FocusHolders.focusSpaceOneFull = true;
        }
        else if (onPhone)
        {
            phoneAnim.SetTrigger("PhoneDown");
            onPhone = false;
            FocusHolders.focusSpaceOneFull = false;
        }
    }

    public void PlayOperatorWeh()
    {
        operatorSpeech.PlayWeh();
    }
}
