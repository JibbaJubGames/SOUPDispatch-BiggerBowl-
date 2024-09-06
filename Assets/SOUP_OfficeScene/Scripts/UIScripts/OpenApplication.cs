using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenApplication : MonoBehaviour
{
    public GameObject[] appPlayerIsUsing;
    public string tagToFind;
    // Start is called before the first frame update
    void Start()
    {
        InitialFindApp();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitialFindApp()
    {
        RuntimeFindApp();
        appPlayerIsUsing[0].gameObject.SetActive(false);
    }

    public void RuntimeFindApp()
    {
        appPlayerIsUsing = GameObject.FindGameObjectsWithTag(tagToFind);
        Debug.Log("The app attached to this button is" + appPlayerIsUsing[0].name);
        appPlayerIsUsing[0] = appPlayerIsUsing[0].transform.parent.gameObject.transform.parent.gameObject;
    }

    public void OpenApp()
    {
        if (appPlayerIsUsing[0] != null)
        {
            if (appPlayerIsUsing[0].gameObject.activeSelf)
            {
                return;
            }
            else
            {
                appPlayerIsUsing[0].gameObject.SetActive(true);
            }
        }
        else
        {
            Debug.Log("App became NULL");
            InitialFindApp();
        }
        
    }
}
