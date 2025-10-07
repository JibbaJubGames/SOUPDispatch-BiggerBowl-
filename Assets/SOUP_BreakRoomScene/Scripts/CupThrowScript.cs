using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupThrowScript : MonoBehaviour
{
    [SerializeField] private Animator cupController;
    [SerializeField] private bool clickable;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cupController.GetCurrentAnimatorStateInfo(0).IsName("IDLE"))
        {
            clickable = true;
        }
    }

    public void ThrowCup()
    {
        if (clickable)
        {
            clickable = false;
            //change range max to 4 once other animations are completed
            int cupTossType = Random.Range(0, 2);
            if (cupTossType == 0) cupController.SetTrigger("One");
            else if (cupTossType == 1) cupController.SetTrigger("Two");
            else if (cupTossType == 2) cupController.SetTrigger("Three");
            else if (cupTossType == 3) cupController.SetTrigger("Four");
        }
    }
}
