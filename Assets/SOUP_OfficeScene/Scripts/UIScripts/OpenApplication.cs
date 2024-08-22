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
        FindApp();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FindApp()
    {
        appPlayerIsUsing = GameObject.FindGameObjectsWithTag(tagToFind);
        appPlayerIsUsing[0] = appPlayerIsUsing[0].transform.parent.gameObject.transform.parent.gameObject;
        appPlayerIsUsing[0].gameObject.SetActive(false);
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
            FindApp();
        }
        
    }
}
