using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FocusSpaceBlockingScript : MonoBehaviour
{
    public Image raycastBlocker;

    // Start is called before the first frame update
    void Start()
    {
        raycastBlocker = this.GetComponent<Image>();
        raycastBlocker.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.childCount != 0)
        {
            raycastBlocker.enabled = true;
        }    
        else raycastBlocker.enabled = false;
    }
}
