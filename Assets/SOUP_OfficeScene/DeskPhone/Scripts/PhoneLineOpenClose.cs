using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneLineOpenClose : MonoBehaviour
{
    public static bool lineOpen = false;
    [SerializeField] private Sprite onSwitchImage;
    [SerializeField] private Sprite offSwitchImage;
    [SerializeField] private Image phoneSwitch;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchLine()
    {
        if (!lineOpen)
        {
            lineOpen = true;
            phoneSwitch.sprite = onSwitchImage;
        }
        else if (lineOpen)
        {
            lineOpen = false;
            phoneSwitch.sprite = offSwitchImage;
        }
    }
}
