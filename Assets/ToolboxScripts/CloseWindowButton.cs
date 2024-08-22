using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseWindowButton : MonoBehaviour
{

    private GameObject menuToClose;
    // Start is called before the first frame update
    void Start()
    {
        menuToClose = this.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseMenu()
    {
        menuToClose.SetActive(false);
    }
}
