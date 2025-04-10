using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitWallAnimScript : MonoBehaviour
{
    static Animator ballAnim;
    // Start is called before the first frame update
    void Start()
    {
        ballAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void HitWallAnim(string triggerToCall)
    {
        ballAnim.SetTrigger(triggerToCall);
        CheckFailScript.UpdateStrikeCount();
    }
}
