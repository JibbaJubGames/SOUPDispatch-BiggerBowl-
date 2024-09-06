using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPenalty : MonoBehaviour
{
    public Animator NightTimerAnim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void LowerEnergy()
    {
        GameManager.playerEnergy--;
        NightTimerAnim.SetTrigger(GameManager.playerEnergy.ToString());
    }
}
