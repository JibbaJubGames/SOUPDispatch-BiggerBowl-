using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreenSwitch : MonoBehaviour
{
    public void FullscreenToggle (bool toggle)
    {
        Screen.fullScreen = toggle;
        Debug.Log($"Fullscreen is {toggle}");
    }
}
