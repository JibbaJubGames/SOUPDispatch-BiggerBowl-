using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixTheStupidTransitionThingScript : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NextTransitionByForce()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.9)
        {
            anim.SetTrigger("Next");
        }
    }
}
