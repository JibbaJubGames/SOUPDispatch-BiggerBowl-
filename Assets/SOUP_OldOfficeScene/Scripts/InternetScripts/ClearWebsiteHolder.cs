using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearWebsiteHolder : MonoBehaviour
{
    [SerializeField] private GameObject websiteHolder;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClearSiteHolder()
    {
        if (websiteHolder.transform.childCount > 0)
        {
            for (int i = 0; i < websiteHolder.transform.childCount; i++)
            {
                if (i == 0)
                {
                    websiteHolder.transform.GetChild(i).gameObject.SetActive(false);
                }
                else
                {
                    Destroy(websiteHolder.transform.GetChild(i).gameObject);
                }
            }
        }
    }
}
