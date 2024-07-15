using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionRandomizerScript : MonoBehaviour
{

    [SerializeField] private Animator transitionHolder;

    // Start is called before the first frame update
    void Start()
    {
        TransitionChoice();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void TransitionChoice()
    {
        int choice = Random.Range(1, 3);
        if (choice == 1)
        {
            transitionHolder.SetTrigger("TransitionOne");
        }
        else if (choice == 2) 
        {
            transitionHolder.SetTrigger("TransitionTwo");
        }
    }
}
