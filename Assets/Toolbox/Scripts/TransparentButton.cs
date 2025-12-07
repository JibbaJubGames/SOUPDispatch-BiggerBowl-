using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransparentButton : Button
{
    protected override void Awake()
    {
        base.Awake();
        // Set the alpha hit test threshold to make transparent areas non-clickable
        // Adjust the value (0.1f) based on how sensitive you want the detection
        GetComponent<Image>().alphaHitTestMinimumThreshold = 1f;
    }
}
