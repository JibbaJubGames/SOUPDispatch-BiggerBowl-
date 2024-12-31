using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebsiteSelection : MonoBehaviour
{
    [SerializeField] private GameObject resultsPage;
    [SerializeField] private GameObject websiteHolder;
    [SerializeField] private GameObject websiteDestination;

    [Header("Homepage No Results Only")]
    [SerializeField] private GameObject homePage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToWebsite()
    {
        websiteHolder = GameObject.FindGameObjectWithTag("WebsiteHolder");
        resultsPage = GameObject.FindGameObjectWithTag("ResultsPage");
   
        if (websiteHolder.transform.childCount > 0) 
        {
        for (int i = 0; i < websiteHolder.transform.childCount; i++)
            {
                if (i == 0)
                {
                websiteHolder.transform.GetChild(i).gameObject.SetActive(true);
                }
                else
                {
                Destroy (websiteHolder.transform.GetChild(i).gameObject);
                }
            }
        }
        Instantiate(websiteDestination, websiteHolder.transform);
        resultsPage.SetActive (false);
    }

    public void GoToNoResultsWebsite()
    {
        websiteHolder = GameObject.FindGameObjectWithTag("WebsiteHolder");
        resultsPage = GameObject.FindGameObjectWithTag("ResultsPage");
   
        if (websiteHolder.transform.childCount > 0) 
        {
        for (int i = 0; i < websiteHolder.transform.childCount; i++)
            {
                if (i == 0)
                {
                websiteHolder.transform.GetChild(i).gameObject.SetActive(true);
                }
                else
                {
                Destroy (websiteHolder.transform.GetChild(i).gameObject);
                }
            }
        }
        Instantiate(websiteDestination, websiteHolder.transform);
        homePage.SetActive (false);
        resultsPage.SetActive (false);
    }
}
