using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseWindowButton : MonoBehaviour
{

    public GameObject menuToClose;
    private GameObject[] appButton;
    public GameObject appType;
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
        appType = this.transform.parent.GetChild(this.transform.GetSiblingIndex() - 2).gameObject.transform.GetChild(0).gameObject;
        this.tag = appType.gameObject.tag;
        appButton = GameObject.FindGameObjectsWithTag(this.gameObject.tag +"Button");
        for (int i = 0; i < appButton.Length; i++)
        {
            if (appButton[i].GetComponent<OpenApplication>() != null)
            {
                appButton[i].GetComponent<OpenApplication>().RuntimeFindApp();
            }
            else appButton[i] = null;
        }
        menuToClose = this.transform.parent.gameObject;
        menuToClose.name = this.transform.name;
        menuToClose.SetActive(false);
    }
}
