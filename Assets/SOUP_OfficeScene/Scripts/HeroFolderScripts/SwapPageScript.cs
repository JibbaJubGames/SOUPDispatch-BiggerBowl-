using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapPageScript : MonoBehaviour
{
    private TransparentButton selectablePage;
    // Start is called before the first frame update
    void Start()
    {
        selectablePage = GetComponent<TransparentButton>();
    }

    public void SwapPageToFront()
    {
        this.gameObject.transform.SetSiblingIndex(1);
        selectablePage.enabled = false;
    }

    public void SwapPageToBack()
    {
        this.gameObject.transform.SetSiblingIndex(0);
        selectablePage.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
