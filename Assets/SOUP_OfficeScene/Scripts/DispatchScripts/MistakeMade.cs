using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MistakeMade : MonoBehaviour
{
    static Animator animator;
    static TMP_Text mistakeTextHolder;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        mistakeTextHolder = GetComponentInChildren<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void MistakeBannerShow(string mistakeText)
    {
        mistakeTextHolder.text = mistakeText;
        animator.SetTrigger("MistakeMade");
        DispatchWinVsLoss.dispatchesLost++;
        Debug.Log($"We failed {DispatchWinVsLoss.dispatchesLost} today.");
    }
}
